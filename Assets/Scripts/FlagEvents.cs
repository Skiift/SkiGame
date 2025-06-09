using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagEvents : MonoBehaviour
{
    public delegate void RaceEvent();
    public static event RaceEvent raceStart;
    public static event RaceEvent raceEnd;
    public static event RaceEvent racePenalty;
    public static event RaceEvent Quit;

    public static void CallQuit()
    {
        if (Quit != null)
            Quit();
    }

    public static void CallRaceStart()
    {
        if (raceStart != null)
            raceStart();
    }
    public static void CallRaceFinish()
    {
        if (raceEnd != null)
            raceEnd();
    }

    public static void CallRacePenalty()
    {
        if (racePenalty != null)
            racePenalty();
    }
}
