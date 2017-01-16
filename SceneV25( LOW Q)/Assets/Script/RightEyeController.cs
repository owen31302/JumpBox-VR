using UnityEngine;
using System.Collections;

public class RightEyeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("i"))
        {
            Debug.Log("QQQ");
            this.transform.Rotate(-2.0f, 0.0f, 0.0f, Space.Self);
        }
        if (Input.GetKey("l"))
        {
            Debug.Log("QQQ");
            this.transform.Rotate(0.0f, 2.0f, 0.0f, Space.World);
        }
        if (Input.GetKey("k"))
        {
            Debug.Log("QQQ");
            this.transform.Rotate(2.0f, 0.0f, 0.0f, Space.Self);
        }
        if (Input.GetKey("j"))
        {
            Debug.Log("QQQ");
            this.transform.Rotate(0.0f, -2.0f, 0.0f, Space.World);
        }
    }
}
