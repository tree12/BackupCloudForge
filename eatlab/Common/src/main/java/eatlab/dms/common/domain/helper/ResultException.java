package eatlab.dms.common.domain.helper;

public class ResultException extends Exception {
    ResultWithInfoBase resultWithInfoBase;
    public ResultException(ResultWithInfoBase resultWithInfoBase) {
        super(resultWithInfoBase.getErrorMessage());
        this.resultWithInfoBase=resultWithInfoBase;
    }

    public ResultWithInfoBase getResultWithInfoBase() {
        return resultWithInfoBase;
    }

    @Override
    public String getMessage() {
        if (resultWithInfoBase.hasException()) return resultWithInfoBase.exception;
        if (resultWithInfoBase.isError())return resultWithInfoBase.getErrorMessage();
        return "No Error found";
    }
}
