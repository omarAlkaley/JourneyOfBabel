using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    private DisplayImage currentDisplay;
    private float initialCameraSize;
    private Vector3 initialCameraPosition;

    private ZoomInObject[] zoomInObjects;

    public AudioClip incorrect;
    public AudioSource source;

    void Awake()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        initialCameraSize = Camera.main.orthographicSize;
        initialCameraPosition = Camera.main.transform.position;

        zoomInObjects = FindObjectsOfType<ZoomInObject>();
    }

	public void OnRightClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall + 1;
    }

    public void OnLeftClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;
    }

    public void OnRightClickArrow1()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.Next);
    }

    public void OnLeftClickArrow1()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.Previous);
    }

    public void OnLeftClickArrow5()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall5);
    }

    public void OnLeftClickArrow6()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall1);
    }
    public void OnLeftClickArrow2()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall2);
    }
    public void OnLeftClickArrow9()
    {

        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall9);
        source.clip = incorrect;
        source.Play();
    }
    public void OnLeftClickArrow10()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall10);
    }
    public void OnLeftClickArrow77()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall6);
    }
    public void OnLeftClickArrow11()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall11);
    }
    public void OnLeftClickArrow12()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall12);
    }
    public void OnLeftClickArrow13()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall13);
    }
    public void OnLeftClickArrow14()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall14);
    }
    public void OnLeftClickArrow15()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall15);
    }
    public void OnLeftClickArrow16()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall16);
    }
    public void OnLeftClickArrow17()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall17);
    }
    public void OnLeftClickArrow18()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall18);
    }
    public void OnLeftClickArrow19()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall19);
    }
    public void OnLeftClickArrow20()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall20);
    }
    public void OnLeftClickArrow7()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall7);
    }
    public void OnLeftClickArrow8()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall8);
    }
    public void OnLeftClickArrow23()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall23);
    }
    public void OnLeftClickArrow24()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall24);
    }
    public void OnLeftClickArrow25()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall25);
    }
    public void OnLeftClickArrow26()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall26);
    }
    public void OnLeftClickArrow27()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall27);
    }
  //  public void OnLeftClickArrow22()
   // {
   //     currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall22);
   // }
    public void OnLeftClickArrow29()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall29);
    }
    public void OnLeftClickArrow30()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall30);
    }
    public void OnLeftClickArrow31()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall31);
    }
    public void OnLeftClickArrow32()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall32);
    }
    public void OnLeftClickArrow33()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall33);
    }
    public void OnLeftClickArrow34()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall34);
    }
    public void OnLeftClickArrow35()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall35);
    }
    public void OnLeftClickArrow36()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall36);
    }
    public void OnLeftClickArrow37()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall37);
    }
    public void OnLeftClickArrow38()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall38);
    }
    public void OnLeftClickArrow39()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall39);
    }
    public void OnLeftClickArrow40()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall40);
    }
    public void OnLeftClickArrow41()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall41);
    }
    public void OnLeftClickArrow42()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall42);
    }
    public void OnLeftClickArrow43()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall43);
    }
    public void OnLeftClickArrow44()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall44);
    }
    public void OnLeftClickArrow45()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall45);
    }
    public void OnLeftClickArrow46()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall46);
    }
    public void OnLeftClickArrow47()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall47);
    }
    public void OnLeftClickArrow48()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall48);
    }
    public void OnLeftClickArrow49()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall49);
    }
    public void OnLeftClickArrow50()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall50);
    }
    public void OnLeftClickArrow51()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall51);
    }
    public void OnLeftClickArrow52()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall52);
    }
    public void OnLeftClickArrow53()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall53);
    }
    public void OnLeftClickArrow54()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall54);
    }
    public void OnLeftClickArrow55()
    {
        currentDisplay.OnButtonClick(DisplayImage.ButtonType.GoToWall55);
    }
    public void OnClickReturn()
    {
        if (currentDisplay.CurrentState == DisplayImage.State.idle) return;

        if (currentDisplay.CurrentState == DisplayImage.State.zoom)
        {
            currentDisplay.CurrentState = DisplayImage.State.normal;

            foreach (var zoomInObject in zoomInObjects)
            {
                zoomInObject.gameObject.layer = 0;
            }

            Camera.main.orthographicSize = initialCameraSize;
            Camera.main.transform.position = initialCameraPosition;
        }
        else
        {
            currentDisplay.GetComponent<SpriteRenderer>().sprite
                = Resources.Load<Sprite>("Sprites/wall" + currentDisplay.CurrentWall);
            currentDisplay.CurrentState = DisplayImage.State.normal;

            Camera.main.orthographicSize = initialCameraSize;
            Camera.main.transform.position = initialCameraPosition;

            foreach (var zoomInObject in zoomInObjects)
            {
                zoomInObject.gameObject.layer = 0;
            }
        }
    }
}

