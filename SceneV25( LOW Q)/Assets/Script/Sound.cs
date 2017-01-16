using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour
{
    private AudioSource _sound;
    // Use this for initialization
    void Start()
    {
        _sound = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnCollisionEnter(Collision collision)
    {
        _sound.Play();
    }
}
