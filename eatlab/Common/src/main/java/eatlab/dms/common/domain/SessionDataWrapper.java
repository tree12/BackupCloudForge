package eatlab.dms.common.domain;

import com.fasterxml.jackson.annotation.JsonIgnore;

import java.util.stream.Collectors;

public class SessionDataWrapper extends SessionData {

    public static boolean LANG_IS_THAI=false;

    @JsonIgnore
    public String getFileSumary() {
        if (fileDatas==null) return "none";
        float size=fileDatas.stream().mapToLong(x->x.size).sum();
        size=size/ (1024);
        String sizeStr;
        if (size>512) sizeStr=String.format("%.2f",size/1024) + " MB";
        else sizeStr=String.format("%.2f",size) + " KB";

        String fileSumary=fileDatas.size() + " Files ("+ sizeStr+")";
        return fileSumary;
    }

    @JsonIgnore
    public String getOrderList() {
        if (sessionWorkloadData ==null || sessionWorkloadData.getItemOrderList()==null) return "none";
        //String orderList=sessionWorkloadData.getProducts().size() + " Products "+
                String orderList= sessionWorkloadData.getItemOrderList().stream().map(x->LANG_IS_THAI?x.getItem().getName_th():x.getItem().getName_en()).distinct().collect(Collectors.joining(", "));
        return orderList;
    }

    @JsonIgnore
    public String getCustomerList() {
        return "no CustomerData available";
        /*
        if (sessionWorkloadData ==null || sessionWorkloadData.getCustomerData()==null) return "none";
        //String orderList=sessionWorkloadData.getProducts().size() + " Products "+
        String orderList= sessionWorkloadData.getCustomerData().stream().map(x->x.getFirstName()+" "+x.getLastName()).distinct().collect(Collectors.joining(", "));
        return orderList;
        */
    }

    @JsonIgnore
    public String getStateSumary() {
        if (state==SessionDataState.COMPLETE) return "complete";
        if (fileDatas==null) return "none";
        if (fileDatas.stream().anyMatch(x->x.getFileState()!= FileData.FileDataState.COMPLETE)) {
            if (fileDatas.stream().anyMatch(x->x.getFileState()== FileData.FileDataState.CURRUPTED)) {
                return "corrupt";
            }
            if (fileDatas.stream().anyMatch(x->x.getFileState()== FileData.FileDataState.INCOMPLETE)) {
                return "incomplete";
            }
            return "undefined";
        }
        return "files complete";
    }

    @JsonIgnore
    public String getFileList() {
        if (fileDatas==null) return "none";
        String fileNames=fileDatas.stream().map(x->x.getName()).collect(Collectors.joining(", "));
        return fileNames;
    }
}
