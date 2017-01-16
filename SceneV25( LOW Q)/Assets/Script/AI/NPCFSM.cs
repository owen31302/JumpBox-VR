using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum DogStates{
    WANDER = 0,
    CATCHBALL,
    TURNBACK
}

public class NPCFSM : MonoBehaviour {

	static public NPCFSM _instance;

	public AIdata _AIData;
    public WanderGizmos WG;
    //private GameObject[] obstacles;

    // Animations
    private Animation animation;
    private List<AnimationState> states;

    // Dog States
    public DogStates currentDogStates;

    public bool left = false;
    public bool right = false;
    public bool center = false;

    // TurnBack
    private Vector3 backDirVector;

    private float countDownTimer;

    // Use this for initialization
    void Awake () {
        _instance = this;
		_AIData = new AIdata ();
        _AIData.turning_factor = 3.0f;
        _AIData.forwardCollisionProbeLength = 1.0f;
		WG = gameObject.GetComponent<WanderGizmos> ();
        currentDogStates = DogStates.WANDER;
        countDownTimer = 0;

        animation = GetComponent<Animation>();

        // Set all animations to loop
        animation.wrapMode = WrapMode.Loop;
        // except shooting
        //animation["attack"].wrapMode = WrapMode.Once;

        // Put idle and walk into lower layers (The default layer is always 0)
        // This will do two things
        // - Since shoot and idle/walk are in different layers they will not affect
        // each other's playback when calling CrossFade.
        // - Since shoot is in a higher layer, the animation will replace idle/walk
        // animations when faded in.
        //animation["attack"].layer = 1;

        // Stop animations that are already playing
        //(In case user forgot to disable play automatically)
        animation.Stop();

        states = new List<AnimationState>();
        foreach (AnimationState state in animation)
        {
            states.Add(state);
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (countDownTimer > 0)
        {
            countDownTimer -= Time.deltaTime;
        }
        else {
            countDownTimer = 0;
        }
        //Debug.Log("currentDogStates: " + currentDogStates);
        switch (currentDogStates) {
            case DogStates.WANDER:
                // Do wander
                if (WanderGizmos.instance.rand_center != null)
                {
                    _AIData.target = WG.rand_center;
                    // obstacleAvoidance
                    if (!AIBehaivor.obstacleAvoidance(this.gameObject, _AIData, out center, out left, out right))
                    {
                        _AIData.maxSpeed = 0.4f;
                        AIBehaivor.seek(this.gameObject, _AIData);
                        animation.CrossFade("Track");
                    }
                    else {
                        // check the direction of the obstacles and then turn to the opposite direction
                        if (left)
                        {
                            //Debug.Log("Trun Right");
                            _AIData.maxSpeed = 0.3f;
                            _AIData.current_velocity = 0.1f;
                            _AIData.target = this.transform.position + this.transform.right * WanderGizmos.instance.distance;
                            AIBehaivor.seek(this.gameObject, _AIData);
                        }
                        else if (right)
                        {
                            //Debug.Log("Trun Left");
                            _AIData.maxSpeed = 0.3f;
                            _AIData.current_velocity = 0.1f;
                            _AIData.target = this.transform.position - this.transform.right * WanderGizmos.instance.distance;
                            AIBehaivor.seek(this.gameObject, _AIData);
                        }
                        else if (center) {
                            float rand = (Random.value - 0.5f) * 2.0f * Mathf.PI / 10.0f;
                            backDirVector = (-transform.forward + transform.right * Mathf.Sin(rand)).normalized;
                            currentDogStates = DogStates.TURNBACK;
                        }
                    }
                }
                // Check other states
                // Catch ball
                if (AIBehaivor.checkBallInFOV(this.gameObject, _AIData, ObjectPool.m_Instance.m_GameObjects[0])) {
                    currentDogStates = DogStates.CATCHBALL;
                }
                break;
            case DogStates.CATCHBALL:
                // do catch ball
                if (_AIData.nearest_Obstacle.m_bUsing)
                {
                    if (countDownTimer == 0) {
                        if ((_AIData.nearest_Obstacle.m_go.transform.position - this.transform.position).magnitude < 0.5f)
                        {
                            _AIData.nearest_Obstacle.m_go.GetComponent<Rigidbody>().velocity = Vector3.zero;
                            countDownTimer = 1.0f;
                        }
                        else {
                            _AIData.target = _AIData.nearest_Obstacle.m_go.transform.position;
                            _AIData.current_velocity = 0.8f;
                            _AIData.maxSpeed = 1.2f;
                            AIBehaivor.seek(this.gameObject, _AIData);
                            animation.CrossFade("Run");
                        }
                    } else if (countDownTimer < 0.2f) {
                        _AIData.nearest_Obstacle = null;
                        _AIData.nearest_Obstacle.m_go.transform.position = new Vector3(4.5f, 1.8f, 3.0f);
                        ObjectPool.m_Instance.UnLoadObjectToPool(0, _AIData.nearest_Obstacle.m_go);
                    } else if (countDownTimer > 0) {
                        animation.CrossFade("start & End Eating");
                    }
                }
                else {
                    currentDogStates = DogStates.WANDER;
                }
                break;
            case DogStates.TURNBACK:
                // Do TURNBACK
                animation.CrossFade("lopp Shitting");
                Vector3 newDir = Vector3.RotateTowards(transform.forward, backDirVector, Time.deltaTime, 1.0f);
                transform.rotation = Quaternion.LookRotation(newDir);
                // Check other states
                if (transform.forward == backDirVector) {
                    currentDogStates = DogStates.WANDER;
                }
                break;
        }
	}
}
