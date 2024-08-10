using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
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
        icons = new GameObject[10];
        DisplayOrder();
    }

    public void DisplayOrder(){
        Index[0] = 0;
        Index[1] = Mathf.Clamp(Random.Range(0,5), 1, 4);
        Index[2] = Mathf.Clamp(Random.Range(0,5), 1, 4);
        Index[3] = Mathf.Clamp(Random.Range(0,5), 1, 4);
        Index[4] = 5;
        Index[6] = Mathf.Clamp(Random.Range(0,4), 1, 2);
        if (Index[6] == 1){
            Index[6] = 6;
            Instantiate(Foods[Index[6]], Slots[5].transform.position, Slots[0].transform.rotation);
        }else{
            Index[6] = 8;
        }
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
