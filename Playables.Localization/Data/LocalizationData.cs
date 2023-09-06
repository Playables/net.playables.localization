using System;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationData : ScriptableObject
{
	[Serializable]
	class Dict : SerializedDict<string,LocalizationLanguageData>{}
	
	[SerializeField]
	Dict languagesSerialized = new Dict();
	public Dictionary<string, LocalizationLanguageData> languages
	{
		get => languagesSerialized.dictionary;
		set => languagesSerialized.dictionary = value;
	}
}
