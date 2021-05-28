using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailcontroller : MonoBehaviour
{
    private TrailRenderer trail;
    // Start is called before the first frame update
    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            trail.startColor = Color.green;
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            trail.startColor = Color.cyan;
        }
    }

}
