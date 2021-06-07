using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum SceneType
{
    Menu,
    Game,
    Result,
    Toturial,
    Staff,

}

public class SceneController : MonoBehaviour
{
    static SceneController instance;

    public Button startGameBtn;
    public Button toturialBtn;
    public Button staaffBtn;
    public Button exitGameBtn;

    private ISceneState currentSceneState = null;
    private AsyncOperation asyncLoad;
    private bool isRunBegin = false;

    private Dictionary<SceneType, ISceneState> sceneDic;

    private void Awake() 
    {
        if(instance == null)
        {    
            instance = this; 
            DontDestroyOnLoad(this.gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        
        // GameObject.DontDestroyOnLoad(this.gameObject);
       
        sceneDic = new Dictionary<SceneType, ISceneState>
        {
            {SceneType.Menu, new MenuSceneState(this)},
            {SceneType.Game, new GameSceneState(this)},
        };
        currentSceneState = new MenuSceneState(this); 
        // SetScene(SceneType.Menu);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(asyncLoad != null && !asyncLoad.isDone)
        {
            Debug.Log("loading...");
            return;
        } 

        if(currentSceneState != null && isRunBegin == false)
        {
            currentSceneState.SceneBegin();
            isRunBegin = true;
        }

        currentSceneState?.SceneUpdate();
    }

    public void SetScene(SceneType sceneType)
    {
        isRunBegin = false;
        Debug.Log(sceneDic[sceneType].SceneName);
        LoadScene(sceneDic[sceneType].SceneName);
        SceneManager.UnloadSceneAsync(currentSceneState.SceneName);
        if(currentSceneState != null) currentSceneState.SceneEnd();
        currentSceneState = sceneDic[sceneType];
    }

    private void LoadScene(string SceneName)
    {
        if(SceneName == null || SceneName.Length == 0) return;
        asyncLoad = SceneManager.LoadSceneAsync(SceneName);
        // SceneManager.LoadScene(SceneName);
    }
}
