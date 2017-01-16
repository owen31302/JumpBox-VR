using UnityEngine;
using System.Collections;

public class L6Fadeinoutanimation : MonoBehaviour {
    float timerin = 0.0f;
    float timeout = 0.5f;
    Animator L6an;
    AnimatorStateInfo L6Info;

    // Use this for initialization
    void Start()
    {
        L6an = this.GetComponent<Animator>();
        L6Info = L6an.GetCurrentAnimatorStateInfo(0);
        L6an.SetBool("fadeout", false);
        L6an.SetBool("MoveBox1", false);

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
            L6an.SetBool("fadeout", true);

        }
        if ((L6Info.IsName("L6 fadein")) && (timerin > 0.5f))
        {
            L6an.SetBool("MoveBox1" , true);
        }
    }
}
