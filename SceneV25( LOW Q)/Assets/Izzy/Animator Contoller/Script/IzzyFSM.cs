using UnityEngine;
using System.Collections;

public enum IzzyStates
{
    Idle = 0,
    Openning,
    Level1,
    Level5,
    Yay,
    Welcome,
    GoAhead,
    End,
    CheckOthers,
    Shocked
}


public class IzzyFSM : MonoBehaviour {

    // IzzyStates
    public IzzyStates currentIzzyState;

    public static IzzyFSM instance;

    private Animator animator;
    public AudioSource audioSource;
    public AudioClip[] mAudioClips;
    private float startSpeakingTimer;
    private Vector3 IzzyIniPosition;

    // trigger
    public bool startCheckOther;
    public bool sayAgain;
    public bool startEnd;
    public bool startOpening;
	public bool startWelcome;
	public bool startLevel1;
    public bool startLevel5;
	public bool startGoAhead;
    private bool isTrigger = false;
    

    
    void Awake () {
        instance = this;
        IzzyIniPosition = transform.position;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        currentIzzyState = IzzyStates.Idle;
		startOpening = false;
		startWelcome = false;
        startEnd = false;
        startLevel1 = false;
        startLevel5 = false;
        sayAgain = true;
        startCheckOther = false;
        startSpeakingTimer = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("currentIzzyState: " + currentIzzyState);
        switch (currentIzzyState)
        {
            case IzzyStates.Idle:
                // do Idle
                // check
                // check yay
                if ((LevelManager.instance._success.text == "SUCCESS") && (LevelManager.instance._currentLevel < 10) && (LevelManager.instance._currentLevel >0))
                {
                    if (!isTrigger)
                    {
                        currentIzzyState = IzzyStates.Yay;
                        isTrigger = true;
                    }
                }
                else
                {
                    isTrigger = false;
                }
                // check openning
				if (startOpening)
                {
                    currentIzzyState = IzzyStates.Openning;
                }
                // check Level1
                if(startLevel1)
                {
                    currentIzzyState = IzzyStates.Level1;
                }
                //check welcome
                if(startWelcome)
                {
                    currentIzzyState = IzzyStates.Welcome;
                }
                //check Level5
                if (startLevel5)
                {
                    currentIzzyState = IzzyStates.Level5;
                }
                //check Gohead
                if (startGoAhead)
                {
                    currentIzzyState = IzzyStates.GoAhead;
                }
                //check CheckOther
                if(startCheckOther && sayAgain)
                {
                    currentIzzyState = IzzyStates.CheckOthers;
                    sayAgain = false;
                }
                //check End
                if(startEnd)
                {
                    currentIzzyState = IzzyStates.End;
                }
                break;
            case IzzyStates.Openning:
                startSpeakingTimer += Time.deltaTime;
                if (startSpeakingTimer > 1.0f)
                {
                    // do Openning
                    if (!isTrigger)
                    {
                        transform.position = IzzyIniPosition;
                        transform.forward =  new Vector3( (Head.instance.transform.position.x - transform.position.x),0, (Head.instance.transform.position.z - transform.position.z) ).normalized;
                        animator.SetTrigger("TalkStart");
                        audioSource.clip = mAudioClips[0];
                        audioSource.Play();
                        isTrigger = true;
                    }
                    // check
                    if (audioSource.isPlaying == false)
                    {
                        currentIzzyState = IzzyStates.Idle;
                        transform.position = IzzyIniPosition;
                        transform.forward =  new Vector3( (Head.instance.transform.position.x - transform.position.x),0, (Head.instance.transform.position.z - transform.position.z) ).normalized;
                        MoviePlayer.instance.movie.Stop();
                        UIManager._instance._startUI.SetActive(true);
                        UIManager._instance._video.SetActive(false);
                        UIManager._instance._tipOn = true;
                        Head.instance.cantChoose = false;
                        startOpening = false;
                        animator.SetTrigger("TalkEnd");
                        isTrigger = false;
                    }
                }

                break;
            case IzzyStates.Level1:
                // do Level1
				if (!isTrigger){
                    transform.position = IzzyIniPosition;
                    transform.forward =  new Vector3( (Head.instance.transform.position.x - transform.position.x),0, (Head.instance.transform.position.z - transform.position.z) ).normalized;
					animator.SetTrigger("Level1Start");
					audioSource.clip = mAudioClips[1];
					audioSource.Play();
					isTrigger = true;
				}
				if (audioSource.isPlaying == false)
				{
					currentIzzyState = IzzyStates.Idle;
                    transform.position = IzzyIniPosition;
                    transform.forward =  new Vector3( (Head.instance.transform.position.x - transform.position.x),0, (Head.instance.transform.position.z - transform.position.z) ).normalized;
					animator.SetTrigger("Level1End");
					isTrigger = false;
                    startLevel1 = false;
				}
                // check
                break;
            case IzzyStates.Level5:
                // do Level5
				if (!isTrigger){
                    transform.position = IzzyIniPosition;
                    transform.forward =  new Vector3( (Head.instance.transform.position.x - transform.position.x),0, (Head.instance.transform.position.z - transform.position.z) ).normalized;
					animator.SetTrigger("Level5Start");
					audioSource.clip = mAudioClips[2];
					audioSource.Play();
					isTrigger = true;
				}
				if (audioSource.isPlaying == false)
				{
					currentIzzyState = IzzyStates.Idle;
                    transform.position = IzzyIniPosition;
                    transform.forward =  new Vector3( (Head.instance.transform.position.x - transform.position.x),0, (Head.instance.transform.position.z - transform.position.z) ).normalized;
					animator.SetTrigger("Level5End");
					isTrigger = false;
                    startLevel5 = false;
				}
                // check
                break;
            case IzzyStates.Yay:
                // do Yay
                transform.position = IzzyIniPosition;
                transform.forward =  new Vector3( (Head.instance.transform.position.x - transform.position.x),0, (Head.instance.transform.position.z - transform.position.z) ).normalized;
                animator.SetTrigger("YayYay");
                audioSource.clip = mAudioClips[3];
                audioSource.Play();
                // check
                currentIzzyState = IzzyStates.Idle;
                break;
            case IzzyStates.GoAhead:
                // do Again
				if (!isTrigger){
                    transform.position = IzzyIniPosition;
                    transform.forward =  new Vector3( (Head.instance.transform.position.x - transform.position.x),0, (Head.instance.transform.position.z - transform.position.z) ).normalized;
					animator.SetTrigger("GoAheadStart");
					audioSource.clip = mAudioClips[4];
					audioSource.Play();
					isTrigger = true;
				}
				if (audioSource.isPlaying == false)
				{
					currentIzzyState = IzzyStates.Idle;
                    transform.position = IzzyIniPosition;
                    transform.forward =  new Vector3( (Head.instance.transform.position.x - transform.position.x),0, (Head.instance.transform.position.z - transform.position.z) ).normalized;
					animator.SetTrigger("GoAheadEnd");
					isTrigger = false;
                    startGoAhead = false;
				}
                // check
                break;
            case IzzyStates.Welcome:
                // do Hi
				if (!isTrigger){
                    transform.position = IzzyIniPosition;
                    transform.forward =  new Vector3( (Head.instance.transform.position.x - transform.position.x),0, (Head.instance.transform.position.z - transform.position.z) ).normalized;
					animator.SetTrigger("WelcomeStart");
					audioSource.clip = mAudioClips[5];
					audioSource.Play();
					isTrigger = true;
				}
				if (audioSource.isPlaying == false)
				{
					currentIzzyState = IzzyStates.Idle;
                    transform.position = IzzyIniPosition;
                    transform.forward =  new Vector3( (Head.instance.transform.position.x - transform.position.x),0, (Head.instance.transform.position.z - transform.position.z) ).normalized;
					animator.SetTrigger("WelcomeEnd");
					isTrigger = false;
                    startWelcome = false;
                }
                // check
                break;
            case IzzyStates.End:
                // do End
                if (!isTrigger)
                {
                    transform.position = IzzyIniPosition;
                    transform.forward = new Vector3((Head.instance.transform.position.x - transform.position.x), 0, (Head.instance.transform.position.z - transform.position.z)).normalized;
                    animator.SetTrigger("EndStart");
                    audioSource.clip = mAudioClips[6];
                    audioSource.Play();
                    isTrigger = true;
                }
                if (audioSource.isPlaying == false)
                {
                    currentIzzyState = IzzyStates.Idle;
                    transform.position = IzzyIniPosition;
                    transform.forward = new Vector3((Head.instance.transform.position.x - transform.position.x), 0, (Head.instance.transform.position.z - transform.position.z)).normalized;
                    animator.SetTrigger("EndEnd");
                    isTrigger = false;
                    startEnd = false;
                }
                // check
                break;
            case IzzyStates.CheckOthers:
                // do CheckOthers
                if (!isTrigger)
                {
                    transform.position = IzzyIniPosition;
                    transform.forward = new Vector3((Head.instance.transform.position.x - transform.position.x), 0, (Head.instance.transform.position.z - transform.position.z)).normalized;
                    animator.SetTrigger("CheckOthersStart");
                    audioSource.clip = mAudioClips[7];
                    audioSource.Play();
                    isTrigger = true;
                }
                if (audioSource.isPlaying == false)
                {
                    currentIzzyState = IzzyStates.Idle;
                    transform.position = IzzyIniPosition;
                    transform.forward = new Vector3((Head.instance.transform.position.x - transform.position.x), 0, (Head.instance.transform.position.z - transform.position.z)).normalized;
                    animator.SetTrigger("CheckOthersEnd");
                    isTrigger = false;
                }
                // check
                break;
            case IzzyStates.Shocked:
                // do Shocked
                if (!isTrigger) {
                    transform.position = IzzyIniPosition;
                    transform.forward = new Vector3((Head.instance.transform.position.x - transform.position.x), 0, (Head.instance.transform.position.z - transform.position.z)).normalized;
                    animator.SetTrigger("ShockedStart");
                    audioSource.clip = mAudioClips[8];
                    audioSource.Play();
                    isTrigger = true;
                }
                // check
                if (animator.GetCurrentAnimatorStateInfo(1).IsName("Shocked")) {
                    if (animator.GetCurrentAnimatorStateInfo(1).normalizedTime >= 0.99f) {
                        currentIzzyState = IzzyStates.Idle;
                        isTrigger = false;
                    }
                }
                break; 
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.name == "pingpongball(Clone)")
        {
            currentIzzyState = IzzyStates.Shocked;
        }
    }
}
