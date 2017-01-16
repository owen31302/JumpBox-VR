using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayBandMouse : MonoBehaviour {
	
	//鼠标基本配置信息
	public Camera[] cameraUI;           	//拍摄到ui的摄像机们
	public Camera mouseCamera;              //拍摄到鼠标的摄像机
	public Vector2 mouseAngleMax = new Vector2 (30f, 30f);          //鼠标上下左右最大移动角度
	public float zoomButtonRatio = 1.2f;				   	        //鼠标在当前按钮的缩放倍率           
	
	//鼠标事件回调
	public GameObject MoveInEventTarget;                            //移动进入按钮回调对象
	public string MoveInEventName;                                  //移动进入按钮回调函数名字
	public GameObject MoveOutEventTarget;                           //移动退出按钮回调对象
	public string MoveOutEventName;                                 //移动退出按钮回调函数名字
	public GameObject MoveStayEventTarget;                          //在按钮中事件回调对象
	public string MoveStayEventName;                                //在按钮中事件回调函数名字
	
	static public float fDebugLogTime = 1.0f;                       //屏幕每条log显示时间
	static public bool isOpenDebugLog = true;                      //是否打开屏幕log

	private Transform mouseCursor;          //鼠标绘制对象
	private Vector3 _vec3CurrentPosition;   //鼠标当前屏幕位置
	
	public struct PlayBandRect
	{
		public float x;
		public float y;
		public float width;
		public float height;
		
		public PlayBandRect(float tx, float ty, float twidth, float theight)
		{
			x = tx;
			y = ty;
			width = twidth;
			height = theight;
		}
		
		public bool isContainInRect(Vector2 pos)
		{
			return !(pos.x < x || pos.y < y || pos.x > x + width || pos.y > y + height);
		}
	};
	
	static public int iMaxButtonDepth = 0;
	static public Dictionary<GameObject, PlayBandMouseClick> mapButtons = new Dictionary<GameObject, PlayBandMouseClick>();   //需要被鼠标点击的按钮
	
	private int mouseUser = 0;
	
	private RaycastHit hit;
	private GameObject lastHit;
	private GameObject lastHitObj;
	private GameObject currentHitObj;
	private GameObject lastTouchObj = null;
	private GameObject currentTouchObj;

	[HideInInspector]
	public bool enableMouse = false;
	private Vector3 anglePosition = Vector3.zero;
	private Vector3 anglePositionCache = Vector3.zero;
	private PlayBandData data;
	//add by Tunshu-shaco 2015/8/28
	//无限范围内的屏幕位置
	private Vector2 _vec2UnlimitedPosition;
	//add end
	
	public void StartMouseListener ()
	{
		mouseCursor.gameObject.SetActive (true);
		enableMouse=true;
		PlayBand.OnIncomingDataEvent+=UpdateMouseCursor;
		
		PlayBand.Device1.OnFingerTriggerEvent -= OnFingerTrigger;
		PlayBand.Device1.OnFingerTriggerEvent += OnFingerTrigger;
		PlayBand.Device1.OnButtonClickedEvent -= onButtonClickCallBack;
		PlayBand.Device1.OnButtonClickedEvent += onButtonClickCallBack;
	}
	
	//
	public void StopMouseListener ()
	{
		//20150910 repair
		//gameObject.SetActive (false);
		mouseCursor.gameObject.SetActive (false);
		enableMouse = false;
		PlayBand.OnIncomingDataEvent-=UpdateMouseCursor;
		PlayBand.Device1.OnFingerTriggerEvent -= OnFingerTrigger;
		PlayBand.Device1.OnButtonClickedEvent -= onButtonClickCallBack;
		
		mapButtons.Clear();
	}
	
	//private void UpdateMouseCursor (PlayBandData data)	
	private void UpdateMouseCursor (PlayBandData[] dataList)
	{
		if (!enableMouse) {
			return;
		}		
		data=dataList[mouseUser];
		float factor = 2.0f;
		Vector3 dir = data.Rotation*Vector3.forward;
		dir *= factor;		
		dir.x = (dir.x + 1.0f)*0.5f;
		dir.y = (dir.y + 1.0f)*0.5f;
		
		var vec3UnlimitedAngle = anglePosition;
		
		anglePosition.x = Mathf.Clamp(dir.x, 0.0f, 1.0f);
		anglePosition.y = Mathf.Clamp(dir.y, 0.0f, 1.0f);
		
		anglePosition.z = mouseCamera.nearClipPlane;
		anglePosition = Vector3.Lerp (anglePosition, anglePositionCache, 0.5f);
		
		float oldZ = mouseCursor.position.z;
		var vec3NewPosition = mouseCamera.ViewportToWorldPoint(anglePosition);
		mouseCursor.position = new Vector3(vec3NewPosition.x, vec3NewPosition.y, oldZ);
		
		//unlimited screen position
		oldZ = mouseCursor.position.z;
		var vec3NewUnlimitedPosition = mouseCamera.ViewportToScreenPoint(vec3UnlimitedAngle);
		_vec2UnlimitedPosition = new Vector3(vec3NewUnlimitedPosition.x, vec3NewUnlimitedPosition.y, oldZ);
		
		anglePositionCache = anglePosition;
		
		updateRaycast(mouseCamera.WorldToScreenPoint(mouseCursor.position));
	}	
	
	//add by shaco 2015/12/25
	public Vector3 getCursorPositionLocal()
	{
		return mouseCursor.localPosition;
	}
	public Vector3 getCursorPositionWolrd()
	{
		return mouseCursor.position;
	}
	public Vector3 getCursorPositionScreen()
	{
		return _vec3CurrentPosition;
	}
	//add end
	
	//add by Tunshu-shaco 2015/8/28
	public Vector2 getCursorAnglePercentUnlimited()
	{
		return _vec2UnlimitedPosition;
	}
	//add end
	
	void Start () 
	{
		mouseCursor = transform.Find("Cursor");
		#if !UNITY_EDITOR
		PlayBand.StartMouseListener();
		#else
		isOpenDebugLog = true;
		#endif
	}

	void OnDestroy()
	{
		#if !UNITY_EDITOR
		PlayBand.StopMouseListener();
		#endif
		mapButtons.Clear();
	}
	
	void onButtonClickCallBack()
	{
		PlayBand.VibrateOnce(50, 150);
	}
	
	static private Vector3 getRealSize(Camera camera, Bounds bounds)
	{
		var vecMin = camera.WorldToScreenPoint(new Vector3(bounds.min.x, bounds.min.y, bounds.min.z));
		var vecMax = camera.WorldToScreenPoint(new Vector3(bounds.max.x, bounds.max.y, bounds.max.z));
		return new Vector3(vecMax.x - vecMin.x, vecMax.y - vecMin.y, vecMax.z - vecMin.z);
	}
	
	static public PlayBandRect GetRectByWorldPosition2D(Camera camera, GameObject obj)
	{
		PlayBandRect retRect = new PlayBandRect (0, 0, 0, 0);
		
		PlayBandMouseClick dataTmp;
		if (!mapButtons.TryGetValue(obj, out dataTmp))
			return retRect;
		
		if (null == dataTmp.renderTarget)
			return retRect;
		
		Bounds boundsTmp = new Bounds();
		var render = dataTmp.renderTarget.GetComponent<Renderer>();
		if (render)
		{
			boundsTmp = render.bounds;
		}
		var colliderTmp = dataTmp.renderTarget.GetComponent<Collider>();
		if (colliderTmp)
		{
			boundsTmp = colliderTmp.bounds;
		}
		
		if (boundsTmp.size.x == 0)
			return retRect;
		Vector3 sizeReal = getRealSize(camera, boundsTmp);
		var pos = camera.WorldToScreenPoint(dataTmp.renderTarget.transform.position);
		
		retRect = new PlayBandRect (pos.x - sizeReal.x / 2, pos.y - sizeReal.y / 2, sizeReal.x, sizeReal.y);
		return retRect;
	}
	
	//获取当前层级最高的buttons
	List<GameObject> GetMaxDepthButtons()
	{
		List<GameObject> listRet = new List<GameObject>();
		foreach(var iter in mapButtons)
		{
			if (iter.Value.functionTarget != null 
			    && iter.Value.renderTarget != null
			    && iter.Value.Depth == iMaxButtonDepth 
			    && iter.Value.gameObject.activeSelf)
			{
				listRet.Add(iter.Key);
			}
			else if (isOpenDebugLog)
			{
				if (iter.Value.functionTarget == null)
				{
					pblog("Button=" + iter.Key.transform.name + "not have function target!", "GetMaxDepthButtons");
				}
				if (iter.Value.renderTarget == null)
				{
					pblog("Button=" + iter.Key.transform.name + "not have render target!", "GetMaxDepthButtons");
				}
			}
		}
		return listRet;
	}
	
	Camera getCameraUI(GameObject obj)
	{
		PlayBandMouseClick dataOut;
		if (!mapButtons.TryGetValue (obj, out dataOut))
			return null;
		
		if (dataOut.CameraIndex < 0 || dataOut.CameraIndex >= cameraUI.Length)
		{
			return null;
		}
		
		return cameraUI [dataOut.CameraIndex];
	}
	
	private void dispatchEvent(PlayBandMouseClick click)
	{
		var listClick = click.gameObject.GetComponents<PlayBandMouseClick>();
		
		foreach(var clickData in listClick)
		{
			dispatchEvent(clickData.functionTarget,
			              clickData.functionName, 
			              lastHit.gameObject);
		}
	}
	
	private void dispatchEvent(GameObject target, string functionName, GameObject sendGameObject)
	{
		target.SendMessage(functionName, sendGameObject, SendMessageOptions.RequireReceiver);
	}
	
	void updateRaycast (Vector3 viewportPoint) 
	{
		_vec3CurrentPosition = viewportPoint;
		pblog ("mousePosition x=" + _vec3CurrentPosition.x + " y=" + _vec3CurrentPosition.y + " z=" + _vec3CurrentPosition.z, "mousePosition", true);
		
		lastHit = null;
		var listValidButton = GetMaxDepthButtons();
		foreach(GameObject obj in listValidButton)
		{
			var cameraTmp = getCameraUI(obj);
			if (null == cameraTmp)
			{
				pblog(obj.name + ":  not find ui camera!!!");
				continue;
			}
			
			PlayBandRect rectTmp = GetRectByWorldPosition2D(cameraTmp, obj);
			
			if (rectTmp.isContainInRect(new Vector2(_vec3CurrentPosition.x, _vec3CurrentPosition.y)))
			{
				pblog("Lasthit name=" + obj.transform.name + " x=" + obj.transform.localPosition.x + " y=" + obj.transform.localPosition.y + " width=" + rectTmp.width + " height=" + rectTmp.height, "LastHit", true);
				lastHit = obj;
				break;
			}
		}
		
		if (lastHit)
		{
			currentTouchObj = lastHit;
			
			if(lastHitObj == currentTouchObj){
				return;
			};
			
			if(lastTouchObj != currentTouchObj){
				lastHitObj=null;
				if(lastTouchObj!=null)
				{
					lastTouchObj.transform.localScale/=zoomButtonRatio;
				}
				else
				{
					
				}
				currentTouchObj.transform.localScale*=zoomButtonRatio;
				if (MoveInEventTarget)
				{
					pblog("moveInTarget!!!!!!!", "moveEvent");
					dispatchEvent(MoveInEventTarget, MoveInEventName, currentTouchObj);
				}

				lastTouchObj=currentTouchObj;
			};
		}	
		else 
		{
			if(lastTouchObj!=null)
			{
				lastTouchObj.transform.localScale/=zoomButtonRatio;
				if (MoveOutEventTarget)
				{
					pblog("moveOutTarget!!!!!!!", "moveEvent");
					dispatchEvent(MoveOutEventTarget, MoveOutEventName, currentTouchObj);
				}
			}
			lastTouchObj=null;
			lastHitObj=null;
			currentTouchObj = null;
		}
		
		if (MoveStayEventTarget && currentTouchObj)
		{
			pblog("moveStayEventTarget!!!!!!!", "moveEvent");
			dispatchEvent(MoveStayEventTarget, MoveStayEventName, currentTouchObj);
		}
	}
	
	public void OnFingerTrigger(PlayBandData data)
	{
		pblog("--------------OnFingerTrigger-----------", "OnFingerTrigger");
		if (lastHit)
		{
			PlayBandMouseClick clickData;
			if (mapButtons.TryGetValue(lastHit.gameObject, out clickData))
			{
				//调用对应object的function
				pblog("clickbutton function=" + clickData.functionName + "  target=" + clickData.functionTarget.transform.name + " button=" + lastHit.transform.name);
				dispatchEvent(clickData);	
			}
		} 
	}
	
	//add by shaco 2015/12/3
	public struct LogData
	{
		public bool isLoop; 
		public string msg;
	};
	static private Dictionary<string, LogData> _strListLog = new Dictionary<string, LogData>();
	private float _fLabelHeight = 0;
	static public void pblog(string msg, string msgKey = "", bool isLoop = false)
	{
		if (isOpenDebugLog)
		{
			var dataTmp = new LogData();
			dataTmp.msg = msg;
			dataTmp.isLoop = isLoop;
			
			if (_strListLog.ContainsKey(msgKey))
			{
				_strListLog[msgKey] = dataTmp;
			}
			else 
			{
				_strListLog.Add(msgKey, dataTmp);
				
				var mouse = getPlayBandMouse();
				if (mouse)
				{
					mouse.CancelInvoke("delayRemoveLogs");
					mouse.InvokeRepeating("delayRemoveLogs", fDebugLogTime, fDebugLogTime);
				}
			}
		}
	}
	
	void delayRemoveLogs()
	{
		//每隔x秒移除第一个log
		if (_strListLog.Count > 0)
		{
			foreach(var iter in _strListLog)
			{
				if (!iter.Value.isLoop)
				{
					_strListLog.Remove(iter.Key);
					break;
				}
			}
		}
	}
	
	static private PlayBandMouse getPlayBandMouse()
	{
		var objMouse = GameObject.Find("PlayBandMouse");
		if (objMouse)
		{
			return objMouse.GetComponent<PlayBandMouse>();
		}
		else
			return null;
	}
	
	void Update()
	{
		//如果log超出了屏幕就全部清空
		if (isOpenDebugLog)
		{
			if (_strListLog.Count * _fLabelHeight >= Screen.height)
			{
				_strListLog.Clear ();
			}
		}
		
		#if UNITY_EDITOR
		float oldZ = mouseCursor.position.z;
		mouseCursor.position = mouseCamera.ScreenToWorldPoint (Input.mousePosition);
		mouseCursor.position = new Vector3(mouseCursor.position.x, mouseCursor.position.y, oldZ);
		
		_vec2UnlimitedPosition = Input.mousePosition;
		updateRaycast(Input.mousePosition);
		
		if (Input.GetMouseButtonUp(0))
		{
			OnFingerTrigger(null);
		}
		#endif
	}
	
	void OnGUI()
	{
		if (isOpenDebugLog)
		{
			GUI.skin.label.fontSize = 24;
			_fLabelHeight = 40;

			GUI.skin.label.normal.textColor = new Color(0, 0, 0); 
			foreach(var value in _strListLog.Values)
			{
				GUILayout.Label(value.msg, GUILayout.Width(Screen.width));
			}
		}
	}
}