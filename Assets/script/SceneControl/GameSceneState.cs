using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneState : ISceneState
{
    private Animator countDownAni;
    public GameSceneState(SceneController sceneController) : base(sceneController)
    {
        this.SceneName = "Game";
    }

    public override void SceneBegin()
    {
        countDownAni = GameObject.Find("CountDownImage")?.GetComponent<Animator>();
        if(countDownAni != null) Time.timeScale = 0;
    }

    public override void SceneUpdate()
    {
        if(countDownAni != null)
        {
            countDownAni.Play("AStartCountdown");
            if(countDownAni.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !countDownAni.IsInTransition(0))
            {
                countDownAni.enabled = false;
                Time.timeScale = 1;
            }
        }
        // if(Input.GetKeyDown(KeyCode.R)) sceneController.SetScene(SceneType.Menu);
    }
}
