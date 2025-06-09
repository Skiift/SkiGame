using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGates : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FlagEvents.CallRaceFinish();
        }
    }
}
