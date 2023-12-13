package eatlab.dms.client;

import de.jensd.fx.glyphs.fontawesome.FontAwesomeIcon;
import eatlab.dms.api.service.QueryService;
import eatlab.dms.api.service.UserService;
import eatlab.dms.common.domain.UserData;
import javafx.beans.property.ReadOnlyObjectWrapper;
import javafx.beans.property.SimpleBooleanProperty;
import javafx.beans.value.ObservableValue;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.*;
import javafx.scene.control.cell.CheckBoxListCell;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;
import javafx.util.Callback;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.autoconfigure.security.SecurityProperties;
import org.springframework.stereotype.Controller;

import java.net.URL;
import java.util.*;

@Controller
public class EditUserController implements Initializable {

    private Logger log= LoggerFactory.getLogger(this.getClass());

    @FXML
    private AnchorPane mainPanel;

    @FXML
    private Label lblHeader;

    @FXML
    private Button btnSave;

    @FXML
    private ListView<UserData.Permissions> lstRoles;

    @FXML
    private TextField txtUserName;

    @FXML
    private TextField txtFullName;

    @Autowired
    private UserService userService;

    private UserData userData=new UserData();

    public UserData getUserData() {
        return userData;
    }

    private HashMap<UserData.Permissions,ObservableValue<Boolean>> permissions=new HashMap<>();

    private boolean isNew=true;

    public void setUserData(UserData userData) {

        this.userData = userData;
        UpdatePermissions();
        isNew=userData.getUserName()==null || userData.getUserName().isEmpty();
        txtUserName.setDisable(!isNew);
        lblHeader.setText(isNew?"Add User":"Edit User");
        btnSave.setText(isNew?"Add User":"Save User");
        txtUserName.setText(userData.getUserName());
        txtFullName.setText(userData.getFullName());
        lstRoles.refresh();
    }

    private void UpdatePermissions() {
        this.permissions.clear();
        for(UserData.Permissions permission:UserData.Permissions.values()) {
            this.permissions.put(permission,new SimpleBooleanProperty(this.userData.HasPermission(permission)));
        }
    }


    @Override
    public void initialize(URL location, ResourceBundle resources) {
        this.isNew=true;
        UpdatePermissions();
        lstRoles.setCellFactory(CheckBoxListCell.forListView(new Callback<UserData.Permissions, ObservableValue<Boolean>>() {
            @Override
            public ObservableValue<Boolean> call(UserData.Permissions param) {
                return EditUserController.this.permissions.get(param);
            }
        }));
        lstRoles.getItems().addAll(UserData.Permissions.values());
    }

    public void handleCancel(ActionEvent actionEvent) {
        Stage stage = (Stage) mainPanel.getScene().getWindow();
        // do what you have to do
        stage.close();
    }

    private UserData getUserDataForSave() {
        UserData userData=UserData.builder().userName(txtUserName.getText()).fullName(txtFullName.getText()).build();
        List<UserData.Permissions> userPermissions = new ArrayList<>();
        for (Map.Entry<UserData.Permissions,ObservableValue<Boolean>> entry :permissions.entrySet()) {
            if (entry.getValue().getValue()) {
                userPermissions.add(entry.getKey());
            }
        }
        userData.setPermissions(userPermissions);
        return userData;
    }

    public void handleSave(ActionEvent actionEvent) {
        UserData userData = getUserDataForSave();
        try {
            if (isNew) {
                userService.addUser(userData);
                CmsApplication.getApplication().ShowAlert(Alert.AlertType.INFORMATION,"User added");
                CmsApplication.StageResult<ChangePasswordController> stageResult = CmsApplication.getApplication().CreateStageResult(mainPanel.getScene().getWindow(), "/changePassword.fxml");
                stageResult.controller.setUserData(userData);
                stageResult.stage.showAndWait();
            } else {
                userService.saveUser(userData);
                CmsApplication.getApplication().ShowAlert(Alert.AlertType.INFORMATION,"User saved");
            }
            handleCancel(null);
        } catch (Exception ex) {
            log.error("Could not add/save user",ex);
            CmsApplication.getApplication().ShowAlert("Could not save User",ex);
        }
    }
}
