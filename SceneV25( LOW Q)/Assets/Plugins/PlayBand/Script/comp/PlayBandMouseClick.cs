using UnityEngine;
using System.Collections;

public class PlayBandMouseClick : MonoBehaviour {
	
	public GameObject renderTarget;
	public GameObject functionTarget;
	public string functionName = "OnClick";

	public int Depth = 0;
	public int CameraIndex = 0;

	void Start ()
	{
	
	}

	void Test(GameObject obj)
	{
		PlayBandMouse.pblog("obj = " + obj.name);
	}

	void OnEnable()
	{
		if (PlayBandMouse.mapButtons.ContainsKey(transform.gameObject))
		{
			return;
		}

		if (null == renderTarget)
		{
			renderTarget = this.gameObject;
		}

		PlayBandMouse.mapButtons.Add(transform.gameObject, this);

		//更新最大depth
		if (Depth > PlayBandMouse.iMaxButtonDepth)
		{
			PlayBandMouse.iMaxButtonDepth = Depth;
		}
	}

	void OnDisable()
	{
		if (!PlayBandMouse.mapButtons.ContainsKey(transform.gameObject))
		{
			return;
		}

		PlayBandMouse.mapButtons.Remove(transform.gameObject);

		bool isUpdateDepth = true;
		
		//确认按钮中是否还有大于该层级的按钮，如果没有需要重新设定最大层级
		foreach(var tmpData in PlayBandMouse.mapButtons.Values)
		{
			if (tmpData.Depth >= Depth)
			{
				isUpdateDepth = false;
				break;
			}
		}
		if (isUpdateDepth)
		{
			int maxTmp = 0;
			//获取当前还存在的最大层级
			foreach(var tmpData in PlayBandMouse.mapButtons.Values)
			{
				if (tmpData.Depth > maxTmp)
				{
					maxTmp = tmpData.Depth;
				}
			}
			PlayBandMouse.iMaxButtonDepth = maxTmp;
		}
	}
}
