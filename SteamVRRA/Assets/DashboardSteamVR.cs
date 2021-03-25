using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class DashboardSteamVR : MonoBehaviour
    {
        public SteamVR_Action_Boolean dash = SteamVR_Input.GetBooleanAction("Dashboard");
        public SteamVR_Input_Sources hand;
        public DashboardController dc;
        public bool open = false;
        public bool pressed = false;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(dash.GetStateDown(hand))
            {
                if(open)
                {
                    dc.CloseDashboard();
                }
                else
                {
                    dc.OpenDashboard();
                }
                open = !open;
                pressed = true;
            }
            else
            {
                pressed = false;
            }
        }
    }
}