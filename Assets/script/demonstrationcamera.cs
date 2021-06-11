using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demonstrationcamera : MonoBehaviour
{
    public Transform spotlight;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        transform.position=spotlight.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotate=transform.eulerAngles;
        transform.eulerAngles=new Vector3(rotate.x,rotate.y+rotateSpeed,rotate.z);
    }
}
