using UnityEngine;
using System.Collections;

public class BGMManager : MonoBehaviour {
    public AudioSource BGMMuisic;
    public AudioClip[] MuisicList;
    // Use this for initialization
    void Start () {

        if (this.GetComponent<AudioSource>() == null)
        {
            BGMMuisic = this.gameObject.AddComponent<AudioSource>();
        }
        else
        {
            BGMMuisic = this.gameObject.GetComponent<AudioSource>();
            BGMMuisic.clip = Resources.Load("In Game/jumpmusic") as AudioClip;
            BGMMuisic.Play();
            BGMMuisic.loop = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (IzzyFSM.instance.audioSource.isPlaying)
        {

                fadeOut();

        }
        else
        {
            
            fadeIn();
        }
    }
    void fadeIn()
    {
        if (BGMMuisic.volume < 0.5f)
        {
            BGMMuisic.volume += 0.1f * Time.deltaTime;
        }
    }

    void fadeOut()
    {
        BGMMuisic.volume -= 0.1f * Time.deltaTime;
    }
}
