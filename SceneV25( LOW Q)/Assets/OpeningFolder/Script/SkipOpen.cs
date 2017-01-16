using UnityEngine;
using System.Collections;

public class SkipOpen : MonoBehaviour {
    RaycastHit hitInfo;
    private float _skipTimer;
    // Use this for initialization
    void Start () {
        _skipTimer = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, 10.0f, 1 << 18))
        {
            _skipTimer += Time.deltaTime;
            if (_skipTimer > 1.0f)
            {
                Application.LoadLevel("CalibrationScene_Landscape");
            }
        }
    }
}
