using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultWinnerControl : MonoBehaviour
{
    [SerializeField]private Sprite p1_win;
    [SerializeField]private Sprite p2_win;
    private Image winImage;
    private int p1;
    private int p2;
    void Awake()
    {
        winImage = this.GetComponent<Image>();
        p1 = PlayerPrefs.GetInt("player1_territory", 1);
        p2 = PlayerPrefs.GetInt("player2_territory", 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(p1 > p2)
        {
            winImage.sprite = p1_win;
        }
        else if(p2 > p1)
        {
            winImage.sprite = p2_win;
        }
        else
        {
            winImage.sprite = null;
        }
    }

}
