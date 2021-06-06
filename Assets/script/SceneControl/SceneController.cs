using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Button startGameBtn;
    public Button toturialBtn;
    public Button staaffBtn;
    public Button exitGameBtn;

    private ISceneState currentSceneState = null;

    // private AsyncOperation operation;
    private bool isRunBegin = false;
    private void Awake() 
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
        currentSceneState = new MenuSceneState(this);      
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(!operation.isDone) return;

        if(currentSceneState != null && isRunBegin == false)
        {
            currentSceneState.SceneBegin();
            isRunBegin = true;
        }

        currentSceneState?.SceneUpdate();
    }

    public void SetScene(ISceneState State)
    {
        isRunBegin = false;
        Debug.Log(State.SceneName);
        LoadScene(State.SceneName);
        if(currentSceneState != null) currentSceneState.SceneEnd();
        currentSceneState = State;
    }

    private void LoadScene(string SceneName)
    {
        if(SceneName == null || SceneName.Length == 0) return;
        SceneManager.LoadScene(SceneName);
    }
}
