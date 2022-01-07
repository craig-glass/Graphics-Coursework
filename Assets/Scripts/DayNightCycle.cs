using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DayNightCycle : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float time;
    public float fullDayLength;
    public float startTime = 0.4f;
    private float timeRate;
    public Vector3 noon;

    [Header("Sun")]
    public Light sun;
    public Gradient sunColor;
    public AnimationCurve sunIntensity;
    public LensFlareComponentSRP sunLensFlare;
   

    [Header("Moon")]
    public Light moon;
    public Gradient moonColor;
    public AnimationCurve moonIntensity;

    [Header("Other Lighting")]
    public AnimationCurve lightingIntensityMultiplier;
    public AnimationCurve reflectionsIntensityMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        timeRate = 1.0f / fullDayLength;
        time = startTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        // increment time
        time += timeRate * Time.deltaTime;

        if (time >= 1.0f)
            time = 0.0f;

        // light rotation
        sun.transform.eulerAngles = (time - 0.25f) * noon * 4.0f;
        moon.transform.eulerAngles = (time - 0.75f) * noon * 4.0f;

        // light intensity
        sun.intensity = sunIntensity.Evaluate(time);
        moon.intensity = moonIntensity.Evaluate(time);

        // change colors
        sun.color = sunColor.Evaluate(time);
        moon.color = moonColor.Evaluate(time);

        // enable / disable the sun
        if (sun.transform.eulerAngles.x > 187f && sun.gameObject.activeInHierarchy)
        {
            moon.gameObject.SetActive(true);
            sunLensFlare.enabled = false;
            sun.gameObject.SetActive(false);            
        }
            
        if (moon.transform.eulerAngles.x > 187f && 
            !sun.gameObject.activeInHierarchy)
        {
            moon.gameObject.SetActive(false);
            sun.gameObject.SetActive(true);
            sunLensFlare.enabled = true;
        }

        // lighting and reflections intensity
        RenderSettings.ambientIntensity = lightingIntensityMultiplier.Evaluate(time);
        RenderSettings.reflectionIntensity = reflectionsIntensityMultiplier.Evaluate(time);
    }
}
