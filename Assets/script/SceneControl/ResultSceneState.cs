using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSceneState : ISceneState
{
    private Button ReturnBtn;
    public ResultSceneState(SceneController sceneController) : base(sceneController)
    {
        this.SceneName = "Result";
    }

    public override void SceneBegin()
    {
        ReturnBtn = GameObject.Find("ReturnBtn")?.GetComponent<Button>();
        if(ReturnBtn) ReturnBtn.onClick.AddListener(OnReturnBtnClick);
    }

    public override void SceneUpdate()
    {
        sceneController.PlayAudio(sceneController.audioObjects.audioList[7]);
    }

    public void OnReturnBtnClick()
    {
        sceneController.SetScene(SceneType.Menu);
    }
}
