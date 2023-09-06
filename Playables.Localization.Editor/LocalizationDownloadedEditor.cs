using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.EditorCoroutines.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

[CustomEditor(typeof(LocalizationDownloader))]
public class LocalizationDownloadedEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUI.enabled = false;

        var outputData = AssetDatabase.LoadAssetAtPath<LocalizationData>( GetOutputPath());

        EditorGUILayout.ObjectField("Localization Data", outputData,typeof(LocalizationData), false);

        GUI.enabled = true;

        if (GUILayout.Button("Download"))
        {
            EditorCoroutineUtility.StartCoroutine(DownloadNow(),this);
        }
    }

    string GetOutputPath()
    {
        
        var outputPath = AssetDatabase.GetAssetPath(target).Replace(".asset", ".loc");

        return outputPath;
    }
    IEnumerator DownloadNow()
    {
        var t = target as LocalizationDownloader;
        var www = UnityWebRequest.Get(t.url);
        Debug.Log("Updating localization from web");
        
       yield return www.SendWebRequest();
       
        if (www.result != UnityWebRequest.Result.Success ||
            www.responseCode != 200)
        {
            Debug.LogWarning($"Updating localization failed: {www.error}\n{www.url}");
            yield break;
        }
        else
        {
            // Debug.Log(www.downloadHandler.text);
        }

        var text = www.downloadHandler.text;

        var outputPath = GetOutputPath();

        File.WriteAllText(outputPath, text);
                
        AssetDatabase.ImportAsset(outputPath,ImportAssetOptions.ForceSynchronousImport);
                
        var asset = AssetDatabase.LoadAssetAtPath<LocalizationData>(outputPath);

        AssetDatabase.Refresh();
        
        var s = FindObjectsOfType<LocalizedText>();
        for (int i = 0; i < s.Length; i++)
        {
            s[i].Refresh();
        }
                
        Debug.Log("Localization updated",asset);
    }
}