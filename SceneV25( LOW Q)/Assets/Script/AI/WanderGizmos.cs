using UnityEngine;
using System.Collections;

public class WanderGizmos : MonoBehaviour {

	public static WanderGizmos instance;

	public Vector3 rand_center;

	private Vector3 center;
    public float distance = 1.0f;
	private float radius = 0.5f;
	private float rand_theta;
	private int count;

	void Start()
	{
		instance = new WanderGizmos ();
		rand_theta = 0.0f;
		count = 0;
	}
		
	void Update()
	{
		rand_position();
	}

	void rand_position()
	{
		if (count == 80)
		{
			float rand = (Random.value - 0.5f) * 2;
			rand_theta += rand * 60;
			//Debug.Log(rand_theta);
			if (rand_theta >= 360)
			{
				rand_theta -= 360;
			}
			else if (rand_theta <= -360)
			{
				rand_theta += 360;
			}
			count++;
		}
		else if (count > 160)
		{
			count = 0;
		}
		else {
            if (NPCFSM._instance.left)
            {
                rand_theta = 90;
                count = 0;
            }
            else if (NPCFSM._instance.right)
            {
                rand_theta = -90;
                count = 0;
            }
            else if (NPCFSM._instance.center) {
                rand_theta = 180;
                count = 0;
            }
            count++;
		}
	}

	void OnDrawGizmos()
	{
        // Wander
        center = this.transform.position + this.transform.forward * distance;
        rand_center = center + radius * Mathf.Cos(Mathf.PI * rand_theta / 180) * this.transform.forward + radius * Mathf.Sin(Mathf.PI * rand_theta / 180) * this.transform.right;
        Gizmos.color = Color.green; //換色
        Gizmos.DrawLine(this.transform.position, center); //畫出正面線
        Gizmos.DrawWireSphere(center, radius);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(rand_center, 0.1f);

        //Obstacle Avoidance
        Gizmos.color = Color.blue;
        if (NPCFSM._instance != null) {
            Gizmos.DrawLine(this.transform.position, this.transform.position + NPCFSM._instance._AIData.forwardCollisionProbeLength * this.transform.forward);
        }
        
    }
}

