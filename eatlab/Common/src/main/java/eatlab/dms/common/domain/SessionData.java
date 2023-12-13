package eatlab.dms.common.domain;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import eatlab.dms.common.domain.custom.SessionWorkloadData;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

import java.util.ArrayList;
import java.util.List;

@Data
@Document
@JsonIgnoreProperties(ignoreUnknown = true)
@NoArgsConstructor
public class SessionData {
    @Id
    String id;

    String nodeId;

    SessionDataState state=SessionDataState.NEW;

    List<FileData> fileDatas=new ArrayList<>();

    List<LogEntry> log=new ArrayList<LogEntry>();

    SessionWorkloadData sessionWorkloadData;

    long createDate;


    @Builder
    public SessionData(String nodeId) {
        this.nodeId = nodeId;
    }

    public enum SessionDataState {
        NEW, INCOMPLETE, COMPLETE
    }
}


