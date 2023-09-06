# Unity Localization Tools

CSV-based localization tools for Unity as used in [My Exercise](https://myex.jp/) or [KIDS](https://playkids.ch/). There may be more sophisticated systems, but this one works for us. 

Includes:
- Custom importer that imports a csv file to a unity data asset to use for localization.
- Minimal sample included.
- LocalizedText component: Does the lookup to find the right localization. Use the resulting text in your UI.
- Helper to download a csv directly from the web into your project, e.g. from a public google docs link (totally optional).
- Utility to map from the Unity-detected language to the language code you use for localization.

Note: CSV files use the ".loc" extension to make the importer happy.

Use at your own risk, no support provided.

By [Mario von Rickenbach](http://mariov.ch)