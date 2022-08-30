using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronometerManager : MonoBehaviour
{
    public bool isChronometerActive = false;

    [SerializeField]
    private Transform secondHand;

    [SerializeField]
    private Transform minuteHand;

    private float timer = 0f;

    private int timeToDegreeMultiplier = 6;
    private int secondsInAMinute = 60;
    
    void Update()
    {
        if (isChronometerActive)
        {
            timer += Time.deltaTime;
            secondHand.eulerAngles = new Vector3(0f, 0f, -timer * timeToDegreeMultiplier);
            minuteHand.eulerAngles = new Vector3(0f, 0f, -((int)timer / secondsInAMinute) * timeToDegreeMultiplier);
        }
    }

    public void StartTime()
    {
        isChronometerActive = true;
    }

    public void StopTime()
    {
        isChronometerActive = false;
        ResetHands();
    }

    private void ResetHands()
    {
        secondHand.eulerAngles = new Vector3(0f, 0f, 0f);
        minuteHand.eulerAngles = new Vector3(0f, 0f, 0f);
    }
}
