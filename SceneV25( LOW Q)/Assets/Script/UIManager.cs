using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager _instance;
    public Button _tryAgain;
    public GameObject _title;
    public GameObject _startUI;
    public GameObject _endUI;
    public GameObject _level;
    public GameObject _timeMessage;
    public GameObject _levelMessage;
    public GameObject _pausePicture;
    public GameObject _pauseButton;
    public GameObject playerData;
    public GameObject _tutorial;
    public GameObject _tip;
    public GameObject _video;
    public Text _difficultSwitch;
    public Text _choose;
    public Text _success;
    public Text _getReady;
    public Text _count1;
    public Text _count2;
    public Text _count3;
    public Image[] playersImg = new Image[8];
    public Image _temp;
    public bool _pause;
    public bool _gameStart;
    public bool _tipOn;
    public bool _twice;

    private bool _loginActive;
    private bool _screenDown;
    private bool _loginClick;
    private bool _exit;
    private float _exitTimer;
    private float _timer;
    private bool _startClick;
    private float _titleFadeTimer;


    void Awake()
    {
        _instance = this;
    }

    // Use this for initialization
    void Start()
    {
        _startClick = false;
        _title.SetActive(false);
        _video.SetActive(false);
        _tip.SetActive(true);
        _tutorial.SetActive(false);
        playerData.SetActive(false);
        _pauseButton.SetActive(false);
        _pausePicture.SetActive(false);
        _startUI.SetActive(false);
        _timeMessage.SetActive(false);
        _endUI.SetActive(false);
        _levelMessage.SetActive(false);
        _level.SetActive(false);
        _getReady.text = " ";
        _count1.text = "";
        _count2.text = "";
        _count3.text = "";
        _timer = 0.0f;
        _exitTimer = 0.0f;
        _loginClick = false;
        _gameStart = true;
        _screenDown = false;
        _loginActive = false;
        _pause = false;
        _tipOn = false;
        _twice = false;
        _exit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_exit)
        {
            _exitTimer += Time.deltaTime;
            if(_exitTimer > 6.0f)
            {
                Application.Quit();
            }
        }



        if (_startClick)
        {
            if (Head.instance.stateInfoFade.IsName("TitleFadeIn"))
            {
                Head.instance.fade.SetBool("titleout", true);
                Head.instance.fade.SetBool("titlein", false);
            }

            _titleFadeTimer += Time.deltaTime;
            if (_titleFadeTimer > 2.0f && _titleFadeTimer < 3.0f)
            {
                _title.SetActive(false);
                _tip.SetActive(true);
                _startUI.SetActive(true);
                Head.instance.fade.SetBool("aftertitle", true);
                for(int i = 0;  i < Head.instance.screencharacter.Length; i++)
                {
                    Head.instance.screencharacter[i].enabled = false;
                }
            }
            else if(_titleFadeTimer > 4.0f)
            {
                for (int i = 0; i < Head.instance.screencharacter.Length; i++)
                {
                    Head.instance.screencharacter[i].enabled = true;
                }
                _startClick = false;
            }
        }

        if (!_tipOn)
        {
            _tutorial.SetActive(false);
        }

        if(_twice || !_tipOn)
        {
            _tip.SetActive(false);
        }

        if (_gameStart)
        {
            if (_screenDown == false)
            {
                if (ScreenAnimate._instance._down)
                {
                    _title.SetActive(true);
                    if (Head.instance.stateInfoFade.IsName("TempState"))
                    {
                        Head.instance.fade.SetBool("titlein", true);
                    }
                    _loginActive = true;
                    _screenDown = true;
                    _gameStart = false;
                }
            }
        }

        if (_loginClick && _loginActive)
        {          //選好角色後
            _timer += Time.deltaTime;
            if (Head.instance.stateInfoFade.IsName("TempState"))
            {
                Head.instance.fade.SetBool("again", false);
            }
        }
        else if (_loginActive == false)
        {
            _timer = 0.0f;
        }

        if (LevelManager.instance._finish)
        {        //全部關卡結束
            _endUI.SetActive(true);
            DataBase._instance.SetLeaderBoradImage();
        }

        if (_timer < 2.0f && _timer > 0.0f)
        {
            _getReady.text = "Get Ready...";
            if (_timer > 1.9f)
            {
                _getReady.text = "";
                Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[10];
                Uibottensound._instance._As.Play();
            }
        }
        else if (_timer < 3.0f && _timer > 2.0f)
        {
            if (_count3.fontSize < 100)
            {
                _count3.fontSize += 2;
            }
            else if (_count3.fontSize == 100)
            {
                _count3.fontSize = 100;
            }
            _count3.text = "3";
            if (_timer > 2.9f)
            {
                _count3.text = "";
                Uibottensound._instance._As.Play();
            }
        }
        else if (_timer < 4.0f && _timer > 3.0f)
        {
            if (_count2.fontSize < 100)
            {
                _count2.fontSize += 2;
            }
            else if (_count2.fontSize == 100)
            {
                _count2.fontSize = 100;
            }
            _count2.text = "2";
            if (_timer > 3.9f)
            {
                _count2.text = "";
                Uibottensound._instance._As.Play();
            }
        }
        else if (_timer < 5.0f && _timer > 4.0f)
        {
            if (_count1.fontSize < 100)
            {
                _count1.fontSize += 2;
            }
            else if (_count1.fontSize == 100)
            {
                _count1.fontSize = 100;
            }
            _count1.text = "1";
            if (_timer > 4.9f)
            {
                _count1.text = "";
            }
        }
        else if (_timer < 6.0f && _timer > 5.0f)
        {
            if (Head.instance.oncebeesound)
            {
                Uibottensound._instance._As.PlayOneShot(Uibottensound._instance._AcSounds[8], 5.0f);
                Head.instance.oncebeesound = false;
            }
            _getReady.text = "GO ! ! !";
        }
        else if (_timer > 7.0f)
        {
            _pauseButton.SetActive(true);
            _loginActive = false;
            _timeMessage.SetActive(true);
            _getReady.text = " ";
            _level.SetActive(true);
            LevelManager.instance._currentLevel = 1;
            _loginClick = false;
            LevelManager.instance._mark.SetActive(true);
            LevelManager.instance._level1.SetActive(true);
            LevelManager.instance.changelevel = true;
            GameTimer._instance.counter = true;
            IzzyFSM.instance.startLevel1 = true;
        }
    }

    public void TutorialComfirmClick()
    {
        _tip.SetActive(false);
        Head.instance.cantChoose = true;
        _tipOn = false;
        _twice = true;
        _tutorial.SetActive(false);
        _video.SetActive(true);
        _startUI.SetActive(false);
        IzzyFSM.instance.startOpening = true;
        MoviePlayer.instance.startPlaying = true;
    }

    public void ExitClick()
    {
        CameraFade.FadeOut();
        _exit = true;
    }

    public void TutorialCancelClick()
    {
        _tutorial.SetActive(false);
    }

    public void Player0Click()
    {
        _twice = true;
        _tipOn = false;
        PlayBandTest.Instance.flag = true;
        _temp.sprite = playersImg[0].sprite;
        _levelMessage.SetActive(true);
        _endUI.SetActive(false);
        _loginClick = true;
        _startUI.SetActive(false);
        GameTimer._instance._begin = true;
        _gameStart = true;
        DataBase._instance._inputName = "Player0";
    }

    public void Player1Click()
    {
        _twice = true;
        _tipOn = false;
        PlayBandTest.Instance.flag = true;
        _temp.sprite = playersImg[1].sprite;
        _levelMessage.SetActive(true);
        _endUI.SetActive(false);
        _loginClick = true;
        _startUI.SetActive(false);
        GameTimer._instance._begin = true;
        _gameStart = true;
        DataBase._instance._inputName = "Player1";
    }

    public void Player2Click()
    {
        _twice = true;
        _tipOn = false;
        PlayBandTest.Instance.flag = true;
        _temp.sprite = playersImg[2].sprite;
        _levelMessage.SetActive(true);
        _endUI.SetActive(false);
        _loginClick = true;
        _startUI.SetActive(false);
        GameTimer._instance._begin = true;
        _gameStart = true;
        DataBase._instance._inputName = "Player2";
    }

    public void Player3Click()
    {
        _twice = true;
        _tipOn = false;
        PlayBandTest.Instance.flag = true;
        _temp.sprite = playersImg[3].sprite;
        _levelMessage.SetActive(true);
        _endUI.SetActive(false);
        _loginClick = true;
        _startUI.SetActive(false);
        GameTimer._instance._begin = true;
        _gameStart = true;
        DataBase._instance._inputName = "Player3";
    }

    public void Player4Click()
    {
        _twice = true;
        _tipOn = false;
        PlayBandTest.Instance.flag = true;
        _temp.sprite = playersImg[4].sprite;
        _levelMessage.SetActive(true);
        _endUI.SetActive(false);
        _loginClick = true;
        _startUI.SetActive(false);
        GameTimer._instance._begin = true;
        _gameStart = true;
        DataBase._instance._inputName = "Player4";
    }

    public void Player5Click()
    {
        _twice = true;
        _tipOn = false;
        PlayBandTest.Instance.flag = true;
        _temp.sprite = playersImg[5].sprite;
        _levelMessage.SetActive(true);
        _endUI.SetActive(false);
        _loginClick = true;
        _startUI.SetActive(false);
        GameTimer._instance._begin = true;
        _gameStart = true;
        DataBase._instance._inputName = "Player5";
    }

    public void Player6Click()
    {
        _twice = true;
        _tipOn = false;
        PlayBandTest.Instance.flag = true;
        _temp.sprite = playersImg[6].sprite;
        _levelMessage.SetActive(true);
        _endUI.SetActive(false);
        _loginClick = true;
        _startUI.SetActive(false);
        GameTimer._instance._begin = true;
        _gameStart = true;
        DataBase._instance._inputName = "Player6";
    }

    public void Player7Click()
    {
        _twice = true;
        _tipOn = false;
        PlayBandTest.Instance.flag = true;
        _temp.sprite = playersImg[7].sprite;
        _levelMessage.SetActive(true);
        _endUI.SetActive(false);
        _loginClick = true;
        _startUI.SetActive(false);
        GameTimer._instance._begin = true;
        _gameStart = true;
        DataBase._instance._inputName = "Player7";
    }

    public void PauseClick()
    {
        _pause = true;
        PlayBandTest.Instance.flag = false;
        _levelMessage.SetActive(false);
        _pausePicture.SetActive(true);
    }

    public void PlayerDataCancle()
    {
        playerData.SetActive(false);
    }

    public void StartClick()
    {
        _startClick = true;
    }


    public void ResumeClick()
    {
        _pause = false;
        PlayBandTest.Instance.flag = true;
        _levelMessage.SetActive(true);
        _pausePicture.SetActive(false);
    }

    public void SwitchModeClick()
    {
        if(_difficultSwitch.text.Equals("Difficult Mode"))
        {
            CorrectionSystemManager._instance.ElevationOffset = 0.5f;
            CorrectionSystemManager._instance.RLAngleOffset = 3.0f;
            CorrectionSystemManager._instance.SpeedOffset = 0.5f;
            CorrectionSystemManager._instance.DoValve = 7;
            _difficultSwitch.text.Equals("Easy Mode");
        }
        else if(_difficultSwitch.text.Equals("Easy Mode"))
        {
            CorrectionSystemManager._instance.ElevationOffset = 1.5f;
            CorrectionSystemManager._instance.RLAngleOffset = 7.0f;
            CorrectionSystemManager._instance.SpeedOffset = 1.0f;
            CorrectionSystemManager._instance.DoValve = 5;
            _difficultSwitch.text.Equals("Difficult Mode");
        }
    }

    public void AgainClick()
    {
        Head.instance.again = true;
        _tipOn = true;
        _pause = false;
        _loginActive = true;
        PlayBandTest.Instance.flag = false;
        LevelManager.instance._timer = 0.0f;
        LevelManager.instance.timerfade = 0.0f;
        LevelManager.instance._currentLevel = 0;
        LevelManager.instance._finish = false;
        GameTimer._instance.m_CurrentStage = 0;
        GameTimer._instance._begin = false;
        GameTimer._instance.counter = false;
        GameTimer._instance.m_isgameover = false;
        _pauseButton.SetActive(false);
        _pausePicture.SetActive(false);
        _endUI.SetActive(false);
        _startUI.SetActive(true);
        _levelMessage.SetActive(false);
        _timeMessage.SetActive(false);
        _level.SetActive(false);
        _gameStart = false;
        _count1.fontSize = 16;
        _count2.fontSize = 16;
        _count3.fontSize = 16;
        _success.text = "Level 1";
        _count1.text = "";
        _count2.text = "";
        _count3.text = "";
        DataBase._instance._inputName = "";
        PlayBandTest.Instance.currentThrowState = ThrowStates2.NOTHING;
        LevelManager.instance.changelevel = false;
        CorrectionSystemManager._instance.ResetCurrent_CorrectionSystem();
        Head.instance.OpenCharacterCollider();
        Head.instance.closeoncesound = false;
        if (Head.instance.stateInfoFade.IsName("TempState"))
        {
            Head.instance.fade.SetBool("again", true);
        }
    }
}

