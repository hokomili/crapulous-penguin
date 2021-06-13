using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaffSceneState : ISceneState
{
    private Button ReturnBtn;

    public StaffSceneState(SceneController sceneController) : base(sceneController)
    {
        this.SceneName = "Staff";
    }

    public override void SceneBegin()
    {
        ReturnBtn = GameObject.Find("ReturnBtn").GetComponent<Button>();
        if(ReturnBtn) ReturnBtn.onClick.AddListener(OnReturnBtnClick);
    }

    public override void SceneUpdate()
    {
        sceneController.PlayAudio(sceneController.audioObjects.audioList[9]);
    }

    public void OnReturnBtnClick()
    {
        sceneController.SetScene(SceneType.Menu);
    }
}
