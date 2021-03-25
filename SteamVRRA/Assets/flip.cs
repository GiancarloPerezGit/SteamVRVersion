using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localRotation = Quaternion.Euler(0, 180f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
