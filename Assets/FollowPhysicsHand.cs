using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPhysicsHand : MonoBehaviour
{

    public Transform target;
    public Rigidbody rb; 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = (target.position - transform.position)/ Time.fixedDeltaTime; 

        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis); 

        Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis; 
        rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad /Time.fixedDeltaTime); 
    }
}
