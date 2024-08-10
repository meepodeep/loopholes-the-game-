using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

public class PlateManager : MonoBehaviour
{
    public float points;
    private string[] RequestedTag;
    private bool implode;
    bool IsPressed = true; 
    public string[] ObjTag; 
    public bool canTake;
    float ObjectNumber; 
    [SerializeField]
    public Rigidbody Scanner; 
    public Transform ScannerTransform;
    bool canMove = true;
    float move;
    public Order order;
    float OrderTimer = 1;
    [SerializeField] private Image Timer = null;
    [SerializeField] private Image TimerBig = null;
    [SerializeField] TextMeshProUGUI PointText;
    [SerializeField] TextMeshProUGUI QuotaText;
    [HideInInspector] public float quota = 40;
    [HideInInspector] public float missedOrders;
    [HideInInspector] public float fulfilledOrders;
    public bool quotaMet;
    float gameTimer = 100;
    public GameObject endScreen;
    public GameObject mainScreen;
    public GameObject ButtonPanel;
    public GameObject[] icons;
    public bool isPlaying = false;
    bool canOrder = true;
    // Start is called before the first frame update
    void Start()
    {
        icons = new GameObject[10];
        RequestedTag = new string[10];
        RequestedTag[0] = "TopBun"; 
        RequestedTag[1] = "Onion"; 
        RequestedTag[2] = "Burger"; 
        RequestedTag[3] = "Lettuce";
        RequestedTag[4] = "CheeseCut";
        RequestedTag[5] = "BottomBun";
        RequestedTag[6] = "Soda";
        RequestedTag[7] = "PlateReal";
        RequestedTag[8] = "nein";
        
        ObjTag = new string[10]; 
        ObjTag[0] = "nein";
        ObjTag[1] = "nein";
        ObjTag[2] = "nein";
        ObjTag[3] = "nein";
        ObjTag[4] = "nein";
        ObjTag[5] = "nein";
        ObjTag[6] = "nein";
        ObjTag[7] = "nein";
        ObjTag[8] = "nein";
        ObjTag[9] = "nein";
    }
    void Update(){
        
        TimerBig.fillAmount = gameTimer/100f;
        if(gameTimer <= 0f){
            endScreen.SetActive(true); 
            mainScreen.SetActive(false);
            ButtonPanel.SetActive(true);
            isPlaying = false; 
            icons = GameObject.FindGameObjectsWithTag("Icon");
            foreach (GameObject icon in icons)
            {
                Destroy(icon);
            }
            gameTimer = 100;
        }
        if(isPlaying == true)
        {
            gameTimer -= .1f*Time.deltaTime;
        }
    }
    public void playing(){
        isPlaying = true;
    }
    void FixedUpdate()
    {
        QuotaText.text = "quota:" + quota.ToString();
        if(points >= quota){
            quotaMet = true;
        }else{
            quotaMet = false; 
        }
        Timer.fillAmount = OrderTimer;
        OrderTimer -= .006f * Time.fixedDeltaTime; 
        if(OrderTimer <= 0 && canOrder == true){
            FindObjectOfType<AudioManager>().Play("Ring");
            missedOrders +=1;
            NewOrder();
            canOrder = false; 
        }
        if (IsPressed == true && canMove == true){
        move = -.05f;
        Scanner.AddForce(transform.up * move);
        }else{
            move = 0f;
            Scanner.velocity = new Vector3(0f, 0f, 0f);
            ScannerTransform.localPosition = new Vector3(0,0,0);
            canMove = true; 
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlateIgnore")){

        }else{
        Debug.Log(other.tag);
        if (other.gameObject.CompareTag("Plate")){
            NewOrder();
            OrderTimer = 1;
            FindObjectOfType<AudioManager>().Play("Ding");
        }else{

        if(IsPressed == true){
            if(other.gameObject.CompareTag("Soda"))
            {
                ObjTag[7] = other.tag;
                Destroy(other.gameObject);
            }else{
        ObjectNumber +=1;
        switch(ObjectNumber){
            case 1:
            ObjTag[0] = other.tag;
            break;
            case 2:
            ObjTag[1] = other.tag;
            break;
            case 3:
            ObjTag[2] = other.tag;
            break;
            case 4:
            ObjTag[3] = other.tag;
            break;
            case 5:
            ObjTag[4] = other.tag;
            break;
            case 6:
            ObjTag[5] = other.tag;
            break;
        }
        Destroy(other.gameObject);
        }
        }
        
        }
        }
    }
    public void Press(){
    IsPressed = true;
    }
    public void UnPress(){
        IsPressed = false;
    }
    public void NewOrder()
    {
        
        RingUp();
        StartCoroutine(DelayReset());

    }
    public IEnumerator DelayReset(){
        yield return new WaitForSeconds(.1f);
        OrderTimer = 1;
        ObjectNumber = 0;
        canMove = false; 
        order.DeleteOldOrder();
        order.DisplayOrder();
        ObjTag[0] = "nein";
        ObjTag[1] = "nein";
        ObjTag[2] = "nein";
        ObjTag[3] = "nein";
        ObjTag[4] = "nein";
        ObjTag[5] = "nein";
        ObjTag[6] = "nein";
        ObjTag[7] = "nein";
        ObjTag[8] = "nein";
        ObjTag[9] = "nein";

    }
    public void RingUp()
    {
        if (ObjTag[5] == RequestedTag[7])
        {
            if (ObjTag[0] == RequestedTag[0])
            {
                points += 1;
            }else{
                points -= 1;
            }
            if (ObjTag[1] == RequestedTag[order.Index[1]])
            {
                points += 1;
            }else{
                points -= 1;
            }
            if (ObjTag[2] == RequestedTag[order.Index[2]])
            {
                points += 1;
            }else{
                points -= 1;
            }
            if (ObjTag[3] == RequestedTag[order.Index[3]])
            {
                points += 1;
            }else{
                points -= 1;
            }
            if (ObjTag[4] == RequestedTag[order.Index[4]])
            {
                points += 1;
            }else{
                points -= 1;
            }
            if (ObjTag[7] == RequestedTag[order.Index[6]])
            {
                points += 1;
            }else{
                points -= 1;
            }
        }else{
            points -= 5;
        }
        fulfilledOrders += 1; 
        PointText.text = "Points:" + points.ToString();
        Debug.Log(points); 
        canOrder = true; 
    }

}

