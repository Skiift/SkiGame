using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    
  void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
}
        