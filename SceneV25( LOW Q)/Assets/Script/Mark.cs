using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mark : MonoBehaviour
{
    public static Mark _instiate;
    private Vector3 _lastInputWorldPos;
	private float BornTime = 5.0f;
	private float Counter = 0.0f;
	public float timer = 0.0f;
    //------CSManager
	float Elervation = 0.6f;
    public GameObject ThrowPosition;
	public float _Speed ;
	public float rotationx;
	public float rotationy;

    //------
    void Awake()
    {
        _instiate = this;
    }

    void Update()
    {
        if (timer > 0) {
			timer -= Time.deltaTime;
		} else if (timer < 0) {
			timer = 0;
		}
        // do state
        if (PlayBandTest.Instance.currentThrowState == ThrowStates2.THROWSTOP && timer == 0) 
        //if(Input.GetKeyDown("k"))
        {
			//catch camera Rx,Ry
			rotationx = CorrectionSystemManager._instance.UserCamera.transform.rotation.eulerAngles.x;
			rotationy = CorrectionSystemManager._instance.UserCamera.transform.rotation.eulerAngles.y;
			// do THROWSTOP
			timer = 0.3f;
			Pingpongpool._instance._fiftyBall = ObjectPool.m_Instance.LoadObjectFromPool (0);
            Pingpongpool._instance._fiftyBall.transform.position = this.transform.position;
			Pingpongpool._instance._rigigdbodyBall = Pingpongpool._instance._fiftyBall.GetComponent<Rigidbody> ();
			//Do CS
			ThrowPosition.transform.rotation = new Quaternion();
			ThrowPosition.transform.Rotate(0.0f, rotationy, 0.0f, Space.World);
			ThrowPosition.transform.Rotate(rotationx, 0.0f, 0.0f, Space.Self);
            _Speed = PlayBandTest.Instance._power;

            //隨機進入
            CorrectionSystemManager._instance.Doornot = Random.Range(CorrectionSystemManager._instance.Min, CorrectionSystemManager._instance.Max);
            if(CorrectionSystemManager._instance.Doornot >= CorrectionSystemManager._instance.DoValve)
            {
            CorrectionSystemManager._instance.DoCorrectionTestVersion();
            }
            // correcting angle
            Vector3 forward = (ThrowPosition.transform.forward + Elervation * ThrowPosition.transform.up - 0.0f * ThrowPosition.transform.right).normalized;
			Pingpongpool._instance._rigigdbodyBall.useGravity = true;
            Pingpongpool._instance._rigigdbodyBall.velocity = forward * _Speed;
		}
    }
}
