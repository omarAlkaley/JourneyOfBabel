using UnityEngine;
using System.IO;

public class VersionCheckWithJSON : MonoBehaviour
{
	// Class to represent the version data in JSON format
	[System.Serializable]
	public class VersionData
	{
		public string version;
	}

	private string versionFilePath;
	private string saveFilePath;

	private void Start()
	{
		// Define the paths for the version file and save file
		versionFilePath = Path.Combine(Application.persistentDataPath , "appVersion.json");
		saveFilePath = DataPresistanceManager.dataHandler.GetDataPath();

		// Get the current app version
		string currentVersion = Application.version;

		// Check if the JSON version file exists
		if (File.Exists(versionFilePath))
		{
			// Read the stored version from the JSON file
			string json = File.ReadAllText(versionFilePath);
			VersionData versionData = JsonUtility.FromJson<VersionData>(json);

			// Compare the stored version with the current version
			if (versionData.version != currentVersion)
			{
				// If save file exists, delete it
				if (File.Exists(saveFilePath))
				{
					File.Delete(saveFilePath);
				}
			}
		}

		// Update the JSON file with the current version
		SaveVersion(currentVersion);
	}

	// Method to save the current version in the JSON file
	private void SaveVersion( string version )
	{
		VersionData versionData = new VersionData();
		versionData.version = version;

		// Write the version data to JSON
		string json = JsonUtility.ToJson(versionData , true);
		File.WriteAllText(versionFilePath , json);
		Debug.Log("App version saved: " + version);
	}
}