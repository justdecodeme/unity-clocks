using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    const float 
        degreesPerHour = 30f,
        degreesPerMinute = 6f,
        degreesPerSecond = 6f;

    public Transform hoursTransform, minutesTransform, secondsTransform;

    public bool continuous;

    void Start() {
        // Debug.Log(DateTime.Now); 
        // Debug.Log(DateTime.Now.Hour); // type is `float`
        // Debug.Log(DateTime.Now.Minute); 
        // Debug.Log(DateTime.Now.Second);

        // Debug.Log(DateTime.Now.TimeOfDay);
        // Debug.Log(DateTime.Now.TimeOfDay.TotalHours); // type is `double`
        // Debug.Log(DateTime.Now.TimeOfDay.TotalMinutes);
        // Debug.Log(DateTime.Now.TimeOfDay.TotalSeconds);
    }

    void Update()
    {
        TimeSpan timeSpan = DateTime.Now.TimeOfDay;
        DateTime timeNormal = DateTime.Now;

        hoursTransform.localRotation = Quaternion.Euler(0f, 0f, -(float)timeSpan.TotalHours * degreesPerHour);
        minutesTransform.localRotation = Quaternion.Euler(0f, 0f, -(float)timeSpan.TotalMinutes * degreesPerMinute);

        if(continuous) {
            UpdateContinuous(timeSpan);
        } else {
            UpdateDiscrete(timeNormal);
        }
    }

    public void UpdateContinuous(TimeSpan timeSpan)
    {
        secondsTransform.localRotation = Quaternion.Euler(0f, 0f, -(float)timeSpan.TotalSeconds * degreesPerSecond);
    }
    public void UpdateDiscrete(DateTime timeNormal)
    {
        secondsTransform.localRotation = Quaternion.Euler(0f, 0f, -timeNormal.Second * degreesPerSecond);
    }

    public void ToggleContinues() {
        continuous = continuous ? false: true;
    }
}
