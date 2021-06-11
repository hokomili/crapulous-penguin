using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataControl : MonoBehaviour
{
    public playercontroler player1;
    public playercontroler player2;

    void OnDisable()
    {
        TimeControl.BeforeGameTimeOver -= SavaFinalData;
    }

    void Start()
    {
        TimeControl.BeforeGameTimeOver += SavaFinalData;
    }

    public void SavaFinalData()
    {
        PlayerPrefs.SetInt("player1_territory", player1.territory);
        PlayerPrefs.SetInt("player2_territory", player2.territory);
    }
}
