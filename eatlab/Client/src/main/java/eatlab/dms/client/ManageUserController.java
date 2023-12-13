package eatlab.dms.client;

import de.jensd.fx.glyphs.fontawesome.FontAwesomeIcon;
import de.jensd.fx.glyphs.fontawesome.FontAwesomeIconView;
import eatlab.dms.api.ApiProperties;
import eatlab.dms.api.service.QueryService;
import eatlab.dms.api.service.UserService;
import eatlab.dms.common.domain.LoginResultData;
import eatlab.dms.common.domain.QueryData;
import eatlab.dms.common.domain.SessionDataWrapper;
import eatlab.dms.common.domain.UserData;
import javafx.beans.property.ReadOnlyObjectWrapper;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.geometry.Side;
import javafx.scene.control.*;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.scene.input.KeyCode;
import javafx.scene.input.KeyEvent;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.HBox;
import javafx.stage.Stage;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;

import java.awt.*;
import java.io.File;
import java.net.URL;
import java.nio.file.Paths;
import java.time.ZoneOffset;
import java.util.ArrayList;
import java.util.ResourceBundle;

@Controller
public class ManageUserController implements Initializable {

    private Logger log= LoggerFactory.getLogger(this.getClass());

    @FXML
    private AnchorPane mainPane;


    @FXML
    private TableView<UserData> tableView;

    @FXML
    private TableColumn<UserData,UserData> btnOpen;


    @FXML
    private Button btnUser;

    @FXML
    private ContextMenu contextMenuBtnUser;


    @Autowired
    private QueryService queryService;

    @Autowired
    private UserService userService;

    private ArrayList<CheckBox> checkboxList = new ArrayList<CheckBox>();

    @Override
    public void initialize(URL location, ResourceBundle resources) {

        btnOpen.setCellValueFactory(param -> new ReadOnlyObjectWrapper<>(param.getValue()));

        btnOpen.setCellFactory(param -> new TableCell<UserData, UserData>() {



            @Override
            protected void updateItem(UserData userData, boolean empty) {
                HBox hbox = new HBox();
                Button openBtn = new Button("Edit");
                Button changePasswordBtn = new Button("Change Password");
                hbox.getChildren().addAll(openBtn,changePasswordBtn);
                openBtn.setGraphic(new FontAwesomeIconView(FontAwesomeIcon.EDIT));
                changePasswordBtn.setGraphic(new FontAwesomeIconView(FontAwesomeIcon.KEY));
                super.updateItem(userData, empty);

                if (userData == null) {
                    setGraphic(null);
                    return;
                }

                //FontAwesomeIconView openButton
                setGraphic(hbox);
                openBtn.setOnAction(event -> {
                    log.info("edit" + userData.getUserName());
                    try {
                        CmsApplication.StageResult<EditUserController> stageResult = CmsApplication.getApplication().CreateStageResult(mainPane.getScene().getWindow(), "/editUser.fxml");
                        stageResult.controller.setUserData(userData);
                        stageResult.stage.showAndWait();
                        loadData();
                    } catch (Exception ex) {
                        log.error("Could not open edit user",ex);
                    }
                });
                changePasswordBtn.setOnAction(event -> {
                    log.info("change password" + userData.getUserName());
                    try {
                        CmsApplication.StageResult<ChangePasswordController> stageResult = CmsApplication.getApplication().CreateStageResult(mainPane.getScene().getWindow(), "/changePassword.fxml");
                        stageResult.controller.setUserData(userData);
                        stageResult.stage.showAndWait();
                    } catch (Exception ex) {
                        log.error("Could not open edit user",ex);
                    }
                });
            }
        });

        loadData();
    }


    private void loadData() {
        try {
            log.debug("loading users...");
            tableView.getItems().clear();
            tableView.getItems().addAll(userService.listUsers());
        } catch (Exception ex) {
            log.error("Could not load Users",ex);
        }
    }





    public void handleAddUser(ActionEvent actionEvent) {
        log.info("Add User");
        try {
            CmsApplication.StageResult<EditUserController> stageResult = CmsApplication.getApplication().CreateStageResult(mainPane.getScene().getWindow(), "/editUser.fxml");
            stageResult.stage.showAndWait();
        } catch (Exception ex) {
            log.error("Could not open edit user",ex);
        }
    }
}
