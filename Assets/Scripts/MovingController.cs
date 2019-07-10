using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovingController : MonoBehaviour
{

    [SerializeField] GameObject walletScreen;
    [SerializeField] GameObject shopsScreen;
    [SerializeField] GameObject ctegoriesScreen;
    [SerializeField] GameObject productsScreen;
    [SerializeField] GameObject cashboxScreen;
    [SerializeField] GameObject changeScreen;
    [SerializeField] GameObject _emoticonImg;
    [SerializeField] GameObject _basket;
    [SerializeField] GameObject _wallet;
    [SerializeField] GameObject _changeArea;
    [SerializeField] GameObject Bag;
    [SerializeField] GameObject BagScene7;
    [SerializeField] GameObject Basket;
    [SerializeField] GameObject Money;
    [SerializeField] GameObject panel;

    public void GoToShops()
	{
		if (CountingItems.listMoney.Count > 0)  // переместили деньги в кошелек
		{
			walletScreen.SetActive(false);
			shopsScreen.SetActive(true);

			LoadProgress(0.2f);
        
        }
		else
		{
            Bag.GetComponent<DropMoney>().funPers = 2;//Анимация персонажа - грусть
            _emoticonImg.GetComponent<EmoticonManager>().SetSadEmoticon();
			walletScreen.GetComponent<TextToSpeech>().StartDownloadAudioDown(ManagerController.text["WalletScreen"]);
		}
	}

	public void GoToCashbox()
	{
		Image[] products = _basket.GetComponentsInChildren<Image>();
		if (products.Length > 1)    // переместили какие-то продукты в корзину
		{
			productsScreen.SetActive(false);
			cashboxScreen.SetActive(true);

			LoadProgress(0.8f);

        }
		else
		{
            Basket.GetComponent<DropProducts>().emoticonPers = 1;
            _emoticonImg.GetComponent<EmoticonManager>().SetSadEmoticon();
			productsScreen.GetComponent<TextToSpeech>().StartDownloadAudioDown(ManagerController.text["ProductsScreen"]);
		}
	}

	public void GoToChange()
	{
		Image[] money = _wallet.GetComponentsInChildren<Image>();

		if (money.Length - 1 != CountingItems.listMoney.Count)  // оплатили покупку
		{
			cashboxScreen.SetActive(false);
			changeScreen.SetActive(true);

			LoadProgress(1.0f);
		}
		else
		{
            Money.GetComponent<GetMoneyCombination>().emotionPers = 1;
			_emoticonImg.GetComponent<EmoticonManager>().SetSadEmoticon();
			cashboxScreen.GetComponent<TextToSpeech>().StartDownloadAudioDown(ManagerController.text["CashboxScreen"]);
		}
	}

	public void BackToCashbox()
	{
		cashboxScreen.SetActive(true);
		changeScreen.SetActive(false);

		LoadProgress(0.8f);
	}

	public void BackToProducts()
	{
		productsScreen.SetActive(true);
		cashboxScreen.SetActive(false);

		LoadProgress(0.5f);
	}

	public void BackToCategories()
	{
		ctegoriesScreen.SetActive(true);
		productsScreen.SetActive(false);

		LoadProgress(0.3f);
	}

	public void BackToShops()
	{
		shopsScreen.SetActive(true);
		ctegoriesScreen.SetActive(false);

		LoadProgress(0.2f);
	}

	public void BackToWallet()
	{
		walletScreen.SetActive(true);
		shopsScreen.SetActive(false);

		LoadProgress(0.1f);
	}

	public void Restart()
	{
		Image[] money = _changeArea.GetComponentsInChildren<Image>();
        int Language = panel.GetComponent<SettingLanguage>().Language;
        if (money.Length == 1)  // переместили сдачу в кошелек
		{
			SceneManager.LoadScene("Main");
            panel.GetComponent<SettingLanguage>().Language = Language;
        }
		else
		{
            BagScene7.GetComponent<DropChange>().emotionPers = 1;
            _emoticonImg.GetComponent<EmoticonManager>().SetSadEmoticon();
			changeScreen.GetComponent<TextToSpeech>().StartDownloadAudioDown(ManagerController.text["ChangeScreen"]);
		}
	}

	void Update()
	{
		// Выход из игры по нажатию кнопки "Назад" на планшете
		if (Application.platform == RuntimePlatform.Android)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Application.Quit();
			}
		}
	}

	// Изменение состояния progress bar
	public void LoadProgress(float progress)
	{
		Scrollbar progressBar = FindObjectOfType<Scrollbar>();
		if (progressBar != null)
		{
			progressBar.GetComponent<Scrollbar>().size = progress;
		}
	}
}
