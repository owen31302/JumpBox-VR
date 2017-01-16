using UnityEngine;
using System.Collections;
using System.Collections.Generic;//使用list 要include
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//定義玩家有哪些資料

public class DataBase : MonoBehaviour
{
    public class Player : PlayerData
    {
        public int m_PlayerRank;
        public Sprite m_PlayerSprite;
        public Sprite m_PlayerSpriteShadow;
    }
    public static DataBase _instance = null;
    public string _inputName = "";          //玩家選擇的動物
    private bool _isgameover = false;      //遊戲是否結束的bool值
    public static List<Player> _playerarray = new List<Player>();
    public static int[] _StageTimerData = new int[10];
    public Image[] _TotalImageRank = new Image[3];
    public Image[] _TotalImageRank2 = new Image[3];
    public Image[] _TotalImageRank3 = new Image[3];
    public Image[] _TotalImageRankShadow = new Image[3];
    public Image[] _TotalImageRank2Shadow = new Image[3];
    public Image[] _TotalImageRank3Shadow = new Image[3];
    public Image[] _EndUiImageRank = new Image[1];
    //最後遊戲結束的時候顯示你的名次
    public Text _yourRankNumber;
    //最後遊戲結束的時候依照名次顯示三種顏色的獎盃
    public Image[] _trophy = new Image[3];


    void Awake()
    {
        _instance = this;
    }

    void Start()
    {

        //LocalData
        //先讀檔，讀到LoadData
        //照LoadData有幾筆資料，生成幾個 unity 裡的 _playerarray 的實體物件
        //把LoadData 依序 塞到 _playerarray
        //因為LoadData裡不存名次，所以必須對_playerarray做一次設定名次的動作
        //把各個玩家的動物圖案依序設定給各個玩家
        //設定rank版上的圖案
        string dataPath = Application.persistentDataPath + "Players.dataBase";
        if (File.Exists(dataPath))
        {
            //Debug.Log("!!!!!!!!!!!");

            LocalDatabase._instance.loadData();
            SetDataBasePlayer();
            LocalDatabase._instance.putdatatounity();
            //Debug.Log("!!!!!!!!!!!");
            SequenceRank();
            SetImageToPlayer();
            SetLeaderBoradImage();
        }


    }
    void Update()
    {



    }
    //依照Localdata的資料數生成玩家
    public void SetDataBasePlayer()
    {

        for (int i = 0; i < LocalDatabase._instance.LoadData.Count; i++)
        {
            _playerarray.Add(new Player());
        }

    }
    //所有玩家依花費時間設定名次(同分同名次)
    public void SequenceRank()
    {
        float m_BestTotalTime = float.MaxValue;
        int m_Rank = 0;
        int iLen = _playerarray.Count;
        for (int i = 0; i < iLen; i++)
        {
            if (m_BestTotalTime != _playerarray[i].m_PlayerTotalTime)
            {
                m_Rank++;
                _playerarray[i].m_PlayerRank = m_Rank;
                m_BestTotalTime = _playerarray[i].m_PlayerTotalTime;
            }
            else
            {
                _playerarray[i].m_PlayerRank = m_Rank;
            }
        }

    }
    //根據名字回傳該名子的player資料
    public static Player FindPlayerData(string findname)
    {
        for (int i = 0; i < _playerarray.Count; i++)
        {
            if (_playerarray[i].m_PlayerName == findname)
            {
                return _playerarray[i];
            }
            continue;
        }
        return null;
    }

