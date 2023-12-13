package eatlab.dms.server.rest;

import com.fasterxml.jackson.databind.ObjectMapper;
import eatlab.dms.common.domain.FileData;
import eatlab.dms.common.domain.LogEntry;
import eatlab.dms.common.domain.SessionData;
import eatlab.dms.common.domain.UserData;
import eatlab.dms.common.domain.custom.ItemOrderData;
import eatlab.dms.common.domain.custom.SessionWorkloadData;
import eatlab.dms.common.domain.helper.ResultException;
import eatlab.dms.common.domain.helper.ResultWithInfo;
import eatlab.dms.common.domain.helper.ResultWithInfoBase;
import eatlab.dms.server.ServerProperties;
import eatlab.dms.server.mongo.SessionDataRepository;
import org.apache.commons.io.Charsets;
import org.apache.commons.io.FileUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.annotation.Secured;
import org.springframework.security.core.annotation.AuthenticationPrincipal;
import org.springframework.util.DigestUtils;
import org.springframework.web.bind.annotation.*;
import springfox.documentation.annotations.ApiIgnore;

import javax.servlet.http.HttpServletRequest;
import java.io.*;
import java.nio.file.Paths;
import java.security.NoSuchAlgorithmException;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.UUID;

@RestController
@RequestMapping("/api/sync")
@Secured("ROLE_NODE")
public class SyncController {
    private final Logger logger = LoggerFactory.getLogger(this.getClass());

    @Autowired
    SessionDataRepository sessionDataRepository;

    @Autowired
    ServerProperties serverProperties;

    @GetMapping("/requestNewSessionDataId/{nodeId}")
    ResponseEntity<ResultWithInfo<SessionData>> requestNewSessionDataId(@PathVariable("nodeId") String nodeId) {
        SessionData sessionData = SessionData.builder().nodeId(nodeId).build();
        sessionData.setCreateDate(System.currentTimeMillis());
        sessionData = sessionDataRepository.save(sessionData);
        return ResultWithInfo.Create(sessionData);
    }

    @GetMapping("/getSessionData/{sessionDataId}")
    ResponseEntity<ResultWithInfo<SessionData>> getSessionData(@PathVariable("sessionDataId") String sessionDataId) {
        ResponseEntity<ResultWithInfo<SessionData>> e = ResultWithInfo.Create(null);
        e.getBody().setData(sessionDataRepository.findById(sessionDataId).orElse(null));
        if (e.getBody().getData() == null) AddErrorNoSessionFound(sessionDataId, e.getBody());
        return e;
    }

    private void AddErrorNoSessionFound(String sessionDataId, ResultWithInfoBase e) {
        AddError(e, "No SessionData found for '" + sessionDataId + "'");
    }

    private void AddError(ResultWithInfoBase e, String errorMsg) {
        e.AddError(errorMsg);
        logger.warn("Call with error: " + errorMsg);
    }

    @PostMapping("/createFileForSession/{sessionDataId}")
    ResponseEntity<ResultWithInfo<FileData>> createFileForSession(@PathVariable("sessionDataId") String sessionDataId, @RequestBody FileData fileData, @ApiIgnore @AuthenticationPrincipal UserData user) {
        fileData.setFileState(FileData.FileDataState.NEW);
        fileData.setTransferred(0);
        fileData.setId(UUID.randomUUID().toString());


        SessionData sessionData = sessionDataRepository.findById(sessionDataId).orElse(null);
        ResponseEntity<ResultWithInfo<FileData>> e = ResultWithInfo.Create(null);
        if (sessionData == null) {
            AddErrorNoSessionFound(sessionDataId, e.getBody());
            return e;
        }

        if (sessionData.getFileDatas().stream().anyMatch(x -> x.getName().equalsIgnoreCase(fileData.getName()))) {
            AddError(e.getBody(), "File '" + fileData.getName() + "' exists already");
            return e;
        }

        sessionData.getFileDatas().add(fileData);
        sessionData.setState(SessionData.SessionDataState.INCOMPLETE);
        sessionDataRepository.save(sessionData);

        e.getBody().setData(fileData);

        logger.info("Created Session " + sessionDataId + " NodeId:" +sessionData.getNodeId() +" User:" + user.getId());
        return e;
    }

    @GetMapping("/finishSession/{sessionDataId}")
    ResponseEntity<ResultWithInfoBase> finishSession(@PathVariable("sessionDataId") String sessionDataId, @ApiIgnore @AuthenticationPrincipal UserData user) {
        SessionData sessionData = sessionDataRepository.findById(sessionDataId).orElse(null);
        ResponseEntity<ResultWithInfoBase> e= new ResponseEntity<>(new ResultWithInfoBase(),HttpStatus.OK);
        if (sessionData == null) {
            AddErrorNoSessionFound(sessionDataId, e.getBody());
            return e;
        }

        if (sessionData.getFileDatas().stream().anyMatch(x->x.getFileState()!= FileData.FileDataState.COMPLETE)) {
            AddError(e.getBody(),"Not all files Uploaded!");
            return e;
        }

        sessionData.setState(SessionData.SessionDataState.COMPLETE);
        sessionDataRepository.save(sessionData);
        e.getBody().AddInfo("Session completed");
        logger.info("Finished Session " + sessionDataId + " NodeId:" +sessionData.getNodeId() +" User:" + user.getId());
        return e;
    }

