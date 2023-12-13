package eatlab.dms.server.rest;

import eatlab.dms.common.domain.QueryData;
import eatlab.dms.common.domain.SessionData;
import eatlab.dms.common.domain.helper.ResultWithInfo;
import eatlab.dms.server.ServerProperties;
import eatlab.dms.server.mongo.SessionDataRepository;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.mongodb.core.MongoTemplate;
import org.springframework.data.mongodb.core.query.Criteria;
import org.springframework.data.mongodb.core.query.Query;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

@RestController
@RequestMapping("/api/query")
@Secured("ROLE_USER")
public class QueryController {
    private final Logger logger = LoggerFactory.getLogger(this.getClass());

    @Autowired
    SessionDataRepository sessionDataRepository;

    @Autowired
    MongoTemplate mongoTemplate;

    @Autowired
    ServerProperties serverProperties;

    @GetMapping("/querySessionsAll")
    ResponseEntity<ResultWithInfo<List<SessionData>>> querySessionsAll() {
        try {
            List<SessionData> list = sessionDataRepository.findAll();

            ResponseEntity<ResultWithInfo<List<SessionData>>> e = ResultWithInfo.Create(list);
            return e;
        }catch (Exception ex) {
            ResponseEntity<ResultWithInfo<List<SessionData>>> e = ResultWithInfo.Create(new ArrayList<>());
            e.getBody().AddError("Error while query data");
            e.getBody().setException(ex);
            return e;
        }
    }

    @PostMapping("/querySessionsAllRegex")
    ResponseEntity<ResultWithInfo<List<SessionData>>> querySessionsAllRegex(@RequestBody QueryData queryData) {
        try {
            //List<SessionData> list = sessionDataRepository.querySessionDataBy(".*"+queryString.getQuery()+".*");

            List<SessionData> list = querySessionDataBy(queryData);

            ResponseEntity<ResultWithInfo<List<SessionData>>> e = ResultWithInfo.Create(list);
            return e;
        }catch (Exception ex) {
            ResponseEntity<ResultWithInfo<List<SessionData>>> e = ResultWithInfo.Create(new ArrayList<>());
            e.getBody().AddError("Error while query data");
            e.getBody().setException(ex);
            return e;
        }
    }

    //@Query("{$or:[{'fileDatas.name': {$regex:?0}},{'sessionWorkloadData.products.name':{$regex:?0}},{'sessionWorkloadData.customerData.firstName':{$regex:?0}},{'sessionWorkloadData.customerData.lastName':{$regex:?0}}]}")
    private List<SessionData> querySessionDataBy(QueryData queryData) {
        String queryRegex=".*"+queryData.getQuery()+".*";
        Criteria criteria = new Criteria();
        Criteria orCriteria = new Criteria();
        String opts="i";

        List<Criteria> orCriterias=new ArrayList<>();
        List<Criteria> andCriterias=new ArrayList<>();

        if (queryData.getQuery()!=null && !queryData.getQuery().isEmpty()) {
            /*if (queryData.isSearchCustomer()) {
                orCriterias.add(Criteria.where("sessionWorkloadData.customerData.lastName").regex(queryRegex, opts));
                orCriterias.add(Criteria.where("sessionWorkloadData.customerData.firstName").regex(queryRegex, opts));
            }*/
            if (queryData.isSearchFileName()) orCriterias.add(Criteria.where("fileDatas.name").regex(queryRegex, opts));

            if (queryData.isSearchProduct()) {
                orCriterias.add(Criteria.where("sessionWorkloadData.itemOrderList.item.name_en").regex(queryRegex, opts));
                orCriterias.add(Criteria.where("sessionWorkloadData.itemOrderList.item.name_th").regex(queryRegex, opts));
            }

            if (orCriterias.size() > 0) {
                orCriteria.orOperator(orCriterias.toArray(new Criteria[orCriterias.size()]));
                andCriterias.add(orCriteria);
            }
        }

        if (queryData.getFromDate()>0) andCriterias.add(Criteria.where("createDate").gte(queryData.getFromDate()));
        if (queryData.getToDate()>0) andCriterias.add(Criteria.where("createDate").lte(queryData.getToDate()+86400000));

        if (andCriterias.size()>0) {
            criteria.andOperator(andCriterias.toArray(new Criteria[andCriterias.size()]));

            return mongoTemplate.find(new Query(criteria), SessionData.class);
        }
        return mongoTemplate.findAll(SessionData.class);
    }


    @GetMapping("/sambaShare")
    ResponseEntity<String> sambaShare() {
        return new ResponseEntity<>(serverProperties.getSambaShare(),HttpStatus.OK);
    }
}