    //自動更新舊資料與生成新資料時順便直接設定player貼圖，順便照總時間排序新的_playerarray，之後也重新設定名次
    public static void AutoUpgratedata(string upgratename, int[] thisgameeachstagetime, int thisgametotaltime)
    {
        if (FindPlayerData(upgratename) != null)
        {
            if (FindPlayerData(upgratename).m_PlayerFirstStageTime > thisgameeachstagetime[0])
            {
                FindPlayerData(upgratename).m_PlayerFirstStageTime = thisgameeachstagetime[0];
            }
            if (FindPlayerData(upgratename).m_PlayerScondStageTime > thisgameeachstagetime[1])
            {
                FindPlayerData(upgratename).m_PlayerScondStageTime = thisgameeachstagetime[1];
            }
            if (FindPlayerData(upgratename).m_PlayerThirdStageTime > thisgameeachstagetime[2])
            {
                FindPlayerData(upgratename).m_PlayerThirdStageTime = thisgameeachstagetime[2];
            }
            if (FindPlayerData(upgratename).m_PlayerFouthStageTime > thisgameeachstagetime[3])
            {
                FindPlayerData(upgratename).m_PlayerFouthStageTime = thisgameeachstagetime[3];
            }
            if (FindPlayerData(upgratename).m_PlayerFifthStageTime > thisgameeachstagetime[4])
            {
                FindPlayerData(upgratename).m_PlayerFifthStageTime = thisgameeachstagetime[4];
            }
            if (FindPlayerData(upgratename).m_PlayerFifthStageTime > thisgameeachstagetime[5])
            {
                FindPlayerData(upgratename).m_PlayerFifthStageTime = thisgameeachstagetime[5];
            }
            if (FindPlayerData(upgratename).m_PlayerFifthStageTime > thisgameeachstagetime[6])
            {
                FindPlayerData(upgratename).m_PlayerFifthStageTime = thisgameeachstagetime[6];
            }
            if (FindPlayerData(upgratename).m_PlayerFifthStageTime > thisgameeachstagetime[7])
            {
                FindPlayerData(upgratename).m_PlayerFifthStageTime = thisgameeachstagetime[7];
            }
            if (FindPlayerData(upgratename).m_PlayerFifthStageTime > thisgameeachstagetime[8])
            {
                FindPlayerData(upgratename).m_PlayerFifthStageTime = thisgameeachstagetime[8];
            }
            if (FindPlayerData(upgratename).m_PlayerFifthStageTime > thisgameeachstagetime[9])
            {
                FindPlayerData(upgratename).m_PlayerFifthStageTime = thisgameeachstagetime[9];
            }
            if (FindPlayerData(upgratename).m_PlayerTotalTime > thisgametotaltime)
            {
                FindPlayerData(upgratename).m_PlayerTotalTime = thisgametotaltime;
            }
            DataBase._instance.quickSort(_playerarray, 0, _playerarray.Count - 1);
            DataBase._instance.SequenceRank();
            return;
        }
        else
        {
            Player createplayer = new Player();
            createplayer.m_PlayerTotalTime = thisgametotaltime;
            createplayer.m_PlayerFirstStageTime = thisgameeachstagetime[0];
            createplayer.m_PlayerScondStageTime = thisgameeachstagetime[1];
            createplayer.m_PlayerThirdStageTime = thisgameeachstagetime[2];
            createplayer.m_PlayerFouthStageTime = thisgameeachstagetime[3];
            createplayer.m_PlayerFifthStageTime = thisgameeachstagetime[4];
            createplayer.m_PlayerSixthStageTime = thisgameeachstagetime[5];
            createplayer.m_PlayerSeventhStageTime = thisgameeachstagetime[6];
            createplayer.m_PlayerEighthStageTime = thisgameeachstagetime[7];
            createplayer.m_PlayerNinthStageTime = thisgameeachstagetime[8];
            createplayer.m_PlayerTenthStageTime = thisgameeachstagetime[9];
            createplayer.m_PlayerName = upgratename;
            for (int i = 0; i < ImageName._instance._playerName.Length; i++)
            {
                if (ImageName._instance._playerName[i].name == upgratename)
                {
                    createplayer.m_PlayerSprite = ImageName._instance._playerImage[i].sprite;
                }
            }
            _playerarray.Add(createplayer);
            DataBase._instance.quickSort(_playerarray, 0, _playerarray.Count - 1);
            DataBase._instance.SequenceRank();
            return;
        }
    }

