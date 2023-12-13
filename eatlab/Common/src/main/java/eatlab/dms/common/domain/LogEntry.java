package eatlab.dms.common.domain;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.Date;

@Data
@JsonIgnoreProperties(ignoreUnknown = true)
@NoArgsConstructor
public class LogEntry {

    public LogEntry(LogEntryStatus status, String message) {
        this.time=new Date().getTime();
        this.status = status;
        this.message = message;
    }

    long time;
    LogEntryStatus status =LogEntryStatus.INFO;
    String message;

    public enum LogEntryStatus{
        INFO,ERROR
    }
}
