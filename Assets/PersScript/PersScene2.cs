using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersScene2 : MonoBehaviour {
    Animator anim;
    [SerializeField] GameObject Bag;
    [SerializeField] AudioSource audioRus;
    [SerializeField] AudioSource audioEng;
    [SerializeField] AudioSource goodRus;
    [SerializeField] AudioSource wrongRus;
    [SerializeField] AudioSource goodEng;
    [SerializeField] AudioSource wrongEng;
    [SerializeField] GameObject panel;
    public bool playAudioGood = false;
    public int fun = 0;

    void Start () {
        anim = GetComponent<Animator>();
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
        fun = Bag.GetComponent<DropMoney>().funPers;

        if (fun == 1)
        {
            anim.SetBool("animFun", true);
            anim.SetBool("animSad", false);
            if (!playAudioGood)
            {
                playAudioGood = true;
                if (PlayerPrefs.HasKey("Language"))
                {
                    if (PlayerPrefs.GetInt("Language") == 1)
                    {
                        goodRus.Play();
                    }
                    else
                    {
                        goodEng.Play();
                    }
                }
                else
                {
                    if (panel.GetComponent<SettingLanguage>().Language == 1)
                    {
                        goodRus.Play();
                    }
                    else if (panel.GetComponent<SettingLanguage>().Language == 2)
                    {
                        goodEng.Play();
                    }
                }
            }
        }
        else if (fun == 2)
        {
            playAudioGood = false;
            anim.SetBool("animFun", false);
            anim.SetBool("animSad", true);
        }
    }


    void stand()
    {
        anim.SetBool("animSad", false);
        anim.SetBool("animFun", false);
        anim.SetBool("animTalk", false);
    }


    public void PlayOnClick()
    {
        if (PlayerPrefs.HasKey("Language"))
        {
            if (PlayerPrefs.GetInt("Language") == 1)
            {
                wrongRus.Play();
            }
            else
            {
                wrongEng.Play();
            }
        }
        else
        {
            if (panel.GetComponent<SettingLanguage>().Language == 1)
            {
                wrongRus.Play();
            }
            else if (panel.GetComponent<SettingLanguage>().Language == 2)
            {
                wrongEng.Play();
            }
        }
    }
}
