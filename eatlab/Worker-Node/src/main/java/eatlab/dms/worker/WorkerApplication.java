package eatlab.dms.worker;

import eatlab.dms.api.ApiProperties;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.data.mongo.MongoDataAutoConfiguration;
import org.springframework.boot.autoconfigure.mongo.MongoAutoConfiguration;
import org.springframework.boot.context.properties.EnableConfigurationProperties;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.scheduling.annotation.EnableScheduling;
import org.springframework.web.client.RestTemplate;

@SpringBootApplication(exclude = {MongoAutoConfiguration.class, MongoDataAutoConfiguration.class})
@ComponentScan("eatlab.dms")
@EnableScheduling
@EnableConfigurationProperties({WorkerProperties.class})
public class WorkerApplication {

    private static final Logger log = LoggerFactory.getLogger(WorkerApplication.class);

    public static void main(String[] args) throws Exception {
        SpringApplication.run(WorkerApplication.class,args);
    }

    @Bean
    public CommandLineRunner run(WorkerProperties workerProperties) throws Exception {
        return args -> {
            ApiProperties.nodeId=workerProperties.id;
            log.info("Joining thread, you can press Ctrl+C to shutdown application");
            Thread.currentThread().join();
        };
    }
}
