using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(LocalizationData))]
public class LocalizationDataEditor : Editor
{
	public override void OnInspectorGUI()
	{

		var obj = target as LocalizationData;

		GUI.enabled = false;
		
		EditorGUILayout.PropertyField(serializedObject.FindProperty("languagesSerialized.values"));
	}
}