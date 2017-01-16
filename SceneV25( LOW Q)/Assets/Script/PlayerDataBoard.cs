using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerDataBoard : MonoBehaviour {
    public Image _character;
    public Image _trophyGold;
    public Image _trophySliver;
    public Image _trophyCopper;
    public Text _rankNumber;
    public Text _lv1;
    public Text _lv2;
    public Text _lv3;
    public Text _lv4;
    public Text _lv5;
    public Text _lv6;
    public Text _lv7;
    public Text _lv8;
    public Text _lv9;
    public Text _lv10;
    public Text _total;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(Head.instance.allPlayerData != null)
        {
            _character.sprite = Head.instance.allPlayerData.m_PlayerSprite;
            _rankNumber.text = Head.instance.allPlayerData.m_PlayerRank.ToString();
            if ((1 <= Head.instance.allPlayerData.m_PlayerRank) && (Head.instance.allPlayerData.m_PlayerRank <= 3))
            {
                _trophyGold.enabled = true;
                _trophySliver.enabled = false;
                _trophyCopper.enabled = false;

            }
            else if ((4 <= Head.instance.allPlayerData.m_PlayerRank) && (Head.instance.allPlayerData.m_PlayerRank <= 6))
            {
                _trophyGold.enabled = false;
                _trophySliver.enabled = true;
                _trophyCopper.enabled = false;
            }
            else if ((7 <= Head.instance.allPlayerData.m_PlayerRank) && (Head.instance.allPlayerData.m_PlayerRank <= 8))
            {
                _trophyGold.enabled = false;
                _trophySliver.enabled = false;
                _trophyCopper.enabled = true;
            }
            _lv1.text = "Level 1 : " + Head.instance.allPlayerData.m_PlayerFirstStageTime + "s";
            _lv2.text = "Level 2 : " + Head.instance.allPlayerData.m_PlayerScondStageTime + "s";
            _lv3.text = "Level 3 : " + Head.instance.allPlayerData.m_PlayerThirdStageTime + "s";
            _lv4.text = "Level 4 : " + Head.instance.allPlayerData.m_PlayerFouthStageTime + "s";
            _lv5.text = "Level 5 : " + Head.instance.allPlayerData.m_PlayerFifthStageTime + "s";
            _lv6.text = "Level 6 : " + Head.instance.allPlayerData.m_PlayerSixthStageTime + "s";
            _lv7.text = "Level 7 : " + Head.instance.allPlayerData.m_PlayerSeventhStageTime + "s";
            _lv8.text = "Level 8 : " + Head.instance.allPlayerData.m_PlayerEighthStageTime + "s";
            _lv9.text = "Level 9 : " + Head.instance.allPlayerData.m_PlayerNinthStageTime + "s";
            _lv10.text = "Level 10 : " + Head.instance.allPlayerData.m_PlayerTenthStageTime + "s";
            _total.text = "Total Time : " + Head.instance.allPlayerData.m_PlayerTotalTime + "s";
        }

    }
}
