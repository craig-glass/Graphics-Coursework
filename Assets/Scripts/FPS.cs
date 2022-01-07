using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Profiling;

public class FPS : MonoBehaviour
{
    public float timer, refresh, avgFramerate;
    public string display = "{0} FPS";
    public Text text;
    public Text memoryText;
    string memoryDisplay = "{0} MB";

    ProfilerRecorder totalMemoryUsed;

    // Start is called before the first frame update
    void Start()
    {
        totalMemoryUsed = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Total Used Memory");
    }

    private void OnDisable()
    {
        totalMemoryUsed.Dispose();
    }
    // Update is called once per frame
    void Update()
    {
        float timelapse = Time.deltaTime;
        timer = timer <= 0 ? refresh : timer -= timelapse;

        if (timer <= 0) avgFramerate = (int)(1f / timelapse);
        //text.text = "FPS: " + string.Format(display, avgFramerate.ToString());
        text.text = "FPS: " + (1.0f / Time.deltaTime).ToString();
        

        if (totalMemoryUsed.Valid)
        {
            string temp = string.Format(memoryDisplay, totalMemoryUsed.LastValue.ToString());
            temp = string.Format(memoryDisplay, temp.Substring(0, 3));
            memoryText.text = "Total Memory Used: " + temp;
        }

    }
}
