using System;
using UnityEngine;

// Use currently active language (runtime only)
[DefaultExecutionOrder(-10)]
public class LanguageFromCurrent : MonoBehaviour
{
	void OnEnable()
	{
		Update();
	}

	void Update()
	{
		GetComponent<Language>().language = Localization.Instance.currentLanguage;
	}
}