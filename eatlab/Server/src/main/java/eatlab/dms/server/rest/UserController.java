package eatlab.dms.server.rest;

import eatlab.dms.common.domain.*;
import eatlab.dms.common.domain.helper.ResultWithInfo;
import eatlab.dms.common.domain.helper.ResultWithInfoBase;
import eatlab.dms.server.SecurityConfig;
import eatlab.dms.server.ServerProperties;
import eatlab.dms.server.helper.MD5Hash;
import eatlab.dms.server.mongo.SessionDataRepository;
import eatlab.dms.server.mongo.UserDataRepository;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.mongodb.core.MongoTemplate;
import org.springframework.data.mongodb.core.query.Criteria;
import org.springframework.data.mongodb.core.query.Query;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.annotation.Secured;
import org.springframework.security.core.annotation.AuthenticationPrincipal;
import org.springframework.security.core.context.SecurityContext;
import org.springframework.web.bind.annotation.*;

import java.security.NoSuchAlgorithmException;
import java.util.ArrayList;
import java.util.List;

@RestController
@RequestMapping("/api/user")
public class UserController {
    private final Logger logger = LoggerFactory.getLogger(this.getClass());


    @Autowired
    SessionDataRepository sessionDataRepository;

    @Autowired
    MongoTemplate mongoTemplate;

    @Autowired
    ServerProperties serverProperties;

    @Autowired
    UserDataRepository userDataRepository;

    @PostMapping("/login")
    ResponseEntity<ResultWithInfo<LoginResultData>> login(@RequestBody LoginData loginData) throws NoSuchAlgorithmException {
        ResponseEntity<ResultWithInfo<LoginResultData>> e = ResultWithInfo.Create(new LoginResultData());
        UserData userData=userDataRepository.findById(loginData.getUserName().toLowerCase()).orElse(null);
        if (userData==null || !userData.getMd5Password().equals(MD5Hash.createMD5(loginData.getPassword()))) {
            e.getBody().AddError("Wrong User/Password");
        }
        e.getBody().setData(LoginResultData.builder().user(userData).token(SecurityConfig.JwtPreAuthTokenFilter.GetTokenFromUser(userData)).build());
        return e;
    }

    @GetMapping("/listUsers")
    @Secured("ROLE_ADMIN")
    ResponseEntity<List<UserData>> listUsers() {
        return new ResponseEntity<> (userDataRepository.findAll(),HttpStatus.OK);
    }

    @PostMapping("/addUser")
    @Secured("ROLE_ADMIN")
    ResponseEntity<ResultWithInfoBase> addUser(@RequestBody UserData user) {
        ResponseEntity<ResultWithInfoBase> response = new ResponseEntity<ResultWithInfoBase>(new ResultWithInfoBase(),HttpStatus.OK);
        user.setId(user.getUserName().toLowerCase());
        if (userDataRepository.findById(user.getId()).orElse(null)!=null) {
            response.getBody().AddError("User allready exists!");
            return response;
        }
        userDataRepository.save(user);
        response.getBody().AddInfo("User added");
        return response;
    }

    @PostMapping("/saveUser")
    @Secured("ROLE_ADMIN")
    ResponseEntity<ResultWithInfoBase> saveUser(@RequestBody UserData user) {
        ResponseEntity<ResultWithInfoBase> response = new ResponseEntity<ResultWithInfoBase>(new ResultWithInfoBase(),HttpStatus.OK);
        user.setId(user.getUserName().toLowerCase());
        UserData existingUser = userDataRepository.findById(user.getId()).orElse(null);
        if (existingUser==null) {
            response.getBody().AddError("User not exists!");
            return response;
        }
        existingUser.setFullName(user.getFullName());
        existingUser.setPermissions(user.getPermissions());
        userDataRepository.save(existingUser);
        response.getBody().AddInfo("User saved");
        return response;
    }

    @PostMapping("/changePassword")
    @Secured("ROLE_USER")
    ResponseEntity<ResultWithInfoBase> changePassword(@RequestParam String userName, @RequestBody String password, @AuthenticationPrincipal UserData callingUser) throws NoSuchAlgorithmException {
        ResponseEntity<ResultWithInfoBase> response = new ResponseEntity<ResultWithInfoBase>(new ResultWithInfoBase(),HttpStatus.OK);
        if (!callingUser.getUserName().equalsIgnoreCase(userName) && !callingUser.HasPermission(UserData.Permissions.ROLE_ADMIN)) {
            response.getBody().AddError("Only Admin can change other Passwords!");
            return response;
        }
        UserData user = userDataRepository.findById(userName.toLowerCase()).orElse(null);
        if (user==null) {
            response.getBody().AddError("User not exists!");
            return response;
        }

        if (password==null || password.length()<5) {
            response.getBody().AddError("Password has to be at least 5 characters (and that is not even secure)!");
            return response;
        }
        user.setMd5Password(MD5Hash.createMD5(password));
        userDataRepository.save(user);
        response.getBody().AddInfo("Password changed!");
        return response;
    }
}
