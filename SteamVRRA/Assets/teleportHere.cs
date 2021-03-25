using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Microsoft.MixedReality.Toolkit.Input;
//using Microsoft.MixedReality.Toolkit.Physics;
//using Microsoft.MixedReality.Toolkit.Utilities;
namespace Valve.VR.InteractionSystem
{
    public class teleportHere : MonoBehaviour
    {
        public Player player;
        // Start is called before the first frame update
        void Start()
        {

        }

        public void teleport()
        {
            Vector3 playerFeetOffset = player.trackingOriginTransform.position - player.feetPositionGuess;
            player.trackingOriginTransform.position = gameObject.transform.position + playerFeetOffset;
            //player.transform.position = new Vector3(gameObject.transform.position.x, player.transform.position.y, gameObject.transform.position.z);
            //player.transform.rotation = gameObject.transform.rotation;

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}