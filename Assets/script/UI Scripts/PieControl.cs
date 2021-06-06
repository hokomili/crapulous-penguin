using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PieControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject penguin1;
    public GameObject penguin2;
    public GameObject penguin1pie;
    public GameObject penguin2pie;
    void Start()
    {
        penguin1pie.GetComponent<Image>().fillAmount=0.5f;
        penguin2pie.GetComponent<Image>().fillAmount=0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        int p1=penguin1.GetComponent<playercontroler>().territory;
        int p2=penguin2.GetComponent<playercontroler>().territory;
        penguin1pie.GetComponent<Image>().fillAmount=(float)p1/(p1+p2);
        penguin2pie.GetComponent<Image>().fillAmount=(float)p2/(p1+p2);
    }
}
