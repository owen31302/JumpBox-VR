using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class LocalDatabase : MonoBehaviour {

    public static LocalDatabase _instance;
    public List<PlayerData> LoadData;

    [SerializeField]
    public List<PlayerData> _PlayeroffolineData;

    // Use this for initialization
    void Awake()
    {
        _instance = this;
        _PlayeroffolineData = new List<PlayerData>();


    }
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("l"))
        {
            ClearLocalData();
        }
    }
    
    public void saveData(List<PlayerData> playerData)
    {
        Debug.Log("存檔成功，二進位儲存的LIST有多少資料" + _PlayeroffolineData.Count);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "Players.dataBase");
        //Debug.Log("Save To: " + Application.persistentDataPath);
        bf.Serialize(file, playerData);
        file.Close();
    }

    public void loadData()
    {
        string dataPath = Application.persistentDataPath + "Players.dataBase";
        if (File.Exists(dataPath))
        {
            _PlayeroffolineData.Clear();
            LoadData.Clear();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(dataPath, FileMode.Open);
            LoadData = (List<PlayerData>)bf.Deserialize(file);
            file.Close();
            if(LoadData.Count > 0)
            {
                    Debug.Log("讀檔成功，有多少玩家資料 " + LoadData.Count);
                    return;
            }
            else {
                Debug.Log("讀檔成功，有多少玩家資料 " + LoadData.Count);
                return; }
        }
    }
    public void putdatatounity()
    {
        for (int i = 0; i < LoadData.Count; i++)
        {
            DataBase._playerarray[i].m_PlayerName = LoadData[i].m_PlayerName;
            DataBase._playerarray[i].m_PlayerFirstStageTime = LoadData[i].m_PlayerFirstStageTime;
            DataBase._playerarray[i].m_PlayerScondStageTime = LoadData[i].m_PlayerScondStageTime;
            DataBase._playerarray[i].m_PlayerThirdStageTime = LoadData[i].m_PlayerThirdStageTime;
            DataBase._playerarray[i].m_PlayerFouthStageTime = LoadData[i].m_PlayerFouthStageTime;
            DataBase._playerarray[i].m_PlayerFifthStageTime = LoadData[i].m_PlayerFifthStageTime;
            DataBase._playerarray[i].m_PlayerSixthStageTime = LoadData[i].m_PlayerSixthStageTime;
            DataBase._playerarray[i].m_PlayerSeventhStageTime = LoadData[i].m_PlayerSeventhStageTime;
            DataBase._playerarray[i].m_PlayerEighthStageTime = LoadData[i].m_PlayerEighthStageTime;
            DataBase._playerarray[i].m_PlayerNinthStageTime = LoadData[i].m_PlayerNinthStageTime;
            DataBase._playerarray[i].m_PlayerTenthStageTime = LoadData[i].m_PlayerTenthStageTime;
            DataBase._playerarray[i].m_PlayerTotalTime = LoadData[i].m_PlayerTotalTime;
        }
    }
    public void OutDataFromUnity()
    {
        _PlayeroffolineData.Clear();
        for (int i = 0; i < DataBase._playerarray.Count; i++)
        {
            PlayerData playerdatas = new PlayerData();
            playerdatas.m_PlayerName = DataBase._playerarray[i].m_PlayerName;
            playerdatas.m_PlayerFirstStageTime = DataBase._playerarray[i].m_PlayerFirstStageTime;
            playerdatas.m_PlayerScondStageTime = DataBase._playerarray[i].m_PlayerScondStageTime;
            playerdatas.m_PlayerThirdStageTime = DataBase._playerarray[i].m_PlayerThirdStageTime;
            playerdatas.m_PlayerFouthStageTime = DataBase._playerarray[i].m_PlayerFouthStageTime;
            playerdatas.m_PlayerFifthStageTime = DataBase._playerarray[i].m_PlayerFifthStageTime;
            playerdatas.m_PlayerSixthStageTime = DataBase._playerarray[i].m_PlayerSixthStageTime;
            playerdatas.m_PlayerSeventhStageTime = DataBase._playerarray[i].m_PlayerSeventhStageTime;
            playerdatas.m_PlayerEighthStageTime = DataBase._playerarray[i].m_PlayerEighthStageTime;
            playerdatas.m_PlayerNinthStageTime = DataBase._playerarray[i].m_PlayerNinthStageTime;
            playerdatas.m_PlayerTenthStageTime = DataBase._playerarray[i].m_PlayerTenthStageTime;
            playerdatas.m_PlayerTotalTime = DataBase._playerarray[i].m_PlayerTotalTime;
            _PlayeroffolineData.Add(playerdatas);
        }
    }
    public void ClearLocalData()
    {
        Debug.Log("清除所有紀錄");
        DataBase._playerarray.Clear();
        _PlayeroffolineData.Clear();
        saveData(_PlayeroffolineData);
        string dataPath = Application.persistentDataPath + "Players.dataBase";
        if (File.Exists(dataPath))
        {
            loadData();
            DataBase._instance.SetDataBasePlayer();
            putdatatounity();
            DataBase._instance.SequenceRank();
            DataBase._instance.SetImageToPlayer();
            DataBase._instance.SetLeaderBoradImage();
        }
    }
}
[Serializable]
public class PlayerData {
    public string m_PlayerName;
    public int m_PlayerFirstStageTime;
    public int m_PlayerScondStageTime;
    public int m_PlayerThirdStageTime;
    public int m_PlayerFouthStageTime;
    public int m_PlayerFifthStageTime;
    public int m_PlayerSixthStageTime;
    public int m_PlayerSeventhStageTime;
    public int m_PlayerEighthStageTime;
    public int m_PlayerNinthStageTime;
    public int m_PlayerTenthStageTime;
    public int m_PlayerTotalTime;
}
