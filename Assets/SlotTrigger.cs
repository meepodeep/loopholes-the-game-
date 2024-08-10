using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotTrigger : MonoBehaviour
{
    public string ObjTag; 
    public bool canTake;
    public void OnTriggerEnter(Collider other)
    {
        ObjTag = other.tag; 
        canTake = true; 
    }
    public void OnTriggerExit(Collider other){
        ObjTag = "nein";
    }
}
