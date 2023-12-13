package eatlab.dms.api;

import lombok.Data;
import org.springframework.boot.context.properties.ConfigurationProperties;

@ConfigurationProperties(
        prefix = "eatlab.dms.api"
)

@Data
public class ApiProperties {

    private String url ="http://localhost:8080";
    private String token="";

    public static String jwtToken;
    public static String nodeId;
}


