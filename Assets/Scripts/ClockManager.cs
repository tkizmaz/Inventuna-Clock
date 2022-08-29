using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockManager : MonoBehaviour
{
    [SerializeField]
    private Transform hourHandTransform;

    [SerializeField]
    private Transform minuteHandTransform;

    [SerializeField]
    private Transform secondHandTransform;

    private int timeToDegreeMultiplier = 6;
    private int totalDegree = 360;
    private int totalHours = 12;

    void Start()
    {
         
    }

    void Update()
    {
        string secondsString = System.DateTime.Now.ToString("ss");
        string minutesString = System.DateTime.Now.ToString("mm");
        string hoursString = System.DateTime.Now.ToString("hh");

        int seconds = int.Parse(secondsString);
        int minutes = int.Parse(minutesString);
        int hours = int.Parse(hoursString);

        secondHandTransform.eulerAngles = new Vector3(0, 0, -seconds * timeToDegreeMultiplier);
        minuteHandTransform.eulerAngles = new Vector3(0, 0, -minutes * timeToDegreeMultiplier);
        hourHandTransform.transform.eulerAngles = new Vector3(0, 0, -(hours + (float)(minutes) / 60f) * (totalDegree / totalHours));
    }
}
