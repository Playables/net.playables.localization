using System;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LocalizationLanguageData))]
public class LocalizationLanguageDataEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		var obj = target as LocalizationLanguageData;

		GUI.enabled = true;

		EditorGUILayout.BeginHorizontal();
		{
			EditorGUILayout.PrefixLabel("Glyphs");
			var glyphs = obj.glyphs;

			var str = "<no glyphs>";
			if (glyphs != null)
				str = new String(glyphs);
			EditorGUILayout.TextArea(str);
		}
		EditorGUILayout.EndHorizontal();

		if (GUILayout.Button("Generate Glyphs"))
		{
			var sb = new StringBuilder();
			sb.Append("_");
			sb.Append("…");
			foreach (var item in obj.items)
			{
				if (string.IsNullOrWhiteSpace(item.Value))
					continue;
				if (item.Value == "\n")
					continue;
				if (item.Value == "\r")
					continue;
				sb.Append(item.Value);
			}
		
			obj.glyphs = sb.ToString().ToCharArray().Distinct().ToArray();
		}
		
		GUI.enabled = false;

	}
}