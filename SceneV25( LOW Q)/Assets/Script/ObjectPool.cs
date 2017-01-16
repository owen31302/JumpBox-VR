using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolData
{
	public GameObject m_go;
	public bool m_bUsing;
}

public class ObjectPool : MonoBehaviour {

	public int m_iCount;
	public static ObjectPool m_Instance;
	public List<ObjectPoolData>[] m_GameObjects;
	public int m_iNumGameObjectInType;



	void Awake () {
		m_Instance = this;
		m_iCount = 0;
		m_iNumGameObjectInType = 10;
		m_GameObjects = new List<ObjectPoolData>[10];
	}
	



	int FindEmptySlot()                                    
	{
		int i;
		for(i = 0; i < m_iNumGameObjectInType; i++) {                  
			if(m_GameObjects[i] == null) {
				break;	
			}
		}
		if(i == m_iNumGameObjectInType) {
			return -1;
		} else {
			return i;
		}
	}

	public void DeInit()
	{
		int i, j;
		int iCount;
		for(i = 0; i < m_iNumGameObjectInType; i++) {
			if(m_GameObjects[i] != null) {
				iCount = m_GameObjects[i].Count;
				for(j = 0; j < iCount; j++) {
					Destroy(m_GameObjects[i][j].m_go);
					Debug.Log("ddd");
				}
			}
		}
	}
	
	
	public int InitObjectsInPool(Object obj, int iCount)         //放在我shoot裡面的話，obj就是子彈的Prefab(也就是我要重複使用子彈)，iCount就是我最多這個Scene會有iCount顆子彈
    {
		int iSlot = FindEmptySlot();                            /*找出空的slot，裡面有一個list，list裡面每個位置的ObjectPoolData可以存兩個東西(物件Prefab:m_go    是否有被使用m_bUsing)
                                                                  ，並給定要生成的數量iCount，並把生成的全部物件資料放入objData(new出來的ObjectPoolData)，最後slot裡面的list裡面會有50個objData*/

        if (iSlot < 0) {
			return -1;	
		}
		m_iCount = iCount;
		m_GameObjects[iSlot] = new List<ObjectPoolData>();
		for(int i = 0; i < iCount; i++) {
			GameObject go = Instantiate(obj) as GameObject;
			if(go == null) {
				break;
			}
			EnableModel(go, false);
			ObjectPoolData objData = new ObjectPoolData();
			objData.m_go = go;
			objData.m_bUsing = false;
			m_GameObjects[iSlot].Add(objData);
		}
		return iSlot;
	}
	
	public GameObject LoadObjectFromPool(int iSlot)
	{
		if(iSlot < 0 || iSlot >= m_iNumGameObjectInType) {
			return null;	
		}
		GameObject go = null;
		int iCount = m_GameObjects[iSlot].Count;
		for(int i = 0; i < iCount; i++) {
			ObjectPoolData objData = m_GameObjects[iSlot][i];             //這個東西代表第iSlot裡面list的第i個元素            (二維陣列)
			if(objData.m_bUsing == false) {
				go = objData.m_go;
				//go.active = true;
				//ShowModel(go, true);
				EnableModel(go, true);
				objData.m_bUsing = true;
				m_GameObjects[iSlot][i] = objData;
				break;
			}
		}
		return go;
	}
	
	public bool UnLoadObjectToPool(int iSlot, GameObject go)
	{
		if(iSlot < 0 || iSlot >= m_iNumGameObjectInType) {
			return false;	
		}
		bool bRet = false;
		int iCount = m_GameObjects[iSlot].Count;
		for(int i = 0; i < iCount; i++) {
			ObjectPoolData objData = m_GameObjects[iSlot][i];
			if(objData.m_go == go) {
				objData.m_bUsing = false;
				EnableModel(go, false);
				//ShowModel(go, false);
				//go.active = false;
				m_GameObjects[iSlot][i] = objData;
				bRet = true;
				break;
			}
		}
		return bRet;
	}
	
	public void DestroyPoolSlot(int iSlot)
	{
		if(iSlot < 0 || iSlot >= m_iNumGameObjectInType) {
			return;	
		}
		int iCount = m_GameObjects[iSlot].Count;
		for(int i = 0; i < iCount; i++) {
			ObjectPoolData objData = m_GameObjects[iSlot][i];
			Destroy(objData.m_go);
			m_GameObjects[iSlot][i] = null;
		}
		m_GameObjects[iSlot] = null;
	}

	public void EnableModel(GameObject go, bool beEnable)
	{
		go.SetActive (beEnable);		
	}
	
	public void ShowModel(GameObject go, bool bShow)
	{
		Renderer [] aRenders = go.GetComponentsInChildren<Renderer>();
		int iLen = aRenders.Length;
		int i;
		for(i = 0; i < iLen; i++) {
			aRenders[i].enabled = bShow;	
		}
	}
	
}
