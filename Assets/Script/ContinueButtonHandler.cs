using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ContinueButtonHandler : MonoBehaviour,IDataPresistance
{
	public static bool enableButton;
	public Button continueButton;
	public void LoadData( GameData gameData )
	{
		enableButton = gameData.enableButton;
	}

	public void SaveData( ref GameData gameData )
	{
		gameData.enableButton = enableButton;
	}

	// Start is called before the first frame update
	void Start()
    {
		continueButton = GetComponent<Button>();
		DataPresistanceManager.Instance.OnLoadData += EnableLoadSavedDataButton;
		DataPresistanceManager.Instance.OnDataNotExist += DisableLoadSavedDataButton;
	}

	private void EnableLoadSavedDataButton()
	{
		continueButton.enabled = true;
		continueButton.GetComponentInChildren<SpriteRenderer>().color = Color.white;
	}
	private void DisableLoadSavedDataButton()
	{
		continueButton.enabled = false;
		continueButton.GetComponentInChildren<SpriteRenderer>().color = Color.gray;
	}
	// Update is called once per frame
	void Update()
    {
        
    }
}
