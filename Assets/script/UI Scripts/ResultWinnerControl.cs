using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultWinnerControl : MonoBehaviour
{
    [SerializeField]private Text winner;
    private int p1;
    private int p2;
    void Awake()
    {
        p1 = PlayerPrefs.GetInt("player1_territory", 1);
        p2 = PlayerPrefs.GetInt("player2_territory", 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(p1 > p2)
        {
            winner.text = "玩家1";
        }
        else if(p2 > p1)
        {
            winner.text = "玩家2";
        }
        else
        {
            winner.text = "平手";
        }
    }

}
