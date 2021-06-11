using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTextControl : MonoBehaviour
{
    [SerializeField]private Text winnerAmount;
    [SerializeField]private Text allAmount;
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
        int winner = p1 > p2 ? p1 : p2;
        winnerAmount.text = winner.ToString();
        allAmount.text = (p1+p2).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
