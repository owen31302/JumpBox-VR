using UnityEngine;
using System.Collections;

public class L2Fadeinoutanimation : MonoBehaviour {
    float timer = 0.5f;
    Animator L2an;
    AnimatorStateInfo L2Info;

    // Use this for initialization
    void Start()
    {
        L2an = this.GetComponent<Animator>();
        L2Info = L2an.GetCurrentAnimatorStateInfo(0);
        L2an.SetBool("fadeout", false);

    }

    // Update is called once per frame
    void Update()
    {

        if (LevelManager.instance.fadeout == true)
        {
            timer -= Time.deltaTime;
        }

        if ((L2Info.IsName("L2 fadein")) && (LevelManager.instance.fadeout == true) && (timer < 0.0f))
        {
            L2an.SetBool("fadeout", true);
        }
    }
}
