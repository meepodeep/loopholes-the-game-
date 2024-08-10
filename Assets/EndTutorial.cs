using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTutorial : MonoBehaviour
{
    public GameObject button;
    public GameObject plate; 

    public void EndTut(){
        button.SetActive(false);
        if(GameObject.Find("/BlackBoard/Tutorial") != null){
        GameObject.Find("/BlackBoard/Tutorial").SetActive(false);
        }
        if(GameObject.Find("/Kitchen/Counter/StartPanel 1") != null){
        GameObject.Find("/Kitchen/Counter/StartPanel 1").SetActive(true);
        }
        plate.SetActive(false);
    }
    public void RemovePanel(){
                if(GameObject.Find("/Kitchen/Counter/StartPanel 1") != null){
        GameObject.Find("/Kitchen/Counter/StartPanel 1").SetActive(false);
        }
            if(GameObject.Find("/BlackBoard/FinishScreen") != null){
        GameObject.Find("/BlackBoard/FinishScreen").SetActive(false);
        }
    }
}
