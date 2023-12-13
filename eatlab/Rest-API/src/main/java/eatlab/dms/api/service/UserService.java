package eatlab.dms.api.service;

import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import eatlab.dms.api.ApiProperties;
import eatlab.dms.common.domain.*;
import eatlab.dms.common.domain.helper.ResultException;
import eatlab.dms.common.domain.helper.ResultWithInfo;
import eatlab.dms.common.domain.helper.ResultWithInfoBase;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;

import java.net.URLEncoder;
import java.util.ArrayList;
import java.util.List;

@Service
public class UserService {

    Logger log = LoggerFactory.getLogger(this.getClass());

    @Autowired
    ApiProperties _apiProperties;

    @Autowired()
    @Qualifier("ApiRestTemplate")
    RestTemplate _restTemplate;

    public LoginResultData login(String username, String password) throws ResultException {
        ResponseEntity e =_restTemplate.postForEntity(_apiProperties.getUrl()+"/eatlab-dms/api/user/login", LoginData.builder().userName(username).password(password).build(), new ResultWithInfo<LoginResultData>().getClass());
        ObjectMapper mapper = new ObjectMapper();
        ResultWithInfo<LoginResultData> r = mapper.convertValue(e.getBody(), new TypeReference<ResultWithInfo<LoginResultData>>(){} );
        if (r.isError()) throw new ResultException(r);
        return r.getData();
    }

    public List<UserData> listUsers() {
        ResponseEntity e =_restTemplate.getForEntity(_apiProperties.getUrl()+"/eatlab-dms/api/user/listUsers", new ArrayList<UserData>().getClass());
        ObjectMapper mapper = new ObjectMapper();
        List<UserData> r = mapper.convertValue(e.getBody(), new TypeReference<List<UserData>>(){} );
        return r;
    }

    public void addUser(UserData user)  throws ResultException  {
        ResponseEntity<ResultWithInfoBase> e =_restTemplate.postForEntity(_apiProperties.getUrl()+"/eatlab-dms/api/user/addUser",user, ResultWithInfoBase.class);
        if (e.getBody().isError()) throw new ResultException(e.getBody());
    }

    public void saveUser(UserData user)  throws ResultException  {
        ResponseEntity<ResultWithInfoBase> e =_restTemplate.postForEntity(_apiProperties.getUrl()+"/eatlab-dms/api/user/saveUser",user, ResultWithInfoBase.class);
        if (e.getBody().isError()) throw new ResultException(e.getBody());
    }

    public void changePassword(UserData user, String password)  throws ResultException  {
        ResponseEntity<ResultWithInfoBase> e =_restTemplate.postForEntity(_apiProperties.getUrl()+"/eatlab-dms/api/user/changePassword?userName="+ URLEncoder.encode(user.getUserName()),password, ResultWithInfoBase.class);
        if (e.getBody().isError()) throw new ResultException(e.getBody());
    }
}
