package eatlab.dms.worker;

import com.fasterxml.jackson.databind.ObjectMapper;
import eatlab.dms.api.service.SyncService;
import eatlab.dms.common.domain.FileData;
import eatlab.dms.common.domain.SessionData;
import eatlab.dms.common.domain.helper.ResultException;
import org.apache.commons.io.FileUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.stereotype.Component;

import javax.swing.*;
import java.io.File;
import java.io.IOException;
import java.nio.file.Paths;
import java.text.SimpleDateFormat;
import java.util.Arrays;
import java.util.Date;
import java.util.List;
import java.util.concurrent.locks.ReentrantLock;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Collectors;

@Component
public class SyncWorker {

    Logger log = LoggerFactory.getLogger(this.getClass());

    @Autowired
    WorkerProperties _workerProperties;

    @Autowired
    SyncService syncService;

    private static final SimpleDateFormat dateFormat = new SimpleDateFormat("HH:mm:ss");

    ReentrantLock lock = new ReentrantLock();

    @Scheduled(fixedDelayString = "${eatlab.dms.worker.scan.interval}")
    public void scanDirectories() {
        log.info("Starting scan of '" + _workerProperties.scan.directory + "' on Node '" + _workerProperties.getId() + "'");
        File scanDirectory = new File(_workerProperties.scan.directory);
        if (!scanDirectory.exists()) {
            log.error("The scan-directory: '" + _workerProperties.scan.directory + "' existiert nicht.");
            return;
        }
        if (!scanDirectory.isDirectory()) {
            log.error("The scan-directory: '" + _workerProperties.scan.directory + "' is not a directory.");
            return;
        }


        for (File directory : scanDirectory.listFiles()) {
            if (!directory.isDirectory()) {
                log.debug("Ignoring file: " + directory);
                continue;
            }

            if (!directory.getName().matches(_workerProperties.scan.matcher)) {
                log.debug("Ignoring directory: " + directory + "because it not matches: " + _workerProperties.scan.matcher);
                continue;
            }

            try {
                SessionData sessionData= syncService.ProcessDirectory(_workerProperties.id,directory);
                String finishMessage=syncService.FinishSession(sessionData.getId());

                log.info("Finished Processing directory '"+ directory+"': " +finishMessage);

                if (_workerProperties.rename) {
                    if (_workerProperties.renameOpt!=null && _workerProperties.renameOpt.replace!=null && _workerProperties.renameOpt.search!=null) {
                        String oldName=directory.getName();
                        String name = directory.getName().replaceAll(_workerProperties.renameOpt.search, _workerProperties.renameOpt.replace);
                        if(directory.renameTo(Paths.get(directory.getParent(), name).toFile()))
                            log.info("Renamed '"+ oldName+"' to " + name);
                        else
                            log.error("Could not reaname " + oldName+ " to "+name+". Maybe the file is still open?");
                    } else {
                        log.warn("Could not reaname because renameOpt not set!");
                    }
                } else {
                    deleteFolder(directory);
                    log.info("Deleted '"+directory+"'");
                }

            } catch (Exception ex) {
                log.error("Error processing directory '" + directory+"'",ex);
            }
        }
    }

    public static void deleteFolder(File folder) {
        File[] files = folder.listFiles();
        if(files!=null) { //some JVMs return null for empty dirs
            for(File f: files) {
                if(f.isDirectory()) {
                    deleteFolder(f);
                } else {
                    f.delete();
                }
            }
        }
        folder.delete();
    }


}
