package eatlab.dms.server.mongo;

import eatlab.dms.common.domain.SessionData;
import eatlab.dms.common.domain.UserData;
import org.springframework.data.mongodb.repository.MongoRepository;
import org.springframework.data.mongodb.repository.Query;

import java.util.List;
import java.util.Optional;

public interface UserDataRepository extends MongoRepository<UserData, String> {
    Optional<UserData> findById(String id);
}
