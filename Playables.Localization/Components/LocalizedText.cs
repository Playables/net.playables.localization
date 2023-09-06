using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteAlways]

[RequireComponent(typeof(Language))]
public class LocalizedText : MonoBehaviour
{
	public string key;
	
	string initializedKey;
	bool forceRefresh;

	public enum LocalizationState
	{
		Missing,
		UsesDefaultLanguageFallback,
		Ok
	}
	public string localizedText { get; private set; }
	public bool hasChanged { get; private set; }
	public LocalizationState localizationState { get; private set; }
	public string displayLanguage { get; private set; }
	public string targetLanguage { get; private set; }

	void OnEnable()
	{
		forceRefresh = true;
		Update();
	}

	void Update()
	{
		if(!Localization.Instance || !Localization.Instance.data )
			return;
		
		var language = GetComponent<Language>().language;
		hasChanged = false;
		if (key == initializedKey && language == targetLanguage && !forceRefresh)
		{
			return;
		}

		forceRefresh = false;

		displayLanguage = language;

		initializedKey = key;
		targetLanguage = language;
		displayLanguage = language;
		localizedText = LocalizationDataUtils.Get(Localization.Instance.data, key, displayLanguage);
		localizationState = LocalizationState.Ok;
		if(string.IsNullOrEmpty(localizedText))
		{
			displayLanguage = Localization.Instance.defaultLanguage;
			localizedText = LocalizationDataUtils.Get(Localization.Instance.data, key, displayLanguage);
			localizationState = LocalizationState.UsesDefaultLanguageFallback;
		}
		if(string.IsNullOrEmpty(localizedText))
		{
			displayLanguage = string.Empty;
			localizationState = LocalizationState.Missing;
		}


		hasChanged = true;
	}

	public void Refresh()
	{
		forceRefresh = true;
	}
}