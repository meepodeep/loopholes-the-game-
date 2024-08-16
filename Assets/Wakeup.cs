using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wakeup : MonoBehaviour
{
    float timeSinceStart;
    public GameObject volume;
    void Start(){
        FindObjectOfType<AudioManager>().Play("Opening");
    }
    void Update()
    {
        timeSinceStart +=1 * Time.deltaTime; 
        if (timeSinceStart >= 10)
        {
            Destroy(volume);
        }
    }
}
