using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSceneState : ISceneState
{
    public MenuSceneState(SceneController sceneController) : base(sceneController)
    {
        this.SceneName = "Menu";
        sceneController.startGameBtn.onClick.AddListener( ()=>OnStartGameClicked() );
        sceneController.toturialBtn.onClick.AddListener( ()=>OnToturialClicked() );
        sceneController.staaffBtn.onClick.AddListener( ()=>OnStaffClicked() );
        sceneController.exitGameBtn.onClick.AddListener( ()=>OnExitGameClicked() );
    }

    public override void SceneBegin()
    {
        
    }

    public void OnStartGameClicked()
    {
        Debug.Log("go to game");
        sceneController.SetScene(new GameSceneState(sceneController));
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
