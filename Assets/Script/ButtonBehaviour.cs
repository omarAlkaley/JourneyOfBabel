using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public enum ButtonId
    {
        roomChangeButton, returnButton
    }

    public ButtonId ThisButtonId;

    private DisplayImage currentDisplay;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }

    void Update()
    {
        HideDisplay();
        Display();
    }

    void HideDisplay()
    {
        if (currentDisplay.CurrentState == DisplayImage.State.normal && ThisButtonId == ButtonId.returnButton)
        {
            HideButton();
        }

        if (currentDisplay.CurrentState == DisplayImage.State.zoom && ThisButtonId == ButtonId.roomChangeButton)
        {
            HideButton();
        }
    }

    void Display()
    {
        if (currentDisplay.CurrentState == DisplayImage.State.zoom && ThisButtonId == ButtonId.returnButton)
        {
            ShowButton();
        }

        if (currentDisplay.CurrentState == DisplayImage.State.normal && ThisButtonId == ButtonId.roomChangeButton)
        {
            ShowButton();
        }
    }

    void HideButton()
    {
        GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                GetComponent<Image>().color.b, 0);
        GetComponent<Button>().enabled = false;
        this.transform.SetSiblingIndex(0);
    }

    void ShowButton()
    {
        GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                GetComponent<Image>().color.b, 1);
        GetComponent<Button>().enabled = true;
    }
}
