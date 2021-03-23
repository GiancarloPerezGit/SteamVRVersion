using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Valve.VR.InteractionSystem
{
    public class pStopSteamVR : MonoBehaviour
    {
        public SteamVR_Action_Boolean pStop = SteamVR_Input.GetBooleanAction("pStop");
        public SteamVR_Input_Sources hand;
        public ButtonManagerScript bms;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(pStop.GetState(hand))
            {
                print("Yo");
                bms.pStop = true;
            }
            else
            {
                bms.pStop = false;
            }
        }
    }
}