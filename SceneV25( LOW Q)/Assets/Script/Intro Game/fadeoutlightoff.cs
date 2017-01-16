using UnityEngine;
using System.Collections;

public class fadeoutlightoff : MonoBehaviour {
    AudioSource _AS;
    float _timer = 0.0f;
    // Use this for initialization
    void Start () {
        _AS = this.GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {

        _timer += Time.deltaTime;
        if (_timer > 0.0f)
        {
            fadeout();
        }
    }
    void fadeout()
    {
        _AS.volume -= 0.008f;
    }
}
