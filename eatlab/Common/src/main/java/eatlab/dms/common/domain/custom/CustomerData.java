package eatlab.dms.common.domain.custom;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

@Data
@Document
@JsonIgnoreProperties(ignoreUnknown = true)
@NoArgsConstructor
public class CustomerData {

    @Builder
    public CustomerData(String firstName, String lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    String firstName;
    String lastName;

}


