using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneState : ISceneState
{
    public GameSceneState(SceneController sceneController) : base(sceneController)
    {
        this.SceneName = "Game";
    }

    public override void SceneBegin()
    {
        
    }

    public override void SceneUpdate()
    {
        
    }
}
