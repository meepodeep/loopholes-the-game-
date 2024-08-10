using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class DrinkFridgeManager : MonoBehaviour
{
    public GameObject food;
    public FridgeCollider fc;
    GameObject[] foodsInFridge;
    GameObject foodInstantiated;
    public Transform fridge;
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
        if(fc.doorClosed == true){
            if(foodNumber > 0){
            foreach (GameObject food in foodsInFridge){
                Destroy(food);
            }
            foodNumber = 0;
            }
            (Instantiate (food, new Vector3(0.892f,fridge.position.y-.04f,0.697f), Quaternion.Euler(0,0,0)) as GameObject).transform.parent = fridge.transform;
            fc.doorClosed = false;
            
            
        }
        
    }
}
