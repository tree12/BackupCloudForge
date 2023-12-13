package eatlab.dms.client;

import lombok.Data;
import org.springframework.boot.context.properties.ConfigurationProperties;

@ConfigurationProperties(
        prefix = "eatlab.dms.client"
)

@Data
public class ClientProperties {
    private String cssStyle;
}
