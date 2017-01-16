using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageName : MonoBehaviour {
    public static ImageName _instance;
    public Image[] _playerImage= new Image[8];
    public GameObject[] _playerName = new GameObject[8];
    public Image[] _playerShade = new Image[9];

    void Awake()
    {
        _instance = this;
    }

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
