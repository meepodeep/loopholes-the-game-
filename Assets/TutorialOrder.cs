using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TutorialOrder : MonoBehaviour
{
    [SerializeField]
    public Transform[] Slots;
    [SerializeField]
    public GameObject[] Foods;
    public int[]Index;
    public GameObject[] icons;
    // Start is called before the first frame update
    void Start()
    {
        Index = new int[10];
        icons = new GameObject[6];
        DisplayOrder1();
    }

    public void DisplayOrder1(){
        Index[0] = 5;
        Index[1] = 6;
        Index[2] = 6;
        Index[3] = 6;
        Index[4] = 6;
        Index[5] = 6;
    }
    public void DisplayOrder2(){
        Index[0] = 2;
        Index[1] = 5;
        Index[2] = 6;
        Index[3] = 6;
        Index[4] = 6;
        Index[5] = 6;
        Instantiate(Foods[Index[0]], Slots[0].transform.position, Slots[0].transform.rotation);
    }
    public void DisplayOrder3(){
        Index[0] = 1;
        Index[1] = 5;
        Index[2] = 6;
        Index[3] = 6;
        Index[4] = 6;
        Index[5] = 6;
        Instantiate(Foods[Index[0]], Slots[0].transform.position, Slots[0].transform.rotation);
    }
    public void DisplayOrder4(){
        Index[0] = 0;
        Index[1] = 1;
        Index[2] = 2;
        Index[3] = 3;
        Index[4] = 4;
        Index[5] = 5;
        Instantiate(Foods[Index[0]], Slots[0].transform.position, Slots[0].transform.rotation);
        Instantiate(Foods[Index[1]], Slots[1].transform.position, Slots[0].transform.rotation);
        Instantiate(Foods[Index[2]], Slots[2].transform.position, Slots[0].transform.rotation);
        Instantiate(Foods[Index[3]], Slots[3].transform.position, Slots[0].transform.rotation);
        Instantiate(Foods[Index[4]], Slots[4].transform.position, Slots[0].transform.rotation);
    }
    public void DeleteOldOrder(){
        icons = GameObject.FindGameObjectsWithTag("Icon");
            foreach (GameObject icon in icons)
            {
                Destroy(icon);
            }

    }
}
