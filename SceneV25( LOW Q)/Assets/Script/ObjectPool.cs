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
	
	
	public int InitObjectsInPool(Object obj, int iCount)         //��b��shoot�̭����ܡAobj�N�O�l�u��Prefab(�]�N�O�ڭn���ƨϥΤl�u)�AiCount�N�O�ڳ̦h�o��Scene�|��iCount���l�u
    {
		int iSlot = FindEmptySlot();                            /*��X�Ū�slot�A�̭����@��list�Alist�̭��C�Ӧ�m��ObjectPoolData�i�H�s��ӪF��(����Prefab:m_go    �O�_���Q�ϥ�m_bUsing)
                                                                  �A�õ��w�n�ͦ����ƶqiCount�A�ç�ͦ������������Ʃ�JobjData(new�X�Ӫ�ObjectPoolData)�A�̫�slot�̭���list�̭��|��50��objData*/

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
			ObjectPoolData objData = m_GameObjects[iSlot][i];             //�o�ӪF��N���iSlot�̭�list����i�Ӥ���            (�G���}�C)
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
