using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersScene5 : MonoBehaviour {
    Animator anim;
    [SerializeField] GameObject Basket;
    [SerializeField] AudioSource audioRus;
    [SerializeField] AudioSource audioEng;
    [SerializeField] AudioSource goodRus;
    [SerializeField] AudioSource wrongRus;
    [SerializeField] AudioSource goodEng;
    [SerializeField] AudioSource wrongEng;
    [SerializeField] GameObject panel;
    public int emoticon = 0;
    public bool PlayAudioGood = true;

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
        emoticon = Basket.GetComponent<DropProducts>().emoticonPers;

        if (emoticon == 1)
        {
            PlayAudioGood = true;
            anim.SetBool("animSad", true);
            anim.SetBool("animFun", false);
            anim.SetBool("animTalk", false);
        }
        else if (emoticon == 2)
        {
            anim.SetBool("animSad", false);
            anim.SetBool("animFun", true);
            anim.SetBool("animTalk", false);

            if (PlayAudioGood)
            {
                PlayAudioGood = false;

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
