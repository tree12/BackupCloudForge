package eatlab.dms.api;

import com.fasterxml.jackson.databind.ObjectMapper;
import eatlab.dms.api.service.SyncService;
import eatlab.dms.common.domain.custom.CustomerData;
import eatlab.dms.common.domain.custom.SessionWorkloadData;
import eatlab.dms.common.domain.custom.ItemData;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.web.client.RestTemplate;

import java.io.File;
import java.io.IOException;

@SpringBootApplication
@ComponentScan()
public class ApiTestApplicaton {

    private static final Logger log = LoggerFactory.getLogger(ApiTestApplicaton.class);
    public static void main(String args[]) {
        SpringApplication.run(ApiTestApplicaton.class);
    }

    @Bean
    @Autowired
    public CommandLineRunner run(RestTemplate restTemplate, SyncService syncService) throws Exception {
        return args -> {

          //  syncService.RequestNewSessionDataId("testNode");
            writeOrderData();

        };
    }

    private void writeOrderData() throws IOException {
        /*SessionWorkloadData sessionWorkloadData = new SessionWorkloadData();
        sessionWorkloadData.getCustomerData().add(new CustomerData("Thomas","Antlinger"));
        sessionWorkloadData.getCustomerData().add(new CustomerData("Resin","Kautschuk"));
        sessionWorkloadData.getProducts().add(new ItemData("Cola",1));
        sessionWorkloadData.getProducts().add(new ItemData("Coffee",2));

        File jsonFile=new File("F:/temp/eatlab_test/data.json");

        ObjectMapper mapper = new ObjectMapper();
        mapper.writeValue(jsonFile, sessionWorkloadData);*/
    }

}
