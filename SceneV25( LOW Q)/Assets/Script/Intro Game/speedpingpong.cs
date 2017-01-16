using UnityEngine;
using System.Collections;

public class speedpingpong : MonoBehaviour {
    AudioSource _AS;

    // Use this for initialization
    void Start () {
        _AS = this.GetComponent<AudioSource>();
        _AS.pitch = 1.3f;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
