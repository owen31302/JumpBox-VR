using UnityEngine;
using System.Collections;

public class LvNine : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
        Pingpongpool._instance._nineBall = ObjectPool.m_Instance.LoadObjectFromPool(1);
        Pingpongpool._instance._nineBall.transform.position = LevelManager.instance.lvNineOriginePos.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
