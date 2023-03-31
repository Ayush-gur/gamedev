using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public static int KillValue = 0;
    Text score;
    
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Kills:" + KillValue;
        if(Input.GetKeyDown(KeyCode.Z))
        {
            KillValue = 0;
        }
    }
}
