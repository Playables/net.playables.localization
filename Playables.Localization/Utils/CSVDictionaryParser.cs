using System.Collections.Generic;
using System.IO;
using CsvFile;
using UnityEngine;

public static class CSVDictionaryParser
{
	public static Dictionary<string, Dictionary<string, string>> ParseCSVFromResourcesPath(string path)
	{
		TextAsset asset = Resources.Load(path) as TextAsset;
		return ParseCSVFromTextAsset(asset);
	}
	
	public static Dictionary<string, Dictionary<string, string>> ParseCSVFromTextAsset(TextAsset asset)
	{
		return ParseCSVFromString(asset.text);
	}
	
	public static Dictionary<string, Dictionary<string, string>> ParseCSVFromString(string str)
	{
		return ParseCSVFromStream(GenerateStreamFromString(str));
	}

	public static Dictionary<string, Dictionary<string, string>> ParseCSVFromStream(Stream stream)
	{
		CsvFileReader csvReader = new CsvFileReader(stream, EmptyLineBehavior.Ignore);

		var dict = new Dictionary<string, Dictionary<string, string>>();

		List<string> firstRow = null;
		List<string> row = new List<string>();
		while (csvReader.ReadRow(row)) 
		{
			if (firstRow == null)
			{
				firstRow = new List<string>();
				for (int i = 0; i < row.Count; i++)
				{
					var key = row[i].ToLower();

					if (!string.IsNullOrWhiteSpace(key))
					{
						dict.Add(key, new Dictionary<string, string>());
					}

					firstRow.Add(key);
				}
			}
			else
			{
				var rowKey = row[0].ToLower();
				if (!string.IsNullOrWhiteSpace(rowKey))
				{
					for (int i = 1; i < row.Count; i++)
					{
						var headerKey = firstRow[i];
						if (string.IsNullOrWhiteSpace(headerKey))
							continue;
						
						var rowContent = row[i];
						if (rowKey.Length > 0 && row[i].Length > 0)
						{
							if (!dict[headerKey].ContainsKey(rowKey))
							{
								dict[headerKey].Add(rowKey, rowContent);
							}
							else
							{
								Debug.LogWarningFormat("Key '{0}' already exists in list", rowKey);
							} 
//							Debug.Log(rowKey + " " + headerKey + " " +rowContent);
						}
					}
				}
			}

			row.Clear();
		}

		return dict;
	}
	
	public static Stream GenerateStreamFromString(string s)
	{
		MemoryStream stream = new MemoryStream();
		StreamWriter writer = new StreamWriter(stream);
		writer.Write(s);
		writer.Flush();
		stream.Position = 0;
		return stream;
	}
}