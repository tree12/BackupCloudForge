package eatlab.dms.common.domain.helper;

import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;

@Data
@NoArgsConstructor
public class ResultWithInfo<T> extends ResultWithInfoBase {

    public ResultWithInfo(T data) {
        this.data=data;
    }
    T data;

    public static <J> ResponseEntity<ResultWithInfo<J>> Create(J o) {
        ResultWithInfo<J> result = new ResultWithInfo<>(o);
        return new ResponseEntity<ResultWithInfo<J>>(result, HttpStatus.OK);
    }

}
