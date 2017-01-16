using UnityEngine;
using System.Collections;

public class ScreenAnimate : MonoBehaviour
{
    public static ScreenAnimate _instance;
    public bool _down;
    public bool _stopTimer;
    public bool _cameraFade;
    public float _cameraFadeTimer;

    private float _ymove;
    private float _screenDropTimer;
    private float _readyTimer;

    void Awake()
    {
        _instance = this;
    }


    // Use this for initialization
    void Start()
    {
        _down = false;
        _stopTimer = false;
        _ymove = -0.1f;
        _readyTimer = 0.0f;
        _cameraFade = false;
        _cameraFadeTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        _cameraFadeTimer += Time.deltaTime;
        if (_cameraFade)
        {
            CameraFade.FadeIn();
            _cameraFade = false;
        }
 
        if (_cameraFadeTimer >= 0.0f && _cameraFadeTimer < 1.0f)
        {
            _cameraFade = true;
        }

        if(_cameraFadeTimer >= 8.0f)
        {
            if (_down == false && _stopTimer == false)
            {
                IzzyFSM.instance.startWelcome = true;
                _screenDropTimer += Time.deltaTime;
                this.transform.Translate(new Vector3(0.0f, _ymove * Time.deltaTime * 3.5f, 0.0f), Space.World);
            }
            if (_screenDropTimer > 4.7f)
            {
                UIManager._instance._tipOn = true;
                _stopTimer = true;
                _down = true;
                _screenDropTimer = 0.0f;
            }
        }
    }
}
