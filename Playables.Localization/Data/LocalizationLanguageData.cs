using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LocalizationLanguageData : ScriptableObject
{
	[Serializable]
	class Dict : SerializedDict<string,string>{}
	
	[SerializeField]
	Dict itemsSerialized = new Dict();

	public char[] glyphs { get; set; }

	public Dictionary<string, string> items
	{
		get => itemsSerialized.dictionary;
		set => itemsSerialized.dictionary = value;
	}
}