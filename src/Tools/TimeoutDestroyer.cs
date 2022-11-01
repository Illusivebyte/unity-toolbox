using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeoutDestroyer : MonoBehaviour
{
    public float timeOut;
    public FloatVariable timeOutVar;


    private void Awake()
    {
        if (timeOutVar != null)
        {
            timeOut = timeOutVar.Value;
        }
        StartCoroutine(TimerRoutine());
    }

    private IEnumerator TimerRoutine()
    {
        yield return new WaitForSeconds(timeOut);
        GameObject.Destroy(this.gameObject);
    }
}