    //根據名子回傳該名子的名次上下一個
    public static void SetPlayerUpAndDowmDataToEndUiBorad(string namefindname)
    {
        Player you = FindPlayerData(namefindname);
        DataBase._instance._EndUiImageRank[0].sprite = you.m_PlayerSprite;
        if ((1 <= you.m_PlayerRank) && (you.m_PlayerRank <= 3))
        {
            DataBase._instance._trophy[0].enabled = true;
            DataBase._instance._trophy[1].enabled = false;
            DataBase._instance._trophy[2].enabled = false;

        }
        else if ((4 <= you.m_PlayerRank) && (you.m_PlayerRank <= 6))
        {
            DataBase._instance._trophy[0].enabled = false;
            DataBase._instance._trophy[1].enabled = true;
            DataBase._instance._trophy[2].enabled = false;
        }
        else if ((7 <= you.m_PlayerRank) && (you.m_PlayerRank <= 8))
        {
            DataBase._instance._trophy[0].enabled = false;
            DataBase._instance._trophy[1].enabled = false;
            DataBase._instance._trophy[2].enabled = true;
        }
            DataBase._instance._yourRankNumber.text = (you.m_PlayerRank).ToString(); 
        
    }
    //根據名次找玩家資料
    public static Player FindPlayerWithRank(int rankfindname)
    {
        DataBase._instance.SequenceRank();
        for (int i = 0; i < _playerarray.Count; i++)
        {
            if (_playerarray[i].m_PlayerRank == rankfindname)
            {
                return _playerarray[i];
            }
            continue;
        }
        return null;
    }
    //設定RANK版上的圖片
    public void SetLeaderBoradImage()
    {
        List<Player> No1Players = new List<Player>();
        List<Player> No2Players = new List<Player>();
        List<Player> No3Players = new List<Player>();

        No1Players = FindPlayerNo1OnRankBorad();
        No2Players = FindPlayerNo2OnRankBorad();
        No3Players = FindPlayerNo3OnRankBorad();


        for (int i = 0; i < _TotalImageRank.Length; i++)
        {
            _TotalImageRank[i].sprite = null;
            _TotalImageRankShadow[i].sprite = null;
            _TotalImageRank[i].enabled = false;
            _TotalImageRankShadow[i].enabled = false;
            _TotalImageRank[i].GetComponent<BoxCollider>().enabled = false;
        }
        if (No1Players != null)
        {
            for (int i = 0; i < No1Players.Count; i++)
            {
                if (No1Players[i] != null)
                {
                    if (i < _TotalImageRank.Length)
                    {
                        _TotalImageRank[i].sprite = No1Players[i].m_PlayerSprite;
                        _TotalImageRankShadow[i].sprite = No1Players[i].m_PlayerSprite;
                        _TotalImageRank[i].enabled = true;
                        _TotalImageRankShadow[i].enabled = true;
                        _TotalImageRank[i].GetComponent<BoxCollider>().enabled = true;

                    }
                    else { continue; }
                }
            }
        }
        


        for (int i = 0; i < _TotalImageRank2.Length; i++)
        {
            _TotalImageRank2[i].sprite = null;
            _TotalImageRank2Shadow[i].sprite = null;
            _TotalImageRank2[i].enabled = false;
            _TotalImageRank2Shadow[i].enabled = false;
            _TotalImageRank2[i].GetComponent<BoxCollider>().enabled = false;
        }
        if (No2Players != null)
        {
            for (int i = 0; i < No2Players.Count; i++)
            {
                if (No2Players[i] != null)
                {
                    if (i < _TotalImageRank2.Length)
                    {
                        _TotalImageRank2[i].sprite = No2Players[i].m_PlayerSprite;
                        _TotalImageRank2Shadow[i].sprite = No2Players[i].m_PlayerSprite;
                        _TotalImageRank2[i].enabled = true;
                        _TotalImageRank2Shadow[i].enabled = true;
                        _TotalImageRank2[i].GetComponent<BoxCollider>().enabled = true;
                    }
                }
            }
        }
        

        for (int i = 0; i < _TotalImageRank3.Length; i++)
        {
            _TotalImageRank3[i].sprite = null;
            _TotalImageRank3Shadow[i].sprite = null;
            _TotalImageRank3[i].enabled = false;
            _TotalImageRank3Shadow[i].enabled = false;
            _TotalImageRank3[i].GetComponent<BoxCollider>().enabled = false;
        }

        if (No3Players != null)
        {
            for (int i = 0; i < No3Players.Count; i++)
            {
                if (No3Players[i] != null)
                {
                    if (i < _TotalImageRank3.Length)
                    {
                        _TotalImageRank3[i].sprite = No3Players[i].m_PlayerSprite;
                        _TotalImageRank3Shadow[i].sprite = No3Players[i].m_PlayerSprite;
                        _TotalImageRank3[i].enabled = true;
                        _TotalImageRank3Shadow[i].enabled = true;
                        _TotalImageRank3[i].GetComponent<BoxCollider>().enabled = true;
                    }
                }
            }
        }
        else { return; }

    }
    //設定玩家的貼圖
    public void SetImageToPlayer()
    {
        for (int i = 0; i < _playerarray.Count; i++)
        {
            for (int j = 0; j < ImageName._instance._playerName.Length; j++)
            {
                if (_playerarray[i].m_PlayerName == ImageName._instance._playerName[j].name)
                {
                    _playerarray[i].m_PlayerSprite = ImageName._instance._playerImage[j].sprite;
                    _playerarray[i].m_PlayerSpriteShadow = ImageName._instance._playerShade[j].sprite;
                }
            }
        }
    }

