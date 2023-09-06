using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
class SerializedDict<T1, T2> : ISerializationCallbackReceiver
{
	[SerializeField]
	List<T1> keys = new List<T1>();
	
	[SerializeField]
	List<T2> values = new List<T2>();
	
	public Dictionary<T1, T2> dictionary = new Dictionary<T1, T2>();

	public void OnBeforeSerialize()
	{
		keys.Clear();
		values.Clear();
		foreach (var kvp in dictionary)
		{
			keys.Add(kvp.Key);
			values.Add(kvp.Value);
		}
	}

	public void OnAfterDeserialize()
	{
		dictionary = new Dictionary<T1, T2>();
		var count = Mathf.Min(keys.Count, values.Count);
		for (int i = 0; i < count; i++)
		{
			dictionary.Add(keys[i], values[i]);
		}
	}
}