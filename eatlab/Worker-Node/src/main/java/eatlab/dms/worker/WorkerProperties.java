package eatlab.dms.worker;

import lombok.Data;
import org.springframework.boot.context.properties.ConfigurationProperties;

@ConfigurationProperties(
        prefix = "eatlab.dms.worker"
)
@Data
public class WorkerProperties {
    String id;

    @Data
    public static class Scan {
        String interval;
        String directory;
        String matcher=".*";
    }

    @Data
    public static class RenameOpt {
        String search;
        String replace;
    }

    boolean rename=false;
    RenameOpt renameOpt;

    Scan scan;
}
