using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class showAngle : MonoBehaviour
{
    // Start is called before the first frame update
    public AxisMode am;
    public TextMeshProUGUI a1Text;
    public TextMeshProUGUI a2Text;
    public TextMeshProUGUI a3Text;
    public TextMeshProUGUI a4Text;
    public TextMeshProUGUI a5Text;
    public TextMeshProUGUI a6Text;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        a1Text.text = Mathf.RoundToInt(am.stop1).ToString();
        a2Text.text = Mathf.RoundToInt(am.stop2 * -1).ToString();
        a3Text.text = Mathf.RoundToInt(am.stop3).ToString();
        a4Text.text = Mathf.RoundToInt(am.stop4).ToString();
        a5Text.text = Mathf.RoundToInt(am.stop5).ToString();
        a6Text.text = Mathf.RoundToInt(am.stop6).ToString();
    }
}
