using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class AutoSaveController : MonoBehaviour, IDataPresistance
{
	[SerializeField] List<Toggle> toggles;
	[SerializeField] AutoSaveCoroutine coroutineController;
	float newWaitTime = 0;
	void Start()
	{
		foreach (var toggle in toggles)
		{
			toggle.onValueChanged.AddListener(delegate { OnToggleChanged(toggle); });
		}
	}

	void OnToggleChanged( Toggle activeToggle )
	{
		if (activeToggle.isOn)
		{
			foreach (var toggle in toggles)
			{
				if (toggle != activeToggle) toggle.isOn = false;
			}
			switch (activeToggle.name)
			{
				case "20Sec":
					newWaitTime = 20f;
					break;
				case "2Min":
					newWaitTime = 120f; 
					break;
				case "3Min":
					newWaitTime = 180f; 
					break;
			}
			coroutineController.UpdateWaitTime(newWaitTime);
		}
	}

	public void LoadData( GameData gameData )
	{
		for (int i = 0; i < toggles.Count; i++)
		{
			if (i < gameData.toggleStates.Count)
			{
				toggles[i].isOn = gameData.toggleStates[i];
			}
		}
	}

	public void SaveData( ref GameData gameData )
	{
		gameData.toggleStates.Clear();
		foreach (var toggle in toggles)
		{
			gameData.toggleStates.Add(toggle.isOn);
		}
	}
}