using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockManager : MonoBehaviour
{
    [SerializeField]
    private GameObject hourHand;

    [SerializeField]
    private GameObject minuteHand;

    [SerializeField]
    private GameObject secondHand;

    private int timeToDegreeMultiplier = 6;

    void Start()
    {
         
    }

    void Update()
    {
        string secondsString = System.DateTime.UtcNow.ToString("ss");
        string minutesString = System.DateTime.UtcNow.ToString("mm");
        string hoursString = System.DateTime.UtcNow.ToString("hh");

        int seconds = int.Parse(secondsString);
        int minutes = int.Parse(minutesString);
        int hours = int.Parse(hoursString);

        secondHand.transform.eulerAngles = new Vector3(0, 0, -seconds * timeToDegreeMultiplier);
        minuteHand.transform.eulerAngles = new Vector3(0, 0, -minutes * timeToDegreeMultiplier);

        float hourDistance = (float) minutes / 60f;
        hourHand.transform.eulerAngles = new Vector3(0, 0, -(hours + hourDistance) / 360/12);
    }
}
