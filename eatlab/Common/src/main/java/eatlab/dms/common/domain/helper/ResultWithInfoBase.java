package eatlab.dms.common.domain.helper;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.beans.Transient;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

@JsonIgnoreProperties(ignoreUnknown = true)
@NoArgsConstructor
public class ResultWithInfoBase {

    @Builder
    public ResultWithInfoBase(List<String> errors, List<String> warnings, List<String> infos,Exception ex) {
        this.errors = errors;
        this.warnings = warnings;
        this.infos=infos;
    }

    public ResultWithInfoBase(Exception ex) {
        this.errors.add(ex.getMessage());
    }

    List<String> errors=new ArrayList<>();
    List<String> warnings=new ArrayList<>();
    List<String> infos=new ArrayList<>();
    String exception;


    public List<String> getErrors() {
        return errors;
    }

    public List<String> getWarnings() {
        return warnings;
    }

    public List<String> getInfos() {
        return infos;
    }

    public String getException() {
        return exception;
    }

    public void setException(Exception ex) {
        this.exception = ex.toString();
    }

    public void setException(String ex) {
        this.exception = ex;
    }

    public void CopyTo(ResultWithInfo destination) {
        if (isError()) {
            destination.getErrors().addAll(errors);
        }
        if (isWarning()) {
            destination.getWarnings().addAll(warnings);
        }
        if (isInfo()) {
            destination.getInfos().addAll(infos);
        }
        if (hasException()) {
            destination.setException(exception);
        }
    }


    public boolean hasException() {
        return this.exception!=null;
    }

    public ResultWithInfoBase AddError(String errorMsg) {
        if (errors==null) errors=new ArrayList<>();
        errors.add(errorMsg);
        return this;
    }

    public ResultWithInfoBase AddErrors(String[] errorMsgs) {
        if (errors==null) errors=new ArrayList<>();
        errors.addAll(Arrays.asList(errorMsgs));
        return this;
    }

    public ResultWithInfoBase AddErrors(List<String> errorMsgs) {
        if (errors==null) errors=new ArrayList<>();
        errors.addAll(errorMsgs);
        return this;
    }

    public ResultWithInfoBase AddError(String errorMsg,Exception ex) {
        if (errors==null) errors=new ArrayList<>();
        errors.add(errorMsg+": " +ex.getMessage());
        exception=ex.getMessage();
        return this;
    }

    public ResultWithInfoBase AddWarning(String warnMsg) {
        if (warnings==null) warnings=new ArrayList<>();
        warnings.add(warnMsg);
        return this;
    }

    public ResultWithInfoBase AddInfo(String infoMsg) {
        if (infos==null) infos=new ArrayList<>();
        infos.add(infoMsg);
        return this;
    }

    public String getErrorMessage() {
        String msg="";
        if (exception!=null) msg+=exception+"\n";
        if (errors!=null) {
            for (String s :
                    errors) {
                msg += s + "\n";
            }
        }
        return msg;
    }

    public boolean isError() {
        return errors!=null && errors.size()>0;
    }

    public boolean isWarning() {
        return warnings!=null && warnings.size()>0;
    }

    public boolean isErrorOrWarning() {
        return isError() || isWarning();
    }

    public boolean isInfo() {
        return infos!=null && infos.size()>0;
    }
}
