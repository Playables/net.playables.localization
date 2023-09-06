using UnityEngine;

public static class SystemLanguageMappingUtils
{
	
	public static string GetDefaultLanguage(SystemLanguageMappings systemLanguageMappings,SystemLanguage systemLanguage)
	{
		for (int i = 0; i < systemLanguageMappings.defaultLanguages.Count; i++)
		{
			var d = systemLanguageMappings.defaultLanguages[i];
			if (d.systemLanguage == systemLanguage)
			{
				return d.localizationLanguage;
			}
		}

		return null;
	}
}