package eatlab.dms.server.migration;

import com.github.mongobee.changeset.ChangeLog;
import com.github.mongobee.changeset.ChangeSet;
import eatlab.dms.common.domain.UserData;
import eatlab.dms.server.helper.MD5Hash;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.data.mongodb.core.MongoTemplate;

import java.util.Arrays;

@ChangeLog
public class MigrateDB {

    Logger log = LoggerFactory.getLogger(this.getClass());

    @ChangeSet(id="createAdmin", order = "0",author = "antth")
    public void createAdmin(MongoTemplate mongoTemplate) {
        UserData userData=mongoTemplate.findById("admin", UserData.class);
        if (userData!=null) return;
        try {
            UserData admin = UserData.builder().fullName("Administrator").userName("admin").md5Password(MD5Hash.createMD5("admin")).build();
            admin.setPermissions(Arrays.asList(UserData.Permissions.ROLE_ADMIN,UserData.Permissions.ROLE_USER,UserData.Permissions.ROLE_NODE));
            mongoTemplate.save(admin);
        } catch (Exception ex) {
            log.error("Could not create Admin",ex);
        }
    }
}
