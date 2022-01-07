using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam : MonoBehaviour
{
    public bool inPosition = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inPosition)
        {
            if (transform.localScale.y < 15)
            {
                transform.localScale += new Vector3(0f, 2f * Time.deltaTime, 0f);
                transform.localPosition += new Vector3(0f, -2f * Time.deltaTime, 0f);
            }
            else if (transform.localScale.x < 0.25)
            {
                transform.localScale += new Vector3(0.02f * Time.deltaTime, 0f, 0.02f * Time.deltaTime);
            }
        }
       
        
       
    }

    
}
