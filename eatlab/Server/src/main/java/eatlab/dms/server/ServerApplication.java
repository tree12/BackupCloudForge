package eatlab.dms.server;


import com.github.mongobee.Mongobee;
import com.github.mongobee.exception.MongobeeException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.context.properties.EnableConfigurationProperties;
import org.springframework.cache.annotation.EnableCaching;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.core.env.Environment;

@SpringBootApplication
@ComponentScan("eatlab.dms")
@EnableConfigurationProperties({ServerProperties.class})
@EnableCaching
public class ServerApplication {


    @Autowired
    private Environment env;

    public static void main(String[] args) {
        SpringApplication.run(ServerApplication.class, args);
    }

    @Bean
    public Mongobee mongobee() throws MongobeeException {
        // props
        String hostname = env.getProperty("spring.data.mongodb.host");
        String port = env.getProperty("spring.data.mongodb.port");
        String database = env.getProperty("spring.data.mongodb.database");
        Mongobee runner = new Mongobee("mongodb://" + hostname + ":" + port + "/" + database);
        runner.setDbName(database);
        runner.setChangeLogsScanPackage("eatlab.dms.server.migration");
        runner.setEnabled(true);
        return runner;
    }
}
