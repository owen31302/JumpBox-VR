using UnityEngine;
using System.Collections;

public class Pingpongpool : MonoBehaviour {
    public static Pingpongpool _instance;
    public GameObject _fiftyBall;
    public GameObject _nineBall;
    public GameObject LevelNineBall;
    public GameObject _ballPrefab;
    public Rigidbody _rigigdbodyBall;
    public Rigidbody _rigigdbodyNineBall;

    void Awake()
    {
        _instance = this;
        
    }

	// Use this for initialization
	void Start () {
        ObjectPool.m_Instance.InitObjectsInPool(_ballPrefab, 50);
        ObjectPool.m_Instance.InitObjectsInPool(LevelNineBall, 10);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
