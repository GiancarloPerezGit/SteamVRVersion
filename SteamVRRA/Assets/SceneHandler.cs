using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class SceneHandler : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    private bool hover = false;
    private bool startHold = false;
    private Color normCol;
    private Color pressCol;
    public ButtonManagerScript bms;
    public ProjectRoboDK.CodeWindow cw;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
        laserPointer.PointerHold += PointerHolding;
        laserPointer.PointerRelease += PointerReleased;
    }

    public void PointerReleased(object sender, PointerEventArgs e)
    {
        if (e.target.tag == "Hold")
        {
            Debug.Log("Button was released");
            ColorBlock custom = e.target.gameObject.GetComponent<Button>().colors;
            custom.normalColor = normCol;
            custom.pressedColor = pressCol;
            e.target.gameObject.GetComponent<Button>().colors = custom;
            bms.OnRelease();
        }
        if (e.target.tag == "PlayClick" || e.target.tag == "BackClick")
        {
            Debug.Log("Button was released");
            ColorBlock custom = e.target.gameObject.GetComponent<Button>().colors;
            custom.normalColor = normCol;
            custom.pressedColor = pressCol;
            e.target.gameObject.GetComponent<Button>().colors = custom;
            cw.unHold();
        }


    }

    public void PointerHolding(object sender, PointerEventArgs e)
    {
        if (e.target.tag == "Hold")
        {
            Debug.Log("Button was held");
            normCol = e.target.gameObject.GetComponent<Button>().colors.normalColor;
            pressCol = e.target.gameObject.GetComponent<Button>().colors.pressedColor;
            ColorBlock custom = e.target.gameObject.GetComponent<Button>().colors;
            custom.normalColor = pressCol;
            custom.pressedColor = normCol;
            e.target.gameObject.GetComponent<Button>().colors = custom;
            bms.OnPress(e.target.gameObject.GetComponent<Button>());
        }
        if (e.target.tag == "PlayClick")
        {
            Debug.Log("Button was held");
            normCol = e.target.gameObject.GetComponent<Button>().colors.normalColor;
            pressCol = e.target.gameObject.GetComponent<Button>().colors.pressedColor;
            ColorBlock custom = e.target.gameObject.GetComponent<Button>().colors;
            custom.normalColor = pressCol;
            custom.pressedColor = normCol;
            e.target.gameObject.GetComponent<Button>().colors = custom;
            cw.hold();
        }
        if (e.target.tag == "BackClick")
        {
            Debug.Log("Button was held");
            normCol = e.target.gameObject.GetComponent<Button>().colors.normalColor;
            pressCol = e.target.gameObject.GetComponent<Button>().colors.pressedColor;
            ColorBlock custom = e.target.gameObject.GetComponent<Button>().colors;
            custom.normalColor = pressCol;
            custom.pressedColor = normCol;
            e.target.gameObject.GetComponent<Button>().colors = custom;
            cw.holdNeg();
        }
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.tag == "Click" || e.target.tag == "MovementType")
        {
            Debug.Log(e.target.name + " click name");
            ExecuteEvents.Execute(e.target.gameObject, new BaseEventData(EventSystem.current), ExecuteEvents.submitHandler);
            //bms.OnClick(e.target.gameObject.GetComponent<Button>());
        }
        else if(e.target.tag == "Other")
        {
            
        }
            
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.tag == "Click" || e.target.tag == "Hold")
        {
            Debug.Log("Button was entered");
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.tag == "Click" || e.target.tag == "Hold")
        {
            Debug.Log("Button was exited");
        }
    }

    
}