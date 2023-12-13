package eatlab.dms.client;

import de.jensd.fx.glyphs.fontawesome.FontAwesomeIconView;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.image.Image;
import javafx.stage.Stage;
import javafx.stage.Window;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.data.mongo.MongoDataAutoConfiguration;
import org.springframework.boot.autoconfigure.mongo.MongoAutoConfiguration;
import org.springframework.boot.builder.SpringApplicationBuilder;
import org.springframework.boot.context.properties.EnableConfigurationProperties;
import org.springframework.context.ConfigurableApplicationContext;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.FilterType;
import org.springframework.scheduling.annotation.EnableScheduling;

import javax.swing.*;
import javax.xml.crypto.Data;
import java.io.IOException;
import java.net.URL;
import java.security.PublicKey;

@SpringBootApplication(exclude = {MongoAutoConfiguration.class, MongoDataAutoConfiguration.class})
@ComponentScan(value="eatlab.dms" /*, excludeFilters={
        @ComponentScan.Filter(type= FilterType.ASSIGNABLE_TYPE, value= SyncWorker.class),@ComponentScan.Filter(type= FilterType.ASSIGNABLE_TYPE, value= WorkerApplication.class)}*/)
@EnableConfigurationProperties({ClientProperties.class})
public class CmsApplication extends Application {

    static private CmsApplication application;

    public static CmsApplication getApplication() {
        return application;
    }

    public ConfigurableApplicationContext getContext() {
        return context;
    }

    private ConfigurableApplicationContext context;
    private Parent rootNode;
    private MainController mainController;

    @Override
    public void init() throws Exception {
        application=this;
        SpringApplicationBuilder builder = new SpringApplicationBuilder(CmsApplication.class);
        context = builder.run(getParameters().getRaw().toArray(new String[0]));
        FXMLLoader loader =GetFxmlLoader("/main.fxml");
        rootNode = loader.load();
        mainController=loader.getController();
    }

    private FXMLLoader GetFxmlLoader(String path) throws IOException {
        FXMLLoader loader = new FXMLLoader(getClass().getResource(path));
        loader.setControllerFactory(context::getBean);
        return loader;
    }

    public <T> StageResult<T> CreateStageResult(Window window, String fxmlPath) throws Exception {
        FXMLLoader loader=GetFxmlLoader(fxmlPath);
        Parent node = loader.load();
        Stage stage = new Stage();
        stage.initOwner(window);
        Scene scene=setCss(new Scene(node));
        stage.setScene(scene);

        stage.getIcons().add(new Image(getClass().getResourceAsStream("/icon.png")));

        return new StageResult<>(stage,loader.getController());
    }

    public Stage CreateStage(Window window, String fxmlPath) throws Exception {
       return CreateStageResult(window,fxmlPath).getStage();
    }

    private Scene setCss(Scene scene) {
        ClientProperties clientProperties=context.getBean(ClientProperties.class);
        if (clientProperties==null || clientProperties.getCssStyle()==null || clientProperties.getCssStyle().isEmpty()) return scene;
        scene.getStylesheets().add(getClass().getResource("/"+clientProperties.getCssStyle()+".css").toExternalForm());
        return scene;
    }

    @Override
    public void start(Stage primaryStage) throws Exception {
        new FontAwesomeIconView(); //Important to load Font!!! (even it looks useless...)
        primaryStage.getIcons().add(new Image(getClass().getResourceAsStream("/icon.png")));
        primaryStage.setScene(setCss(new Scene(rootNode)));
        primaryStage.show();
        mainController.login();
    }

    public static void main(String[] args) {
        launch(args);
    }

    @lombok.Data
    public class StageResult<T>{

        public StageResult (Stage stage, T controller) {
            this.stage = stage;
            this.controller = controller;
        }

        Stage stage;
        T controller;
    }

    public void ShowAlert(String message, Exception ex) {
        ShowAlert(Alert.AlertType.ERROR,message,ex);
    }

    public void ShowAlert(Alert.AlertType alertType, String message, Exception ex) {
        Alert alert=new Alert(alertType);
        alert.setTitle("Error");
        alert.setHeaderText(message);
        if (ex!=null)
            alert.setContentText(ex.getMessage());
        alert.showAndWait();
    }

    public void ShowAlert(String message) {
        ShowAlert(Alert.AlertType.ERROR,message);
    }

    public void ShowAlert(Alert.AlertType alertType, String message) {
        ShowAlert(alertType,message,null);
    }

    public class Tuple<X, Y> {
        public final X x;
        public final Y y;
        public Tuple(X x, Y y) {
            this.x = x;
            this.y = y;
        }
    }
}
