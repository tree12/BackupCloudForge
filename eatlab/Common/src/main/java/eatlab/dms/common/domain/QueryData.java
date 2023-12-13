package eatlab.dms.common.domain;

import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
public class QueryData {

    @Builder
    public QueryData(String query, boolean searchProduct, boolean searchCustomer, boolean searchFileName, long fromDate, long toDate) {
        this.query = query;
        this.searchProduct = searchProduct;
        this.searchCustomer = searchCustomer;
        this.searchFileName = searchFileName;
        this.fromDate = fromDate;
        this.toDate = toDate;
    }


    private String query;

    private boolean searchProduct;
    private boolean searchCustomer;
    private boolean searchFileName;

    private long fromDate;
    private long toDate;
}
