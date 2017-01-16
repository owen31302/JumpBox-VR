using UnityEngine;
using System.Collections;

public class L9Fadeinoutanimation : MonoBehaviour {
    float timer = 0.5f;
    Animator L9an;
    AnimatorStateInfo L9Info;

    // Use this for initialization
    void Start()
    {
        L9an = this.GetComponent<Animator>();
        L9Info = L9an.GetCurrentAnimatorStateInfo(0);
        L9an.SetBool("fadeout", false);


    }

    // Update is called once per frame
    void Update()
    {

        if (LevelManager.instance.fadeout == true)
        {
            timer -= Time.deltaTime;
        }

        if ((L9Info.IsName("L9 fadein")) && (LevelManager.instance.fadeout == true) && (timer < 0.0f))
        {
            L9an.SetBool("fadeout", true);
        }
    }
}
