using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Head : MonoBehaviour
{
    public static Head instance;
    public Image[] comfirmCircle = new Image[27];
    public BoxCollider _titleColl;
    public SphereCollider _exitColl;
    private float timer = 0.0f;
    private float circleSpeed = 0.4f;
    public bool again;
    public GameObject Aim;
    public GameObject _screen;
    public GameObject playerData;
    public GameObject eixtTip;
    public AnimatorStateInfo stateInfoFade;
    public Image[] characterRank = new Image[9];
    public BoxCollider[] screencharacter = new BoxCollider[8];
    public DataBase.Player allPlayerData;
    public bool cantChoose;
    public bool[] chooseDone = new bool[8];
    public bool oncebeesound = true;
    public bool closeoncesound = false;


    private bool onceclicksound = true;
    private bool oncesound = true;
    public Animator fade;
    private float _fadeTimer;
    private bool _fadeBegin;
    
    RaycastHit hitInfo;
    void Awake()
    {
        eixtTip.SetActive(false);
        cantChoose = false;
        fade = _screen.GetComponent<Animator>();
        instance = this;
        again = false;
        hitInfo = new RaycastHit();
        _fadeTimer = 0.0f;
        _fadeBegin = false;
        for (int i = 0; i < chooseDone.Length; i++)
        {
            chooseDone[i] = false;
        }

    }

    void Update()
    {
        if (Input.GetKey("f"))
        {
            LevelManager.instance._success.text = "SUCCESS";
            LevelManager.instance.fadeout = true;

        }

        stateInfoFade = fade.GetCurrentAnimatorStateInfo(0);
        if (_fadeBegin)
        {
            _fadeTimer += Time.deltaTime;
            if (stateInfoFade.IsName("AfterTitle"))
            {
                fade.SetBool("fade", true);
            }
        }
        else
        {
            _fadeTimer = 0.0f;
        }

        if (chooseDone[0])
        {
            closeoncesound = true;
            cantChoose = true;
            if (_fadeTimer > 2.0f)
            {
                Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[0];
                Uibottensound._instance._As.Play();
                _fadeBegin = false;
                fade.SetBool("fade", false);
                UIManager._instance.Player0Click();
                comfirmCircle[0].fillAmount = 0.0f;
                closeoncesound = false;
                cantChoose = false;
                chooseDone[0] = false;
            }
        }
        else if (chooseDone[1])
        {
            closeoncesound = true;
            cantChoose = true;
            if (_fadeTimer > 2.0f)
            {
                Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[1];
                Uibottensound._instance._As.Play();
                _fadeBegin = false;
                fade.SetBool("fade", false);
                UIManager._instance.Player1Click();
                comfirmCircle[1].fillAmount = 0.0f;
                closeoncesound = false;
                cantChoose = false;
                chooseDone[1] = false;
            }
        }
        else if (chooseDone[2])
        {
            closeoncesound = true;
            cantChoose = true;
            if (_fadeTimer > 2.0f)
            {
                Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[2];
                Uibottensound._instance._As.Play();
                _fadeBegin = false;
                fade.SetBool("fade", false);
                UIManager._instance.Player2Click();
                comfirmCircle[2].fillAmount = 0.0f;
                closeoncesound = false;
                cantChoose = false;
                chooseDone[2] = false;
            }
        }
        else if (chooseDone[3])
        {
            closeoncesound = true;
            cantChoose = true;
            if (_fadeTimer > 2.0f)
            {
                Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[3];
                Uibottensound._instance._As.Play();
                _fadeBegin = false;
                fade.SetBool("fade", false);
                UIManager._instance.Player3Click();
                comfirmCircle[3].fillAmount = 0.0f;
                closeoncesound = false;
                cantChoose = false;
                chooseDone[3] = false;
            }
        }
        else if (chooseDone[4])
        {
            closeoncesound = true;
            cantChoose = true;            
            if (_fadeTimer > 2.0f)
            {
                Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[4];
                Uibottensound._instance._As.Play();
                _fadeBegin = false;
                fade.SetBool("fade", false);
                UIManager._instance.Player4Click();
                comfirmCircle[4].fillAmount = 0.0f;
                cantChoose = false;
                closeoncesound = false;
                cantChoose = false;
                chooseDone[4] = false;
            }
        }
        else if (chooseDone[5])
        {
            closeoncesound = true;
            cantChoose = true;
            if (_fadeTimer > 2.0f)
            {
                Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[5];
                Uibottensound._instance._As.Play();
                _fadeBegin = false;
                fade.SetBool("fade", false);
                UIManager._instance.Player5Click();
                comfirmCircle[5].fillAmount = 0.0f;
                closeoncesound = false;
                cantChoose = false;
                chooseDone[5] = false;
            }
        }
        else if (chooseDone[6])
        {
            closeoncesound = true;
            cantChoose = true;
            if (_fadeTimer > 2.0f)
            {
                Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[6];
                Uibottensound._instance._As.Play();
                _fadeBegin = false;
                fade.SetBool("fade", false);
                UIManager._instance.Player6Click();
                comfirmCircle[6].fillAmount = 0.0f;
                closeoncesound = false;
                cantChoose = false;
                chooseDone[6] = false;
            }
        }
        else if (chooseDone[7])
        {
            closeoncesound = true;
            cantChoose = true;
            if (_fadeTimer > 2.0f)
            {
                Uibottensound._instance._As.volume = 0.6f;
                Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[7];
                Uibottensound._instance._As.Play();
                Uibottensound._instance._As.volume = Uibottensound._instance.vlofix;
                _fadeBegin = false;
                fade.SetBool("fade", false);
                UIManager._instance.Player7Click();
                comfirmCircle[7].fillAmount = 0.0f;
                closeoncesound = false;
                cantChoose = false;
                chooseDone[7] = false;
            }
        }

        if(Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, 10.0f, 1 << 17))
        {
            if (UIManager._instance._tipOn)
            {
                UIManager._instance._tutorial.SetActive(true);
            }
        }

        if (Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, 10.0f, 1 << 11)
           || Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, 10.0f, 1 << 10)
           || Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, 10.0f, 1 << 17))
        {
            Aim.SetActive(true);
            Aim.transform.position = hitInfo.point;
            if(hitInfo.collider.name.Equals("RankBoard"))
            {
                IzzyFSM.instance.startCheckOther = true;
            }
        }
        else
        {
            Aim.SetActive(false);
        }


        if (Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, 10.0f, 1 << 14)
            || Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, 10.0f, 1 << 15))
        {
            if (oncesound && !closeoncesound)
            {
                Uibottensound._instance._As.PlayOneShot(Uibottensound._instance._AcSounds[12], Uibottensound._instance.vlofix * 2.0f);
                oncesound = false;
            }

            Aim.SetActive(true);
            Aim.transform.position = hitInfo.point;

            if (hitInfo.collider.name.Equals("exit"))
            {
                eixtTip.SetActive(true);
                comfirmCircle[26].fillAmount += Time.deltaTime * circleSpeed;
                if (comfirmCircle[26].fillAmount >= 1.0f)
                {
                    Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[13];
                    Uibottensound._instance._As.Play();
                    
                    _exitColl.enabled = false;
                    comfirmCircle[26].fillAmount = 0.0f;
                    UIManager._instance.ExitClick();
                }
            }
            else
            {
                eixtTip.SetActive(false);
            }

            if (hitInfo.collider.name.Equals("Title"))
            {
                comfirmCircle[25].fillAmount += Time.deltaTime * circleSpeed;
                if (comfirmCircle[25].fillAmount >= 1.0f)
                {
                    Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[13];
                    Uibottensound._instance._As.Play();
                    _titleColl.enabled = false;
                    comfirmCircle[25].fillAmount = 0.0f;
                    UIManager._instance.StartClick();
                }
            }

            if (hitInfo.collider.name.Equals("Switch"))
            {
                comfirmCircle[24].fillAmount += Time.deltaTime * circleSpeed;
                if (comfirmCircle[24].fillAmount >= 1.0f)
                {
                    Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[13];
                    Uibottensound._instance._As.Play();
                    comfirmCircle[24].fillAmount = 0.0f;
                    UIManager._instance.SwitchModeClick();
                }
            }

            if (hitInfo.collider.name.Equals("No1First"))
            {
                comfirmCircle[12].fillAmount += Time.deltaTime * circleSpeed;
                if (comfirmCircle[12].fillAmount >= 1.0f)
                {
                    cantChoose = true;
                    CloseCharacterCollider();
                    Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[13];
                    Uibottensound._instance._As.Play();
                    comfirmCircle[12].fillAmount = 0.0f;
                    playerData.SetActive(true);
                    allPlayerData = SearchRank(characterRank[0].sprite.name);
                    for(int i = 0; i < characterRank.Length; i++)
                    {
                        if(characterRank[i].sprite != null)
                        {
                            characterRank[i].GetComponent<BoxCollider>().enabled = true;
                        }
                    }
                    characterRank[0].GetComponent<BoxCollider>().enabled = false;
                }
            }

            if (hitInfo.collider.name.Equals("No1Second"))
            {
                comfirmCircle[13].fillAmount += Time.deltaTime * circleSpeed;
                if (comfirmCircle[13].fillAmount >= 1.0f)
                {
                    cantChoose = true;
                    CloseCharacterCollider();
                    Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[13];
                    Uibottensound._instance._As.Play();
                    comfirmCircle[13].fillAmount = 0.0f;
                    playerData.SetActive(true);
                    allPlayerData = SearchRank(characterRank[1].sprite.name);
                    for (int i = 0; i < characterRank.Length; i++)
                    {
                        if (characterRank[i].sprite != null)
                        {
                            characterRank[i].GetComponent<BoxCollider>().enabled = true;
                        }
                    }
                    characterRank[1].GetComponent<BoxCollider>().enabled = false;
                }
            }

            if (hitInfo.collider.name.Equals("No1Third"))
            {
                comfirmCircle[14].fillAmount += Time.deltaTime * circleSpeed;
                if (comfirmCircle[14].fillAmount >= 1.0f)
                {
                    cantChoose = true;
                    CloseCharacterCollider();
                    Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[13];
                    Uibottensound._instance._As.Play();
                    comfirmCircle[14].fillAmount = 0.0f;
                    playerData.SetActive(true);
                    allPlayerData = SearchRank(characterRank[2].sprite.name);
                    for (int i = 0; i < characterRank.Length; i++)
                    {
                        if (characterRank[i].sprite != null)
                        {
                            characterRank[i].GetComponent<BoxCollider>().enabled = true;
                        }
                    }
                    characterRank[2].GetComponent<BoxCollider>().enabled = false;
                }
            }

            if (hitInfo.collider.name.Equals("No2First"))
            {
                comfirmCircle[15].fillAmount += Time.deltaTime * circleSpeed;
                if (comfirmCircle[15].fillAmount >= 1.0f)
                {
                    cantChoose = true;
                    CloseCharacterCollider();
                    Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[13];
                    Uibottensound._instance._As.Play();
                    comfirmCircle[15].fillAmount = 0.0f;
                    playerData.SetActive(true);
                    allPlayerData = SearchRank(characterRank[3].sprite.name);
                    for (int i = 0; i < characterRank.Length; i++)
                    {
                        if (characterRank[i].sprite != null)
                        {
                            characterRank[i].GetComponent<BoxCollider>().enabled = true;
                        }
                    }
                    characterRank[3].GetComponent<BoxCollider>().enabled = false;
                }
            }

            if (hitInfo.collider.name.Equals("No2Second"))
            {
                comfirmCircle[16].fillAmount += Time.deltaTime * circleSpeed;
                if (comfirmCircle[16].fillAmount >= 1.0f)
                {
                    cantChoose = true;
                    CloseCharacterCollider();
                    Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[13];
                    Uibottensound._instance._As.Play();
                    comfirmCircle[16].fillAmount = 0.0f;
                    playerData.SetActive(true);
                    allPlayerData = SearchRank(characterRank[4].sprite.name);
                    for (int i = 0; i < characterRank.Length; i++)
                    {
                        if (characterRank[i].sprite != null)
                        {
                            characterRank[i].GetComponent<BoxCollider>().enabled = true;
                        }
                    }
                    characterRank[4].GetComponent<BoxCollider>().enabled = false;
                }
            }

            if (hitInfo.collider.name.Equals("No2Third"))
            {
                comfirmCircle[17].fillAmount += Time.deltaTime * circleSpeed;
                if (comfirmCircle[17].fillAmount >= 1.0f)
                {
                    cantChoose = true;
                    CloseCharacterCollider();
                    Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[13];
                    Uibottensound._instance._As.Play();
                    comfirmCircle[17].fillAmount = 0.0f;
                    playerData.SetActive(true);
                    allPlayerData = SearchRank(characterRank[5].sprite.name);
                    for (int i = 0; i < characterRank.Length; i++)
                    {
                        if (characterRank[i].sprite != null)
                        {
                            characterRank[i].GetComponent<BoxCollider>().enabled = true;
                        }
                    }
                    characterRank[5].GetComponent<BoxCollider>().enabled = false;

                }
            }

            if (hitInfo.collider.name.Equals("No3First"))
            {
                comfirmCircle[18].fillAmount += Time.deltaTime * circleSpeed;
                if (comfirmCircle[18].fillAmount >= 1.0f)
                {
                    cantChoose = true;
                    CloseCharacterCollider();
                    Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[13];
                    Uibottensound._instance._As.Play();
                    comfirmCircle[18].fillAmount = 0.0f;
                    playerData.SetActive(true);
                    allPlayerData = SearchRank(characterRank[6].sprite.name);
                    for (int i = 0; i < characterRank.Length; i++)
                    {
                        if (characterRank[i].sprite != null)
                        {
                            characterRank[i].GetComponent<BoxCollider>().enabled = true;
                        }
                    }
                    characterRank[6].GetComponent<BoxCollider>().enabled = false;
                }
            }

            if (hitInfo.collider.name.Equals("No3Second"))
            {
                comfirmCircle[19].fillAmount += Time.deltaTime * circleSpeed;
                if (comfirmCircle[19].fillAmount >= 1.0f)
                {
                    cantChoose = true;
                    CloseCharacterCollider();
                    Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[13];
                    Uibottensound._instance._As.Play();
                    comfirmCircle[19].fillAmount = 0.0f;
                    playerData.SetActive(true);
                    allPlayerData = SearchRank(characterRank[7].sprite.name);
                    for (int i = 0; i < characterRank.Length; i++)
                    {
                        if (characterRank[i].sprite != null)
                        {
                            characterRank[i].GetComponent<BoxCollider>().enabled = true;
                        }
                    }
                    characterRank[7].GetComponent<BoxCollider>().enabled = false;

                }
            }

            if (hitInfo.collider.name.Equals("No3Third"))
            {
                comfirmCircle[20].fillAmount += Time.deltaTime * circleSpeed;
                if (comfirmCircle[20].fillAmount >= 1.0f)
                {
                    cantChoose = true;
                    CloseCharacterCollider();
                    Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[13];
                    Uibottensound._instance._As.Play();
                    comfirmCircle[20].fillAmount = 0.0f;
                    playerData.SetActive(true);
                    allPlayerData = SearchRank(characterRank[8].sprite.name);
                    for (int i = 0; i < characterRank.Length; i++)
                    {
                        if (characterRank[i].sprite != null)
                        {
                            characterRank[i].GetComponent<BoxCollider>().enabled = true;
                        }
                    }
                    characterRank[8].GetComponent<BoxCollider>().enabled = false;

                }
            }
            
            if (hitInfo.collider.name.Equals("PlayerDataCancle"))
            {

                comfirmCircle[21].fillAmount += Time.deltaTime * circleSpeed;
                if (comfirmCircle[21].fillAmount >= 1.0f)
                {
                    Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[9];
                    Uibottensound._instance._As.Play();
                    playerData.SetActive(false);
                    cantChoose = false;
                    OpenCharacterCollider();
                    for (int i = 0; i < characterRank.Length; i++)
                    {
                        if (characterRank[i].sprite != null)
                        {
                            characterRank[i].GetComponent<BoxCollider>().enabled = true;
                        }
                    }
                }
            }

            if (hitInfo.collider.name.Equals("Pause"))
            {
                comfirmCircle[8].fillAmount += Time.deltaTime * circleSpeed;
                if (comfirmCircle[8].fillAmount >= 1.0f)
                {
                    Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[9];
                    Uibottensound._instance._As.Play();
                    comfirmCircle[8].fillAmount = 0.0f;
                    UIManager._instance.PauseClick();
                }
            }

            if (hitInfo.collider.name.Equals("Resume"))
            {
                comfirmCircle[9].fillAmount += Time.deltaTime * circleSpeed;
                if (comfirmCircle[9].fillAmount >= 1.0f)
                {
                    Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[9];
                    Uibottensound._instance._As.Play();
                    comfirmCircle[9].fillAmount = 0.0f;
                    UIManager._instance.ResumeClick();
                }
            }

            if (hitInfo.collider.name.Equals("Repeat"))
            {
                comfirmCircle[10].fillAmount += Time.deltaTime * circleSpeed;
                if (comfirmCircle[10].fillAmount >= 1.0f)
                {
                    Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[9];
                    Uibottensound._instance._As.Play();
                    comfirmCircle[10].fillAmount = 0.0f;
                    onceclicksound = true;
                    oncebeesound = true;
                    UIManager._instance.AgainClick();
                }
            }

            if (hitInfo.collider.name.Equals("TryAgain"))
            {
                comfirmCircle[11].fillAmount += Time.deltaTime * circleSpeed;
                if (comfirmCircle[11].fillAmount >= 1.0f)
                {
                    Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[9];
                    Uibottensound._instance._As.Play();
                    comfirmCircle[11].fillAmount = 0.0f;
                    onceclicksound = true;
                    oncebeesound = true;
                    UIManager._instance.AgainClick();
                }
            }

            if (hitInfo.collider.name.Equals("TutorialComfirm"))
            {
                comfirmCircle[22].fillAmount += Time.deltaTime * circleSpeed;
                if (comfirmCircle[22].fillAmount >= 1.0f)
                {
                    Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[9];
                    Uibottensound._instance._As.Play();
                    comfirmCircle[22].fillAmount = 0.0f;
                    //do teaching
                    UIManager._instance.TutorialComfirmClick();
                }
            }

            if (hitInfo.collider.name.Equals("TutorialCancel"))
            {
                comfirmCircle[23].fillAmount += Time.deltaTime * circleSpeed;
                if (comfirmCircle[23].fillAmount >= 1.0f)
                {
                    Uibottensound._instance._As.clip = Uibottensound._instance._AcSounds[9];
                    Uibottensound._instance._As.Play();
                    comfirmCircle[23].fillAmount = 0.0f;
                    //do cancel
                    UIManager._instance.TutorialCancelClick();
                }
            }

            if (!cantChoose)
            {
                for (int i = 0; i < comfirmCircle.Length; i++)
                {
                    if (hitInfo.collider.name.Equals("Player" + i))
                    {
                        comfirmCircle[i].fillAmount += Time.deltaTime * circleSpeed;
                        if (comfirmCircle[i].fillAmount >= 1.0f)
                        {
                            if (onceclicksound)
                            {
                                Uibottensound._instance._As.PlayOneShot(Uibottensound._instance._AcSounds[11], 5.0f);
                                onceclicksound = false;
                            }
                            if (i == 0)
                            {
                                _fadeBegin = true;
                                chooseDone[i] = true;
                            }
                            else if (i == 1)
                            {
                                _fadeBegin = true;
                                chooseDone[i] = true;
                            }
                            else if (i == 2)
                            {
                                _fadeBegin = true;
                                chooseDone[i] = true;
                            }
                            else if (i == 3)
                            {
                                _fadeBegin = true;
                                chooseDone[i] = true;
                            }
                            else if (i == 4)
                            {
                                _fadeBegin = true;
                                chooseDone[i] = true;
                            }
                            else if (i == 5)
                            {
                                _fadeBegin = true;
                                chooseDone[i] = true;
                            }
                            else if (i == 6)
                            {
                                _fadeBegin = true;
                                chooseDone[i] = true;
                            }
                            else if (i == 7)
                            {
                                _fadeBegin = true;
                                chooseDone[i] = true;
                            }
                        }
                    }
                }
            }
        }
        else
        {
            oncesound = true;
            for (int i = 0; i < comfirmCircle.Length; i++)
            {
                comfirmCircle[i].fillAmount = 0.0f;
            }
        }

        if (Input.GetKey("w"))
        {
            this.transform.Rotate(-0.2f, 0.0f, 0.0f, Space.Self);
        }
        if (Input.GetKey("d"))
        {
            this.transform.Rotate(0.0f, 0.2f, 0.0f, Space.World);
        }
        if (Input.GetKey("s"))
        {
            this.transform.Rotate(0.2f, 0.0f, 0.0f, Space.Self);
        }
        if (Input.GetKey("a"))
        {
            this.transform.Rotate(0.0f, -0.2f, 0.0f, Space.World);
        }
    }

    public DataBase.Player SearchRank(string s)
    {
        for(int i = 0; i < DataBase._playerarray.Count; i++)
        {
            if(DataBase._playerarray[i].m_PlayerName == s)
            {
                return DataBase._playerarray[i];
            }
        }
        return null;
    }
    public void CloseCharacterCollider()
    {
        for(int i = 0; i < screencharacter.Length; i++)
        {
            screencharacter[i].enabled = false;
        }
    }
    public void OpenCharacterCollider()
    {
        for (int i = 0; i < screencharacter.Length; i++)
        {
            screencharacter[i].enabled = true;
        }
    }
}