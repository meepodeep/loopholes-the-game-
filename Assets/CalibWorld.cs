using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem; 
public class CalibWorld : MonoBehaviour
{
    public Rigidbody World;
    public Transform PlayerCamera; 
    public InputActionProperty Calib; 
    public Transform AgainstTheKitchenFloor; 
    float PlayerHeightFromCounter = 1f; 
    bool isCalibButtonPressed = true;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        if (isCalibButtonPressed == true && Calib.action.ReadValue<float>() > 0.1f){
            Calibrate();
        }
         if (isCalibButtonPressed == false && Calib.action.ReadValue<float>() < 0.1f){
            isCalibButtonPressed = true; 
        }
    }
    void Calibrate(){
        PlayerHeightFromCounter = PlayerCamera.transform.position.y - AgainstTheKitchenFloor.transform.position.y; 
        World.transform.position = new Vector3(0, PlayerHeightFromCounter, 0); 
        isCalibButtonPressed = false; 
    }
}
