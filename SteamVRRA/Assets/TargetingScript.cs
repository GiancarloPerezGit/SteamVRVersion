//using Microsoft.MixedReality.Toolkit;
//using Microsoft.MixedReality.Toolkit.Input;

using UnityEngine.XR.WSA.Input;
using UnityEngine.XR;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// note: I could probably do this in less lines 
// but I did it for the ease of read for others

public class TargetingScript : MonoBehaviour
{
    public GameObject ControllerTarget;
    public GameObject node;

    public string currentList;

    public TextMeshPro uiNodeList;

    private List<Vector3> nodeList = new List<Vector3>();
    private Transform currentloc;

    public bool nodePlaceMode;


    void Start()
    {
        nodePlaceMode = true;
    }
    void Update()
    {
        currentloc = ControllerTarget.gameObject.transform;

        if (nodePlaceMode == true)
        {

            Debug.Log(Input.GetAxis("AXIS_9"));
            Debug.Log(currentloc);

            if (Input.GetAxis("AXIS_9") == 1)
            {
                Instantiate(node, currentloc.position, currentloc.rotation);
                nodeList.Add(currentloc.position);
                nodePlaceMode = false;
            }
        }

        //Debug.Log(currentloc.position);

        //transform add to the list
    }

    //methods for manipulating the nodelist
    void NodeListAdd(Vector3 node)
    {
        nodeList.Add(node);
        VisualUpdate();
    }
    void NodeListRemove()
    {
        nodeList.RemoveAt(0);
        VisualUpdate();
    }

    //method to update visuals (coming soon)
    void VisualUpdate()
    {
        foreach (Vector3 i in nodeList)
        {
            Instantiate(node, i, currentloc.rotation);
        }
    }
}

