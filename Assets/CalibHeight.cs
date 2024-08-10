using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CalibHeight : MonoBehaviour
{
    public InputActionProperty CalibInputSource;
    public GameObject playerBody; 
    public GameObject physicsRig; 
    public Transform mainCamera; 
    public Transform Kitchenfloor;
    bool isCalibPressed;
    [SerializeField]
    float PlayerHeight = 1.4f; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (isCalibPressed == true){
            Calibrate();
            isCalibPressed = false; 
        }else {
            isCalibPressed = CalibInputSource.action.ReadValue<float>() > 0.1f;
        }
    }
    void Calibrate(){
        PlayerHeight = mainCamera.transform.position.y - Kitchenfloor.position.y ;
        playerBody.transform.position = new Vector3(0,-PlayerHeight,0);
        physicsRig.transform.position = new Vector3(0,PlayerHeight,0);
        playerBody.transform.localScale = new Vector3(1,PlayerHeight*1.9f,1);
    }
}
