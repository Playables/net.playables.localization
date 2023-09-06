using System;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteAlways]
public class Localization : MonoBehaviour
{
	public LocalizationData data;
	public string currentLanguage;
	public string defaultLanguage = "en";

	public static Localization Instance;

	void OnEnable()
	{
		Instance = this;
	}
}