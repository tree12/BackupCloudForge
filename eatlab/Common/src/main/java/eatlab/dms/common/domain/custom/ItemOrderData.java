package eatlab.dms.common.domain.custom;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.mongodb.core.mapping.Document;

import javax.mail.FetchProfile;
import java.util.List;

@Data
@Document
@JsonIgnoreProperties(ignoreUnknown = true)
@NoArgsConstructor
public class ItemOrderData {
    ItemData item;
    double amount;
    List<String> options_en;
    List<String> options_th;
    String status;
}
