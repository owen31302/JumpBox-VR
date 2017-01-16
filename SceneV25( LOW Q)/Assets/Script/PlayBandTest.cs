using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public enum ThrowStates2
{
    NOTHING = 0,
    HANDUPCONTINUE,
    HANDUPSTOP,
    THROWCONTINUE,
    THROWSTOP,
	TURNLEFT,
	LEFT,
	TURNRIGHT,
	RIGHT,
}

public class PlayBandTest : MonoBehaviour {

    // Control object
    private GameObject go;
    public static PlayBandTest Instance;

    public float PowerCoefficient = 4.0f;

    // UI
    public bool flag;
    public bool shakeFlag = false;
    private float countDownTimer;

    // Ring
    public PlayBandData m_PlayBandData;

    // RotationVelocity
    private Vector3 previousRotation;
    private AngularVelocity mRotationVelocity;

    // RotationAcceleration
    private AngularVelocity previousRotationVelocity;
    private AngularAcceleration mRotationAcceleration;
    private bool isFirst = true;
    private bool isSecond = true;

    // timer
    private float _time;
    private float _lastTime;
    public float deltaTime { get { return _time - _lastTime; } }

    // remove 0 angular velocity
    private Vector3 previousEulerVelocity;

    public GameObject GO { get { return go; } set { go = value; } }

    // Throw
    public ThrowStates2 currentThrowState = ThrowStates2.NOTHING;
    public ThrowStates2 lastThrowState = ThrowStates2.NOTHING;
    private int continueCounter = 0;
    private int ShortThrowCounter = 0;
    private float lastValue = 0;
    private float maxValue;
    private float ShortThrowMaxValue = 0;
    private float ShortThrowSumTwoAngularVelocity = 0;
    private int stages = 0;
    private float[] Az_history;
    private float[] Vz_history;
    private int history_index = 5;
    private List<string> log_history;

    //power
    public float _power = 0;

    // Eular
    public AngularAcceleration EularAcceleration { get { return mRotationAcceleration; } }
    public Vector3 EularAngle { get { return m_PlayBandData.EulerAngles; } }
    public AngularVelocity EularVelocity { get { return mRotationVelocity; } }

    // data record
    private bool dataFlag = false;
    private bool buttonFlag = false;

    // facing
    public GameObject camera;

    // controller
    public bool left = false;
    public bool right = false;
    public bool click = true;
    public bool click_block = true;
    private int clickCounter;
    private int LeftContinueCounter = 0;
    private int RightContinueCounter = 0;
    private string controlMessage = "";
    private float controlCountDownTimer = 0;


    public float AccelerationMagnitude
    {
        get {
            return m_PlayBandData.Acceleration.x * m_PlayBandData.Acceleration.x +
                m_PlayBandData.Acceleration.y * m_PlayBandData.Acceleration.y +
                m_PlayBandData.Acceleration.z * m_PlayBandData.Acceleration.z;
        }
    }

    void Awake()
    {
        Instance = this;
        log_history = new List<string>();
        
    }

    void Start() {
        PlayBand.Device1.OnIncomingDataEvent += ReceiveData;
        m_PlayBandData = new PlayBandData();
        countDownTimer = 0;
        _time = 0;
        _lastTime = 0;
        clickCounter = 0;
        Az_history = new float[history_index];
        Vz_history = new float[history_index];
        history_index = 0;
        maxValue = 0.0f;
    }

    void Update()
    {
        if (_time != _lastTime)
        {
            if (mRotationVelocity != null)
            {
                if ((mRotationVelocity.y != 0) || (previousEulerVelocity.y == 0) && (mRotationVelocity.y == 0))
                {
                    mRotationAcceleration = Angular.getRotationAcceleration(mRotationVelocity, ref previousRotationVelocity);

                    // FSM
                    if (flag)
                    {
                        ThrowFSM();
                    }
                }
                previousEulerVelocity.y = mRotationVelocity.y;
            }
        }
        _lastTime = _time;
    }

