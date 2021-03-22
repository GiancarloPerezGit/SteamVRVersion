using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothAxisMode : MonoBehaviour
{
    public Animation A1Rotate;
    public Animation A2Rotate;
    public Animation A3Rotate;
    public Animation A4Rotate;
    public Animation A5Rotate;
    public Animation A6Rotate;

    private float normTime1 = 0.5f;
    private float normTime2 = 0.425531914893617f;
    private float normTime3 = 0.7608695652173913f;
    private float normTime4 = 0.5f;
    private float normTime5 = 0.5f;
    private float normTime6 = 0.5f;

    private float jogSp;

    private ButtonManagerScript bhs;
    public SpeedPopup sp;
    void Start()
    {
        bhs = GameObject.FindGameObjectWithTag("BMS").GetComponent<ButtonManagerScript>();
        A1Rotate.Play("A1Rotate");
        A1Rotate["A1Rotate"].normalizedTime = 0.5f;
        A1Rotate["A1Rotate"].speed = 0;
        A2Rotate.Play("A2Rotate");
        A2Rotate["A2Rotate"].normalizedTime = 0.425531914893617f;
        A2Rotate["A2Rotate"].speed = 0;
        A3Rotate.Play("A3Rotate");
        A3Rotate["A3Rotate"].normalizedTime = 0.7608695652173913f;
        A3Rotate["A3Rotate"].speed = 0;
        A4Rotate.Play("A4Rotate");
        A4Rotate["A4Rotate"].normalizedTime = 0.5f;
        A4Rotate["A4Rotate"].speed = 0;
        A5Rotate.Play("A5Rotate");
        A5Rotate["A5Rotate"].normalizedTime = 0.5f;
        A5Rotate["A5Rotate"].speed = 0;
        A6Rotate.Play("A6Rotate");
        A6Rotate["A6Rotate"].normalizedTime = 0.5f;
        A6Rotate["A6Rotate"].speed = 0;
        print(A2Rotate["A2Rotate"].length + " Anim length");
    }

    private void OnEnable()
    {
        //Abhs = GameObject.FindGameObjectWithTag("BMS").GetComponent<ButtonManagerScript>();
        A1Rotate.Play("A1Rotate", PlayMode.StopAll);
        A1Rotate["A1Rotate"].normalizedTime = 0.5f;
        A1Rotate["A1Rotate"].speed = 0;
        A2Rotate.Play("A2Rotate", PlayMode.StopAll);
        A2Rotate["A2Rotate"].normalizedTime = 0.425531914893617f;
        A2Rotate["A2Rotate"].speed = 0;
        A3Rotate.Play("A3Rotate", PlayMode.StopAll);
        A3Rotate["A3Rotate"].normalizedTime = 0.7608695652173913f;
        A3Rotate["A3Rotate"].speed = 0;
        A4Rotate.Play("A4Rotate", PlayMode.StopAll);
        A4Rotate["A4Rotate"].normalizedTime = 0.5f;
        A4Rotate["A4Rotate"].speed = 0;
        A5Rotate.Play("A5Rotate", PlayMode.StopAll);
        A5Rotate["A5Rotate"].normalizedTime = 0.5f;
        A5Rotate["A5Rotate"].speed = 0;
        A6Rotate.Play("A6Rotate", PlayMode.StopAll);
        A6Rotate["A6Rotate"].normalizedTime = 0.5f;
        A6Rotate["A6Rotate"].speed = 0;
    }

    //private void OnDisable()
    //{
    //    normTime1 = A1Rotate["A1Rotate"].time;
    //    normTime2 = A2Rotate["A2Rotate"].time;
    //    normTime3 = A3Rotate["A3Rotate"].time;
    //    normTime4 = A4Rotate["A4Rotate"].time;
    //    normTime5 = A5Rotate["A5Rotate"].time;
    //    normTime6 = A6Rotate["A6Rotate"].time;
    //}

    public void newTimes(float a1Tim, float a2Tim, float a3Tim, float a4Tim, float a5Tim, float a6Tim)
    {

        print(a2Tim + "This is stop 2");

        A1Rotate["A1Rotate"].time = (a1Tim + 170f)/60f;
        A2Rotate["A2Rotate"].time = (a2Tim * -1 + 190f) / 60f;
        A3Rotate["A3Rotate"].time = (a3Tim + 120f) / 60f;
        A4Rotate["A4Rotate"].time = (a4Tim + 185f) / 60f;
        A5Rotate["A5Rotate"].time = (a5Tim + 120f) / 60f;
        A6Rotate["A6Rotate"].time = (a6Tim + 350f) / 60f;

        print("A2Rot " + (a2Tim + 190f) / 60f);
        print("A3Rot " + (a3Tim + 120f) / 60f);
        print("A4Rot " + (a4Tim + 185f) / 60f);
        print("A5Rot " + (a5Tim + 120f) / 60f);
        print("A6Rot " + (a6Tim + 350f) / 60f);


        A1Rotate.Play("A1Rotate");
        A2Rotate.Play("A2Rotate");
        A3Rotate.Play("A3Rotate");
        A4Rotate.Play("A4Rotate");
        A5Rotate.Play("A5Rotate");
        A6Rotate.Play("A6Rotate");

    }

    void Update()
    {
        jogSp = sp.jogSp;
        print(A1Rotate["A1Rotate"].time + " tim");
        print(A1Rotate["A1Rotate"].length + " tim");

        if (bhs.BtnA1PlusOn && A1Rotate["A1Rotate"].time < A1Rotate["A1Rotate"].length)
        {
            A1Rotate["A1Rotate"].speed = jogSp/100;
        }
        else if (bhs.BtnA2PlusOn && A2Rotate["A2Rotate"].time < A2Rotate["A2Rotate"].length)
        {
            A2Rotate["A2Rotate"].speed = jogSp / 100;
        }
        else if (bhs.BtnA3PlusOn && A3Rotate["A3Rotate"].time < A3Rotate["A3Rotate"].length)
        {
            A3Rotate["A3Rotate"].speed = jogSp / 100;
        }
        else if (bhs.BtnA4PlusOn && A4Rotate["A4Rotate"].time < A4Rotate["A4Rotate"].length)
        {
            A4Rotate["A4Rotate"].speed = jogSp / 100;
        }
        else if (bhs.BtnA5PlusOn && A5Rotate["A5Rotate"].time < A5Rotate["A5Rotate"].length)
        {
            A5Rotate["A5Rotate"].speed = jogSp / 100;
        }
        else if (bhs.BtnA6PlusOn && A6Rotate["A6Rotate"].time < A6Rotate["A6Rotate"].length)
        {
            A6Rotate["A6Rotate"].speed = jogSp / 100;
        }
        else if (bhs.BtnA1MinusOn && A1Rotate["A1Rotate"].time > 0f)
        {
            A1Rotate["A1Rotate"].speed = jogSp / -100;
        }
        else if (bhs.BtnA2MinusOn && A2Rotate["A2Rotate"].time > 0f)
        {
            A2Rotate["A2Rotate"].speed = jogSp / -100;
        }
        else if (bhs.BtnA3MinusOn && A3Rotate["A3Rotate"].time > 0f)
        {
            A3Rotate["A3Rotate"].speed = jogSp / -100;
        }
        else if (bhs.BtnA4MinusOn && A4Rotate["A4Rotate"].time > 0f)
        {
            A4Rotate["A4Rotate"].speed = jogSp / -100;
        }
        else if (bhs.BtnA5MinusOn && A5Rotate["A5Rotate"].time > 0f)
        {
            A5Rotate["A5Rotate"].speed = jogSp / -100;
        }
        else if (bhs.BtnA6MinusOn && A6Rotate["A6Rotate"].time > 0f)
        {
            A6Rotate["A6Rotate"].speed = jogSp / -100;
        }
        else
        {
            A1Rotate["A1Rotate"].speed = 0;
            A2Rotate["A2Rotate"].speed = 0;
            A3Rotate["A3Rotate"].speed = 0;
            A4Rotate["A4Rotate"].speed = 0;
            A5Rotate["A5Rotate"].speed = 0;
            A6Rotate["A6Rotate"].speed = 0;
        }

        normTime1 = A1Rotate["A1Rotate"].time;
        normTime2 = A2Rotate["A2Rotate"].time;
        normTime3 = A3Rotate["A3Rotate"].time;
        normTime4 = A4Rotate["A4Rotate"].time;
        normTime5 = A5Rotate["A5Rotate"].time;
        normTime6 = A6Rotate["A6Rotate"].time;

    }
}
