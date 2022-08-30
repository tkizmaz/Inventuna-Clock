using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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

    private WorldHoursManager worldHoursManager = new WorldHoursManager();

    System.DateTime targetTimeZone;

    private void Awake()
    {
        GameObject gameObject = new GameObject();
        gameObject.AddComponent<WorldHoursManager>();
        worldHoursManager = gameObject.GetComponent<WorldHoursManager>();
    }

    void Update()
    {
        targetTimeZone = worldHoursManager.GetSelectedCity() == null ? System.DateTime.Now : worldHoursManager.GetTargetTimeZone();

        string secondsString = targetTimeZone.Second.ToString();
        string minutesString = targetTimeZone.Minute.ToString();
        string hoursString = targetTimeZone.Hour.ToString();

        int seconds = int.Parse(secondsString);
        int minutes = int.Parse(minutesString);
        int hours = int.Parse(hoursString);

        secondHandTransform.eulerAngles = new Vector3(0, 0, -seconds * timeToDegreeMultiplier);
        minuteHandTransform.eulerAngles = new Vector3(0, 0, -minutes * timeToDegreeMultiplier);
        hourHandTransform.transform.eulerAngles = new Vector3(0, 0, -hours * (totalDegree / totalHours));
    }

    public void SetCity(Button button)
    {
        worldHoursManager.SetSelectedCity(button.name);
    }
}
