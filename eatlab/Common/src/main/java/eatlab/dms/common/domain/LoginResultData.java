package eatlab.dms.common.domain;

import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
public class LoginResultData {

    @Builder
    public LoginResultData(UserData user, String token) {
        this.user = user;
        this.token = token;
    }

    private UserData user;
    private String token;

}
