using UnityEngine;
using System.IO;
using System;

public class FileDataHandler
{
	private string dataDirPath;
	private string dataFileName;

	public FileDataHandler( string dataDirPath , string dataFileName )
	{
		this.dataDirPath = dataDirPath;
		this.dataFileName = dataFileName;
	}

	public GameData Load()
	{
		string fullPath = GetDataPath();
		GameData loadedData = null;

		if (File.Exists(fullPath))
		{
			try
			{
				// Load the serialized data from the file
				string dataToLoad = File.ReadAllText(fullPath);

				// Deserialize JSON into GameData object
				loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
			}
			catch (Exception e)
			{
				LogFileError("load" , fullPath , e);
			}
		}
		else
		{
			Debug.LogWarning("No save file found at path: " + fullPath);
		}

		return loadedData;
	}

	public void Save( GameData data )
	{
		string fullPath = GetDataPath();

		try
		{
			// Ensure the directory exists
			Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

			// Serialize GameData to JSON and write it to file
			string dataToStore = JsonUtility.ToJson(data , true);
			File.WriteAllText(fullPath , dataToStore);
		}
		catch (Exception e)
		{
			LogFileError("save" , fullPath , e);
		}
	}

	// Helper method to get the data path
	public string GetDataPath()
	{
		return Path.Combine(dataDirPath , dataFileName);
	}

	// Centralized error logging method for file operations
	private void LogFileError( string operation , string path , Exception e )
	{
		Debug.LogError($"Error occurred while trying to {operation} data at path: {path}\n{e}");
	}
	
};
