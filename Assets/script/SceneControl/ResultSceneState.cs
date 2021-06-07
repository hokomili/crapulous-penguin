using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSceneState : ISceneState
{
    public ResultSceneState(SceneController sceneController) : base(sceneController)
    {
        this.SceneName = "Result";
    }
}
