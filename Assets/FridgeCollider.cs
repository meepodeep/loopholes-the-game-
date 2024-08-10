using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeCollider : MonoBehaviour
{
    [HideInInspector]public bool doorClosed = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Fridge")){
            doorClosed = true;
            Debug.Log("Fridge");
        }
    }
        void OnTriggerExit(Collider other){
            doorClosed = false;
        }
    // Update is called once per frame
    void Update()
    {
        
    }
}
