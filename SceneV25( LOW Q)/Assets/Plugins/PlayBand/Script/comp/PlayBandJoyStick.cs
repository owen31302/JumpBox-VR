using UnityEngine;
using System.Collections;

public class PlayBandJoyStick : MonoBehaviour {
	
	public GameObject CircleBiger;
	public GameObject CircleSmall;
	public GameObject RedCircle;
	
	public Camera PlayBandCamera;
	public GameObject CircleObj;
	//[HideInInspector]
	private float greenCircleRadio=1.4f;
	public float bigCircle=25.0f;
	public float samllCircle=15.0f;
	float mouseAngleMax = 30.0f;
	
	Vector3 CursorAnglePosition;
	Vector2 _vec2CursorPosition;
	public PlayBandMouse playBandMouse;
	[HideInInspector]
	public Vector3 roution;
	public float joyAngle;
	[HideInInspector]
	public float Radian;
	public Vector2 joyUnitVector;
	[HideInInspector]
	public bool isSamllCircleTrigger=false;
	public int HowManyDir=1;//支持几个方向
	public int range;//鼠标所在的区域
	
	float PI=3.14159f;//Mathf.PI
	Vector3 position;
	float _fAverageWidthAndHeight;
	
	public bool isLockCenter=true;//true 锁定中心	

	float pixelOnelength;
	void Start () {

		position = RedCircle.transform.localPosition;
		
		if(playBandMouse==null )
		{
			if(GameObject.Find ("PlayBandMouse"))
			{
				playBandMouse=GameObject.Find ("PlayBandMouse").GetComponent<PlayBandMouse>()as PlayBandMouse;
			}
		}	

		mouseAngleMax = playBandMouse.mouseAngleMax.x;
		_fAverageWidthAndHeight =(1.0f+Screen.width/Screen.height)/2;
		pixelOnelength = Screen.height / 10;
		//_fAverageWidthAndHeight = (Screen.width + Screen.height) / 2;
		float fPrePixelAngle = _fAverageWidthAndHeight / mouseAngleMax;
		Vector3 scale=Vector3.one;
		scale.x= fPrePixelAngle * bigCircle;
		scale.z = scale.x;
		CircleBiger.transform.localScale = scale;
		scale.x= fPrePixelAngle * samllCircle;
		scale.z = scale.x;
		CircleSmall.transform.localScale = scale;
	}

	void OnDestroy()
	{
	}

//	void on4WayTrigger(PlayBandDirection dir, PlayBandData data)
//	{
//		Application.LoadLevel("1");
//	}
	
	Vector2 vec2CenterCircle;
	Vector2 vec2CenterToCursor;
	float fAngle;
	Vector2 vec2_1;
	
	void Update()
	{
		CursorAnglePosition = playBandMouse.getCursorAnglePercentUnlimited();

		_vec2CursorPosition = new Vector2(1 * CursorAnglePosition.x, 
		                                  1 * CursorAnglePosition.y);

		//圆心位置
		vec2CenterCircle = CircleBiger.transform.position;
		vec2CenterCircle = PlayBandCamera.WorldToScreenPoint(CircleBiger.transform.position);
		
		//圆心到鼠标的向量
		vec2CenterToCursor = _vec2CursorPosition - vec2CenterCircle;
		
		//垂直向上的向量(用于计算角度值)
		Vector2 vec2Origin = new Vector2(vec2CenterCircle.x, vec2CenterCircle.y + CircleBiger.transform.localScale.x / 2);
		
		vec2_1 = vec2Origin - vec2CenterCircle;
		fAngle = Vector2.Angle(vec2_1, vec2CenterToCursor);
		
		bool isLeftAngle = _vec2CursorPosition.x < vec2CenterCircle.x;
		fAngle = isLeftAngle ? fAngle : -fAngle;
		
		//左下角红点的位置和角度
		roution.y = -fAngle;
		joyAngle = roution.y;
		RedCircle.transform.localRotation = Quaternion.Euler (roution);
		Radian = fAngle / 180 * PI;
		
		
		//鼠标位置是否在小圆范围内
		if(vec2CenterToCursor.magnitude >= pixelOnelength*10*CircleSmall.transform.localScale.x / 2)
		{
			isSamllCircleTrigger=true;
			if(HowManyDir==0)
			{
				position.x =0;
				position.z =0;
				RedCircle.transform.localPosition = position;				
			}
			if(HowManyDir==1)//任意方向
			{
				position.x = greenCircleRadio*Mathf.Sin(Radian);
				position.z = -greenCircleRadio*Mathf.Cos(Radian);
				RedCircle.transform.localPosition = position;
			}
			else if(HowManyDir>=2)
			{
				ForHowManyDirWay (Radian);
			}		
		}
		else 
		{		
			range=HowManyDir+1;
			isSamllCircleTrigger=false;
			position.x=0;
			position.z=0;
			RedCircle.transform.localPosition = position;	
		}

		if(isLockCenter==false)
		{		
			float sizeCrileBiger = pixelOnelength*10*CircleBiger.transform.localScale.x / 2;
			//当鼠标位置在大圆范围外
			if((int)vec2CenterToCursor.magnitude >= (int)sizeCrileBiger)
			{			
				float addLength = vec2CenterToCursor.magnitude - sizeCrileBiger;
				addLength -= 1;
				if (addLength <= 0)
					addLength = 0;

				Vector2 delta;
				delta.x=-addLength*Mathf.Sin(Radian)*10/Screen.height;
				delta.y=addLength*Mathf.Cos(Radian)*10/Screen.height;
				Vector3 vec3BigCircle = CircleObj.transform.localPosition;
				vec3BigCircle.x+=delta.x;
				vec3BigCircle.y+=delta.y;			
				CircleObj.transform.localPosition = vec3BigCircle;
			}
		}		
		joyUnitVector.x = -Mathf.Sin (Radian);
		joyUnitVector.y = Mathf.Cos (Radian);
	}
	
	void ForHowManyDirWay(float Radian)//指针所在的方向
	{
		float asd = PI/HowManyDir;// 0.7853982f=pi/4;
		for(int i=0;i<HowManyDir;i++)
		{
			float left=asd+2*i*asd;
			float right=-asd+2*i*asd;
			if(Radian > right && Radian <= left)
			{
				range=i+1;
				Radian=(left+right)/2;
				break;
			}
			
			right=-asd-2*i*asd;
			left=asd-2*i*asd;
			if(Radian >= right && Radian < left)
			{
				range=HowManyDir-i+1;
				Radian=(left+right)/2;
				break;
			}
		}
		roution.y = Radian*57.2958f;//180/PI ; Mathf.Rad2Deg
		joyAngle = roution.y;
	}
}
