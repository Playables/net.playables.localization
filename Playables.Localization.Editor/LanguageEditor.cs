using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Language))]
internal class LanguageEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		var t = target as Language;
		
		if (Localization.Instance && !LocalizationDataUtils.LanguageExists(Localization.Instance.data, t.language))
		{
			EditorGUILayout.HelpBox($"Language {t.language} not found", MessageType.Warning);
		}
	}
}