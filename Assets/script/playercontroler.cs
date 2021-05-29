using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroler : MonoBehaviour {
	public float speed;
	public float rotationalspeed;
	public GameObject meshs;
	public float backspeed;
	private Rigidbody rb;
	private float cooldown=0;
	public Color colo;
	//private int[][] triangles;
	private MeshFilter[] meshF;
	//private MeshRenderer[] meh;
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		meshF=meshs.GetComponentsInChildren<MeshFilter>();
		//meh=meshs.GetComponentsInChildren<MeshRenderer>();
		//triangles= new int[meshF.Length][];
		for(int i=0;i<meshF.Length;i++){
			//triangles[i]= meshF[i].mesh.triangles;
			Color[] mecol= new Color[meshF[i].mesh.vertices.Length];
			for(int j=0;j<meshF[i].mesh.vertices.Length;j++){
				mecol[j]= new Color(0,0,0,1);
			}
			meshF[i].mesh.colors=mecol;
		}
	}
	void FixedUpdate (){
		float movex = Input.GetAxis("Horizontal");
		float movez = Input.GetAxis("Vertical");
		Vector3 movement;
		RaycastHit hit;
		/*if(cooldown==0){
			transform.rotation=Quaternion.Lerp(transform.rotation,Quaternion.Euler(-rb.velocity.y*30,transform.eulerAngles.y,0f),0.8f*Time.deltaTime);
		}*/
		if(Physics.SphereCast(transform.position, 0.01f, new Vector3(0f,-1f,0f), out hit, 0.6f)) {
			if(hit.triangleIndex>=0){
				Vector3 leerp=new Vector3(Quaternion.LookRotation(Vector3.Cross(transform.right, hit.normal)).eulerAngles.x,Quaternion.LookRotation(Vector3.Cross(transform.right, hit.normal)).eulerAngles.y,0f);
				transform.rotation=Quaternion.Lerp(transform.rotation,Quaternion.Euler(leerp),backspeed*4*Time.deltaTime);
				MeshFilter meshh = hit.transform.GetComponent<MeshFilter>();
				//var vert1 = triangles[hit.triangleIndex * 3 + 0];
				//var vert2 = triangles[hit.triangleIndex * 3 + 1];
				//var vert3 = triangles[hit.triangleIndex * 3 + 2];
				Color[] mecol= meshh.mesh.colors;
				mecol[meshh.mesh.triangles[hit.triangleIndex * 3 + 0]] = colo;
				mecol[meshh.mesh.triangles[hit.triangleIndex * 3 + 1]] = colo;
				mecol[meshh.mesh.triangles[hit.triangleIndex * 3 + 2]] = colo;
				meshh.mesh.colors=mecol;
			}
		}
		else/* if(cooldown>0||rb.velocity.y<0)*/{
			if(transform.rotation.x<0){
				transform.rotation=Quaternion.Lerp(transform.rotation,Quaternion.Euler(10f,transform.eulerAngles.y,0f),backspeed*Time.deltaTime);
			}else{
				transform.rotation=Quaternion.Lerp(transform.rotation,Quaternion.Euler(Mathf.Clamp(-rb.velocity.y*100,-1,1)*30,transform.eulerAngles.y,0f),backspeed*Time.deltaTime);
			}
			//transform.eulerAngles=new Vector3(-rb.velocity.y,transform.eulerAngles.y,0f);
		}
		transform.Rotate(new Vector3(0f,movex*rotationalspeed,0f));
		if (Input.GetKeyDown("space")==true&&(cooldown<=0)){
			cooldown=1f;
			movement = new Vector3 (rb.transform.forward.x*100, rb.transform.forward.y*100+980f,rb.transform.forward.z*100);
		}
		else if(Input.GetKeyDown("left shift")==true){
			movement = new Vector3 (rb.transform.forward.x*1000, rb.transform.forward.y*1000-49f, rb.transform.forward.z*1000);
		}
		else{
			movement = new Vector3 (rb.transform.forward.x*100, rb.transform.forward.y*100-49f, rb.transform.forward.z*100);
		}
		if(cooldown>0){
			cooldown-=Time.deltaTime;
		}
		rb.AddForce (movement * speed*60*Time.deltaTime);
	}
}
