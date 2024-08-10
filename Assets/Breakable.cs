using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public List<GameObject> breakablePeices;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in breakablePeices){
            item.SetActive(false);
        }
    }

    // Update is called once per frame
    public void Break()
    {
        foreach (var item in breakablePeices){
            item.SetActive(true);
            item.transform.parent = null;
        }
        gameObject.SetActive(false);
    }
    
}
