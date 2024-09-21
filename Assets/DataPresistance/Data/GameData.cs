using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameData
{
	public int currentWall;
	public bool enableButton;
	public bool doesDataExist;
	public float timeBetweenEachSave;
	public List<bool> toggleStates;
	// the values defined in this constructor will be the default values
	// the game starts with when there's no data to load
	public GameData()
	{
		this.currentWall = 0;
		this.enableButton = false;
		doesDataExist = false; 
		this.timeBetweenEachSave = 20;
		toggleStates = new(){ false, false,false};
	}
}
