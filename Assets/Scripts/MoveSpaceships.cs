using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpaceships : MonoBehaviour
{
    Vector3 newPosition = new Vector3(-1157f, 678f, 597f);
    public TerrainBlowUp terrainBlowupScript;

    private void Awake()
    {
        terrainBlowupScript = GetComponentInChildren<TerrainBlowUp>();
        terrainBlowupScript.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == newPosition)
        {
            if (GetComponentInChildren<LightBeam>())
            {
                GetComponentInChildren<LightBeam>().inPosition = true;
                terrainBlowupScript.enabled = true;
            }
            
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * 500f);
        }
        
    }
}
