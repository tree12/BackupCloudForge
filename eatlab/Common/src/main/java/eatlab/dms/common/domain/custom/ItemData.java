package eatlab.dms.common.domain.custom;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

import java.util.List;

@Data
@Document
@JsonIgnoreProperties(ignoreUnknown = true)
@NoArgsConstructor
public class ItemData {
    List<String> options_en;
    List<String> options_th;
    String _id;
    String category;
    String subcategory;

    String name_en;
    String name_th;

    String details_en;
    String details_th;

    double price;
    double calories;

    boolean enabled;

    String thumbnail_url;
    String video_url;

    boolean signature_dish;

    double __v;
}


