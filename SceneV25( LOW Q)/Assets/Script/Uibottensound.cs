using UnityEngine;
using System.Collections;

public class Uibottensound : MonoBehaviour {
    public static Uibottensound _instance;
    public AudioSource _As;
    public float vlofix = 0.1f;
    //八種動物聲音 0-7 +  哨子音 8 + 一個按鈕音效 9  + 3 2 1 音效 10 + 腳色選擇音效 11 + highlight 12 
    public AudioClip[] _AcSounds = new AudioClip[13];
	// Use this for initialization
    void Awake()
    {
        _instance = this;


        if (_As == null)
        {
            this.gameObject.AddComponent<AudioSource>();
            _As = this.GetComponent<AudioSource>();

        }
        _AcSounds[0] = Resources.Load("In Game/bear") as AudioClip;
        _AcSounds[1] = Resources.Load("In Game/cat") as AudioClip;
        _AcSounds[2] = Resources.Load("In Game/elephant") as AudioClip;
        _AcSounds[3] = Resources.Load("In Game/panda") as AudioClip;
        _AcSounds[4] = Resources.Load("In Game/pig") as AudioClip;
        _AcSounds[5] = Resources.Load("In Game/monkey") as AudioClip;
        _AcSounds[6] = Resources.Load("In Game/tiger") as AudioClip;
        _AcSounds[7] = Resources.Load("In Game/whale") as AudioClip;
        _AcSounds[8] = Resources.Load("In Game/bee") as AudioClip;
        _AcSounds[9] = Resources.Load("In Game/botten") as AudioClip;
        _AcSounds[10] = Resources.Load("In Game/32") as AudioClip;
        _AcSounds[11] = Resources.Load("In Game/1") as AudioClip;
        _AcSounds[12] = Resources.Load("In Game/botten highlight") as AudioClip;
        _AcSounds[13] = Resources.Load("In Game/clickrankcharacter") as AudioClip;


        _As.playOnAwake = true;
        _As.volume = vlofix;

    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}
    public IEnumerator hightsound()
    {
        StopAllCoroutines();
        _As.PlayOneShot(_AcSounds[12] , vlofix);
        yield return null;
    }

}
