using UnityEngine;
using System.Collections;
using HighlightingSystem;

public class L10Fadeinoutanimation : MonoBehaviour {

    public static L10Fadeinoutanimation _instance;
    float timer = 0.5f;
    Animator L10an;
    AnimatorStateInfo L10Info;
    public Highlighter[] L10Boxs = new Highlighter[8];


    // Use this for initialization
    void Start()
    {
        _instance = this;
        L10an = this.GetComponent<Animator>();
        L10Info = L10an.GetCurrentAnimatorStateInfo(0);
        L10an.SetBool("fadeout", false);

    }

    // Update is called once per frame
    void Update()
    {

        if (LevelManager.instance.fadeout == true)
        {
            timer -= Time.deltaTime;
        }

        if ((L10Info.IsName("L10 fadein")) && (LevelManager.instance.fadeout == true) && (timer < 0.0f))
        {
            L10an.SetBool("fadeout" , true);
        }


    }
}
