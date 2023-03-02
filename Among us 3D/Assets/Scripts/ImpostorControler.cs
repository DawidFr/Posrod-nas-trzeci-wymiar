using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Special;

public class ImpostorControler : MonoBehaviour
{
    private AudioSource audioS;
    public AudioClip[] killSound;
    public float killColdown = 22f;
    public bool canKill; 
    private Image killButton;
    public TriggerAndInteractionHandler trig;
    private void OnEnable() {
        killButton = GetComponent<Sus_UI_controller>().killButtton;
        killButton.enabled = true;
        audioS = GetComponent<AudioSource>();

    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Q) && canKill){
            if(trig.impostorTarget != null){
                audioS.clip = MyRandom.GetObject<AudioClip>(killSound);
                audioS.Play();
                trig.impostorTarget.GetComponentInChildren<Sus_Movement>().killCrewmate();
                killButton.color = new Color(255, 255, 255, 0.3f);
                StartCoroutine(killColddown());
                trig.impostorTarget = null;
                canKill = false;
            }  
        }    

    }
    public IEnumerator killColddown(){
        yield return new WaitForSeconds(killColdown);
        canKill = true;
        if(trig.impostorTarget != null) killButton.color = new Color(255, 255, 255, 1); 
    }
}
