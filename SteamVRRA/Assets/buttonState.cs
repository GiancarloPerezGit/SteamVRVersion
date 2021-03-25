using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class buttonState : MonoBehaviour
{
    private GameObject uiMan;
    void Start()
    {
        uiMan = GameObject.FindGameObjectWithTag("UIManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(uiMan.GetComponent<ProjectRoboDK.CodeWindow>().buttonOn)
        {
            transform.gameObject.GetComponent<Button>().enabled = true;
            transform.gameObject.GetComponent<BoxCollider>().center = new Vector3(transform.gameObject.GetComponent<BoxCollider>().center.x, transform.gameObject.GetComponent<BoxCollider>().center.y, -1);
        }
        else
        {
            transform.gameObject.GetComponent<Button>().enabled = false;
            transform.gameObject.GetComponent<BoxCollider>().center = new Vector3(transform.gameObject.GetComponent<BoxCollider>().center.x, transform.gameObject.GetComponent<BoxCollider>().center.y, 0);
        }
    }
}
