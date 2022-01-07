using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float speed = 5f;
    float rotationSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 15f;
            rotationSpeed = 15f;
          
        }
        else
        {
            speed = 5f;
            rotationSpeed = 10f;
        }
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0f, -rotationSpeed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(0f, 0.005f, 0f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(0f, -0.005f, 0f);
        } 
        if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0f, 0.1f, 0f);
        }
        if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0f, -0.1f, 0f);
        }
        
    }
}
