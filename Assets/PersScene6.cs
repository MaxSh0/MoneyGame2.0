using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersScene6 : MonoBehaviour {
    Animator anim;
    [SerializeField] GameObject Money;
    public int emoticon = 0;

    void Start()
    {
        anim = GetComponent<Animator>();

        anim.SetBool("animTalk", true);
        Invoke("stand", 3);

    }

    void Update()
    {
        emoticon = Money.GetComponent<DropToPay>().emotionPers;

        if (emoticon == 1)
        {
            anim.SetBool("animSad", true);
            anim.SetBool("animFun", false);
            anim.SetBool("animTalk", false);
        }
        else if (emoticon == 2)
        {
            anim.SetBool("animSad", false);
            anim.SetBool("animFun", true);
            anim.SetBool("animTalk", false);
        }



    }

    void stand()
    {
        anim.SetBool("animSad", false);
        anim.SetBool("animFun", false);
        anim.SetBool("animTalk", false);
    }
}
