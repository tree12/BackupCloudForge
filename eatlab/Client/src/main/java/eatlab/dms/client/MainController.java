package eatlab.dms.client;

import de.jensd.fx.glyphs.fontawesome.FontAwesomeIcon;
import de.jensd.fx.glyphs.fontawesome.FontAwesomeIconView;
import eatlab.dms.api.ApiProperties;
import eatlab.dms.api.service.QueryService;
import eatlab.dms.api.service.SyncService;
import eatlab.dms.api.service.UserService;
import eatlab.dms.common.domain.*;
import javafx.beans.property.ReadOnlyObjectWrapper;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.geometry.Side;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.scene.input.KeyCode;
import javafx.scene.input.KeyEvent;
import javafx.scene.layout.AnchorPane;
import javafx.stage.DirectoryChooser;
import javafx.stage.FileChooser;
import javafx.stage.Stage;
import org.apache.commons.logging.LogConfigurationException;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;


import java.awt.*;
import java.awt.MenuItem;
import java.io.File;
import java.net.URI;
import java.net.URL;
import java.nio.file.Paths;
import java.time.ZoneOffset;
import java.util.ArrayList;
import java.util.ResourceBundle;

@Controller
public class MainController implements Initializable {

    private Logger log= LoggerFactory.getLogger(this.getClass());

    @FXML
    private AnchorPane mainPane;

    @FXML
    private TableView<SessionDataWrapper> tableView;

    @FXML
    private TableColumn<SessionDataWrapper,SessionDataWrapper> btnOpen;

    @FXML
    private TextField txtSearch;

    @FXML
    private CheckBox cbSearchFileName;

    @FXML
    private FontAwesomeIconView test;

    @FXML
    private CheckBox cbSearchProduct;

    @FXML
    private CheckBox cbSearchCustomer;

    @FXML
    private DatePicker dateFrom;

    @FXML
    private DatePicker dateTo;

    @FXML
    private Button btnUser;

    @FXML
    private Button btnUpload;

    @FXML
    private ContextMenu contextMenuBtnUser;

    @FXML
    private ToggleButton btnLanguage;

    @Autowired
    private QueryService queryService;

    @Autowired
    private SyncService syncService;

    @Autowired
    private UserService userService;

    private ArrayList<CheckBox> checkboxList = new ArrayList<CheckBox>();

    @Override
    public void initialize(URL location, ResourceBundle resources) {

        //login();

        checkboxList.add(cbSearchCustomer);
        checkboxList.add(cbSearchProduct);
        checkboxList.add(cbSearchFileName);

        log.info("Fontawsome TypeSelector: "+test.getTypeSelector());

        btnOpen.setCellValueFactory(param -> new ReadOnlyObjectWrapper<>(param.getValue()));


        btnOpen.setCellFactory(param -> new TableCell<SessionDataWrapper, SessionDataWrapper>() {

            final Button openBtn = new Button("Open");


            @Override
            protected void updateItem(SessionDataWrapper sessionDataWrapper, boolean empty) {
                openBtn.setGraphic(new FontAwesomeIconView(FontAwesomeIcon.FOLDER_OPEN));
                super.updateItem(sessionDataWrapper, empty);

                if (sessionDataWrapper == null) {
                    setGraphic(null);
                    return;
                }

                //FontAwesomeIconView openButton
                setGraphic(openBtn);
                openBtn.setOnAction(event -> {
                    log.info("open" + sessionDataWrapper);
                    try {
                        String sambaShare=queryService.getSambaShare();
                        String filePath=sambaShare + sessionDataWrapper.getId();
                        /*File file =Paths.get(sambaShare, sessionDataWrapper.getId()).toUri();
                        if ( !file.exists()) {
                            CmsApplication.getApplication().ShowAlert("The file not exists on the server");
                        }*/
                        if (Desktop.isDesktopSupported())
                            Desktop.getDesktop().open(new File(filePath));
                        else {
                            OpenFile(filePath);
                        }
                    } catch (Exception ex) {
                        log.error("Could not open SessionData on Samba",ex);
                        CmsApplication.getApplication().ShowAlert("Open Files failed",ex);
                    }
                });
            }
        });

        //loadData();
    }

    static private UserData currentUser;
    static public UserData GetCurrentUser() {
        return currentUser;
    }

    public void SetCurrentUser(UserData user) {
        currentUser=user;
        if (currentUser==null) {
            btnUser.setText("No User - login");
            btnUpload.setDisable(true);
            return;
        }
        btnUpload.setDisable(!user.HasPermission(UserData.Permissions.ROLE_NODE));
        btnUser.setText(user.getFullName());
        contextMenuBtnUser.getItems().stream().filter(x->x.getText().contains("anage")).forEach(x->x.setDisable(!user.HasPermission(UserData.Permissions.ROLE_ADMIN)));
    }

    public void login() {
        try {
            logout();

            CmsApplication.StageResult<LoginController> stageResult = CmsApplication.getApplication().CreateStageResult(mainPane.getScene().getWindow(), "/login.fxml");

            stageResult.stage.showAndWait();
            if (stageResult.getController().getUserData()!=null)
                SetCurrentUser(stageResult.getController().getUserData());

            loadData();

        } catch (Exception ex) {
            log.error("Could not log in",ex);
        }
    }

