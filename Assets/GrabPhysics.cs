using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabPhysics : MonoBehaviour
{
    public InputActionProperty grabInputSource;
    public float radius = 0.1f;
    public LayerMask grabLayer;
    float max = 0;
    private FixedJoint fixedJoint;
    public bool isGrabbing = false;
    // Update is called once per frame
    void FixedUpdate()
    {
        
        bool isGrabButtonPressed = grabInputSource.action.ReadValue<float>() > 0.1f;

        if (isGrabButtonPressed && !isGrabbing)
        {
            Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, radius, grabLayer, QueryTriggerInteraction.Ignore);
            max = Mathf.Max(nearbyColliders.Length);
            if(nearbyColliders.Length > 0)
            {
                Rigidbody nearbyRigidbody = nearbyColliders[0].attachedRigidbody;

                fixedJoint = gameObject.AddComponent<FixedJoint>();
                fixedJoint.autoConfigureConnectedAnchor = false;
                fixedJoint.breakForce = 4000; 
                if (nearbyRigidbody)
                {
                    fixedJoint.connectedBody = nearbyRigidbody;
                    fixedJoint.connectedAnchor = nearbyRigidbody.transform.InverseTransformPoint(transform.position);
                }
                else
                {
                    fixedJoint.connectedAnchor = transform.position;
                }
                isGrabbing = true;
                }
        }
        else if(!isGrabButtonPressed && isGrabbing)
        {
            isGrabbing = false;
            if (fixedJoint)
            {
                Destroy(fixedJoint);
            }
        }
    }
}