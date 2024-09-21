using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ButtonPair
{
    public Button firstButton;
    public Button secondButton;
    public GameObject associatedObject;
    public GameObject associatedObject2;
    
    public Vector3 newScale = new Vector3(1f, 1f, 1f);
}