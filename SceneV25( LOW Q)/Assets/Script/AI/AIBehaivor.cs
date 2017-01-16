using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIdata{
	//seek
	public float maxSpeed = 0.4f;
	public float current_velocity = 0.0f;
    public float turning_factor = 1.0f;
    public Vector3 target;

	//obstacleAvoidance
	public float forwardCollisionProbeLength = 1.0f;

    //checkBallInFOV
    public ObjectPoolData nearest_Obstacle = null;
    public float detectedDistance = 2.0f;
    public float fieldOfView = 80.0f;
    public float fMinDistance = Mathf.Infinity;
    
}

public class AIBehaivor {

    public static void seek(GameObject go, AIdata aiAdata) {
        // calculate the steering velocity
        Vector3 pos_d = aiAdata.target - go.transform.position;
        pos_d.y = 0.0f;
        float d = pos_d.magnitude;
        pos_d.Normalize();
        Vector3 desired_velocity = pos_d * aiAdata.maxSpeed;
        Vector3 steering_velocity = desired_velocity - go.transform.forward * aiAdata.current_velocity;

        // reach goal and return
        if (d < Time.deltaTime * aiAdata.maxSpeed * 2.0f) {
			go.transform.position = new Vector3( aiAdata.target.x, 0.0f, aiAdata.target.z);
            return;
        }

        // decompose the steering_velocity
        Vector3 steering_velocity_parallel = Vector3.Project(steering_velocity, go.transform.forward);
        Vector3 steering_velocity_normal = steering_velocity - steering_velocity_parallel;

        //seek angle
        Vector3 turn_forward_vector = go.transform.forward + steering_velocity_normal * Time.deltaTime * aiAdata.turning_factor;
        turn_forward_vector.Normalize();
        go.transform.forward = turn_forward_vector;

        //seek velocity
        aiAdata.current_velocity = aiAdata.current_velocity + steering_velocity_parallel.magnitude * Time.deltaTime;
        // prevent exceed the max speed
        if (aiAdata.current_velocity > aiAdata.maxSpeed) {
            aiAdata.current_velocity = aiAdata.maxSpeed;
        }
        go.transform.position = go.transform.position + go.transform.forward * aiAdata.current_velocity * Time.deltaTime;
    }

    public static bool obstacleAvoidance(GameObject go, AIdata aiAdata, out bool Center, out bool Left, out bool Right) {

        // Check Obstacle
        // Raycast Center
        RaycastHit hitInfo = new RaycastHit();
        LayerMask layerMask = (1<<LayerMask.NameToLayer("table")) | (1 << LayerMask.NameToLayer("chair")) | (1 << LayerMask.NameToLayer("Izzy") | (1 << LayerMask.NameToLayer("box")));
        Center = Physics.Raycast(go.transform.position, go.transform.forward, out hitInfo, aiAdata.forwardCollisionProbeLength, layerMask);
        if (Center) {
            // Raycast Left
            RaycastHit hitInfoLeft = new RaycastHit();
            Vector3 LeftHeading = (go.transform.forward - go.transform.right * 0.05f);
            Left = Physics.Raycast(go.transform.position, LeftHeading, out hitInfoLeft, aiAdata.forwardCollisionProbeLength, layerMask);

            // Raycast Right
            RaycastHit hitInfoRight = new RaycastHit();
            Vector3 RightHeading = (go.transform.forward + go.transform.right * 0.05f);
            Right = Physics.Raycast(go.transform.position, RightHeading, out hitInfoRight, aiAdata.forwardCollisionProbeLength, layerMask);
            

            if (Vector3.Dot((aiAdata.target - go.transform.position), go.transform.forward) < 0)
            {
                return false;
            }
            else {
                return true;
            }

        } else {
            Left = false;
            Right = false;
            return false;
        }
    }

    public static bool checkBallInFOV(GameObject go, AIdata aiAdata, List<ObjectPoolData> targets) {
        float distance_vector_dotForward;
        float theta;
        Vector3 distance_vector;
        float distance;
        for (int i = 0; i < targets.Count; i++)
        {
            if (ObjectPool.m_Instance.m_GameObjects[0][i].m_bUsing)
            {
                Debug.Log("ObjectPool.m_Instance.m_GameObjects[0][i].m_go.transform.position.y: " + ObjectPool.m_Instance.m_GameObjects[0][i].m_go.transform.position.y);
				if(ObjectPool.m_Instance.m_GameObjects[0][i].m_go.transform.position.y < 0.1f){
                    // if obstacles are in the circle (radius = self define)
                    Debug.Log("SDASDASD");
					distance_vector = ObjectPool.m_Instance.m_GameObjects[0][i].m_go.transform.position - go.transform.position;
                    distance_vector.y = 0;
                    distance = distance_vector.magnitude;
					if (distance > aiAdata.detectedDistance)
					{
						continue;
					}
					
					// if obstacles are in of FOV
					distance_vector_dotForward = Vector3.Dot(distance_vector.normalized, go.transform.forward);
					theta = Mathf.Acos(distance_vector_dotForward) * Mathf.Rad2Deg;
					if (theta > aiAdata.fieldOfView)
					{
						continue;
					}
					
					// find the Nearest intersected obstacle 
					if (distance < aiAdata.fMinDistance)
					{
						aiAdata.fMinDistance = distance;
						aiAdata.nearest_Obstacle = ObjectPool.m_Instance.m_GameObjects[0][i];
					}
				}
            }
        }
        if (aiAdata.nearest_Obstacle != null)
        {
            return true;
        }
        return false;
    }
}

