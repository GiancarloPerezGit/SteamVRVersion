using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Microsoft.MixedReality.Toolkit.Input;
//using Microsoft.MixedReality.Toolkit.Physics;
//using Microsoft.MixedReality.Toolkit.Utilities;
public class teleportHere : MonoBehaviour
{
    public Microsoft.MixedReality.Toolkit.Teleport.CustomTeleport ct;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void teleport()
    {
        if(ct.rotateTimes == 1)
        {
            ct.player.transform.Rotate(new Vector3(0, -90, 0));
        }
        else if(ct.rotateTimes == 2)
        {
            ct.player.transform.Rotate(new Vector3(0, -180, 0));
        }
        else if(ct.rotateTimes == 3)
        {
            ct.player.transform.Rotate(new Vector3(0, -270, 0));
        }
        ct.rotateTimes = 0;
        ct.player.transform.position = new Vector3(gameObject.transform.position.x + -1 * ct.cam.transform.localPosition.x, gameObject.transform.position.y, gameObject.transform.position.z + 1 * ct.cam.transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
