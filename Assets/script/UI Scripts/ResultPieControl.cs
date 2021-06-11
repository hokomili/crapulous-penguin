using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPieControl : MonoBehaviour
{
    private int p1;
    private int p2;

    [SerializeField]private Image p1Pie;
    [SerializeField]private Image p2Pie;
    
    void Awake()
    {
        p1 = PlayerPrefs.GetInt("player1_territory", 1);
        p2 = PlayerPrefs.GetInt("player2_territory", 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        p1Pie.fillAmount = (float)p1 / (p1 + p2);
        p2Pie.fillAmount = (float)p2 / (p1 + p2);
    }

}
