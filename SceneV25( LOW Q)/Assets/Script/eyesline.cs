using UnityEngine;
using System.Collections;

public class eyesline : MonoBehaviour {

    public Camera Rcamera;
    public Camera Lcamera;
    public float dis;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Rcamera.transform.position = new Vector3(this.transform.position.x + dis, this.transform.position.y, this.transform.position.z);
        Lcamera.transform.position = new Vector3(this.transform.position.x - dis, this.transform.position.y, this.transform.position.z);

    }
}
