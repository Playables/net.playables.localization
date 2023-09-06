using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class LocalizationDataUtils
{

	
	public static List<string> GetAllStrings(LocalizationData localizationData,string language)
	{
		return localizationData.languages[language].items.Keys.ToList();
	}

	public static bool LanguageExists(LocalizationData localizationData,string language)
	{
		return localizationData &&
		       localizationData.languages != null &&
		       !string.IsNullOrEmpty(language) && localizationData.languages.ContainsKey(language);
	}

	public static bool ItemExists(LocalizationData localizationData,string item, string language)
	{
		if (!LanguageExists(localizationData,language))
			return false;
		
		return localizationData.languages[language].items.ContainsKey(item);
	}

	public static string GetActualItemLanguage(LocalizationData localizationData,string item, string language, string defaultLanguage = "en")
	{
		if (ItemExists(localizationData,item,language))
		{
			return language;
		}

		return defaultLanguage;
	}

	public static string Get(LocalizationData localizationData,string item, string lang, string[] args = null, bool localizeArgs = true)
	{
		if (String.IsNullOrEmpty(item) || 
		    !LanguageExists(localizationData,lang) || 
		    !ItemExists(localizationData,item,lang))
		{
			return string.Empty;
		}

		var str = localizationData.languages[lang].items[item];

		if (args != null)
		{
			if (localizeArgs)
			{
				for (int i = 0; i < args.Length; i++)
					args[i] = Get(localizationData, args[i], lang);
			}
			
			str = String.Format(str, args);
		}

		return str;
	}
}