using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.UI;

public class MenuPanel : MonoBehaviour
{
    public Transform buttonTopTutorial;
    public Transform buttonTopPlay;
    public Transform buttonTopExit;
    public Transform buttonBase;
    public UnityEvent PlayOnPressed;
    public UnityEvent PlayOnReleased;
    public UnityEvent TutorialOnPressed;
    public UnityEvent TutorialOnReleased;
    public UnityEvent ExitOnPressed;
    public UnityEvent ExitOnReleased;
    private float TutorialDistance;
    private float PlayDistance;
    private float ExitDistance;
    private float ExitThreshold;
    private float PlayThreshold;
    private float TutorialThreshold;
    bool CanToggle = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delayThreshold());
    }
    public IEnumerator delayThreshold(){
        yield return new WaitForSeconds(1f);
        TutorialThreshold = TutorialDistance/10e35f;
        ExitThreshold = ExitDistance/10e35f;
        PlayThreshold = PlayDistance/10e35f;
        CanToggle = true;
    }
    // Update is called once per frame
    void Update()
    {
        
        TutorialDistance = buttonTopTutorial.localPosition.y-buttonBase.localPosition.y;
        if(TutorialDistance <= TutorialThreshold && CanToggle == true){
            TutorialOnPressed.Invoke();
            
        }else{
            TutorialOnReleased.Invoke();
        }
        
        PlayDistance = buttonTopPlay.localPosition.y-buttonBase.localPosition.y;
        if(PlayDistance <= PlayThreshold && CanToggle == true){
            PlayOnPressed.Invoke();
        }else{
            PlayOnReleased.Invoke();
        }
        ExitDistance = buttonTopExit.localPosition.y-buttonBase.localPosition.y;
        if(ExitDistance <= ExitThreshold && CanToggle == true){
            ExitOnPressed.Invoke();
        }else{
            ExitOnReleased.Invoke();
            
        }
    }
    public void Implode(){
        Application.Quit();
        Debug.Log("Implode");
    }
}
