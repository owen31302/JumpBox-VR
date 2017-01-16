using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int _currentBoxLv5;
    public GameObject lvNineOriginePos;
    public GameObject _levelMessage;
    public GameObject _level1;
    public GameObject _level2;
    public GameObject _level3;
    public GameObject _level4;
    public GameObject _level5;
    public GameObject _level6;
    public GameObject _level7;
    public GameObject _level8;
    public GameObject _level9;
    public GameObject _level10;
    public GameObject _mark;
    public GameObject _ballPre;
    public GameObject _pause;
    public Text _success;
    public Text _timeMessage;
    public int _currentLevel;
    public bool _finish;
    public float _timer;
    public bool changelevel = false;
    public bool fadeout = false;
    public float timerfade;

    private AnimatorStateInfo stateInfoFade;
    private Animator fade;

    void Awake()
    {
        instance = this;

    }

    // Use this for initialization
    void Start()
    {
        timerfade = 0.0f;
        _currentBoxLv5 = 0;
        _currentLevel = 0;
        _success.text = "Level 1";
        _timer = 0.0f;
        _finish = false;
        fade = Head.instance._screen.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        stateInfoFade = fade.GetCurrentAnimatorStateInfo(0);


        if (Head.instance.again)
        {
            Head.instance.again = false;
            _currentBoxLv5 = 0;
            _mark.SetActive(false);
            _level1.SetActive(false);
            _level2.SetActive(false);
            _level3.SetActive(false);
            _level4.SetActive(false);
            _level5.SetActive(false);
            _level6.SetActive(false);
            _level7.SetActive(false);
            _level8.SetActive(false);
            _level9.SetActive(false);
            _level10.SetActive(false);
            changelevel = true;
        }
        if (_currentLevel == 1)
        {
            timerfade += Time.deltaTime;
            if (_success.text == "Level 1")
            {
                _timeMessage.text = "" + GameTimer._instance.iTimeLevel1;
            }
            else if (_success.text == "SUCCESS")
            {
                _mark.SetActive(false);
                _timeMessage.text = "" + GameTimer._instance.iTimeLevel1;
                fadeout = true;
                if (_timer > 2.0f)
                {
                    _mark.SetActive(true);
                    _level1.SetActive(false);
                    _level2.SetActive(true);
                    _currentLevel = 2;
                    _success.text = "Level 2";
                    _timer = 0.0f;
                    changelevel = true;
                    fadeout = false;
                    timerfade = 0.0f;

                }
                _timer += Time.deltaTime;
            }
        }
        else if (_currentLevel == 2)
        {
            timerfade += Time.deltaTime;
            if (_success.text == "Level 2")
            {
                _timeMessage.text = "" + GameTimer._instance.iTimeLevel2;
            }
            else if (_success.text == "SUCCESS")
            {
                _mark.SetActive(false);
                _timeMessage.text = "" + GameTimer._instance.iTimeLevel2;
                fadeout = true;

                if (_timer > 2.0f)
                {
                    _mark.SetActive(true);
                    _level2.SetActive(false);
                    _level3.SetActive(true);
                    _currentLevel = 3;
                    _success.text = "Level 3";
                    _timer = 0.0f;
                    changelevel = true;
                    fadeout = false;
                    timerfade = 0.0f;
                }
                _timer += Time.deltaTime;
            }
        }
        else if (_currentLevel == 3)
        {
            timerfade += Time.deltaTime;
            if (_success.text == "Level 3")
            {
                _timeMessage.text = "" + GameTimer._instance.iTimeLevel3;
            }
            else if (_success.text == "SUCCESS")
            {
                _mark.SetActive(false);
                fadeout = true;
                _timeMessage.text = "" + GameTimer._instance.iTimeLevel3;
                if (_timer > 2.0f)
                {
                    _mark.SetActive(true);
                    _level3.SetActive(false);
                    _level4.SetActive(true);
                    _currentLevel = 4;
                    _success.text = "Level 4";
                    _timer = 0.0f;
                    changelevel = true;
                    fadeout = false;
                    timerfade = 0.0f;
                }
                _timer += Time.deltaTime;
            }
        }
        else if (_currentLevel == 4)
        {
            timerfade += Time.deltaTime;
            if (_success.text == "Level 4")
            {
                _timeMessage.text = "" + GameTimer._instance.iTimeLevel4;
                changelevel = false;
            }
            else if (_success.text == "SUCCESS")
            {
                _mark.SetActive(false);
                fadeout = true;
                _timeMessage.text = "" + GameTimer._instance.iTimeLevel4;
                if (_timer > 2.0f)
                {
                    _mark.SetActive(true);
                    _level4.SetActive(false);
                    _level5.SetActive(true);
                    _currentLevel = 5;
                    _success.text = "Level 5";
                    _timer = 0.0f;
                    changelevel = true;
                    fadeout = false;
                    timerfade = 0.0f;
                    IzzyFSM.instance.startLevel5 = true;
                }
                _timer += Time.deltaTime;
            }
        }
        else if (_currentLevel == 5)
        {
            timerfade += Time.deltaTime;
            if (_success.text == "Level 5" || _success.text == "Box One Check" || _success.text == "Box Two Check" || _success.text == "Box Three Check")
            {
                _timeMessage.text = "" + GameTimer._instance.iTimeLevel5;
            }
            else if (_success.text == "SUCCESS")
            {
                _mark.SetActive(false);
                fadeout = true;
                _timeMessage.text = "" + GameTimer._instance.iTimeLevel5;
                if (_timer > 2.0f)
                {
                    _mark.SetActive(true);
                    _level5.SetActive(false);
                    _level6.SetActive(true);
                    _currentLevel = 6;
                    _success.text = "Level 6";
                    _timer = 0.0f;
                    changelevel = true;
                    fadeout = false;
                    timerfade = 0.0f;
                }
                _timer += Time.deltaTime;
            }
        }
        else if(_currentLevel == 6)
        {
            //do level6
            timerfade += Time.deltaTime;
            if (_success.text == "Level 6")
            {
                _timeMessage.text = "" + GameTimer._instance.iTimeLevel6;
            }
            else if (_success.text == "SUCCESS")
            {
                _mark.SetActive(false);
                _timeMessage.text = "" + GameTimer._instance.iTimeLevel6;
                fadeout = true;
                if (_timer > 2.0f)
                {
                    _mark.SetActive(true);
                    _level6.SetActive(false);
                    _level7.SetActive(true);
                    _currentLevel = 7;
                    _success.text = "Level 7";
                    _timer = 0.0f;
                    changelevel = true;
                    fadeout = false;
                    timerfade = 0.0f;

                }
                _timer += Time.deltaTime;
            }
        }
        else if (_currentLevel == 7)
        {
            //do level7
            timerfade += Time.deltaTime;
            if (_success.text == "Level 7")
            {
                _timeMessage.text = "" + GameTimer._instance.iTimeLevel7;
            }
            else if (_success.text == "SUCCESS")
            {
                _mark.SetActive(false);
                _timeMessage.text = "" + GameTimer._instance.iTimeLevel7;
                fadeout = true;
                if (_timer > 2.0f)
                {
                    _mark.SetActive(true);
                    _level7.SetActive(false);
                    _level8.SetActive(true);
                    _currentLevel = 8;
                    _success.text = "Level 8";
                    _timer = 0.0f;
                    changelevel = true;
                    fadeout = false;
                    timerfade = 0.0f;

                }
                _timer += Time.deltaTime;
            }
        }
        else if (_currentLevel == 8)
        {
            //do level8
            timerfade += Time.deltaTime;
            if (_success.text == "Level 8")
            {
                _timeMessage.text = "" + GameTimer._instance.iTimeLevel8;
            }
            else if (_success.text == "SUCCESS")
            {
                _mark.SetActive(false);
                _timeMessage.text = "" + GameTimer._instance.iTimeLevel8;
                fadeout = true;
                if (_timer > 2.0f)
                {
                    _mark.SetActive(true);
                    _level8.SetActive(false);
                    _level9.SetActive(true);
                    _currentLevel = 9;
                    _success.text = "Level 9";
                    _timer = 0.0f;
                    changelevel = true;
                    fadeout = false;
                    timerfade = 0.0f;

                }
                _timer += Time.deltaTime;
            }
        }
        else if (_currentLevel == 9)
        {
            //do level9
            timerfade += Time.deltaTime;
            if (_success.text == "Level 9")
            {
                _timeMessage.text = "" + GameTimer._instance.iTimeLevel9;
            }
            else if (_success.text == "SUCCESS")
            {
                _mark.SetActive(false);
                _timeMessage.text = "" + GameTimer._instance.iTimeLevel9;
                fadeout = true;
                if (_timer > 2.0f)
                {
                    _mark.SetActive(true);
                    _level9.SetActive(false);
                    _level10.SetActive(true);
                    _currentLevel = 10;
                    _success.text = "Level 10";
                    _timer = 0.0f;
                    changelevel = true;
                    fadeout = false;
                    timerfade = 0.0f;

                }
                _timer += Time.deltaTime;
            }
        }
        else if (_currentLevel == 10)
        {
            //do level10
            timerfade += Time.deltaTime;
            if (_success.text == "Level 10" /*|| _success.text == "BOX ONE SUCCESS" || _success.text == "BOX TWO SUCCESS" || _success.text == "BOX THREE SUCCESS"*/)
            {
                _timeMessage.text = "" + GameTimer._instance.iTimeLevel10;
            }
            else if (_success.text == "SUCCESS")
            {
                _mark.SetActive(false);
                fadeout = true;
                _timeMessage.text = "" + GameTimer._instance.iTimeLevel10;
                if (stateInfoFade.IsName("TempState") && _timer > 2.0f)
                {
                    IzzyFSM.instance.startEnd = true;
                    fade.SetBool("finish", true);
                }
                if (_timer > 6.0f)
                {
                    _level10.SetActive(false);
                    _levelMessage.SetActive(false);
                    _timer = 0.0f;
                    _finish = true;
                    _timeMessage.text = "";
                    PlayBandTest.Instance.click_block = false;
                    _currentLevel = 0;
                    changelevel = true;
                    fadeout = false;
                    fade.SetBool("finish", false);
                    timerfade = 0.0f;
                    return;
                }
                _timer += Time.deltaTime;
            }
        }
    }
}
