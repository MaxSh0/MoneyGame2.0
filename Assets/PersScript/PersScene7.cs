using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PersScene7 : MonoBehaviour {

    Animator anim;
    [SerializeField] GameObject BagScene7;
    [SerializeField] AudioSource audioRus;
    [SerializeField] AudioSource audioEng;
    [SerializeField] AudioSource goodRus;
    [SerializeField] AudioSource wrongRus;
    [SerializeField] AudioSource goodEng;
    [SerializeField] AudioSource wrongEng;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject _changeArea;

    public int emotion = 0;
    public bool PlayAudioGood = true;

    void Start()
    {
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

    void Update()
    {
        emotion = BagScene7.GetComponent<DropChange>().emotionPers;
        Image[] money = _changeArea.GetComponentsInChildren<Image>();

        if (emotion == 1)
        {
            PlayAudioGood = true;
            anim.SetBool("animFun", false);
            anim.SetBool("animSad", true);
        }
        else if (emotion == 2)
        {
            anim.SetBool("animFun", true);
            anim.SetBool("animSad", false);

            if (PlayAudioGood && money.Length == 1)
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
