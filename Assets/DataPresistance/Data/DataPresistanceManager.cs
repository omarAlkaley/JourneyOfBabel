using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataPresistanceManager : MonoBehaviour, IDataPresistance
{
	[Header("File Storage Config")]
	[SerializeField] private string fileName;

	private bool doesDataExist;

	public static DataPresistanceManager Instance { get; private set; }

	private GameData gameData;
	private List<IDataPresistance> dataPersistenceObjects;
	public static FileDataHandler dataHandler;

	public event Action OnLoadData;
	public event Action OnDataNotExist;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject); // Optional if you want this manager to persist across scenes
		}
		else
		{
			Destroy(gameObject); // Destroy duplicate instance
			return;
		}
	}

	private void Start()
	{
		dataHandler = new FileDataHandler(Application.persistentDataPath , fileName);
		dataPersistenceObjects = FindAllDataPersistenceObjects();

		LoadGame();

		// Ensure event invocation only if there are listeners
		if (doesDataExist && OnLoadData != null)
		{
			OnLoadData.Invoke();
			Debug.Log("LoadData");
		}
		else if (!doesDataExist && OnDataNotExist != null)
		{
			OnDataNotExist.Invoke();
			Debug.Log("data not loaded");
		}
	}

	public void NewGame()
	{
		gameData = new GameData();
		doesDataExist = false;
	}

	public void LoadGame()
	{
		// Load any saved data from a file using the data handler
		gameData = dataHandler.Load();

		// If no data can be loaded, initialize to a new game.
		if (gameData == null)
		{
			Debug.LogError("No data found. Initializing to defaults.");
			NewGame();
		}
		else
		{
			doesDataExist = true;
		}

		// Push the loaded data to all the scripts that need it
		foreach (IDataPresistance dataPersistenceObj in dataPersistenceObjects)
		{
			dataPersistenceObj.LoadData(gameData);
		}

		Debug.Log("Loaded current wall is: " + gameData.currentWall);
	}

	public void SaveGame()
	{
		// Pass the data to other scripts so they can update it
		foreach (IDataPresistance dataPersistenceObj in dataPersistenceObjects)
		{
			dataPersistenceObj.SaveData(ref gameData);
		}
		doesDataExist = true;
		// Save the updated data to a file
		dataHandler.Save(gameData);
	}

	private void OnApplicationQuit()
	{
		SaveGame();
	}

	// Find all objects in the scene that implement IDataPersistence
	private List<IDataPresistance> FindAllDataPersistenceObjects()
	{
		return FindObjectsOfType<MonoBehaviour>().OfType<IDataPresistance>().ToList();
	}

	// Interface methods to handle loading and saving
	public void LoadData( GameData gameData )
	{
		this.doesDataExist = gameData.doesDataExist;
	}

	public void SaveData( ref GameData gameData )
	{
		gameData.doesDataExist = this.doesDataExist;
	}
}