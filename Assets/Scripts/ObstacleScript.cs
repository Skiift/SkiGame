using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerCollision();
        }
    }

    protected virtual void PlayerCollision() //redzama tikai mantiniekiem
    {
        PlayerEvents.CallOnHitEvent();  //definē kad izsauc delegate
        Debug.Log("Player hit" + name);
    }
    
}
