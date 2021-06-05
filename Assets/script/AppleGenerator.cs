using UnityEngine;
using System.Collections.Generic;
public class AppleGenerator : MonoBehaviour {
	public GameObject[] GeneratableMeshs;
    public Vector2 gentime;
    public float offsetheight;
    public GameObject[] apples;
	private List<MeshFilter> meshF=new List<MeshFilter>();
    private List<Vector3> vertexs=new List<Vector3>();
    private float cooldown;
	//private MeshRenderer[] meh;
	void Start ()
	{
        
        for(int i=0;i<GeneratableMeshs.Length;i++){
            meshF.AddRange(GeneratableMeshs[i].GetComponentsInChildren<MeshFilter>());
        }
        for(int i=0;i<meshF.Count;i++){
            for(int j=0;j<meshF[i].mesh.vertices.Length;j++){
                vertexs.Add(meshF[i].transform.TransformPoint(meshF[i].mesh.vertices[j]));
            }
        }
		cooldown=Random.Range(gentime[0],gentime[1]);
	}
    void Update(){
        cooldown-=Time.deltaTime;
        if(cooldown<=0){
            cooldown=Random.Range(gentime[0],gentime[1]);
            Vector3 posi=vertexs[Random.Range(0,vertexs.Count)];
            posi.y+=offsetheight;
            Instantiate(apples[Mathf.FloorToInt(Random.Range(0,2))],posi,default);
        }
    }
}