using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.InputSystem;
public class PullObject : MonoBehaviour
{
    Ray ray;
    RaycastHit hit; 
    public Transform hand; 
    public LayerMask layersToHit;
    public float maxDistance = 100;
    public InputActionProperty grabInputSource;
    public GameObject CurrentObject;
    public Collider CurrentObjectCollider;
    public bool IsGrabbing = false;
    public GrabPhysics grabPhysics;
    [SerializeField] LineRenderer lineRenderer;
    public ParticleSystem particles; 
    void FixedUpdate()
    {
        bool isGrabButtonPressedPull = grabInputSource.action.ReadValue<float>() > 0.1f;
        if (CurrentObject != null && isGrabButtonPressedPull && grabPhysics.isGrabbing == false){
            particles.Play();
            lineRenderer.enabled = false;
            CurrentObjectCollider.attachedRigidbody.AddForce((hand.position - CurrentObject.transform.position)* 40f, ForceMode.Force);
        }else{
            particles.Stop();
        }
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(hand.position, hand.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layersToHit))
        {


            if (IsGrabbing && isGrabButtonPressedPull && hit.distance >= .5){
            CurrentObject = hit.collider.gameObject;
            CurrentObjectCollider = hit.collider;
            IsGrabbing = false;
            }
            if (hit.distance >= .5){
            if(isGrabButtonPressedPull == false){
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0,hand.transform.position);
            lineRenderer.SetPosition(1,hit.point);}
            Debug.Log(hit.distance);
            Debug.DrawRay(hand.position, hand.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log(hit.collider.gameObject.name + "Did Hit");} else{
                lineRenderer.enabled = false;
            }
        }else{
            lineRenderer.enabled = false;
        }
        if(isGrabButtonPressedPull == false){
            IsGrabbing = true;
            CurrentObject = null;
            CurrentObjectCollider = null;
        }
    }
}
