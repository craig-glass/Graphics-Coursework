using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlasma : MonoBehaviour
{
    public GameObject lightbeam;
    public GameObject plasmaExplosionEffect;
    public ParticleSystem plasmaExplosion;
    public TerrainBlowUp blowUpScript;

    // Start is called before the first frame update
    void Start()
    {
        plasmaExplosion.Stop();
        blowUpScript = GameObject.Find("LightBeam").GetComponent<TerrainBlowUp>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightbeam.transform.localScale.x > 0.24)
        {
            transform.localPosition += new Vector3(0f, -20f * Time.deltaTime, 0f);
            if (transform.localPosition.y < -20f)
            {
                StartCoroutine(Plasma());

            }
        }
    }

    IEnumerator Plasma()
    {
        
        plasmaExplosion.Play();
        blowUpScript.BlowTerrain();
        yield return new WaitForSeconds(1);
        Destroy(plasmaExplosionEffect);
        Destroy(gameObject);
        Destroy(lightbeam);
    }

    
}
