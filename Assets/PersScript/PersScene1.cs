using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersScene1 : MonoBehaviour {
    Animator anim;
    [SerializeField] GameObject Manager;
    public bool autorizationNum = true;
    bool audioPlay = true;
    [SerializeField] AudioSource audioRus;
    [SerializeField] AudioSource audioEng;
    [SerializeField] AudioSource passwordEng;
    [SerializeField] AudioSource passwordRus;
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
	

	void Update () {
        autorizationNum = Manager.GetComponent<Authorization>().autorization;



        if (autorizationNum == false)
        {
            anim.SetBool("animSad", true);
            anim.SetBool("animFun", false);
            anim.SetBool("animTalk", false);
            if (audioPlay)
            {
               // audioPlay = false;
               // PlayAudio();
            }
        }
	}


    void stand()
    {
        anim.SetBool("animSad", false);
        anim.SetBool("animFun", false);
        anim.SetBool("animTalk", false);
    }

    //public void PlayAudio()
    //{

    //    if (autorizationNum == false)
    //    {
    //        if (panel.GetComponent<SettingLanguage>().Language == 1)
    //        {
    //            passwordRus.Play();
    //        }
    //        else if (panel.GetComponent<SettingLanguage>().Language == 2)
    //        {
    //            passwordEng.Play();
    //        }
    //    }

    //}

    public void PlayOnClik()
    {
        StartCoroutine(PlayAudioCorutine());
    }





    IEnumerator PlayAudioCorutine() {
        yield return new WaitForSeconds(1f);
        if (autorizationNum == false)
        {

            if (PlayerPrefs.HasKey("Language"))
            {
                if (PlayerPrefs.GetInt("Language") == 1)
                {
                    passwordRus.Play();
                }
                else
                {
                    passwordEng.Play();
                }
            }
            else
            {
                if (panel.GetComponent<SettingLanguage>().Language == 1)
                {
                    passwordRus.Play();
                }
                else if (panel.GetComponent<SettingLanguage>().Language == 2)
                {
                    passwordEng.Play();
                }
            }
        }

    }
}
