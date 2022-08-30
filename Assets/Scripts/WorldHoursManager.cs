using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WorldHoursManager : MonoBehaviour
{
    Dictionary<string, string> cityHourDifference = new Dictionary<string, string>
    {
        {"NewYork" , "Eastern Standard Time"},
        {"China",  "China Standard Time"},
        {"Israel", "Israel Standard Time"},
        {"London",  "GMT Standard Time"},
        {"Istanbul", "Turkey Standard Time" }
    };

    private string selectedCity;
    public string GetTimeZone()
    {
        if (cityHourDifference.ContainsKey(selectedCity))
        {
            return cityHourDifference[selectedCity];
        }

        return "Istanbul Standard Time";
    }

    public System.DateTime GetTargetTimeZone()
    {
        string timeZone = GetTimeZone();
        System.TimeZoneInfo timeZoneInfo = System.TimeZoneInfo.FindSystemTimeZoneById(timeZone);
        System.DateTime targetTime = System.TimeZoneInfo.ConvertTime(System.DateTime.Now, timeZoneInfo);
        return targetTime;
    }

    public void SetSelectedCity(string city)
    {
        selectedCity = city;
    }

    public string GetSelectedCity()
    {
        return selectedCity;
    }
}