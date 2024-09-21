using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AutoSaveCoroutine : MonoBehaviour, IDataPresistance
{
	[SerializeField] DataPresistanceManager dataPresistanceManager;
	[SerializeField] private Text autoSaveText;
	 
	float timeBetweenEachSave;

	bool autoSaveOn;

	IEnumerator Start()
	{
		while (true)
		{
			if (autoSaveOn)
			{
				autoSaveText.enabled = true;
				autoSaveText.GetComponent<Animator>().SetTrigger("autoSave");
				dataPresistanceManager.SaveGame();
				yield return new WaitForSeconds(timeBetweenEachSave);
			}
			else
			{
				yield return null;
			}
		}
	}
	public void UpdateWaitTime( float newWaitTime )
	{
		timeBetweenEachSave = newWaitTime;
	}

	public void EnableAutoSaveRoutine()
	{
		autoSaveOn = true;
	}
	public void LoadData( GameData gameData )
	{
		this.timeBetweenEachSave = gameData.timeBetweenEachSave;
	}

	public void SaveData( ref GameData gameData )
	{
		gameData.timeBetweenEachSave = this.timeBetweenEachSave;
	}
}