    private void logout() {
        ApiProperties.jwtToken=null;
        tableView.getItems().clear();
        SetCurrentUser(null);
    }

    @FXML
    protected void handleCheckBox(ActionEvent event) {
        if (event.getSource() instanceof CheckBox) {
            CheckBox source = (CheckBox) event.getSource();
            if (!checkboxList.stream().anyMatch(x -> x.isSelected())) {
                source.setSelected(true);
                return;
            }
        }
        loadData();
    }

    private void OpenFile(String fileURL) throws Exception {
        if (isWindows())
            Runtime.getRuntime().exec("explorer.exe " + fileURL);
        else if (isMac())
            Runtime.getRuntime().exec("open " + fileURL);
            else
            throw new Exception("Open file only implemented for Windows and Mac so far... sorry!");
    }

    private static String OS = System.getProperty("os.name").toLowerCase();


    private static boolean isWindows() {
        return (OS.indexOf("win") >= 0);
    }

    private static boolean isMac() {
        return (OS.indexOf("mac") >= 0);
    }

    private static boolean isUnix() {
        return (OS.indexOf("nux") >= 0);
    }


    private void loadData() {
        try {
            log.debug("loading data...");
            tableView.getItems().clear();
            /*if (txtSearch.getText().isEmpty())
                tableView.getItems().addAll(queryService.QuerySessionsAll());
            else {*/
                QueryData.QueryDataBuilder queryData = QueryData.builder();
                if (!txtSearch.getText().isEmpty()) queryData.query(txtSearch.getText());
                if (cbSearchCustomer.isSelected()) queryData.searchCustomer(true);
                if (cbSearchFileName.isSelected()) queryData.searchFileName(true);
                if (cbSearchProduct.isSelected()) queryData.searchProduct(true);
                if (dateFrom.getValue()!=null) queryData.fromDate(dateFrom.getValue().atStartOfDay().toInstant(ZoneOffset.UTC).toEpochMilli());
                if (dateTo.getValue()!=null) queryData.toDate(dateTo.getValue().atStartOfDay().toInstant(ZoneOffset.UTC).toEpochMilli());
                tableView.getItems().addAll(queryService.querySessionsAllRegex(queryData.build()));
            //}
        } catch (Exception ex) {
            log.error("Could not queryData",ex);
        }
    }

    @FXML protected void handleRefresh(ActionEvent event) {
        loadData();
    }

    @FXML protected void handleBtnUser(ActionEvent event) {
        contextMenuBtnUser.hide();
        if (GetCurrentUser()==null) {
            login();
            return;
        }
        if (!contextMenuBtnUser.isShowing()) contextMenuBtnUser.show(btnUser, Side.BOTTOM,0,0);
    }


    @FXML protected void handleKeyDown(KeyEvent keyEvent) {
        if (keyEvent.getCode()== KeyCode.ENTER) {
            loadData();
        }
    }

    public void handleLogout(ActionEvent actionEvent) {
        logout();
    }

    public void handleManageUsers(ActionEvent actionEvent) throws Exception {
        if (currentUser==null) return;
        if (!currentUser.HasPermission(UserData.Permissions.ROLE_ADMIN)) {
            CmsApplication.getApplication().ShowAlert("Only for Admin!");
            return;
        }
        Stage dialog=CmsApplication.getApplication().CreateStage(mainPane.getScene().getWindow(),"/manageUsers.fxml");
        dialog.showAndWait();
    }

    public void handleChangePassword(ActionEvent actionEvent) {
        try {
            CmsApplication.StageResult<ChangePasswordController> stageResult = CmsApplication.getApplication().CreateStageResult(mainPane.getScene().getWindow(), "/changePassword.fxml");
            stageResult.controller.setUserData(currentUser);
            stageResult.stage.showAndWait();
        } catch (Exception ex) {
            CmsApplication.getApplication().ShowAlert("Could not change password!",ex);
        }
    }

    public void handleUpload(ActionEvent actionEvent) {
        DirectoryChooser fileChooser = new DirectoryChooser();
        fileChooser.setTitle("Upload Data to Server");
        File directory = fileChooser.showDialog(mainPane.getScene().getWindow());
        if (directory==null || !directory.exists()) return;
        try {
            SessionData sessionData=syncService.ProcessDirectory("client-" + currentUser.getId(), directory);
            String finishMessage=syncService.FinishSession(sessionData.getId());
            CmsApplication.getApplication().ShowAlert(Alert.AlertType.INFORMATION,finishMessage);
        } catch (Exception ex) {
            CmsApplication.getApplication().ShowAlert("Could not upload data",ex);
        }
        loadData();
    }

    public void handleLanguage(ActionEvent actionEvent) {
        btnLanguage.setText(btnLanguage.isSelected()?"ไทย":"English");
        SessionDataWrapper.LANG_IS_THAI=btnLanguage.isSelected();
        tableView.refresh();
    }
}

