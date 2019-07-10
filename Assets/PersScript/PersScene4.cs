using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersScene4 : MonoBehaviour
{
    Animator anim;
    [SerializeField] AudioSource audioRus;
    [SerializeField] AudioSource audioEng;
    [SerializeField] GameObject panel;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("animSad", false);
        anim.SetBool("animFun", false);
        anim.SetBool("animTalk", true);

        Invoke("stand", 3);

        if (PlayerPrefs.HasKey("Language"))
        {
            if (PlayerPrefs.GetInt("Language") == 1)
            {
                audioRus.Play();
            }
            else
            {
                audioEng.Play();
            }
        }
        else
        {
            if (panel.GetComponent<SettingLanguage>().Language == 1)
            {
                audioRus.Play();
            }
            else if (panel.GetComponent<SettingLanguage>().Language == 2)
            {
                audioEng.Play();
            }
        }
    }

    void stand()
    {
        anim.SetBool("animSad", false);
        anim.SetBool("animFun", false);
        anim.SetBool("animTalk", false);
    }
}
