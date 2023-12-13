package eatlab.dms.server.mongo;

import eatlab.dms.common.domain.SessionData;
import org.springframework.data.mongodb.MongoDbFactory;
import org.springframework.data.mongodb.core.query.Criteria;

import org.springframework.data.mongodb.repository.MongoRepository;
import org.springframework.data.mongodb.repository.Query;

import java.util.List;
import java.util.Optional;

public interface SessionDataRepository extends MongoRepository<SessionData, String> {
    Optional<SessionData> findById(String id);

    @Query("{$or:[{'fileDatas.name': {$regex:?0}},{'sessionWorkloadData.products.name':{$regex:?0}},{'sessionWorkloadData.customerData.firstName':{$regex:?0}},{'sessionWorkloadData.customerData.lastName':{$regex:?0}}]}")
    List<SessionData> querySessionDataBy(String queryRegex);
}
