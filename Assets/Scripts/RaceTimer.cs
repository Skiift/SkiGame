using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTimer : MonoBehaviour
{
    [SerializeField] private float penaltyTime = 1;
    private float raceTime = 0;
    private bool timerRunning = false;
    [SerializeField] private Leaderboard leaderboard;
    private void Update()
    {
        if (timerRunning)
            raceTime += Time.deltaTime;
    }

    private void OnEnable()
    {
        FlagEvents.raceStart += StartRace;
        FlagEvents.raceEnd += FinishRace;
        FlagEvents.racePenalty += Penalty;
    }

    private void OnDisable()
    {
        FlagEvents.raceStart -= StartRace;
        FlagEvents.raceEnd -= FinishRace;
        FlagEvents.racePenalty += Penalty;
    }

    private void StartRace()
    {
        raceTime = 0;
        timerRunning = true;
        Debug.Log("race started");
    }

    private void FinishRace()
    {
        timerRunning = false;
        leaderboard.AddTime(raceTime);
        GameData.Instance.racesCompleted++;
        Debug.Log("Races completed: " + GameData.Instance.racesCompleted);
        Debug.Log("race time "+ raceTime);
    }

    private void Penalty()
    {
        raceTime += penaltyTime;
        Debug.Log("Penalty recieved");
    }
}