    void ThrowFSM()
    {
        // print status
        if (currentThrowState != lastThrowState)
        {
            Debug.Log("********: " + currentThrowState);
            log_history.Add("********: " + currentThrowState);
            lastThrowState = currentThrowState;
        }
        switch (currentThrowState)
        {
            case ThrowStates2.NOTHING:
                // do NOTHING
                /* Debug.Log("-------------------------------------------------");
                 Debug.Log("Acceleration.z: " + m_PlayBandData.Acceleration.z);
                 Debug.Log("Acceleration.y: " + m_PlayBandData.Acceleration.y);
                 Debug.Log("mRotationVelocity.y: " + mRotationVelocity.y);
                 Debug.Log("deltaTime: " + deltaTime);*/
                // slow rotation velocity
                if (mRotationVelocity.y < -1.0f && m_PlayBandData.EulerAngles.y < 0)
                {
                    continueCounter++;
                }
                else {
                    continueCounter = 0;
                }
                // fast rotation velocity
                if (mRotationVelocity.y < -10.0f) {
                    continueCounter = 4;
                }

                // check HANDUPCONTINUE state
                if (continueCounter > 3)
                {
                    currentThrowState = ThrowStates2.HANDUPCONTINUE;
                    continueCounter = 0;
                    _power = 0;
                    lastValue = 0;
                    maxValue = 0.0f;
                    ShortThrowCounter = 0;
                    ShortThrowSumTwoAngularVelocity = 0;
                    ShortThrowMaxValue = 0;
                    stages = 0;
                    history_index = 0;
                    log_history.Clear();
                }
                break;
            case ThrowStates2.HANDUPCONTINUE:
                // do HANDUPCONTINUE
                //Debug.Log("-------------------------------------------------");
                //Debug.Log("Acceleration.z: " + m_PlayBandData.Acceleration.z);
                //Debug.Log("Velocity.z: " + m_PlayBandData.Velocity.z);
                //Debug.Log("mRotationVelocity.y                        : " + mRotationVelocity.y);
                //Debug.Log("deltaTime: " + deltaTime);
                log_history.Add("-------------------------------------------------");
                log_history.Add("Acceleration.z: " + m_PlayBandData.Acceleration.z);
                log_history.Add("Velocity.z: " + m_PlayBandData.Velocity.z);
                log_history.Add("mRotationVelocity.y                        : " + mRotationVelocity.y);
                log_history.Add("deltaTime: " + deltaTime);


                // Check THROWCONTINUE
                // 利用角速度來判斷出手
                // 長時間角速度變化(正常力與小力)

                // 記錄最後5個Az
                Az_history[history_index] = m_PlayBandData.Acceleration.z;
                Vz_history[history_index] = m_PlayBandData.Velocity.z;
                history_index++;
                if (history_index >= Az_history.Length)
                {
                    history_index = 0;
                }

                if (mRotationVelocity.y > 30) {
                    continueCounter += 2;
                }
                else if (mRotationVelocity.y > 4.0f)
                {
                    continueCounter++;
                }
                else if ((mRotationVelocity.y == 0) && (continueCounter >= 1))
                { //濾掉雜訊
                    continueCounter++;
                }
                else {
                    maxValue = 0.0f;
                    continueCounter = 0;
                }

                if (continueCounter >= 3)
                {
                    for (int i = 0; i < Az_history.Length; i++) {
                        if (Vz_history[i] * 200.0f > maxValue) {
                            maxValue = Vz_history[i] * 200.0f;
                        }
                    }

                    if (maxValue > 0.1f)
                    {
                        _power = maxValue;
                        Debug.Log("****_power: " + _power);
                        log_history.Add("****_power: " + _power);
                        currentThrowState = ThrowStates2.THROWSTOP;
                        continueCounter = 0;
                    }
                    else {
                        Debug.Log("Back!!!!");
                        log_history.Add("Back!!!!: " + _power);
                        //currentThrowState = ThrowStates2.NOTHING;
                        continueCounter = 0;
                    }
                }


                break;
            case ThrowStates2.THROWSTOP:
                /*Debug.Log("-------------------------------------------------");
                Debug.Log("Acceleration.z: " + m_PlayBandData.Acceleration.z);
                Debug.Log("Acceleration.y: " + m_PlayBandData.Acceleration.y);
                Debug.Log("mRotationVelocity.y: " + mRotationVelocity.y);
                Debug.Log("deltaTime: " + deltaTime);*/
                // return to NOTHING
                //Save(log_history);
                currentThrowState = ThrowStates2.NOTHING;
                break;
        }
    }

    public void ReceiveData(PlayBandData data)
    {
        _time = Time.time;

        // AngularVelocity
        if (isFirst)
        {
            previousRotation = data.EulerAngles;
            isFirst = false;
        }
        else {
            mRotationVelocity = Angular.getRotationVelocity(data, ref previousRotation);
            if (isSecond)
            {
                previousRotationVelocity = mRotationVelocity;
                isSecond = false;
            }
        }
        m_PlayBandData = data;
    }

    private void Save(List<string> log) {
        string temp = "";
        for (int i = 0; i < log.Count; i++) {
            temp = temp + log[i] + "\n";
        }
        System.DateTime now = System.DateTime.Now;
        string date = now.Year + "-" + now.Month + "-" + now.Day + "-" + now.Hour + "-" + now.Minute + "-" + now.Second;
        string FILE_NAME = "BandData-" + date + ".txt";
        System.IO.File.WriteAllText(Application.persistentDataPath + "_" + FILE_NAME, temp);
        Debug.Log(Application.persistentDataPath);
    }

}
