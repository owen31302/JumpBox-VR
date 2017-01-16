using UnityEngine;
using System.Collections;

public class L8Fadeinoutanimation : MonoBehaviour {
    float timerin = 0.0f;
    float timeout = 0.5f;
    Animator L8an;
    AnimatorStateInfo L8Info;

    // Use this for initialization
    void Start()
    {
        L8an = this.GetComponent<Animator>();
        L8Info = L8an.GetCurrentAnimatorStateInfo(0);
        L8an.SetBool("fadeout", false);

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
            L8an.SetTrigger("fadeout");

        }
        if ((L8Info.IsName("L8 Fadein")) && (timerin > 0.5f))
        {
            L8an.SetBool("MoveBox", true);
        }
    }
}
