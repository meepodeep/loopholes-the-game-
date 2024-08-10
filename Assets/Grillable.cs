using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Grillable : MonoBehaviour
{
    public ParticleSystem Cooking;
    public ParticleSystem Cooking2;
    float grillPercent;
    public GameObject burgerRaw; 
    public GameObject burgerCooked;
    public GameObject burgerBurnt;
    public GameObject burger; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if (grillPercent >= 10  && grillPercent < 15){
        Cooked();
        burger.tag = "Burger";
       }
        if (grillPercent >= 15){
        Burnt();
        burger.tag = "Untagged";
       }
    }
     void OnTriggerStay(Collider other)
    {
            if(other.gameObject.CompareTag("Grill"))
            {   
                
                Cook();
            }
            if(other.gameObject.CompareTag("Untagged"))
            {
                Uncook();
            }
    }
    void OnTriggerExit(Collider other)
    {
       
        Uncook();
    }
    void Uncook(){
        Cooking.Stop();
        Cooking2.Stop();

    }
    void Cook(){
        Cooking.Play(true);
        Cooking2.Play(true);
        Mathf.Clamp(grillPercent,0f, 15f);
        grillPercent += 1f * Time.deltaTime;
        
    }
    void Cooked()
    {
    burgerRaw.SetActive(false); 
    burgerCooked.SetActive(true); 
    burgerBurnt.SetActive(false); 
    
    }
     void Burnt()
    {
    burgerCooked.SetActive(false);
    burgerBurnt.SetActive(true);
    
    }
}
