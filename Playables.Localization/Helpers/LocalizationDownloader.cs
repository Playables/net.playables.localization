using UnityEngine;

// Download localization from e.g. google docs directly from unity
[CreateAssetMenu]
public class LocalizationDownloader : ScriptableObject {

	[Multiline]
	public string url = "https://docs.google.com/spreadsheets/d/<doc-id>/gviz/tq?tqx=out:csv&sheet=<sheet_name>";
}