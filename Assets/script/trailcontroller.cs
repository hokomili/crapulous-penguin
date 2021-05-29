using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailcontroller : MonoBehaviour
{
    public TrailRenderer trail;
    public Mesh trailmesh;
    public Camera selfcamera;
    // Start is called before the first frame update
    void Start()
    {
        trailmesh=new Mesh();
        this.GetComponent<MeshCollider>().sharedMesh=trailmesh;
        this.GetComponent<MeshFilter>().mesh=trailmesh;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        trail.BakeMesh(trailmesh);
    }
}
