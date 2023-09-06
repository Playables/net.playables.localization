using System;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LocalizedText))]
internal class LocalizedTextEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		GUI.enabled = false;
		var t = target as LocalizedText;

		EditorGUILayout.TextField("Localized Text", t.localizedText);
		EditorGUILayout.TextField("Display Language", t.displayLanguage);
		EditorGUILayout.TextField("Target Language", t.targetLanguage);
		if (!Localization.Instance)
		{
			EditorGUILayout.HelpBox("No localization instance found. Create a game object with the \"Localization\" script attached to use localization. ", MessageType.Warning);
		}
		else if (!Localization.Instance.data)
		{
			EditorGUILayout.HelpBox("Localization data not found. Check the object with the \"Localization\" script attached.", MessageType.Warning);
		}
		else
		{
			var text = t.localizationState switch
			{
				LocalizedText.LocalizationState.Missing => "Localization is missing.",
				LocalizedText.LocalizationState.UsesDefaultLanguageFallback => "Localization is missing for active language, using default language as fallback.",
				LocalizedText.LocalizationState.Ok => string.Empty,
				_ => throw new ArgumentOutOfRangeException()
			};
			if (!string.IsNullOrEmpty(text))
				EditorGUILayout.HelpBox(text, MessageType.Warning);
		}
	}
}