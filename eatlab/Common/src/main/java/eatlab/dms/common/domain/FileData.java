package eatlab.dms.common.domain;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.annotation.Id;
import org.springframework.util.DigestUtils;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

@Data
@NoArgsConstructor
@JsonIgnoreProperties(ignoreUnknown = true)
public class FileData {

    @Id
    String id;
    String name;
    long size;
    long transferred;
    long lastModified;
    long uploadFinished;
    String md5;

    List<LogEntry> log=new ArrayList<LogEntry>();

    FileDataState fileState;

    public FileData(File file) throws IOException {
        name=file.getName();
        size=file.length();
        lastModified=file.lastModified();
        String md5= DigestUtils.md5DigestAsHex(new FileInputStream(file));
        setMd5(md5);
    }

    public enum FileDataState {
        NEW, INCOMPLETE, COMPLETE, CURRUPTED
    }
}
