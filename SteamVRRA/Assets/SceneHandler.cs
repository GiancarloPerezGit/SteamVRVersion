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
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.tag == "Click")
        {
            Debug.Log(e.target.name + " click name");
            bms.OnClick(e.target.gameObject.GetComponent<Button>());
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