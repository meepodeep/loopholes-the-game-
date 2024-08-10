using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class FridgeManager : MonoBehaviour
{
    public GameObject food;
    public FridgeCollider fc;
    bool canSpawn = false; 
    GameObject[] foodsInFridge;
    GameObject foodInstantiated;
    int foodNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        foodsInFridge = new GameObject[500];
    }
    void OnTriggerStay(Collider other)
    {
        if(fc.doorClosed == true){
        foodsInFridge[foodNumber] = other.gameObject; 
        foodNumber +=1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(fc.doorClosed == false && canSpawn == true){
        Instantiate(food, new Vector3(0,.1f,0), Quaternion.Euler(-90,0,0));
        canSpawn = false;
        }
        if(fc.doorClosed == true){
            if(foodNumber > 0){
            foreach (GameObject food in foodsInFridge){
                Destroy(food);
            }
            foodNumber = 0;
            }
            canSpawn = true;
        }
        
    }
}
