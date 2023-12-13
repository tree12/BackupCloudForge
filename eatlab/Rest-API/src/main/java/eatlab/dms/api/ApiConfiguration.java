package eatlab.dms.api;

import org.springframework.boot.context.properties.EnableConfigurationProperties;
import org.springframework.boot.web.client.RestTemplateBuilder;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.http.HttpRequest;
import org.springframework.http.client.ClientHttpRequestExecution;
import org.springframework.http.client.ClientHttpRequestInterceptor;
import org.springframework.http.client.ClientHttpResponse;
import org.springframework.web.client.RestTemplate;

import java.io.IOException;
import java.util.Arrays;
import java.util.Collections;

@Configuration
@EnableConfigurationProperties({ApiProperties.class})
@ComponentScan
public class ApiConfiguration {

    public static final String X_AUTH_TOKEN = "X-Auth-Token";
    public static final String TOKEN_PREFIX = "EatLab ";
    public static final String HEADER_STRING = "Authorization";

    @Bean("ApiRestTemplate")
    public RestTemplate restTemplateSign(RestTemplateBuilder builder, ApiProperties apiProperties) {
        //RestTemplate template = builder.setConnectTimeout(5000).setReadTimeout(20000).build();
        RestTemplate template = builder.build();

        template.setInterceptors(Arrays.asList(new HeaderRequestInterceptor(apiProperties)));

        return template;
    }

    public class HeaderRequestInterceptor implements ClientHttpRequestInterceptor {

        private ApiProperties apiProperties;

        public HeaderRequestInterceptor(ApiProperties apiProperties) {
            this.apiProperties = apiProperties;
        }

        @Override
        public ClientHttpResponse intercept(HttpRequest request, byte[] body, ClientHttpRequestExecution execution) throws IOException {
            if (ApiProperties.jwtToken==null) {
                request.getHeaders().set(X_AUTH_TOKEN, apiProperties.getToken());
                request.getHeaders().set("X-Auth-ClientId", "" + ApiProperties.nodeId);
            } else
                request.getHeaders().set(HEADER_STRING,TOKEN_PREFIX+ApiProperties.jwtToken);
            return execution.execute(request, body);
        }
    }
}


