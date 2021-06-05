using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    public playercontroler playercon;
    public GameObject pb;
    public bool alive;
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive)
        {
            playercon.Playsound(0);
            Instantiate(pb, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Penguin")
        {
            playercon=other.GetComponent<playercontroler>();
            alive = false;
        }else if (other.gameObject.tag=="Snake")
        {
            playercon=other.GetComponent<playercontroler>();
            alive = false;
        }
    }
}
