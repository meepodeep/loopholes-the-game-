using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI QuotaText;
    [SerializeField] TextMeshProUGUI QuotaMet;
    [SerializeField] TextMeshProUGUI OrdersMissed;
    [SerializeField] TextMeshProUGUI OrdersMet;
    [SerializeField] TextMeshProUGUI PointTotal;
    public PlateManager pm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pm.quotaMet == true){
            QuotaMet.text = "Quota Met";
        }else{
            QuotaMet.text = "Missed Quota"; 
        }
        QuotaText.text = "Quota:" + pm.quota.ToString();
        PointTotal.text = "Point Total:" + pm.points.ToString();
        OrdersMet.text = "Orders Fulfilled:" + pm.fulfilledOrders.ToString();
        OrdersMissed.text = "Orders Missed:" + pm.missedOrders.ToString();
    }
}
