using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSceneState : ISceneState
{

    public TutorialSceneState(SceneController sceneController) : base(sceneController)
    {
        this.SceneName = "Tutorial";
    }


}
