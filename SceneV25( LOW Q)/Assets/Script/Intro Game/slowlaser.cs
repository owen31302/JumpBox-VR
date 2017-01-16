using UnityEngine;
using System.Collections;

public class slowlaser : MonoBehaviour {
    AudioSource _AS;
    float _timer = 0.0f;
    // Use this for initialization
    void Start () {
         _AS = this.GetComponent<AudioSource>();
        _AS.pitch = 0.6f;
    }
	
	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime;
        if (_timer > 0.0f && _timer < 1.0f)
        {
            fadein();
        }
        else if (_timer > 1.0f)
        {
            fadeout();
        }
    }
    void fadein()
    {
        _AS.volume += 0.05f;
    }
    void fadeout()
    {
        _AS.volume -= 0.003f;

    }
}
