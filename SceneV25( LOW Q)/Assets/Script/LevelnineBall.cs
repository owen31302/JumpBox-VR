using UnityEngine;
using System.Collections;

public class LevelnineBall : MonoBehaviour
{
    private float _life;
    private int _rebornOnce;
    private bool _rebornTrigger;
    private bool _velocityZero;
    private bool _lifeOn;

    // Use this for initialization
    void OnEnable()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        Pingpongpool._instance._rigigdbodyNineBall = this.GetComponent<Rigidbody>();
        _life = 0.0f;
        _rebornTrigger = false;
        _velocityZero = false;
        _lifeOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_life > 0)
        {
            _life -= Time.deltaTime;
        }
        else if (_life < 0) {
            Pingpongpool._instance._rigigdbodyNineBall.velocity = Vector3.zero;
            ObjectPool.m_Instance.UnLoadObjectToPool(1, this.gameObject);
            _life = 0;
        }

        if (LevelManager.instance._success.text == "SUCCESS")
        {
            ObjectPool.m_Instance.UnLoadObjectToPool(1, this.gameObject);
        }
    }
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name.Equals("pingpongball(Clone)"))
        {
            
            //Pingpongpool._instance._rigigdbodyNineBall.constraints = RigidbodyConstraints.None;
        }
    }
    void OnCollisionStay(Collision c)
    {
        if (LevelManager.instance._currentLevel == 9)
        {
            if(!_velocityZero)
            {
                if (c.gameObject.name.Equals("pillar"))
                {
                    Pingpongpool._instance._rigigdbodyNineBall.velocity = Vector3.zero;
                    _velocityZero = true;
                }
            }
            
            if (c.gameObject.name.Equals("BoxTarget"))
            {
                LevelManager.instance._success.text = "SUCCESS";
            }

            if (c.gameObject.name.Equals("bakedTable") || c.gameObject.name.Equals("bakedTable(1)") || c.gameObject.name.Equals("Ground") || c.gameObject.name.Equals("Chair04B") || c.gameObject.name.Equals("Chair04B(1)") || c.gameObject.name.Equals("Chair04B(2)") || c.gameObject.name.Equals("Chair04B(3)"))
            {
                if(!_rebornTrigger)
                {
                    Pingpongpool._instance._nineBall = ObjectPool.m_Instance.LoadObjectFromPool(1);
                    Pingpongpool._instance._nineBall.transform.position = LevelManager.instance.lvNineOriginePos.transform.position;
                    _life = 1.0f;
                    _velocityZero = true;
                    _rebornTrigger = true;
                }
            }
        }
    }
}
