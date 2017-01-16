using UnityEngine;
using System.Collections;

public class CreatBall : MonoBehaviour {
	private float _life = 10.0f;
	// Use this for initialization
	void Start () {

	}

	void OnEnable()
	{
		_life = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if ((_life < 0) || (LevelManager.instance._success.text == "SUCCESS"))         //life減少到小於0時把它unload就又回到objectpool裡又可以再度使用
		{
            this.gameObject.transform.position = new Vector3(4.5f, 1.8f, 3.0f);
            ObjectPool.m_Instance.UnLoadObjectToPool(0, this.gameObject);
			return;        //if裡面執行完
		}				
		_life = _life - Time.deltaTime;        //life隨時間慢慢減少
	}
}
