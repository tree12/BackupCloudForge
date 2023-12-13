package eatlab.dms.server;

import lombok.Data;
import org.springframework.boot.context.properties.ConfigurationProperties;

@ConfigurationProperties(
        prefix = "eatlab.dms.server"
)

@Data
public class ServerProperties {
    private String directory;
    private String jsonDataFileName;
    private String sambaShare;
    private String allowedTokens;
    private boolean fixBrokenJson;
}
