using System;
using System.Collections.Generic;
using UnityEngine;

// Helper to map from Unity system languages to localization languages.
[CreateAssetMenu]
public class SystemLanguageMappings : ScriptableObject
{
	public List<SystemLanguageMapping> defaultLanguages = new List<SystemLanguageMapping>();
}

[Serializable]
public struct SystemLanguageMapping
{
	public SystemLanguage systemLanguage;
	public string localizationLanguage;
}