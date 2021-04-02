using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Valve.VR.InteractionSystem
{
    public class RoboticAcademyLessonScript : MonoBehaviour
    {
        public Animation A1axisRotate;
        public Animation A2axisRotate;
        public Animation A3axisRotate;
        public Animation A4axisRotate;
        public Animation A5axisRotate;
        public Animation A6axisRotate;

        public Animation A1highRotate;
        public Animation A2highRotate;
        public Animation A3highRotate;
        public Animation A4highRotate;
        public Animation A5highRotate;
        public Animation A6highRotate;

        public GameObject teleTargetTutorial;
        public GameObject teleTargetPNP;
        public GameObject teleTargetAxis;
        public GameObject teleTargetPNPBehind;

        public GameObject logoObject;
        public GameObject clickTarget;

        public GameObject teleportGraphic;
        public GameObject turnGraphic;
        public GameObject clickGraphic;
        public GameObject dashboardGraphic;

        public GameObject Dashboard;

        public GameObject Teleport;

        public GameObject workEvelope;
        public GameObject coverPanel;

        public GameObject axisBot;
        public GameObject highlightBot;
        public GameObject lessonBot;

        public GameObject UIarrows;

        public GameObject lessonAnimation;

        public GameObject lesson1CompleteBox;

        public GameObject lessonAudio;

        public GameObject pnpSceneObject;

        public GameObject pnpLights;

        public GameObject clickGraphicPNP;

        public GameObject lesson1Graphics;

        public GameObject CheckOverlap;

        public GameObject listImage;

        //In hinde sight I should have just imported the control pannel earlier
        //would have saves a ton of game object calls.
        public GameObject controlPannel;
        public GameObject lightWall;

        public bool teleTurnPressed = false;
        public bool menuButtonPressed = false;
        public bool targetPressed = false;

        public bool eStopDisengaged = true;
        //bools for the interactive parts of lesson 1
        public bool targetT1Pressed = false;
        public bool targetT1ConfirmPressed = false;
        public bool axisButtonPressed = false;
        public bool worldButtonPressed = false;

        public bool estopButtonPressed = false;
        public bool estopButtonConfirmPressed = false;

        public bool triggerheld = false;
        public bool isTriggerheld = false;

        public bool robotOverlap = false;

        public float timeRemaining = 5;

        //these veriable need to be moved back into the lesson 0-3a, 0-3b, and 0-3c
        private bool completeTele = false;
        private bool completeView = false;
        private bool completeClick = false;

        //private
        private Animator pnpKR420Animation;
        private Animator pnpKR30Animation;
        private Animator pnpToolAnimation;
        private Animator pnpBrickAnimation;


        //lesson 1-5 boolean
        //private bool eStopDisengaged = false;
        //private bool t1varified = false;
        //private bool enableingSwitchOn = false;
        //private bool driverOn = false;

        //light
        private Light pnpKR420Light;
        private Light pnpKR30Light;

        public Trackpad trp;
        public DashboardSteamVR dsvr;
        public Sample.SkeletonUIOptions skui;
        //----a TON of click methods. because it would be faster than creating a simple Case machine---
        public void OnTargetClick()
        {

            targetPressed = true;
        }

        public void OnTargetT1Click()
        {

            targetT1Pressed = true;
        }

        public void OnTargetT1ConfirmClick()
        {

            estopButtonConfirmPressed = true;
            targetT1ConfirmPressed = true;
        }

        public void OnEstopConfirmClick()
        {

            estopButtonConfirmPressed = true;

        }

        public void OnEstopClick()
        {

            estopButtonPressed = true;
        }

        public void OnAxisButtonClick()
        {
            //when the user turns using the track pad signal true
            axisButtonPressed = true;
        }

        public void OnWorldButtonClick()
        {
            //when the user turns using the track pad signal true
            worldButtonPressed = true;
        }

        //----------start stop code for trigger timing------
        public void HeldTriggerTimerStart()
        {

            isTriggerheld = true;
        }
        public void HeldTriggerTimerEnd()
        {
            isTriggerheld = false;
            timeRemaining = 5;
        }



        public void OnClick(Button btn)
        {
            switch (btn.name)
            {
                case "EmergencySwitchOff":
                    eStopDisengaged = true;
                    break;
            }
        }
        public void OnTurn()
        {
            //when the user turns using the track pad signal true
            teleTurnPressed = true;
            Debug.Log("turning");
        }

        public void OnOpenDashboard()
        {
            //when the dashboard button is pressed
            menuButtonPressed = true;
        }

        //on the start of the project, run the first co-routine
        private void Start()
        {
            skui.ShowController();
            highlightBot.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            highlightBot.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);
            highlightBot.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);
            highlightBot.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);
            highlightBot.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);
            highlightBot.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(1).GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);

            pnpKR420Animation = pnpSceneObject.transform.GetChild(0).GetComponent<Animator>();
            pnpKR30Animation = pnpSceneObject.transform.GetChild(1).GetChild(0).GetComponent<Animator>();
            pnpBrickAnimation = pnpSceneObject.transform.GetChild(6).GetComponent<Animator>();
            pnpToolAnimation = pnpSceneObject.transform.GetChild(7).GetComponent<Animator>();

            pnpKR420Light = pnpLights.transform.GetChild(14).GetComponent<Light>();
            pnpKR30Light = pnpLights.transform.GetChild(15).GetComponent<Light>();

            StartCoroutine("Lesson0_7");
            //startLesson1();

        }

        private void Update()
        {
            if (isTriggerheld == true)
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                }
                else
                {
                    triggerheld = true;
                }
        }

        //this is a list of enumerators that can be turned on and off and activated on and off of sequence
        //basically a sequencer...

        //methods for animation
        public void pnpAnimatorControllerSpeed(float s)
        {
            pnpKR420Animation.speed = s;
            pnpKR30Animation.speed = s;
            pnpBrickAnimation.speed = s;
            pnpToolAnimation.speed = s;
        }

        //method for lights
        public void pnpLightIntensity(string a, float s)
        {
            if (a == "KR30")
            {
                pnpKR30Light.intensity = s;
            }
            else if (a == "KR240")
            {
                pnpKR420Light.intensity = s;
            }
        }

        //--LESSON 0--VR TUTORIAL//
        IEnumerator Lesson0_1()
        {
            controlPannel.SetActive(false);
            logoObject.SetActive(true);

            yield return new WaitForSeconds(2);
            pnpAnimatorControllerSpeed(0);

            //animation for the RA loop plays
            Teleport.SetActive(false);



            lessonAudio.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            logoObject.SetActive(false);

            yield return new WaitForSeconds(lessonAudio.transform.GetChild(0).GetChild(0).GetComponent<AudioSource>().clip.length - 1);
            lessonAudio.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);


            StartCoroutine("Lesson0_2");
        }

        IEnumerator Lesson0_2()
        {
            //listImage.gameObject.SetActive(true);
            StopCoroutine("Lesson0_1");
            Debug.Log("lesson started 0-2");
            listImage.gameObject.SetActive(true);
            lessonAudio.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(0).GetChild(1).GetComponent<AudioSource>().clip.length);
            lessonAudio.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            StartCoroutine("Lesson0_3a");
            listImage.gameObject.SetActive(false);
        }

        IEnumerator Lesson0_3a()
        {
            StopCoroutine("Lesson0_2");
            Debug.Log("lesson started 0-3a");
            lessonAudio.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
            teleportGraphic.SetActive(true);
            yield return new WaitForSeconds(12);
            teleTargetTutorial.SetActive(true);
            yield return new WaitForSeconds(7);
            Teleport.SetActive(true);

            while (completeTele != true)
            {
                if (teleTargetTutorial.GetComponent<TargetCheck>().targetTeleported == true)
                {
                    completeTele = true;
                    Debug.Log("teleport tutorial completed");
                    teleTargetTutorial.SetActive(false);
                    teleportGraphic.SetActive(false);
                    lessonAudio.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);

                    StartCoroutine("Lesson0_3b");
                }
                yield return null;
            }
        }

        IEnumerator Lesson0_3b()
        {
            StopCoroutine("Lesson0_3a");
            Debug.Log("lesson started 0-3b");
            lessonAudio.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
            yield return new WaitForSeconds(7);
            turnGraphic.SetActive(true);
            teleTurnPressed = false;
            yield return new WaitForSeconds(21);

            while (completeView != true)
            {
                print("test");
                if (trp.turned)
                {
                    completeView = true;
                    Debug.Log("turn tutorial completed");
                    turnGraphic.SetActive(false);
                    lessonAudio.transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
                    StartCoroutine("Lesson0_3c");
                }
                yield return null;
            }
        }

        IEnumerator Lesson0_3c()
        {
            StopCoroutine("Lesson0_3b");
            Debug.Log("lesson started 0-3c");
            lessonAudio.transform.GetChild(0).GetChild(4).gameObject.SetActive(true);
            yield return new WaitForSeconds(5);

            clickTarget.SetActive(true);
            clickGraphic.SetActive(true);
            while (completeClick != true)
            {
                if (targetPressed == true)
                {
                    completeClick = true;
                    Debug.Log("click tutorial completed");
                    clickTarget.SetActive(false);
                    clickGraphic.SetActive(false);
                    lessonAudio.transform.GetChild(0).GetChild(4).gameObject.SetActive(false);
                    StartCoroutine("Lesson0_4");
                }
                yield return null;
            }
        }
        IEnumerator Lesson0_4()
        {
            //controlPannel.SetActive(true);

            Debug.Log("obnoxious code gulag complete");
            StopCoroutine("Lesson0_3c");
            Debug.Log("lesson started 0-4");
            lessonAudio.transform.GetChild(0).GetChild(5).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(0).GetChild(5).GetComponent<AudioSource>().clip.length);
            dashboardGraphic.SetActive(true);

            menuButtonPressed = false;

            while (dsvr.pressed != true)
            {
                lessonAudio.transform.GetChild(0).GetChild(5).gameObject.SetActive(false);
                yield return null;
            }
            dashboardGraphic.SetActive(false);
            StartCoroutine("Lesson0_5");
        }
        IEnumerator Lesson0_5()
        {
            StopCoroutine("Lesson0_4");
            Debug.Log("lesson Started 0-5");
            //bool completeDashboard = false;

            //voice over to go through the dashboard
            menuButtonPressed = false;

            lessonAudio.transform.GetChild(0).GetChild(6).gameObject.SetActive(true);
            Dashboard.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Toggle>().isOn = true;
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(0).GetChild(6).GetComponent<AudioSource>().clip.length);
            lessonAudio.transform.GetChild(0).GetChild(6).gameObject.SetActive(false);

            lessonAudio.transform.GetChild(0).GetChild(7).gameObject.SetActive(true);
            Dashboard.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<Toggle>().isOn = true;
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(0).GetChild(7).GetComponent<AudioSource>().clip.length);
            lessonAudio.transform.GetChild(0).GetChild(7).gameObject.SetActive(false);

            lessonAudio.transform.GetChild(0).GetChild(8).gameObject.SetActive(true);
            Dashboard.transform.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<Toggle>().isOn = true;
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(0).GetChild(8).GetComponent<AudioSource>().clip.length);
            lessonAudio.transform.GetChild(0).GetChild(8).gameObject.SetActive(false);

            lessonAudio.transform.GetChild(0).GetChild(9).gameObject.SetActive(true);
            Dashboard.transform.GetChild(0).GetChild(0).GetChild(3).GetChild(0).GetComponent<Toggle>().isOn = true;
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(0).GetChild(9).GetComponent<AudioSource>().clip.length);
            lessonAudio.transform.GetChild(0).GetChild(9).gameObject.SetActive(false);

            lessonAudio.transform.GetChild(0).GetChild(10).gameObject.SetActive(true);
            Dashboard.transform.GetChild(0).GetChild(0).GetChild(4).GetChild(0).GetComponent<Toggle>().isOn = true;
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(0).GetChild(10).GetComponent<AudioSource>().clip.length);
            lessonAudio.transform.GetChild(0).GetChild(10).gameObject.SetActive(false);

            yield return new WaitForSeconds(5);
            Dashboard.transform.GetChild(0).GetChild(0).GetChild(4).GetChild(0).GetComponent<Toggle>().isOn = false;
            //completeDashboard = true;

            while (dsvr.pressed != true)
            {
                yield return null;

            }
            StartCoroutine("Lesson0_6");
        }
        IEnumerator Lesson0_6()
        {
            pnpAnimatorControllerSpeed(0);

            Debug.Log("lesson Started 0-6");
            lessonAudio.transform.GetChild(0).GetChild(11).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(0).GetChild(11).GetComponent<AudioSource>().clip.length);

            teleTargetPNP.SetActive(true);
            lessonAudio.transform.GetChild(0).GetChild(11).gameObject.SetActive(false);

            completeTele = false;

            while (completeTele != true)
            {
                if (teleTargetPNP.GetComponent<TargetCheck>().targetTeleported == true)
                {
                    completeTele = true;
                    Debug.Log("PNP teleport completed");
                    teleTargetPNP.SetActive(false);

                    //end instruction.
                    StartCoroutine("Lesson0_7");
                }
                yield return null;
            }
        }
        IEnumerator Lesson0_7()
        {
            pnpAnimatorControllerSpeed(0);
            StopCoroutine("Lesson0_6");
            Debug.Log("lesson Started 0-7");
            completeTele = false;
            targetPressed = false;

            lessonAudio.transform.GetChild(0).GetChild(12).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(0).GetChild(12).GetComponent<AudioSource>().clip.length);
            lessonAudio.transform.GetChild(0).GetChild(12).gameObject.SetActive(false);
            teleTargetPNPBehind.SetActive(true);

            while (completeTele != true)
            {
                if (teleTargetPNPBehind.GetComponent<TargetCheck>().targetTeleported == true)
                {

                    completeTele = true;
                    Debug.Log("PNP teleport completed");
                    teleTargetPNPBehind.SetActive(false);

                    pnpLightIntensity("KR30", 30);

                    pnpAnimatorControllerSpeed(0.25f);

                    lessonAudio.transform.GetChild(0).GetChild(13).gameObject.SetActive(true);
                    yield return new WaitForSeconds(5);
                    pnpAnimatorControllerSpeed(1);

                    yield return new WaitForSeconds(12.5f);
                    pnpAnimatorControllerSpeed(0);
                    yield return new WaitForSeconds(1.5f);
                    lessonAudio.transform.GetChild(0).GetChild(13).gameObject.SetActive(false);

                    lessonAudio.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
                    yield return new WaitForSeconds(lessonAudio.transform.GetChild(2).GetChild(0).GetComponent<AudioSource>().clip.length);
                    lessonAudio.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);

                    clickGraphicPNP.gameObject.SetActive(true);

                    while (targetPressed != true)
                    {
                        yield return null;
                    }
                    pnpLightIntensity("KR240", 30);
                    pnpLightIntensity("KR30", 0);

                    clickGraphicPNP.gameObject.SetActive(false);
                    pnpAnimatorControllerSpeed(1);

                    lessonAudio.transform.GetChild(0).GetChild(14).gameObject.SetActive(true);
                    yield return new WaitForSeconds(lessonAudio.transform.GetChild(0).GetChild(14).GetComponent<AudioSource>().clip.length);
                    lessonAudio.transform.GetChild(0).GetChild(14).gameObject.SetActive(false);

                    pnpLightIntensity("KR240", 0);

                    lessonAudio.transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
                    yield return new WaitForSeconds(lessonAudio.transform.GetChild(2).GetChild(1).GetComponent<AudioSource>().clip.length);
                    lessonAudio.transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
                }
                yield return null;
            }

            //StartCoroutine("Lesson0_8");

        }
        //IEnumerator Lesson0_8()
        //{
        //    StopCoroutine("Lesson0_7");
        //    Debug.Log("lesson Started 0-8");
        //    //instructions to move to Axis
        //    //teleTargetAxis.SetActive(true);
        //    completeTele = false;


        //    while (completeTele != true)
        //    {
        //        if (teleTargetAxis.GetComponent<TargetCheck>().targetTeleported == true)
        //        {
        //            completeTele = true;
        //            Debug.Log("Axis teleport completed");
        //            teleTargetAxis.SetActive(false);

        //            //end instruction.
        //            StartCoroutine("Lesson0_9");
        //        }
        //        yield return null;
        //    }

        //}
        //IEnumerator Lesson0_9()
        //{
        //    StopCoroutine("Lesson0_8");
        //    Debug.Log("lesson Started 0-9");
        //    //start talk about the next steps. "open up the dashboard and select the next Lesson

        //    lesson1CompleteBox.gameObject.SetActive(true);
        //    yield return new WaitForSeconds(5);
        //    //StartCoroutine("Lesson0_8");
        //}

        //--LESSON 1--AXIS TUTORIAL//
        public void startLesson1()
        {
            lesson1CompleteBox.gameObject.SetActive(false);
            StartCoroutine("Lesson1_0");

        }
        IEnumerator Lesson1_0()
        {
            lessonAudio.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(0).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            StartCoroutine("Lesson1_1");
        }
        IEnumerator Lesson1_1()
        {
            StopCoroutine("Lesson1_0");
            //overview explination of lesson
            Debug.Log("lesson Started 1-1");

            lessonAudio.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            yield return new WaitForSeconds(10);
            lesson1Graphics.transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(5);
            lesson1Graphics.transform.GetChild(0).gameObject.SetActive(false);
            lesson1Graphics.transform.GetChild(1).gameObject.SetActive(true);
            yield return new WaitForSeconds(7);
            lesson1Graphics.transform.GetChild(1).gameObject.SetActive(false);
            lessonAudio.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);

            StartCoroutine("Lesson1_2");
        }

        IEnumerator Lesson1_2()
        {

            Debug.Log("lesson Started 1-2");
            StopCoroutine("Lesson1_1");

            lessonAudio.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
            yield return new WaitForSeconds(6);
            lesson1Graphics.transform.GetChild(2).gameObject.SetActive(true);
            yield return new WaitForSeconds(6);
            lesson1Graphics.transform.GetChild(2).gameObject.SetActive(false);
            lesson1Graphics.transform.GetChild(3).gameObject.SetActive(true);
            yield return new WaitForSeconds(14);
            lesson1Graphics.transform.GetChild(3).gameObject.SetActive(false);
            yield return new WaitForSeconds(5);
            lessonAudio.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);

            //Explain each axis with hightlight
            axisBot.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            highlightBot.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);

            A1axisRotate.Play("A1Lesson");
            A1highRotate.Play("A1Lesson");


            Debug.Log("axis 1");
            lessonAudio.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(3).GetComponent<AudioSource>().clip.length + 2);
            lessonAudio.transform.GetChild(1).GetChild(3).gameObject.SetActive(false);

            A1axisRotate["A1Lesson"].speed = 0;
            A1highRotate["A1Lesson"].speed = 0;

            A2axisRotate.Play("A2Lesson");
            A2highRotate.Play("A2Lesson");

            axisBot.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            highlightBot.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            //-----------------------------------------------------------------------------

            axisBot.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);
            highlightBot.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);

            lessonAudio.transform.GetChild(1).GetChild(4).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(4).GetComponent<AudioSource>().clip.length + 4);
            lessonAudio.transform.GetChild(1).GetChild(4).gameObject.SetActive(false);

            A2axisRotate["A2Lesson"].speed = 0;
            A2highRotate["A2Lesson"].speed = 0;

            A3axisRotate.Play("A3Lesson");
            A3highRotate.Play("A3Lesson");

            axisBot.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);
            highlightBot.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);
            //-------------------------------------------------------------------------------


            axisBot.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);
            highlightBot.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);

            lessonAudio.transform.GetChild(1).GetChild(5).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(5).GetComponent<AudioSource>().clip.length + 4);
            lessonAudio.transform.GetChild(1).GetChild(5).gameObject.SetActive(false);

            A3axisRotate["A3Lesson"].speed = 0;
            A3highRotate["A3Lesson"].speed = 0;

            A4axisRotate.Play("A4Lesson");
            A4highRotate.Play("A4Lesson");

            axisBot.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);
            highlightBot.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);
            //-------------------------------------------------------------------------------


            axisBot.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);
            highlightBot.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);

            lessonAudio.transform.GetChild(1).GetChild(6).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(6).GetComponent<AudioSource>().clip.length + 4);
            lessonAudio.transform.GetChild(1).GetChild(6).gameObject.SetActive(false);

            A4axisRotate["A4Lesson"].speed = 0;
            A4highRotate["A4Lesson"].speed = 0;

            A5axisRotate.Play("A5Lesson");
            A5highRotate.Play("A5Lesson");


            axisBot.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);
            highlightBot.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);
            //--------------------------------------------------------------------------------


            axisBot.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);
            highlightBot.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);

            lessonAudio.transform.GetChild(1).GetChild(7).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(7).GetComponent<AudioSource>().clip.length + 4);
            lessonAudio.transform.GetChild(1).GetChild(7).gameObject.SetActive(false);

            A5axisRotate["A5Lesson"].speed = 0;
            A5highRotate["A5Lesson"].speed = 0;

            A6axisRotate.Play("A6Lesson");
            A6highRotate.Play("A6Lesson");

            axisBot.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);
            highlightBot.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);
            //----------------------------------------------------------------------------------


            axisBot.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(1).GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);
            highlightBot.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(1).GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);

            lessonAudio.transform.GetChild(1).GetChild(8).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(8).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(8).gameObject.SetActive(false);
            //Explain the axis 6 Flange

            lessonAudio.transform.GetChild(1).GetChild(9).gameObject.SetActive(true);
            yield return new WaitForSeconds(5);

            axisBot.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(1).GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);
            highlightBot.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(1).GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);
            yield return new WaitForSeconds(22);


            yield return null;
            StartCoroutine("Lesson1_3");
        }

        IEnumerator Lesson1_3()
        {
            Debug.Log("lesson Started 1-3");
            StopCoroutine("Lesson1_2");

            lessonAudio.transform.GetChild(1).GetChild(9).gameObject.SetActive(false);

            workEvelope.SetActive(true);
            lessonAudio.transform.GetChild(1).GetChild(10).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(10).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(10).gameObject.SetActive(false);
            workEvelope.SetActive(false);

            //Industrial Vs colabortive

            //industrial video
            //overall safety
            //show safety barrier
            //overall workcell
            //show robot moving to complete task
            lessonAudio.transform.GetChild(1).GetChild(11).gameObject.SetActive(true);
            lesson1Graphics.transform.GetChild(10).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(11).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);



            //colaborative video
            lessonAudio.transform.GetChild(1).GetChild(12).gameObject.SetActive(true);
            //lesson1Graphics.transform.GetChild(5).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(12).GetComponent<AudioSource>().clip.length + 1);
            //lesson1Graphics.transform.GetChild(5).gameObject.SetActive(false);
            lessonAudio.transform.GetChild(1).GetChild(12).gameObject.SetActive(false);

            //In-scene safety
            lessonAudio.transform.GetChild(1).GetChild(13).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(13).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(13).gameObject.SetActive(false);

            lessonAudio.transform.GetChild(1).GetChild(14).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(14).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(14).gameObject.SetActive(false);


            lesson1Graphics.transform.GetChild(10).GetChild(2).GetComponent<RawImage>().color = Color.clear;
            lesson1Graphics.transform.GetChild(10).GetChild(1).gameObject.SetActive(false);

            lightWall.gameObject.SetActive(true);
            lessonAudio.transform.GetChild(1).GetChild(15).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(15).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(15).gameObject.SetActive(false);

            lessonAudio.transform.GetChild(1).GetChild(16).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(16).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(16).gameObject.SetActive(false);
            lightWall.gameObject.SetActive(false);

            lesson1Graphics.transform.GetChild(10).GetChild(2).GetComponent<RawImage>().color = Color.white;
            lesson1Graphics.transform.GetChild(10).GetChild(1).gameObject.SetActive(true);

            //overal safety work
            lessonAudio.transform.GetChild(1).GetChild(17).gameObject.SetActive(true);
            //lesson1Graphics.transform.GetChild(6).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(17).GetComponent<AudioSource>().clip.length + 1);
            //lesson1Graphics.transform.GetChild(6).gameObject.SetActive(false);
            lessonAudio.transform.GetChild(1).GetChild(17).gameObject.SetActive(false);

            lessonAudio.transform.GetChild(1).GetChild(18).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(18).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(18).gameObject.SetActive(false);


            yield return null;
            StartCoroutine("Lesson1_4");

        }
        IEnumerator Lesson1_4()
        {
            //turn on the command pannel here

            Debug.Log("lesson Started 1-4");
            StopCoroutine("Lesson1_3");

            //coverPanel.SetActive(true);


            lessonAudio.transform.GetChild(1).GetChild(19).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(19).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(19).gameObject.SetActive(false);

            controlPannel.gameObject.SetActive(true);

            lessonAudio.transform.GetChild(1).GetChild(20).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(20).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(20).gameObject.SetActive(false);



            //e-stop explination'   
            lessonAudio.transform.GetChild(1).GetChild(21).gameObject.SetActive(true);
            yield return new WaitForSeconds(7);
            UIarrows.transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(21).GetComponent<AudioSource>().clip.length - 7);
            lessonAudio.transform.GetChild(1).GetChild(21).gameObject.SetActive(false);

            //difference between Axis/world'
            UIarrows.transform.GetChild(0).gameObject.SetActive(false);
            lessonAudio.transform.GetChild(1).GetChild(22).gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
            UIarrows.transform.GetChild(1).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(22).GetComponent<AudioSource>().clip.length - 3);

            //I/O button explination
            UIarrows.transform.GetChild(1).gameObject.SetActive(false);
            lessonAudio.transform.GetChild(1).GetChild(23).gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            UIarrows.transform.GetChild(2).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(23).GetComponent<AudioSource>().clip.length - 2);

            //program expliantion
            UIarrows.transform.GetChild(2).gameObject.SetActive(false);
            lessonAudio.transform.GetChild(1).GetChild(24).gameObject.SetActive(true);
            yield return new WaitForSeconds(9);
            UIarrows.transform.GetChild(3).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(24).GetComponent<AudioSource>().clip.length - 9);

            //submenu explination
            UIarrows.transform.GetChild(3).gameObject.SetActive(false);
            lessonAudio.transform.GetChild(1).GetChild(25).gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
            UIarrows.transform.GetChild(4).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(25).GetComponent<AudioSource>().clip.length - 3);

            UIarrows.transform.GetChild(4).gameObject.SetActive(false);
            lessonAudio.transform.GetChild(1).GetChild(26).gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
            UIarrows.transform.GetChild(5).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(26).GetComponent<AudioSource>().clip.length - 3);

            UIarrows.transform.GetChild(5).gameObject.SetActive(false);
            lessonAudio.transform.GetChild(1).GetChild(27).gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            UIarrows.transform.GetChild(5).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(27).GetComponent<AudioSource>().clip.length + 1);

            targetT1Pressed = false;

            while (targetT1Pressed != true)
            {
                yield return null;
            }

            UIarrows.transform.GetChild(5).gameObject.SetActive(false);
            lessonAudio.transform.GetChild(1).GetChild(28).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(28).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(28).gameObject.SetActive(false);

            //lesson J
            lessonAudio.transform.GetChild(1).GetChild(29).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(29).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(29).gameObject.SetActive(false);

            lessonAudio.transform.GetChild(1).GetChild(30).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(30).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(30).gameObject.SetActive(false);

            lessonAudio.transform.GetChild(1).GetChild(31).gameObject.SetActive(true);
            //lesson1Graphics.transform.GetChild(8).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(31).GetComponent<AudioSource>().clip.length + 1);
            //lesson1Graphics.transform.GetChild(8).gameObject.SetActive(false);
            lessonAudio.transform.GetChild(1).GetChild(31).gameObject.SetActive(false);

            lessonAudio.transform.GetChild(1).GetChild(32).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(32).GetComponent<AudioSource>().clip.length);
            lessonAudio.transform.GetChild(1).GetChild(32).gameObject.SetActive(true);

            targetT1ConfirmPressed = false;
            while (targetT1ConfirmPressed != true)
            {
                yield return null;
            }

            UIarrows.transform.GetChild(6).gameObject.SetActive(true);
            lessonAudio.transform.GetChild(1).GetChild(33).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(33).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(33).gameObject.SetActive(true);
            UIarrows.transform.GetChild(6).gameObject.SetActive(false);

            lessonAudio.transform.GetChild(1).GetChild(34).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(34).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(34).gameObject.SetActive(true);

            lessonAudio.transform.GetChild(1).GetChild(35).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(35).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(35).gameObject.SetActive(true);

            UIarrows.transform.GetChild(7).gameObject.SetActive(true);
            lessonAudio.transform.GetChild(1).GetChild(36).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(36).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(36).gameObject.SetActive(true);


            lessonAudio.transform.GetChild(1).GetChild(37).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(37).GetComponent<AudioSource>().clip.length);
            lessonAudio.transform.GetChild(1).GetChild(37).gameObject.SetActive(true);

            axisButtonPressed = false;
            while (axisButtonPressed != true)
            {
                yield return null;
            }
            UIarrows.transform.GetChild(7).gameObject.SetActive(false);

            lessonAudio.transform.GetChild(1).GetChild(38).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(38).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(38).gameObject.SetActive(true);

            lessonAudio.transform.GetChild(1).GetChild(39).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(39).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(39).gameObject.SetActive(true);

            lessonAudio.transform.GetChild(1).GetChild(40).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(40).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(40).gameObject.SetActive(true);

            UIarrows.transform.GetChild(7).gameObject.SetActive(true);
            worldButtonPressed = false;
            while (worldButtonPressed != true)
            {
                yield return null;
            }
            UIarrows.transform.GetChild(7).gameObject.SetActive(false);

            lessonAudio.transform.GetChild(1).GetChild(41).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(41).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(41).gameObject.SetActive(true);

            lessonAudio.transform.GetChild(1).GetChild(42).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(42).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(42).gameObject.SetActive(true);

            //coverPanel.SetActive(false);
            yield return null;
            StartCoroutine("Lesson1_5");

        }
        IEnumerator Lesson1_5()
        {
            Debug.Log("lesson Started 1-5");
            StopCoroutine("Lesson1_4");


            //lessonAudio.transform.GetChild(1).GetChild(43).gameObject.SetActive(true);
            //yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(43).GetComponent<AudioSource>().clip.length);
            //lessonAudio.transform.GetChild(1).GetChild(43).gameObject.SetActive(false);

            //lessonAudio.transform.GetChild(1).GetChild(44).gameObject.SetActive(true);
            //yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(44).GetComponent<AudioSource>().clip.length);
            //lessonAudio.transform.GetChild(1).GetChild(44).gameObject.SetActive(false);

            //lessonAudio.transform.GetChild(1).GetChild(45).gameObject.SetActive(true);
            //yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(45).GetComponent<AudioSource>().clip.length);
            //lessonAudio.transform.GetChild(1).GetChild(45).gameObject.SetActive(false);

            //lessonAudio.transform.GetChild(1).GetChild(46).gameObject.SetActive(true);
            //yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(46).GetComponent<AudioSource>().clip.length);
            //lessonAudio.transform.GetChild(1).GetChild(46).gameObject.SetActive(false);

            //lessonAudio.transform.GetChild(1).GetChild(47).gameObject.SetActive(true);
            //yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(47).GetComponent<AudioSource>().clip.length);
            //lessonAudio.transform.GetChild(1).GetChild(47).gameObject.SetActive(false);

            //lessonAudio.transform.GetChild(1).GetChild(48).gameObject.SetActive(true);
            //yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(48).GetComponent<AudioSource>().clip.length);
            //lessonAudio.transform.GetChild(1).GetChild(48).gameObject.SetActive(false);

            //lessonAudio.transform.GetChild(1).GetChild(49).gameObject.SetActive(true);
            //yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(49).GetComponent<AudioSource>().clip.length);
            //lessonAudio.transform.GetChild(1).GetChild(49).gameObject.SetActive(false);

            //lessonAudio.transform.GetChild(1).GetChild(50).gameObject.SetActive(true);
            //yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(50).GetComponent<AudioSource>().clip.length);
            //lessonAudio.transform.GetChild(1).GetChild(50).gameObject.SetActive(false);

            //lessonAudio.transform.GetChild(1).GetChild(51).gameObject.SetActive(true);
            //yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(51).GetComponent<AudioSource>().clip.length);
            //lessonAudio.transform.GetChild(1).GetChild(51).gameObject.SetActive(false);

            //lessonAudio.transform.GetChild(1).GetChild(52).gameObject.SetActive(true);
            //yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(52).GetComponent<AudioSource>().clip.length);
            //lessonAudio.transform.GetChild(1).GetChild(52).gameObject.SetActive(false);

            //lessonAudio.transform.GetChild(1).GetChild(53).gameObject.SetActive(true);
            //yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(53).GetComponent<AudioSource>().clip.length + 1);
            //lessonAudio.transform.GetChild(1).GetChild(53).gameObject.SetActive(false);

            ////lessonAudio.transform.GetChild(1).GetChild(54).gameObject.SetActive(true);
            ////yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(54).GetComponent<AudioSource>().clip.length + 1);
            ////lessonAudio.transform.GetChild(1).GetChild(54).gameObject.SetActive(true);

            //lessonAudio.transform.GetChild(1).GetChild(55).gameObject.SetActive(true);
            //yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(55).GetComponent<AudioSource>().clip.length + 1);
            //lessonAudio.transform.GetChild(1).GetChild(55).gameObject.SetActive(false);

            //lessonAudio.transform.GetChild(1).GetChild(56).gameObject.SetActive(true);
            //yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(56).GetComponent<AudioSource>().clip.length + 1);
            //lessonAudio.transform.GetChild(1).GetChild(56).gameObject.SetActive(true);

            //lessonAudio.transform.GetChild(1).GetChild(57).gameObject.SetActive(true);
            //yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(57).GetComponent<AudioSource>().clip.length);
            //lessonAudio.transform.GetChild(1).GetChild(57).gameObject.SetActive(true);


            //estopButtonPressed = false;
            //estopButtonConfirmPressed = false;

            //while (estopButtonPressed != true)
            //{
            //    yield return null;
            //    while (estopButtonConfirmPressed != true)
            //    {
            //        yield return null;
            //    }
            //}

            //lessonAudio.transform.GetChild(1).GetChild(58).gameObject.SetActive(true);
            //yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(58).GetComponent<AudioSource>().clip.length + 1);
            //lessonAudio.transform.GetChild(1).GetChild(58).gameObject.SetActive(true);
            ////gif of trigger goes here.

            //lessonAudio.transform.GetChild(1).GetChild(59).gameObject.SetActive(true);
            //yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(59).GetComponent<AudioSource>().clip.length + 1);
            //lessonAudio.transform.GetChild(1).GetChild(59).gameObject.SetActive(true);

            //triggerheld = false;
            //while (triggerheld != true)
            //{
            //    yield return null;
            //}

            //lessonAudio.transform.GetChild(1).GetChild(60).gameObject.SetActive(true);
            //yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(60).GetComponent<AudioSource>().clip.length + 1);
            //lessonAudio.transform.GetChild(1).GetChild(60).gameObject.SetActive(true);

            //lessonAudio.transform.GetChild(1).GetChild(61).gameObject.SetActive(true);
            //yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(61).GetComponent<AudioSource>().clip.length + 1);
            //lessonAudio.transform.GetChild(1).GetChild(61).gameObject.SetActive(true);

            //lessonAudio.transform.GetChild(1).GetChild(62).gameObject.SetActive(true);
            //yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(62).GetComponent<AudioSource>().clip.length + 1);
            //lessonAudio.transform.GetChild(1).GetChild(62).gameObject.SetActive(true);

            //lessonAudio.transform.GetChild(1).GetChild(63).gameObject.SetActive(true);
            //yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(63).GetComponent<AudioSource>().clip.length + 1);
            //lessonAudio.transform.GetChild(1).GetChild(63).gameObject.SetActive(true);

            //lessonAudio.transform.GetChild(1).GetChild(64).gameObject.SetActive(true);
            //yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(64).GetComponent<AudioSource>().clip.length + 1);
            //lessonAudio.transform.GetChild(1).GetChild(64).gameObject.SetActive(true);

            //lessonAudio.transform.GetChild(1).GetChild(65).gameObject.SetActive(true);
            //yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(65).GetComponent<AudioSource>().clip.length + 1);
            //lessonAudio.transform.GetChild(1).GetChild(65).gameObject.SetActive(true);

            lessonAnimation.gameObject.GetComponent<animationPlayer>().Run();

            lessonBot.SetActive(true);

            lessonAudio.transform.GetChild(1).GetChild(66).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(66).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(66).gameObject.SetActive(true);

            robotOverlap = false;
            while (robotOverlap != true)
            {
                robotOverlap = CheckOverlap.gameObject.GetComponent<CheckOverlap>().overlapping;
                yield return null;
            }

            lessonAudio.transform.GetChild(1).GetChild(67).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(67).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(67).gameObject.SetActive(true);

            lessonAudio.transform.GetChild(1).GetChild(68).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(68).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(68).gameObject.SetActive(true);

            lessonAudio.transform.GetChild(1).GetChild(69).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(69).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(69).gameObject.SetActive(true);

            lessonAudio.transform.GetChild(1).GetChild(70).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(70).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(70).gameObject.SetActive(true);




            ////turn on highlight, discuss the goal of this lesson

            //yield return new WaitForSeconds(5);

            ////explination of the sequence of events
            //yield return new WaitForSeconds(5);

            ////Disengage e-stop
            //yield return new WaitForSeconds(5);
            //eStopDisengaged = false;
            //while (eStopDisengaged != true)
            //{
            //    //voice acting about e-stop
            //    Debug.Log("currently waiting for e-stop");
            //    yield return null;

            //}

            //Debug.Log("1) estop disengaged");

            ////Varified T1
            ////voiceline goes here
            //yield return new WaitForSeconds(5);

            //Debug.Log("2) Varified T1");

            ////enabling switch
            //yield return new WaitForSeconds(5);
            //enableingSwitchOn = false;
            //while (enableingSwitchOn != true)
            //{
            //    //voice acting about enabling switch
            //    Debug.Log("3) enabling switch on");
            //    yield return null;
            //}

            //Debug.Log("2) enabling switch pressed");

            ////drivers
            ////voiceline goes here
            //yield return new WaitForSeconds(5);

            //Debug.Log("2) Varified T1");

            //yield return new WaitForSeconds(5);

            //yield return null;
            StartCoroutine("Lesson1_6");

        }
        IEnumerator Lesson1_6()
        {
            Debug.Log("lesson Started 1-6");
            StopCoroutine("Lesson1_5");

            lessonAudio.transform.GetChild(1).GetChild(68).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(68).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(68).gameObject.SetActive(true);

            lessonAudio.transform.GetChild(1).GetChild(69).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(69).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(69).gameObject.SetActive(true);

            lessonAudio.transform.GetChild(1).GetChild(70).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(70).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(70).gameObject.SetActive(true);

            lessonAudio.transform.GetChild(1).GetChild(71).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(71).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(71).gameObject.SetActive(true);

            lessonAudio.transform.GetChild(1).GetChild(72).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(72).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(72).gameObject.SetActive(true);

            lessonAudio.transform.GetChild(1).GetChild(73).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(73).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(73).gameObject.SetActive(true);

            lessonAudio.transform.GetChild(1).GetChild(74).gameObject.SetActive(true);
            yield return new WaitForSeconds(lessonAudio.transform.GetChild(1).GetChild(74).GetComponent<AudioSource>().clip.length + 1);
            lessonAudio.transform.GetChild(1).GetChild(74).gameObject.SetActive(true);

            //discuss the difference of axis Six 
            yield return null;
            StartCoroutine("Lesson1_7");

        }

    }
}