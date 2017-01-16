using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameTimer : MonoBehaviour
{
    public static GameTimer _instance;
    public float m_EachStageTimer = 0;           //遊戲時時間計時器
    public int[] m_StageTime = new int[10];
    public int m_TotalTimer = 0;
    public bool m_isgameover = false;            //遊戲是否結束
    public int m_CurrentStage = 0;
    public int iTimeLevel1;
    public int iTimeLevel2;
    public int iTimeLevel3;
    public int iTimeLevel4;
    public int iTimeLevel5;
    public int iTimeLevel6;
    public int iTimeLevel7;
    public int iTimeLevel8;
    public int iTimeLevel9;
    public int iTimeLevel10;
    public bool _begin;
    public Text _success;
    public Text _firstStageTime;
    public Text _secondStageTime;
    public Text _thirdStageTime;
    public Text _fourthStageTime;
    public Text _fifthStageTime;
    public Text _sixthStageTime;
    public Text _seventhStageTime;
    public Text _eighthStageTime;
    public Text _ninethStageTime;
    public Text _tenthStageTime;
    public Text _totalTime;
    public bool counter;
    private float _secondEachStage;
    private float _secondTotal;
    private int _recordTime;
    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        _recordTime = 0;
        m_EachStageTimer = 0;
        m_isgameover = false;
        m_CurrentStage = 0;
        _secondEachStage = 0.0f;
        int iTime = Convert.ToInt16(Math.Floor(_secondEachStage));
		_firstStageTime.text = "Level 1 : " + iTime;
        _secondTotal = 0.0f;
        _begin = false;
        counter = false;
        iTimeLevel1 = 0;
        iTimeLevel2 = 0;
        iTimeLevel3 = 0;
        iTimeLevel4 = 0;
        iTimeLevel5 = 0;
        iTimeLevel6 = 0;
        iTimeLevel7 = 0;
        iTimeLevel8 = 0;
        iTimeLevel9 = 0;
        iTimeLevel10 = 0;
        //_no1Image.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        //_no2Image.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        //_no3Image.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    void Update()
    {
        if (Head.instance.again)
        {
            for (int i = 0; i < m_StageTime.Length; i++)
            {
                m_StageTime[i] = 0;
            }
            m_TotalTimer = 0;

            m_EachStageTimer = 0.0f;
            iTimeLevel1 = 0;
            iTimeLevel2 = 0;
            iTimeLevel3 = 0;
            iTimeLevel4 = 0;
            iTimeLevel5 = 0;
        }
        if ((m_CurrentStage != 10) && _begin)
        {
            if(_success.text != "SUCCESS" && counter && UIManager._instance._pause == false)
            {
                if(m_CurrentStage == 0)
                {
                    if (LevelManager.instance.timerfade > 2.0f)
                    {
                        m_EachStageTimer += Time.deltaTime;
                    }
                }
                else if (m_CurrentStage == 1)
                {
                    if (LevelManager.instance.timerfade > 3.0f)
                    {
                        m_EachStageTimer += Time.deltaTime;
                    }
                }
                else if (m_CurrentStage == 2)
                {
                    if (LevelManager.instance.timerfade > 3.0f)
                    {
                        m_EachStageTimer += Time.deltaTime;
                    }
                }
                else if (m_CurrentStage == 3)
                {
                    if (LevelManager.instance.timerfade > 2.0f)
                    {
                        m_EachStageTimer += Time.deltaTime;
                    }
                }
                else if (m_CurrentStage == 4)
                {
                    if (LevelManager.instance.timerfade > 4.0f)
                    {
                        m_EachStageTimer += Time.deltaTime;
                    }
                }
                else if (m_CurrentStage == 5)
                {
                    if (LevelManager.instance.timerfade > 2.0f)
                    {
                        m_EachStageTimer += Time.deltaTime;
                    }
                }
                else if (m_CurrentStage == 6)
                {
                    if (LevelManager.instance.timerfade > 5.0f)
                    {
                        m_EachStageTimer += Time.deltaTime;
                    }
                }
                else if (m_CurrentStage == 7)
                {
                    if (LevelManager.instance.timerfade > 3.0f)
                    {
                        m_EachStageTimer += Time.deltaTime;
                    }
                }
                else if (m_CurrentStage == 8)
                {
                    if (LevelManager.instance.timerfade > 3.0f)
                    {
                        m_EachStageTimer += Time.deltaTime;
                    }
                }
                else if (m_CurrentStage == 9)
                {
                    if (LevelManager.instance.timerfade > 1.0f)
                    {
                        m_EachStageTimer += Time.deltaTime;
                    }
                }
            }
                       
            if (m_CurrentStage == 0)
            {
                if(LevelManager.instance.timerfade > 2.0f)
                {
                    iTimeLevel1 = Convert.ToInt16(Math.Floor(m_EachStageTimer));
                    _firstStageTime.text = "Level 1 : " + iTimeLevel1;
                }
            }
            else if (m_CurrentStage == 1)
            {
                if (LevelManager.instance.timerfade > 3.0f)
                {
                    iTimeLevel2 = Convert.ToInt16(Math.Floor(m_EachStageTimer));
                    _secondStageTime.text = "Level 2 : " + iTimeLevel2;
                } 
            }
            else if (m_CurrentStage == 2)
            {
                if (LevelManager.instance.timerfade > 3.0f)
                {
                    iTimeLevel3 = Convert.ToInt16(Math.Floor(m_EachStageTimer));
                    _thirdStageTime.text = "Level 3 : " + iTimeLevel3;
                } 
            }
            else if (m_CurrentStage == 3)
            {
                if (LevelManager.instance.timerfade > 2.0f)
                {
                    iTimeLevel4 = Convert.ToInt16(Math.Floor(m_EachStageTimer));
                    _fourthStageTime.text = "Level 4 : " + iTimeLevel4;
                }    
            }
            else if (m_CurrentStage == 4)
            {
                if (LevelManager.instance.timerfade > 4.0f)
                {
                    iTimeLevel5 = Convert.ToInt16(Math.Floor(m_EachStageTimer));
                    _fifthStageTime.text = "Level 5 : " + iTimeLevel5;
                }
            }
            else if (m_CurrentStage == 5)
            {
                if (LevelManager.instance.timerfade > 2.0f)
                {
                    iTimeLevel6 = Convert.ToInt16(Math.Floor(m_EachStageTimer));
                    _sixthStageTime.text = "Level 6 : " + iTimeLevel6;
                }
            }
            else if (m_CurrentStage == 6)
            {
                if (LevelManager.instance.timerfade > 5.0f)
                {
                    iTimeLevel7 = Convert.ToInt16(Math.Floor(m_EachStageTimer));
                    _seventhStageTime.text = "Level 7 : " + iTimeLevel7;
                }
            }
            else if (m_CurrentStage == 7)
            {
                if (LevelManager.instance.timerfade > 3.0f)
                {
                    iTimeLevel8 = Convert.ToInt16(Math.Floor(m_EachStageTimer));
                    _eighthStageTime.text = "Level 8 : " + iTimeLevel8;
                }
            }
            else if (m_CurrentStage == 8)
            {
                if (LevelManager.instance.timerfade > 3.0f)
                {
                    iTimeLevel9 = Convert.ToInt16(Math.Floor(m_EachStageTimer));
                    _ninethStageTime.text = "Level 9 : " + iTimeLevel9;
                }
            }
            else if (m_CurrentStage == 9)
            {
                if (LevelManager.instance.timerfade > 1.0f)
                {
                    iTimeLevel10 = Convert.ToInt16(Math.Floor(m_EachStageTimer));
                    _tenthStageTime.text = "Level 10 : " + iTimeLevel10;
                }
            }
            if (LevelManager.instance._timer > 2.0f)
            {
                if(m_CurrentStage == 0)
                {
                    float fTime = m_EachStageTimer;
                    iTimeLevel1 = Convert.ToInt16(Math.Floor(fTime));
					_firstStageTime.text = "Level 1 : " + iTimeLevel1;
                    _recordTime = iTimeLevel1;
                }
                else if (m_CurrentStage == 1)
                {
                    float fTime = m_EachStageTimer;
                    iTimeLevel2 = Convert.ToInt16(Math.Floor(fTime));
					_secondStageTime.text = "Level 2 : " + iTimeLevel2;
                    _recordTime = iTimeLevel2;
                }
                else if (m_CurrentStage == 2)
                {
                    float fTime = m_EachStageTimer;
                    iTimeLevel3 = Convert.ToInt16(Math.Floor(fTime));
					_thirdStageTime.text = "Level 3 : " + iTimeLevel3;
                    _recordTime = iTimeLevel3;
                }
                else if (m_CurrentStage == 3)
                {
                    float fTime = m_EachStageTimer;
                    iTimeLevel4 = Convert.ToInt16(Math.Floor(fTime));
					_fourthStageTime.text = "Level 4 : " + iTimeLevel4;
                    _recordTime = iTimeLevel4;
                }
                else if (m_CurrentStage == 4)
                {
                    float fTime = m_EachStageTimer;
                    iTimeLevel5 = Convert.ToInt16(Math.Floor(fTime));
					_fifthStageTime.text = "Level 5 : " + iTimeLevel5;
                    _recordTime = iTimeLevel5;
                }
                else if (m_CurrentStage == 5)
                {
                    float fTime = m_EachStageTimer;
                    iTimeLevel6 = Convert.ToInt16(Math.Floor(fTime));
                    _sixthStageTime.text = "Level 6 : " + iTimeLevel6;
                    _recordTime = iTimeLevel6;
                }
                else if (m_CurrentStage == 6)
                {
                    float fTime = m_EachStageTimer;
                    iTimeLevel7 = Convert.ToInt16(Math.Floor(fTime));
                    _seventhStageTime.text = "Level 7 : " + iTimeLevel7;
                    _recordTime = iTimeLevel7;
                }
                else if (m_CurrentStage == 7)
                {
                    float fTime = m_EachStageTimer;
                    iTimeLevel8 = Convert.ToInt16(Math.Floor(fTime));
                    _eighthStageTime.text = "Level 8 : " + iTimeLevel8;
                    _recordTime = iTimeLevel8;
                }
                else if (m_CurrentStage == 8)
                {
                    float fTime = m_EachStageTimer;
                    iTimeLevel9 = Convert.ToInt16(Math.Floor(fTime));
                    _ninethStageTime.text = "Level 9 : " + iTimeLevel9;
                    _recordTime = iTimeLevel9;
                }
                else if (m_CurrentStage == 9)
                {
                    float fTime = m_EachStageTimer;
                    iTimeLevel10 = Convert.ToInt16(Math.Floor(fTime));
                    _tenthStageTime.text = "Level 10 : " + iTimeLevel10;
                    _recordTime = iTimeLevel10;
                }
                m_StageTime[m_CurrentStage] = _recordTime;
                m_CurrentStage++;
                m_EachStageTimer = 0;
            }



        }
        else if ((m_CurrentStage == 10) && (m_isgameover == false))
        {
            for (int i = 0; i < m_StageTime.Length; i++)
            {
                m_TotalTimer += m_StageTime[i];
            }
            _totalTime.text = "Total Time : " + m_TotalTimer;
            m_isgameover = true;



            //先看這次玩的人是不是新的Play或是已經有舊資料
            //有新的資料，要從新排序_playerarray，更新舊資料也要排序一次_playerarray，也重新設定名次
            //因為資料型態不一樣，Unity用player，存檔適用playerdata要先轉型後才能存檔
            DataBase.AutoUpgratedata(DataBase._instance._inputName, GameTimer._instance.m_StageTime, GameTimer._instance.m_TotalTimer);
            LocalDatabase._instance.OutDataFromUnity();
            LocalDatabase._instance.saveData(LocalDatabase._instance._PlayeroffolineData);
            DataBase.SetPlayerUpAndDowmDataToEndUiBorad(DataBase._instance._inputName);
        }
    }
}
