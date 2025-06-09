using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanThrow : MonoBehaviour
{
    public GameObject snowBall;
    public float throwDistance;
    public int throwSpeed;
    private bool justThown = false;
    [SerializeField]private Vector3 throwHeightOffset = new Vector3(0, 0.33f, 0);
    private GameObject target;
    
    void Start()
    { 
        target = GameObject.Find("Player");
    }
    
    void Update()
    {
        if (Time.frameCount % 6 == 0) // % atgriež atlikumu dalīšanā
        {
            float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);

            if (distanceToTarget < throwDistance && justThown == false)
            {
                ThrowSnowball();
            }
        }
    }

    void ThrowSnowball()
    {
        justThown = true;
        GameObject tempSnowBall = Instantiate(snowBall, transform.position, transform.rotation);
        Rigidbody tempRb = tempSnowBall.GetComponent<Rigidbody>();
        Vector3 targetDirection = Vector3.Normalize(target.transform.position - transform.position);

        //Add a small throw angle
        targetDirection += throwHeightOffset;
        tempRb.AddForce(targetDirection * throwSpeed);
        Invoke("ThrowOver", 0.1f);
    }

    void ThrowOver()
    {
        justThown = false;
    }
}
