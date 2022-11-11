using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FPSCounter : MonoBehaviour
{
    protected Text fpsText;

    public void Awake()
    {
        fpsText = this.gameObject.GetComponent<Text>();
    }

    protected void OnEnable()
    {
        StartCoroutine(FPSRoutine());       
    }

    protected IEnumerator FPSRoutine()
    {
        int frameCount = 0;
        float nextUpdate = Time.time;
        float fps = 0f;
        float fpsUpdateRate = 2.0f;
        while(this.enabled)
        {
            frameCount++;
            if (Time.time > nextUpdate)
            {
                nextUpdate += 1.0f / fpsUpdateRate;
                fps = frameCount * fpsUpdateRate;
                frameCount = 0;
                fpsText.text = "FPS: " + fps.ToString("0.0"); 
            }
            yield return null;
        }
    } 
}
