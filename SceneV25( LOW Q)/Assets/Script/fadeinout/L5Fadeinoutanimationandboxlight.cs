using UnityEngine;
using System.Collections;
using HighlightingSystem;

public class L5Fadeinoutanimationandboxlight : MonoBehaviour {

    public static L5Fadeinoutanimationandboxlight _instance;
    public float time = 0.5f;
    Animator L5an;
    AnimatorStateInfo L5Info;
    public GameObject G1;
    public GameObject G2;
    public GameObject G3;
    public GameObject G4;

    public Highlighter H1;
    public Highlighter H2;
    public Highlighter H3;
    public Highlighter H4;


    public
    // Use this for initialization
    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        L5an = this.GetComponent<Animator>();
        L5an.SetBool("fadeout", false);

        H1 = G1.GetComponent<Highlighter>();
        H2 = G2.GetComponent<Highlighter>();
        H3 = G3.GetComponent<Highlighter>();
        H4 = G4.GetComponent<Highlighter>();

        H1.constantly = false;
        H2.constantly = false;
        H3.constantly = false;
        H4.constantly = false;
    }

    // Update is called once per frame
    void Update()
    {
        L5Info = L5an.GetCurrentAnimatorStateInfo(0);
        if (LevelManager.instance.fadeout == true)
        {
            time -= Time.deltaTime;
        }

        if ((L5Info.IsName("L5 fadein")) && (LevelManager.instance.fadeout == true) && (time < 0.0f))
        {
            L5an.SetTrigger("fadeout");
        }
    }
}
