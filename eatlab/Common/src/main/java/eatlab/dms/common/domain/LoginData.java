package eatlab.dms.common.domain;

import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
public class LoginData {

    @Builder
    public LoginData(String userName, String password) {
        this.userName = userName;
        this.password = password;
    }

    private String userName;
    private String password;
}
