using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOverlap : MonoBehaviour
{

    public GameObject RealA1;
    public GameObject RealA2;
    public GameObject RealA3;
    public GameObject RealA4;
    public GameObject RealA5;
    public GameObject RealA6;
    public GameObject GhostA1;
    public GameObject GhostA2;
    public GameObject GhostA3;
    public GameObject GhostA4;
    public GameObject GhostA5;
    public GameObject GhostA6;

    public bool overlapping = false;

    void Update()
    {
        if (Quaternion.Angle(RealA1.transform.rotation, GhostA1.transform.rotation) <= 30)
        {
            print("a1 complete");
            if (Quaternion.Angle(RealA2.transform.rotation, GhostA2.transform.rotation) <= 30)
            {
                print("a2 complete");
                if (Quaternion.Angle(RealA3.transform.rotation, GhostA3.transform.rotation) <= 30)
                {
                    print("a3 complete");
                    if (Quaternion.Angle(RealA4.transform.rotation, GhostA4.transform.rotation) <= 30)
                    {
                        print("a4 complete");
                        if (Quaternion.Angle(RealA5.transform.rotation, GhostA5.transform.rotation) <= 30)
                        {
                            print("a5 complete");
                            if (Quaternion.Angle(RealA6.transform.rotation, GhostA6.transform.rotation) <= 180)
                            {
                                print("a6 complete");
                                overlapping = true;
                            }
                            else
                            {
                                overlapping = false;
                            }
                        }
                        else
                        {
                            overlapping = false;
                        }
                    }
                    else
                    {
                        overlapping = false;
                    }
                }
                else
                {
                    overlapping = false;
                }
            }
            else
            {
                overlapping = false;
            }
        }
        else
        {
            overlapping = false;
        }
    }
}
