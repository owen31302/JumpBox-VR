using UnityEngine;
using System.Collections;

public class L4Fadeinoutanimation : MonoBehaviour {
    float timerin = 0.0f;
    float timeout = 0.5f;
    Animator L4an;
    AnimatorStateInfo L4Info;

    // Use this for initialization
    void Start()
    {
        L4an = this.GetComponent<Animator>();
        L4Info = L4an.GetCurrentAnimatorStateInfo(0);
    }

    // Update is called once per frame
    void Update()
    {
        timerin += Time.deltaTime;

        if (LevelManager.instance.fadeout == true)
        {
            timeout -= Time.deltaTime;
        }
        if (LevelManager.instance.fadeout == true && timeout < 0.0f)
        {
            L4an.SetTrigger("fadeout");

        }
        if ((L4Info.IsName("L4 fadein")) && (timerin > 0.5f))
        {
                L4an.SetTrigger("Move");
        }
    }
}
