using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanTab : MonoBehaviour
{
    public GameObject Unopened;
    public GameObject Opened;
    public bool CanOpened = false; 
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SodaTab"))
        {
            FindObjectOfType<AudioManager>().Play("CanOpen");
            CanOpened = true;
            Unopened.SetActive(false);
            Opened.SetActive(true);
        }
    }
}
