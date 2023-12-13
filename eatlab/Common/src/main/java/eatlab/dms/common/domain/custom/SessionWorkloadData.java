package eatlab.dms.common.domain.custom;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
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
public class SessionWorkloadData {
    @Id
    String id;

    List<ItemOrderData> itemOrderList=new ArrayList<>();
    //List<CustomerData> customerData=new ArrayList<>();


}


