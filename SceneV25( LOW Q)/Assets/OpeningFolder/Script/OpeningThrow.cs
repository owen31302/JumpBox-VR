using UnityEngine;
using System.Collections;

public class OpeningThrow : MonoBehaviour {
    private bool _change;
    private bool _stop;
    private SphereCollider _sc;
    private MeshRenderer _me;
    public GameObject _trigger;
    // Use this for initialization
    void Start () {
        _change = false;
        _stop = false;
        _sc = this.GetComponent<SphereCollider>();
        _me = this.GetComponent<MeshRenderer>();
        _sc.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        if(OpeningAnimation._instance._done)
        {
            _sc.enabled = true;
            if (!_stop)
            {
                if (!_change)
                {
                    this.transform.Translate(this.transform.forward * 0.03f, Space.World);
                    this.transform.Rotate(new Vector3(0.0f, 0.0f, -0.9f), Space.World);
                }
                else
                {
                    this.transform.Translate(this.transform.forward * 0.03f, Space.World);
                    this.transform.Rotate(new Vector3(0.0f, 0.0f, -2.4f), Space.World);
                }
            }
            else
            {
                this.transform.Translate(0.0f, 0.0f, 0.0f, Space.World);
                this.transform.Rotate(0.0f, 0.0f, 0.0f, Space.World);
            }
        }
    }

    void OnCollisionEnter(Collision c)
    {
        _change = true;
        this.transform.forward = _trigger.transform.forward;
        if(c.gameObject.name == "Cube (5)T" || c.gameObject.name == "BoxTarget" || c.gameObject.name == "CubeLeftT" || c.gameObject.name == "CubeRightT" || c.gameObject.name == "CubeFrontT" || c.gameObject.name == "CubeBackT")
        {
            _stop = true;
            _me.enabled = false;
            _sc.enabled = false;
        }
    }
}
