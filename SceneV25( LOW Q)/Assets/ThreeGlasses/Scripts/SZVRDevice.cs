/* */

using System;
using System.Collections;
using UnityEngine;
using SZVR_SDK;

public class SZVRDevice : MonoBehaviour
{
	[HideInInspector]
	public Camera leftEyeCamera;
	[HideInInspector]
	public Camera rightEyeCamera;

	public float nearClipPlane = 0.03f;
	public float farClipPlane = 1000.0f;

	private float rotationY = 0.0f;

    private Quaternion hmdOrientation;
    public Quaternion orentationOffset;
    public static Quaternion sensorOffset = Quaternion.identity;
	public static Quaternion direction = Quaternion.identity;

    private Vector2 touchPosition;

	public Transform followTarget;
	public float eyeToNeckHeight;

	private SZVRCanvas canvas;

    private float updateInterval = 0.5f;
    private float accum = 0.0f;
    private float frames = 0;
    private float timeleft;

    public static bool IsSensorAttach = false;
    public static bool IsTouchPadAttach = false;

    public bool SetInitAngle = false;

    private bool m_IsTouch = false;
    private float time = 0.0f;
    public bool IsTouch 
    { 
        get
        {
            return m_IsTouch;
        }
        set
        {
            m_IsTouch = value;
        }
    }

    private bool m_touchStart = true;
    private float m_touchTimer = 0.0f;

    private int touchCounts = 0;

    void Awake()
    {
        orentationOffset = gameObject.transform.rotation;
        DeviceInterface.SetPositionAndReslution();
    }

	void Start ()
	{
		canvas = gameObject.GetComponent<SZVRCanvas>();
		if(canvas == null)
			canvas = gameObject.AddComponent<SZVRCanvas>();
		canvas.CreateRenderTexture();

		//You can manually add two names were LeftEye and RightEye camera.
        leftEyeCamera = SimulationEye("LeftEye", -DeviceInterface.ipd, -1);
        rightEyeCamera = SimulationEye("RightEye", DeviceInterface.ipd, -2);

        hmdOrientation = Quaternion.identity;
        touchPosition = Vector2.zero;

		if(leftEyeCamera != null && rightEyeCamera != null)
		{
			leftEyeCamera.transform.localPosition += new Vector3(0.0f, eyeToNeckHeight, 0.0f);
			rightEyeCamera.transform.localPosition += new Vector3(0.0f, eyeToNeckHeight, 0.0f);
		}

        timeleft = updateInterval;
        DeviceInterface.ResetInitOrientation();
	}

	private Camera SimulationEye(string name, float ipd, int depth)
	{
		Transform tran = transform.FindChild(name);

		if(tran == null)
		{
			tran = new GameObject(name).transform;
#if UNITY_5
			tran.SetParent(transform);
#else
			tran.parent = transform;
#endif
		}
		tran.localPosition = new Vector3(0.5f*ipd,0,0);
		Camera cam = tran.GetComponent<Camera>();
		if(cam == null)
			cam = tran.gameObject.AddComponent<Camera>();
		cam.depth = depth;
        //cam.fieldOfView = DistortionMesh.GetFOV().y;
        cam.fieldOfView = 96.09097f;
		cam.nearClipPlane = nearClipPlane;
		cam.farClipPlane = farClipPlane;
		if(name.Equals("LeftEye"))
			cam.rect = new Rect(0,0,0.5f,1);
		else
			cam.rect = new Rect(0.5f,0,0.5f,1);

		cam.renderingPath = canvas.cameraRenderingPath;
		cam.targetTexture = canvas.cameraTexture;

		return cam;
	}

	void Update ()
	{
        GetDeviceData();
        SetHmdCameraFunction();
        TouchFunction();
        ResetOrientation();
	}

    private void ResetOrientation()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            DeviceInterface.ResetInitOrientation();
            Debug.Log("12312312");
        }
    }

    private void GetDeviceData()
    {
        IsSensorAttach = DeviceInterface.GetCameraOrientation(ref hmdOrientation);
        IsTouchPadAttach = DeviceInterface.GetTouch(ref touchPosition);
    }

    private void SetHmdCameraFunction()
    {
        if (IsSensorAttach)
        {
            if (followTarget != null)
                direction = followTarget.rotation * orentationOffset * sensorOffset * hmdOrientation;
            else
                direction = orentationOffset * sensorOffset * hmdOrientation;

            transform.rotation = direction;
        }
    }

    private void TouchFunction()
    {
        if (IsTouchPadAttach)
        {
            if (touchPosition.x == -1 && touchPosition.y == -1)
            {
                //Debug.Log("exit");
                touchCounts = 0;
            }
            else
            {
                if (Time.realtimeSinceStartup - time <= 0.2f)
                {
                    m_touchTimer += Time.deltaTime;

                    if (m_touchTimer < 0.2f)
                    {
                        touchCounts++;
                        m_IsTouch = false;
                        if (!m_IsTouch)
                        {
                            if (touchCounts == 1)
                            {
                                Debug.Log("Testing!");
                                m_IsTouch = true;
                            }
                        }
                    }
                    else
                    {
                        touchCounts = 0;
                    }
                }
                time = Time.realtimeSinceStartup;
                //Debug.Log("DoubleTouchTimer:" + doubleTouchTimer);
            }
        }
    }

    public string ShowFps()
    {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        ++frames;

        if (timeleft <= 0.0)
        {
            return (accum / frames).ToString("f2");
            //timeleft = updateInterval;
            //accum = 0.0f;
            //frames = 0;
        }
        else
        {
            return "0";
        }
    }
}
