using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AssetImporters;
using System.IO;

[ScriptedImporter(1, "loc")]
public class LocalizationDataImporter : ScriptedImporter
{
	List<string> ignoredColumns = new List<string>()
	{
		"id",
		"comment"
	};
	
	public override void OnImportAsset(AssetImportContext ctx)
	{
		var text = File.ReadAllText(ctx.assetPath);
		
		var strings = CSVDictionaryParser.ParseCSVFromString(text);
		for (int i = 0; i < ignoredColumns.Count; i++)
		{
			if (strings.ContainsKey(ignoredColumns[i]))
				strings.Remove(ignoredColumns[i]);
		}

		var obj = ScriptableObject.CreateInstance<LocalizationData>();
		
		foreach (var pair in strings)
		{
			var lang = ScriptableObject.CreateInstance<LocalizationLanguageData>();
			lang.name = pair.Key;
			lang.items = pair.Value;
			ctx.AddObjectToAsset(lang.name, lang);
			obj.languages.Add(lang.name,lang);
		}

		ctx.AddObjectToAsset("main", obj);
		ctx.SetMainObject(obj);
	}
}