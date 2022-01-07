using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour
{
    float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(-speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(speed * Time.deltaTime, 0f, 0f);
        }
    }
}
