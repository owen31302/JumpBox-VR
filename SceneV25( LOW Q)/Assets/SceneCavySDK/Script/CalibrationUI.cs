using UnityEngine;
using System.Collections;
using System;

public class CalibrationUI : MonoBehaviour
{
	public Action OnCalibratedEvent;
	public Action OnConnectedEvent;
	public bool doCalibration=true;
	public float passAlignTime=1.5f;
	public float warningTime=2.5f;
	public GameObject connectUI;
	public GameObject alignmentUI;

	public GameObject warningUI;
	public GameObject warningUI1;
	public GameObject warningUI2;
	public GameObject warningUI3;
	public GameObject mouseCursor;
	public GameObject mouseCursorAlign;

	public GameObject[] mouseStatus;
	public Animator alignmentAnimator;
	[HideInInspector]
	public bool calibrated=false;
	//
	private Vector3 cursorEuler=Vector3.zero;
	private Vector3 cursorPos=Vector3.zero;
	private bool[] allowRange=new bool[2];
	private bool inAlignRange=false;
	private float alignAngelRange=12f;
	private float alignTime=0f;
	private float startAlignTime=0f;
	
	//add by Tunshu-shaco 2015/9/23
	private static bool _isCorrectStep = false;
	//add end

	int range;
	void Start()
	{
		_isCorrectStep = false;
		range = UnityEngine.Random.Range (0,4);
		showUI(true,false,false);
	}
	
	void OnDestroy()
	{
		PlayBand.OnConnectResultEvent -= Step2_OnConnectResult;
		PlayBand.Device1.OnIncomingDataEvent -= ReceiveBandData;
		//PlayBand.Device1.OnButtonClickedEvent -= Step4_OnUserAligned;
	}
	
	public void Connect(){

		PlayBandInvoke.Invoke(this, Step1_Connect, 0.5f);
	}

	private void Step1_Connect(){

		calibrated=false;
		if(!PlayBand.Device1.connected){
			PlayBand.OnConnectResultEvent += Step2_OnConnectResult;
			StartConnect();
		}else{
			Step2_1_OnWarning();
		}
	}

	//20150728
	private void StartConnect() {
		showUI(true,false,false);
		PlayBand.Connect();
	}

	//20150728
	public void Step2_OnConnectResult(PlayBandConnectData result)
	{
		if(result.status==PlayBandConnectStatus.Success){
			PlayBand.OnConnectResultEvent -= Step2_OnConnectResult;
			Step2_1_OnWarning();
		}else if(result.status==PlayBandConnectStatus.Failed){
		}else if(result.status==PlayBandConnectStatus.DeviceFailed){
		}else if(result.status==PlayBandConnectStatus.NoBracelet){
			PlayBandInvoke.Invoke(this, StartConnect, 1.0f);
		}else if(result.status==PlayBandConnectStatus.Disconnect){

		}else if(result.status==PlayBandConnectStatus.Connecting){
		}
	}
	
	//
	public void Step2_1_OnWarning()
	{
		showUI(false,false,true);
		PlayBandInvoke.Invoke(this, Step2_2_OnWarningOver,warningTime);
	}

	public void Step2_2_OnWarningOver()
	{
		if (OnConnectedEvent != null) {
			OnConnectedEvent ();
		}
		if(doCalibration){
			PlayBandInvoke.Invoke(this, Step3_WaitUserAlignment, 1f);
		}
	}
	//
	private void Step3_WaitUserAlignment(){
		showUI(false,true,false);
		startAlignTime=Time.time;
		PlayBand.Device1.OnIncomingDataEvent += ReceiveBandData;
		//PlayBand.Device1.OnButtonClickedEvent+=Step4_OnUserAligned;
		_isCorrectStep = true;
	}
	
	public static bool isCorrectStep()
	{
		return _isCorrectStep;
	}

	public void ReceiveBandData(PlayBandData data)
	{
		allowRange[0]=Mathf.Abs(data.EulerAngles.z)<alignAngelRange;
		allowRange[1]=Mathf.Abs(data.EulerAngles.y)<alignAngelRange;
	    cursorEuler.z=allowRange[0]?0:data.EulerAngles.z;
	    cursorPos.y=allowRange[1]?0:Mathf.Clamp(-data.EulerAngles.y*0.028f,-2.5f,2.5f);
		mouseCursor.transform.localRotation=Quaternion.Lerp(mouseCursor.transform.localRotation,Quaternion.Euler(cursorEuler),0.5f);
		mouseCursor.transform.localPosition=Vector3.Lerp(mouseCursor.transform.localPosition,cursorPos,0.5f);
		//
		inAlignRange=allowRange[0] && allowRange[1];
		if(inAlignRange){
			alignTime=(Time.time-startAlignTime);
			mouseCursorAlign.SetActive(false);
		}else{
			alignTime=0f;
			startAlignTime=Time.time;
			mouseCursorAlign.SetActive(true);
		}

		setMousStatus(inAlignRange);

		if(alignTime>=passAlignTime){
			alignTime=0f;
			Step4_OnUserAligned();
		}
	}
	//
	private void Step4_OnUserAligned(){
		PlayBand.Device1.OnIncomingDataEvent -= ReceiveBandData;
		//PlayBand.Device1.OnButtonClickedEvent-=Step4_OnUserAligned;
		calibrated=true;
		Step5_CallGameStart();
	}
	
	private void Step5_CallGameStart ()
	{
		if (OnCalibratedEvent != null) {
			OnCalibratedEvent ();
		}
	}
	//
	private void showUI(bool showConnect,bool showAlignment,bool showWarning){
		if(connectUI.activeSelf!=showConnect){
			connectUI.SetActive(showConnect);
		}

		if(alignmentUI.activeSelf!=showAlignment){
			alignmentUI.SetActive(showAlignment);
		}
		switch (range)
		{
			case 0:
				if(warningUI.activeSelf!=showWarning){
					warningUI.SetActive(showWarning);
				}
			break;
			case 1:
				if(warningUI1.activeSelf!=showWarning){
					warningUI1.SetActive(showWarning);
				}
			break;
			case 2:
				if(warningUI2.activeSelf!=showWarning){
					warningUI2.SetActive(showWarning);
				}
			break;
			case 3:
				if(warningUI3.activeSelf!=showWarning){ 
					warningUI3.SetActive(showWarning);
				}
			break;
			default:
				if(warningUI.activeSelf!=showWarning){
					warningUI.SetActive(showWarning);
				}
			break;
		}


//		if(warningUI.activeSelf!=showWarning){
//			warningUI.SetActive(showWarning);
//		}

		setMousStatus(false);
	}

	private void setMousStatus(bool inAlignRange){
//			mouseStatus[0].SetActive(!inAlignRange);
//			mouseStatus[1].SetActive(inAlignRange);
//		    alignmentAnimator.SetBool("Aligned",inAlignRange);
	}
	
}