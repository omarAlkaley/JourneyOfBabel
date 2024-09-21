using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPresistance
{
	void LoadData(GameData gameData);

	void SaveData(ref GameData gameData);
}
