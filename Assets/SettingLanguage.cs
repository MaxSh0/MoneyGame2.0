using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingLanguage : MonoBehaviour {

    [SerializeField] public Toggle Rus;
    [SerializeField] public Toggle Eng;
    [SerializeField] public Toggle Dutch;
    [SerializeField] public GameObject TextRus;
    [SerializeField] public GameObject TextEng;
    [SerializeField] public GameObject TextDutch;
    public int Language = 0; //1 - русский 2 - английский 3 - нидерландский
	void Start () {


            Language = PlayerPrefs.GetInt("Language");

            if (Language == 1)
            {
                Rus.isOn = true;
                Eng.isOn = false;
            }
            else if (Language == 2)
            {
                Rus.isOn = false;
                Eng.isOn = true;
            }
        

	}
	
	void Update () {

        if (Rus.isOn)
        {
            Language = 1;
            TextRus.SetActive(true);
            TextEng.SetActive(false);
            TextDutch.SetActive(false);
        }
        else if (Eng.isOn)
        {
            Language = 2;
            TextRus.SetActive(false);
            TextEng.SetActive(true);
            TextDutch.SetActive(false);
        }
        else {
            Language = 3;
            TextRus.SetActive(false);
            TextEng.SetActive(false);
            TextDutch.SetActive(true);
        }
    }

    public void SaveSetting()
    {
        PlayerPrefs.SetInt("Language", Language);
    }
}
