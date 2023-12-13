package eatlab.dms.client;

import eatlab.dms.api.service.UserService;
import eatlab.dms.common.domain.UserData;
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
import org.springframework.stereotype.Controller;

import java.net.URL;
import java.util.*;

@Controller
public class ChangePasswordController implements Initializable {

    private Logger log= LoggerFactory.getLogger(this.getClass());

    @FXML
    private AnchorPane mainPanel;

    @FXML
    private Label lblHeader;

    @FXML
    private Button btnSave;


    @FXML
    private PasswordField password1;

    @FXML
    private PasswordField password2;

    @Autowired
    private UserService userService;

    private UserData userData=new UserData();

    public UserData getUserData() {
        return userData;
    }

    private HashMap<UserData.Permissions,ObservableValue<Boolean>> permissions=new HashMap<>();

    public void setUserData(UserData userData) {
        this.userData = userData;
        lblHeader.setText("Change Password for " + userData.getFullName());
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {
    }

    public void handleCancel(ActionEvent actionEvent) {
        Stage stage = (Stage) mainPanel.getScene().getWindow();
        // do what you have to do
        stage.close();
    }


    public void handleSave(ActionEvent actionEvent) {
        if (!password1.getText().equals(password2.getText())) {
            CmsApplication.getApplication().ShowAlert("The passwords not match!");
            return;
        }
        try {
            userService.changePassword(userData, password1.getText());
            CmsApplication.getApplication().ShowAlert(Alert.AlertType.INFORMATION,"Password changed successfully");
            handleCancel(null);
        } catch (Exception ex) {
            CmsApplication.getApplication().ShowAlert("Could not change password",ex);
        }
    }
}
