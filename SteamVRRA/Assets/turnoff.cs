using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class turnoff : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject next;
    public float times;
    public float startTime;
    private float subTime;

    void Awake()
    {
        
        gameObject.transform.GetChild(1).GetComponent<VideoPlayer>().Play();
        gameObject.transform.GetChild(1).GetComponent<VideoPlayer>().time = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        subTime += Time.deltaTime;
        if(subTime > times)
        {
            next.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
