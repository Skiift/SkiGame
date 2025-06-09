using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenaltyFlag : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FlagEvents.CallRacePenalty();
            PlayerEvents.CallOnFlagHit();
        }
    }
}
