using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TutorialControl : MonoBehaviour
{
    public Image tutorial;
    public List<Button> tutorialDots;
    public Button leftArrow;
    public Button rightArrow;
    public TutorialImage tutorialImages;

    private Dictionary<Button, Sprite> tutorialDic;
    private GameObject activeBtnObject;

    // Start is called before the first frame update
    void Awake()
    {
        tutorialDic = new Dictionary<Button, Sprite>();
        for(int i = 0; i < tutorialDots.Count; i++)
        {
            tutorialDic.Add(tutorialDots[i], tutorialImages.Tutorial[i]);
        }

        for(int i = 0; i < tutorialDots.Count; i++)
        {
            tutorialDots[i].onClick.AddListener(SetTutorial);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTutorial()
    {
        activeBtnObject = EventSystem.current.currentSelectedGameObject;

        Button currentBtn = activeBtnObject.GetComponent<Button>();
        if(currentBtn == null || !tutorialDic.ContainsKey(currentBtn)) return;
        for(int i = 0; i < tutorialDots.Count; i++)
        {
            tutorialDots[i].GetComponent<Image>().color = new Color32(255,255,255,255);
        }
        currentBtn.GetComponent<Image>().color = new Color32(165,245,255,255);
        tutorial.sprite = tutorialDic[currentBtn];
    }
}
