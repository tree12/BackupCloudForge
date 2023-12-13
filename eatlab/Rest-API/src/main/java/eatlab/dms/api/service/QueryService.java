package eatlab.dms.api.service;

import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import eatlab.dms.api.ApiProperties;
import eatlab.dms.common.domain.FileData;
import eatlab.dms.common.domain.QueryData;
import eatlab.dms.common.domain.SessionData;
import eatlab.dms.common.domain.SessionDataWrapper;
import eatlab.dms.common.domain.helper.ResultException;
import eatlab.dms.common.domain.helper.ResultWithInfo;
import eatlab.dms.common.domain.helper.ResultWithInfoBase;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.client.RestTemplate;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.List;

@Service
public class QueryService {

    Logger log = LoggerFactory.getLogger(this.getClass());

    @Autowired
    ApiProperties _apiProperties;

    @Autowired()
    @Qualifier("ApiRestTemplate")
    RestTemplate _restTemplate;

    public List<SessionDataWrapper> QuerySessionsAll() throws ResultException {
        ResponseEntity e =_restTemplate.getForEntity(_apiProperties.getUrl()+"/eatlab-dms/api/query/querySessionsAll", new ResultWithInfo<List<SessionDataWrapper>>().getClass());
        ObjectMapper mapper = new ObjectMapper();
        ResultWithInfo<List<SessionDataWrapper>> r = mapper.convertValue(e.getBody(), new TypeReference<ResultWithInfo<List<SessionDataWrapper>>>(){} );
        if (r.isError()) throw new ResultException(r);
        return r.getData();
    }

    public List<SessionDataWrapper> querySessionsAllRegex(QueryData queryData) throws ResultException {
        ResponseEntity e =_restTemplate.postForEntity(_apiProperties.getUrl()+"/eatlab-dms/api/query/querySessionsAllRegex", queryData, new ResultWithInfo<List<SessionDataWrapper>>().getClass());
        ObjectMapper mapper = new ObjectMapper();
        ResultWithInfo<List<SessionDataWrapper>> r = mapper.convertValue(e.getBody(), new TypeReference<ResultWithInfo<List<SessionDataWrapper>>>(){} );
        if (r.isError()) throw new ResultException(r);
        return r.getData();
    }


    public String getSambaShare() {
        return _restTemplate.getForObject(_apiProperties.getUrl()+"/eatlab-dms/api/query/sambaShare",String.class);
    }
}
