using UnityEngine;
using System.Collections;

public class L7Fadeinoutanimation : MonoBehaviour {
    float timer = 0.5f;
    Animator L7an;
    AnimatorStateInfo L7Info;

    // Use this for initialization
    void Start()
    {
        L7an = this.GetComponent<Animator>();
        L7Info = L7an.GetCurrentAnimatorStateInfo(0);
        L7an.SetBool("fadeout", false);


    }

    // Update is called once per frame
    void Update()
    {

        if (LevelManager.instance.fadeout == true)
        {
            timer -= Time.deltaTime;
        }

        if ((L7Info.IsName("L7 Fadein")) && (LevelManager.instance.fadeout == true) && (timer < 0.0f))
        {
            L7an.SetBool("fadeout", true);
        }
    }
}
