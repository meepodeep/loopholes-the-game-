using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
public class HandPresencePhysics : MonoBehaviour
{
    [SerializeField]
    PID Ycontroller; 
    [SerializeField]
    PID Xcontroller; 
    [SerializeField]
    PID Zcontroller; 
    public Transform target;
    private Rigidbody rb;
    private Collider[] handColliders;
    float correctionForce = 1000;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        handColliders = GetComponentsInChildren<Collider>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float inputUp = Ycontroller.Update(Time.fixedDeltaTime, rb.transform.position.y, target.transform.position.y); 
        float inputStrafe = Xcontroller.Update(Time.fixedDeltaTime, rb.transform.position.x, target.transform.position.x);
        float inputForward = Zcontroller.Update(Time.fixedDeltaTime, rb.transform.position.z, target.transform.position.z);
        rb.AddForce(0, correctionForce * inputUp, 0, ForceMode.Force);
        rb.AddForce(correctionForce * inputStrafe, 0 , 0, ForceMode.Force);
        rb.AddForce(0, 0, correctionForce * inputForward, ForceMode.Force); 
        
        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis;

        rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }
        public void EnableHandCollider()
    {
        foreach (var item in handColliders){
            item.enabled = true;
        }
    }
    public void EnableHandColliderDelay(){
        Invoke("EnableHandCollider", .3f);
    }
    public void DisableHandCollider()
    {
          foreach (var item in handColliders){
            item.enabled = false;
        }
    }
}