    //快速排序
    public void exchange(List<Player> A, int i, int j)
    {

        var temp = A[i];
        A[i] = A[j];
        A[j] = temp;
    }
    public int partition(List<Player> A, int p, int r)
    {
        var x = A[p].m_PlayerTotalTime;
        int i = p;
        for (int j = p + 1; j < r + 1; j++)
        {
            if (A[j].m_PlayerTotalTime <= x)
            {
                i++;
                exchange(A, i, j);
            }
        }
        exchange(A, p, i);
        return i;
    }
    public void quickSort(List<Player> A, int p, int r)
    {
        if (p < r)
        {
            int q = partition(A, p, r);
            quickSort(A, p, q - 1);
            quickSort(A, q + 1, r);
        }
    }
    public static List<Player> FindPlayerNo1OnRankBorad()
    {
        int i;
        List<Player> No1Players = new List<Player>();
        DataBase._instance.SequenceRank();
        for (i = 0; i < _playerarray.Count; i++)
        {
            if (_playerarray[i].m_PlayerRank == 1)
            {
                No1Players.Add(_playerarray[i]);
            }
        }

        if (No1Players.Count == 0)
        {
            return null;
        }
        else
        {
            return No1Players;

        }
    }
    public static List<Player> FindPlayerNo2OnRankBorad()
    {
        int i;
        List<Player> No2Players = new List<Player>();
        DataBase._instance.SequenceRank();
        for (i = 0; i < _playerarray.Count; i++)
        {
            if (_playerarray[i].m_PlayerRank == 2)
            {
                No2Players.Add(_playerarray[i]);
            }
        }

        if (No2Players.Count == 0)
        {
            return null;
        }
        else
        {
            return No2Players;

        }
    }
    public static List<Player> FindPlayerNo3OnRankBorad()
    {
        int i;
        List<Player> No3Players = new List<Player>();
        DataBase._instance.SequenceRank();
        for (i = 0; i < _playerarray.Count; i++)
        {
            if (_playerarray[i].m_PlayerRank == 3)
            {
                No3Players.Add(_playerarray[i]);
            }
        }

        if (No3Players.Count == 0)
        {
            return null;
        }
        else
        {
            return No3Players;

        }
    }

}
