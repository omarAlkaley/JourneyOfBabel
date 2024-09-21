using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermissionRequest : MonoBehaviour
{
	void Start()
	{
		// Check if the permission has already been granted
		if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.ExternalStorageRead) ||
			!UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.ExternalStorageWrite))
		{
			// Request both read and write permissions
			UnityEngine.Android.Permission.RequestUserPermission(UnityEngine.Android.Permission.ExternalStorageRead);
			UnityEngine.Android.Permission.RequestUserPermission(UnityEngine.Android.Permission.ExternalStorageWrite);
		}
		else
		{
			Debug.Log("Permissions already granted.");
		}
	}
}
