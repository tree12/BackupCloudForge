package eatlab.dms.api.service;

import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import eatlab.dms.api.ApiProperties;
import eatlab.dms.common.domain.FileData;
import eatlab.dms.common.domain.SessionData;
import eatlab.dms.common.domain.helper.ResultException;
import eatlab.dms.common.domain.helper.ResultWithInfo;
import eatlab.dms.common.domain.helper.ResultWithInfoBase;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.core.ParameterizedTypeReference;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.client.RestTemplate;

import java.io.*;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.nio.file.Paths;
import java.security.NoSuchAlgorithmException;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

import static eatlab.dms.api.ApiConfiguration.HEADER_STRING;
import static eatlab.dms.api.ApiConfiguration.TOKEN_PREFIX;
import static eatlab.dms.api.ApiConfiguration.X_AUTH_TOKEN;

@Service
public class SyncService {

    Logger log = LoggerFactory.getLogger(this.getClass());

    public static final String FILE_SESSION_DATA_JSON = "sessionData.json";

    @Autowired
    ApiProperties _apiProperties;

    @Autowired()
    @Qualifier("ApiRestTemplate")
    RestTemplate _restTemplate;

    public SessionData RequestNewSessionDataId(String nodeId) throws ResultException {
        ResponseEntity e =_restTemplate.getForEntity(_apiProperties.getUrl()+"/eatlab-dms/api/sync/requestNewSessionDataId/"+nodeId, new ResultWithInfo<SessionData>().getClass());
        ObjectMapper mapper = new ObjectMapper();
        ResultWithInfo<SessionData> r = mapper.convertValue(e.getBody(), new TypeReference<ResultWithInfo<SessionData>>(){} );
        if (r.isError()) throw new ResultException(r);
        return r.getData();
    }

    public SessionData GetSessionData(String sessionDataId) throws ResultException {
        ResponseEntity e = _restTemplate.getForEntity(_apiProperties.getUrl()+"/eatlab-dms/api/sync/getSessionData/"+sessionDataId,new ResultWithInfo<SessionData>().getClass());
        ObjectMapper mapper = new ObjectMapper();
        ResultWithInfo<SessionData> r = mapper.convertValue(e.getBody(), new TypeReference<ResultWithInfo<SessionData>>(){} );
        if (r.isError()) throw new ResultException(r);
        return r.getData();
    }

    public FileData CreateFileForSession(String sessionDataId,FileData fileData) throws ResultException {
        ResponseEntity e =_restTemplate.postForEntity(_apiProperties.getUrl()+"/eatlab-dms/api/sync/createFileForSession/"+sessionDataId, fileData,new ResultWithInfo<FileData>().getClass());
        ObjectMapper mapper = new ObjectMapper();
        ResultWithInfo<FileData> r = mapper.convertValue(e.getBody(), new TypeReference<ResultWithInfo<FileData>>(){} );
        if (r.isError()) throw new ResultException(r);
        return r.getData();
    }

    public void UploadFile(String sessionDataId, String fileDataId, File file, long offset) throws IOException {
        log.info("Uploading File: "+file.getAbsolutePath() + " size: "+file.length() + " starting at offset: " +offset);
        FileInputStream fis = new FileInputStream(file);
        fis.skip(offset);

        URL url = new URL(_apiProperties.getUrl()+"/eatlab-dms/api/sync/uploadFile/"+sessionDataId+"/"+fileDataId+"/"+offset);
        HttpURLConnection con = (HttpURLConnection) url.openConnection();
        con.setFixedLengthStreamingMode(file.length()-offset);
        con.setReadTimeout(5*60*1000);
        con.setRequestMethod("PUT");
        con.setDoOutput(true);
        con.setRequestProperty("Content-Type", "application/octet");
        con.setRequestProperty("Accept", "application/octet");

        if (ApiProperties.jwtToken==null) {
            con.setRequestProperty(X_AUTH_TOKEN, _apiProperties.getToken());
            con.setRequestProperty("X-Auth-ClientId", ""+ApiProperties.nodeId);
        }
        else
            con.setRequestProperty(HEADER_STRING,TOKEN_PREFIX+ApiProperties.jwtToken);



        OutputStream out = con.getOutputStream();

        byte[] buffer = new byte[1024*10];
        int bytesRead=0;
        while (-1!=(bytesRead=fis.read(buffer))) {
            out.write(buffer,0,bytesRead);
        }
        fis.close();

        int resultCode=con.getResponseCode();
        log.info("Result from PUT:" + resultCode );
    }

    public String FinishSession(String sessionDataId) throws ResultException {
        ResponseEntity<ResultWithInfoBase> e =_restTemplate.getForEntity(_apiProperties.getUrl()+"/eatlab-dms/api/sync/finishSession/"+sessionDataId,ResultWithInfoBase.class);

        if (e.getBody().isError()) throw new ResultException(e.getBody());
        return e.getBody().getInfos().stream().findFirst().orElse("No Message");
    }

    public SessionData ProcessDirectory(String nodeId, File directory) throws IOException, ResultException {
        log.info("processing directory: '" + directory.getName() + "'");

        File jsonFile = Paths.get(directory.getAbsolutePath(), FILE_SESSION_DATA_JSON).toFile();

        SessionData sessionData = null;

        if (jsonFile.exists()) {

            ObjectMapper mapper = new ObjectMapper();
            sessionData = mapper.readValue(jsonFile, SessionData.class);
            //Load from Server
            sessionData = this.GetSessionData(sessionData.getId());
        }

        if (sessionData == null) {
            sessionData = this.RequestNewSessionDataId(nodeId);
            ObjectMapper mapper = new ObjectMapper();
            mapper.writeValue(jsonFile, sessionData);
        }

        if (sessionData.getState()== SessionData.SessionDataState.COMPLETE) {
            log.info("Skiping completed directory: " + directory.getAbsolutePath());
            return sessionData;
        }

        List<FileData> notFinishedFiles = sessionData.getFileDatas().stream().filter(x -> !x.getFileState().equals(FileData.FileDataState.COMPLETE)).collect(Collectors.toList());

        for (FileData fileData : notFinishedFiles) {
            File uploadFile = Paths.get(directory.getAbsolutePath(), fileData.getName()).toFile();
            if (!uploadFile.exists()) {
                log.warn(uploadFile + " not exists any more!");
                continue;
            }
            this.UploadFile(sessionData.getId(), fileData.getId(), uploadFile, fileData.getTransferred());
        }

        SessionData finalSessionData = sessionData;
        List<File> files= Arrays.stream(directory.listFiles()).filter(x->x.isFile() && !x.getName().equalsIgnoreCase(FILE_SESSION_DATA_JSON)&& !finalSessionData.getFileDatas().stream().anyMatch(y->y.getName().equalsIgnoreCase(x.getName()))).collect(Collectors.toList());

        for(File file:files) {
            FileData fileData=new FileData(file);
            fileData=this.CreateFileForSession(sessionData.getId(),fileData);
            this.UploadFile(sessionData.getId(), fileData.getId(), file, fileData.getTransferred());
        }
        return sessionData;
    }
}
