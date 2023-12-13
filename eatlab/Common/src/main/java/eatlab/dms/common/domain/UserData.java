package eatlab.dms.common.domain;

import com.fasterxml.jackson.annotation.JsonIgnore;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

import java.util.List;
import java.util.stream.Collectors;

@Document
@Data
@NoArgsConstructor
public class UserData {

    @Builder
    public UserData(String userName, String fullName, String md5Password) {
        this.id=userName.toLowerCase();
        this.userName=userName;
        this.fullName = fullName;
        this.md5Password = md5Password;
    }

    @Id
    private String id;

    private String userName;

    private String fullName;

    private List<Permissions> permissions;

    @JsonIgnore
    private String md5Password;

    public boolean HasPermission(Permissions permission) {
        if (permissions==null) return false;
        return permissions.stream().anyMatch(x->x==permission);
    }

    public enum Permissions{
        ROLE_ADMIN,ROLE_USER,ROLE_NODE
    }

    @JsonIgnore
    public String GetPermissionList() {
        if (permissions==null || permissions.size()==0) return "none";
        return permissions.stream().map(x->x.name()).collect(Collectors.joining(","));
    }
}
