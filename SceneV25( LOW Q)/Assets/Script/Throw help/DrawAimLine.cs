using UnityEngine;
using System.Collections;

public class DrawAimLine : MonoBehaviour {
    public GameObject ThrowPosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        //Debug.Log("------------------------------");
        //Debug.Log("XDrawAimLine!!!!!!!!!!!!!!!!!:" + ThrowPosition.transform.position.x);
        //Debug.Log("YDrawAimLine!!!!!!!!!!!!!!!!!:" + ThrowPosition.transform.position.y);
        //Debug.Log("ZDrawAimLine!!!!!!!!!!!!!!!!!:" + ThrowPosition.transform.position.z);
        this.transform.forward = ThrowPosition.transform.forward;
        /*Debug.Log("-----------------------------------");
        Debug.Log("ThrowPosition.transform.forward.x" + ThrowPosition.transform.forward.x);
        Debug.Log("ThrowPosition.transform.forward.y" + ThrowPosition.transform.forward.y);
        Debug.Log("ThrowPosition.transform.forward.z" + ThrowPosition.transform.forward.z);*/
        this.transform.position = ThrowPosition.transform.position;
    }
	void OnDrawGizmos(){
		Gizmos.color = Color.green;
		Gizmos.DrawLine(this.transform.position,this.transform.position + this.transform.forward * 3.0f);
	}
}
