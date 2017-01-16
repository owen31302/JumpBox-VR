using UnityEngine;
using System.Collections;

public class L1Fadeinoutanimation : MonoBehaviour {
    float timer = 0.5f;
    Animator L1an;
    AnimatorStateInfo L1Info;

    // Use this for initialization
    void Start () {
        L1an = this.GetComponent<Animator>();
        L1an.SetBool("fadeout", false);
    }

    // Update is called once per frame
    void Update () {
        L1Info = L1an.GetCurrentAnimatorStateInfo(0);
        if (LevelManager.instance.fadeout == true)
        {
            timer -= Time.deltaTime;
        }

        if (L1Info.IsName("L1 fadein") && LevelManager.instance.fadeout == true && timer < 0.0f)
        {
            L1an.SetBool("fadeout", true);
        }
    }
}