    @PutMapping("/uploadFile/{sessionDataId}/{fileDataId}/{offset}")
    ResponseEntity uploadFile(@PathVariable("sessionDataId") String sessionDataId, @PathVariable("fileDataId") String fileDataId, @PathVariable("offset") long offset, HttpServletRequest request, @ApiIgnore @AuthenticationPrincipal UserData user) throws NoSuchAlgorithmException, IOException, ResultException {

        FileData fileData = null;
        SessionData sessionData = null;
        try {
            logger.info("Recieving File from user: "+ user.getId() +" for sessionDataId: " + sessionDataId + " fileDataId: " + fileDataId + " offset(resume): " + offset);
            sessionData = sessionDataRepository.findById(sessionDataId).orElse(null);
            if (sessionData == null) {
                throw new ResultException(new ResultWithInfoBase().AddError("no SessionData found"));
            }

            fileData = sessionData.getFileDatas().stream().filter(x -> x.getId().equals(fileDataId)).findFirst().orElse(null);
            if (fileData == null) {
                throw new ResultException(new ResultWithInfoBase().AddError("no FileData found"));
            }

            if (fileData.getTransferred() < offset) {
                throw new ResultException(new ResultWithInfoBase().AddError("UploadFile: less data than Worker want to start with..."));
            }

            logger.info("Starting transfer for sessionDataId: " +sessionDataId + " nodeId:"+sessionData.getNodeId()+" fileDataId: " + fileDataId + " fileName: " + fileData.getName() + " offset:" + offset);

            File file = Paths.get(serverProperties.getDirectory(), sessionDataId, fileData.getName()).toFile();
            file.getParentFile().mkdirs();
            if (!file.exists()) file.createNewFile();

            if (file.length() < offset) throw new ResultException(new ResultWithInfoBase().AddError("UploadFile: less data than Worker want to start with..."));

            RandomAccessFile r = new RandomAccessFile(file, "rw");

            r.seek(offset);

            InputStream in = request.getInputStream();

            byte[] buffer = new byte[1024 * 10];
            int readBytes = 0;
            long writeOffset = offset;
            try {
                while (-1 != (readBytes = in.read(buffer, 0, buffer.length))) {
                    r.write(buffer, 0, readBytes);
                    writeOffset += readBytes;
                }
            } catch (Exception ex) {
                r.close();
                fileData.setTransferred(writeOffset);
                fileData.setFileState(FileData.FileDataState.INCOMPLETE);
                sessionDataRepository.save(sessionData);
                throw ex;
            }

            r.close();

            FileInputStream fis = new FileInputStream(file);

            String md5 = DigestUtils.md5DigestAsHex(fis);

            if (md5.equals(fileData.getMd5())) {
                fileData.setTransferred(fileData.getSize());
                fileData.setFileState(FileData.FileDataState.COMPLETE);
                fileData.setUploadFinished(new Date().getTime());
            } else {
                fileData.setFileState(FileData.FileDataState.CURRUPTED);
                fileData.setTransferred(0);
                throw new ResultException(new ResultWithInfoBase().AddError("UploadFile: MD5 Hash not matching Reset-Transfer..."));
            }

            if (fileData.getName().equalsIgnoreCase(serverProperties.getJsonDataFileName())) {
                ObjectMapper om = new ObjectMapper();
                String content=FileUtils.readFileToString(file, Charsets.UTF_8);

                if (serverProperties.isFixBrokenJson()) {                //Fix bad JSON-Format
                    if (content.startsWith("{")) content = "[" + content;
                    if (content.trim().endsWith(",")) content = content.substring(0, content.lastIndexOf(",")) + "]";
                }

                List<ItemOrderData> itemOrderDataList = om.readValue(content, new ArrayList<ItemOrderData>().getClass());
                SessionWorkloadData sessionWorkloadData = new SessionWorkloadData();
                sessionWorkloadData.setItemOrderList(itemOrderDataList);
                sessionData.setSessionWorkloadData(sessionWorkloadData);
            }

            sessionDataRepository.save(sessionData);
            logger.info("Finished transfer for  fileDataId: " + fileDataId + " fileName: " + fileData.getName());
            return new ResponseEntity(HttpStatus.OK);
        } catch (Exception ex) {
            String msg="FileUpload SessionDataId: " +sessionDataId + " FileDataId: " +fileDataId;
            if (sessionData!=null) msg+=" NodeId:" + sessionData.getNodeId();
            if (fileData!=null) msg+=" FileName:" + fileData.getName();
            msg+=" Error: " + ex.getMessage();
            logger.error(msg,ex);
            if (fileData!=null) fileData.getLog().add(new LogEntry(LogEntry.LogEntryStatus.ERROR, msg));
            if (sessionData!=null) sessionDataRepository.save(sessionData);
            throw ex;
        }
    }
}
