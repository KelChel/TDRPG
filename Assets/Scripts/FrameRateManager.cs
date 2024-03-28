using System.Collections;
using System.Threading;
using UnityEngine;
public class FrameRateManager : MonoBehaviour
{
    [Header("Frame Settings")]
    int MaxRate = 240;
    public float TargetFrameRate = 60.0f;
    float currentFrameTime;
    void Awake()
    {
        if (PlayerPrefs.GetFloat("fps") == 0f)
        {
            TargetFrameRate = 60f;
        }
        else
        {
            TargetFrameRate = PlayerPrefs.GetFloat("fps");
        }
        
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = MaxRate;
        currentFrameTime = Time.realtimeSinceStartup;
        StartCoroutine("WaitForNextFrame");
        
    }
    IEnumerator WaitForNextFrame()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            currentFrameTime += 1.0f / TargetFrameRate;
            var t = Time.realtimeSinceStartup;
            var sleepTime = currentFrameTime - t - 0.01f;
            if (sleepTime > 0)
                Thread.Sleep((int)(sleepTime * 1000));
            while (t < currentFrameTime)
                t = Time.realtimeSinceStartup;
        }
    }


    public void ChangeFPS(float targetfps)
    {
        PlayerPrefs.SetFloat("fps", targetfps);
        TargetFrameRate = PlayerPrefs.GetFloat("fps");
        StopCoroutine("WaitForNextFrame");
        StartCoroutine("WaitForNextFrame");
    }
}