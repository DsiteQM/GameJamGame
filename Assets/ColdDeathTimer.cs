using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdDeathTimer : MonoBehaviour
{
    public float timeLimit = 60f; // Time limit in seconds
    private float currentTime; // Current time left
    private Coroutine timerCoroutine; // Coroutine reference to stop the timer


    public void StartTimer()
    {
        currentTime = timeLimit;
        timerCoroutine = StartCoroutine(DecreaseTimer());
    }

    private IEnumerator DecreaseTimer()
    {
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1f); // Wait for 1 second
            currentTime--;
        }

    }

    public void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }
    }
}
