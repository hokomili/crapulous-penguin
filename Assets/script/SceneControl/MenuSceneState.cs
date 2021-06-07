using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSceneState : ISceneState
{
    public MenuSceneState(SceneController sceneController) : base(sceneController)
    {
        this.SceneName = "Menu";
        sceneController.startGameBtn = GameObject.Find("StartGameBtn")?.GetComponent<Button>();
        sceneController.toturialBtn = GameObject.Find("ToturialBtn")?.GetComponent<Button>();
        sceneController.staaffBtn = GameObject.Find("StaffBtn")?.GetComponent<Button>();
        sceneController.exitGameBtn = GameObject.Find("ExitGameBtn")?.GetComponent<Button>();
    }

    public override void SceneBegin()
    {
        sceneController.startGameBtn?.onClick.AddListener( ()=>OnStartGameClicked() );
        sceneController.toturialBtn?.onClick.AddListener( ()=>OnToturialClicked() );
        sceneController.staaffBtn?.onClick.AddListener( ()=>OnStaffClicked() );
        sceneController.exitGameBtn?.onClick.AddListener( ()=>OnExitGameClicked() );
    }

    public void OnStartGameClicked()
    {
        Debug.Log("go to game");
        sceneController.SetScene(SceneType.Game,SceneType.Menu);
    }

    public void OnToturialClicked()
    {
        //go to toturial scene
    }

    public void OnStaffClicked()
    {
        //go to staff scene
    }

    public void OnExitGameClicked()
    {
        Application.Quit();
    }
}
