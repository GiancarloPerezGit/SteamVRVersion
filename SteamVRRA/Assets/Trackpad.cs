using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Valve.VR.InteractionSystem
{
    public class Trackpad : MonoBehaviour
    {
        public SteamVR_Action_Vector2 trackPos = SteamVR_Input.GetVector2Action("Trackpad_Position");
        public SteamVR_Action_Boolean trackClick = SteamVR_Input.GetBooleanAction("Trackpad_click");
        public SteamVR_Input_Sources hand;

        public SnapTurn st;
        public Teleport tp;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //print(trackPos.axis + " Finger location");
            if (trackClick.GetStateDown(hand))
            {
                if(trackPos.axis.x<-0.5 && trackPos.axis.y < 0.5 && trackPos.axis.y > -0.5)
                {
                    st.RotatePlayer(-st.snapAngle);
                }
                else if(trackPos.axis.x > 0.5 && trackPos.axis.y < 0.5 && trackPos.axis.y > -0.5)
                {
                    st.RotatePlayer(st.snapAngle);
                }
                else if(trackPos.axis.x > -0.5 && trackPos.axis.x < 0.5 && trackPos.axis.y > 0.5)
                {
                    tp.pressed = true;
                }
            }
            else
            {
                tp.pressed = false;
            }
            if(trackClick.GetState(hand))
            {
                if (trackPos.axis.x > -0.5 && trackPos.axis.x < 0.5 && trackPos.axis.y > 0.5)
                {
                    tp.down = true;
                }
            }
            else
            {
                tp.down = false;
            }
            if(trackClick.GetStateUp(hand))
            {
                if (trackPos.axis.x > -0.5 && trackPos.axis.x < 0.5 && trackPos.axis.y > 0.5)
                {
                    tp.released = true;
                }
            }
            else
            {
                tp.released = false;
            }

        }
    }
}