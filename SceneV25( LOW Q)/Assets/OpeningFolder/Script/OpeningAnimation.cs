using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpeningAnimation : MonoBehaviour
{
    public static OpeningAnimation _instance;


    public GameObject _firstRun;
    public GameObject _secondRun;
    public GameObject _thirdRun;
    public GameObject _fifthRun;
    public GameObject _ledShow;
    public GameObject _ballFake;
    public GameObject _ball;
    public GameObject _level;
    public bool _done;
    public Image _logo;

    private Animator ar1;
    private Animator ar2;
    private Animator ar3;
    private Animator ar5;
    private Animator arLED;
    private Animator arFade;

    private float _timer;
    private float _ledTimer;
    private float _colorTimer;
    private float _cameraFadeTimer;
    private float _colorChange = 0.065f;
    private bool _cameraFade;
    private bool _camerFadeIn;
    private bool _camerFadeOut;
    private bool _led;
    private int _materialIndex;
    private string _rainbowColor;
    public  AudioSource LOGOSound;
    void Awake()
    {
        _instance = this;
    }

    // Use this for initialization
    void Start()
    {
        ar1 = _firstRun.GetComponent<Animator>();
        ar2 = _secondRun.GetComponent<Animator>();
        ar3 = _thirdRun.GetComponent<Animator>();
        ar5 = _fifthRun.GetComponent<Animator>();
        arLED = _ledShow.GetComponent<Animator>();
        arFade = _level.GetComponent<Animator>();
        _timer = 0.0f;
        _ledTimer = 0.0f;
        _colorTimer = 0.0f;
        _cameraFadeTimer = 0.0f;
        _led = true;
        _done = false;
        _cameraFade = true;
        _camerFadeIn = true;
        _camerFadeOut = false;
        _materialIndex = 0;
        _rainbowColor = "red";
    }

    // Update is called once per frame
    void Update()
    {
        




        AnimatorStateInfo stateInfo1 = ar1.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo stateInfo2 = ar2.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo stateInfo3 = ar3.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo stateInfo5 = ar5.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo stateInfoLED = arLED.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo stateInfoFade = arFade.GetCurrentAnimatorStateInfo(0);
        /***********************************************************************///攝影機淡入
        if (_camerFadeIn)
        {
            CameraFade.FadeIn();
            _camerFadeIn = false;
        }
        if (_cameraFade)
        {
            _cameraFadeTimer += Time.deltaTime;
            if (_cameraFadeTimer > 5.0f)
            {
                _cameraFade = false;
            }
        }
        /***********************************************************************///攝影機淡入


        else if (!_cameraFade)
        {
            if (_led)
            {
                _ledTimer += Time.deltaTime;
                if (stateInfoLED.IsName("TempState"))
                {
                    arLED.SetBool("lightoff", true);
                }
                if(_ledTimer > 2.0f)
                {
                    if (stateInfoLED.IsName("LEDShow"))
                    {
                        arLED.SetTrigger("snake");
                    }
                }
                if (_ledTimer > 6.0f)
                {
                    _led = false;
                }
            }
            else if (!_led)
            {
                _timer += Time.deltaTime;
                if ((stateInfo1.IsName("TempState")) && (_timer >= 0.0f))
                {
                    ar1.SetBool("firstrun", true);
                }
                else if ((stateInfo2.IsName("TempState")) && (_timer >= 1f))
                {
                    ar2.SetBool("secondrun", true);
                }
                else if ((stateInfo3.IsName("TempState")) && (_timer >= 2f))
                {
                    ar3.SetBool("thirdrun", true);
                }
                else if ((stateInfo5.IsName("TempState")) && (_timer >= 3f))
                {
                    ar5.SetBool("fifthrun", true);
                }

                if (_timer > 5.0f)
                {
                    _ballFake.SetActive(true);
                    if ((stateInfoFade.IsName("TempState")))
                    {
                        arFade.SetBool("fade", true);
                    }
                }

                if (_timer > 7.0f)
                {
                    _ballFake.SetActive(false);
                    _ball.SetActive(true);
                    _done = true;
                }

                if (_timer > 11.0f && _timer < 12.0f)
                {
                    LOGOSound.enabled = true;
                    _logo.fillAmount += Time.deltaTime*2.0f;
                    if(_logo.fillAmount == 1.0f)
                    {
                        _logo.fillAmount = 1.0f;
                    }
                }

                if (_camerFadeOut)
                {
                    CameraFade.FadeOut();
                    _camerFadeOut = false;
                }
                if (_timer < 13.0f && _timer >= 12.0f)
                {
                    _camerFadeOut = true;
                }

               

                if (_timer > 15.0f)
                {
                    Application.LoadLevel("CalibrationScene_Landscape");
                }
            }
        }
    }
}
