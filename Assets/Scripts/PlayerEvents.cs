using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public delegate void OnHit(); //delegate type
    public static event OnHit onHitEvent; //type function as an event
    public delegate void OnFlagHit();
    public static event OnFlagHit onFlagHitEvent;
    public static void CallOnHitEvent() 
    {
        if (onHitEvent != null)
            onHitEvent();
    }
    public static void CallOnFlagHit()
    {
        if (onFlagHitEvent != null)
            onFlagHitEvent();
    }
}
