using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EmoticonManager : MonoBehaviour
{
	[SerializeField] GameObject _shopsScreen;

	void Start()
	{
		gameObject.SetActive(false);
	}

	public void SetHappyEmoticon()
	{
		gameObject.SetActive(true);
		_shopsScreen.GetComponent<ShopsController>().SetSprite(gameObject, "good");
	}
	public void SetSadEmoticon()
	{
		gameObject.SetActive(true);
		_shopsScreen.GetComponent<ShopsController>().SetSprite(gameObject, "bad");
	}
}
