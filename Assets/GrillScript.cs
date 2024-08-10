using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillScript : MonoBehaviour
{
    public GameObject grill; 
    public void GrillOn()
    {
        grill.gameObject.tag = "Grill"; 
    }
    public void GrillOff()
    {
        grill.gameObject.tag = "Untagged"; 
    }
}
