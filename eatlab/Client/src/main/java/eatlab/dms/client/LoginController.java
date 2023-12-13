package eatlab.dms.client;

import eatlab.dms.api.ApiProperties;
import eatlab.dms.api.service.UserService;
import eatlab.dms.common.domain.LoginResultData;
import eatlab.dms.common.domain.UserData;
import javafx.application.Application;
import javafx.beans.property.SimpleBooleanProperty;
import javafx.beans.value.ObservableValue;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.*;
import javafx.scene.control.cell.CheckBoxListCell;
import javafx.scene.input.KeyCode;
import javafx.scene.input.KeyEvent;
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
public class LoginController implements Initializable {

    private Logger log= LoggerFactory.getLogger(this.getClass());

    @FXML
    private AnchorPane mainPanel;

    
    @FXML
    private TextField txtUserName;

    @FXML
    private PasswordField txtPassword;

    @Autowired
    private UserService userService;


    @Override
    public void initialize(URL location, ResourceBundle resources) {
    }

    public void handleCancel(ActionEvent actionEvent) {
        Stage stage = (Stage) mainPanel.getScene().getWindow();
        // do what you have to do
        stage.close();
    }

    private UserData userData;

    public UserData getUserData() {
        return userData;
    }

    public void handleLogin(ActionEvent actionEvent) {
        try {
            LoginResultData loginResultData = userService.login(txtUserName.getText(), txtPassword.getText());
            ApiProperties.jwtToken = loginResultData.getToken();
            userData=loginResultData.getUser();
            handleCancel(null);
        } catch (Exception ex) {
            CmsApplication.getApplication().ShowAlert("Could not login",ex);
        }
    }

    public void handleKey(KeyEvent keyEvent) {
        if (keyEvent.getCode()== KeyCode.ENTER) {
            handleLogin(null);
        }
    }
}
