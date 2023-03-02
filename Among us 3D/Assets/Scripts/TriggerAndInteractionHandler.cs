using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAndInteractionHandler : MonoBehaviour
{
    public GameObject target;
    public GameObject impostorTarget;
    public GameObject reportTarget;
    public Sus_UI_controller sus_UI;
    public ImpostorControler impostorControler;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Interactable"){
            sus_UI.useButton.color = new Color(255, 255, 255, 1);
            target = other.gameObject;
        }
        
        if(other.transform.parent.tag == "Crewmate"){
            if(impostorControler.canKill) sus_UI.killButtton.color = new Color(255, 255, 255, 1);
            impostorTarget = other.gameObject;
        }
        if(other.transform.parent.tag == "DeadCrewmate"){
            sus_UI.reportButton.color = new Color(255, 255, 255, 1);
            reportTarget = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Interactable" && other.gameObject == target){
            sus_UI.useButton.color = new Color(255, 255, 255, 0.3f);
            target = null;
        }
        if(other.transform.parent.tag == "Crewmate" && other.gameObject  == impostorTarget){
            sus_UI.killButtton.color = new Color(255, 255, 255, 0.3f);
            impostorTarget = null;
        }
        if(other.transform.parent.tag == "DeadCrewmate" && other.gameObject == reportTarget){
            reportTarget = null;
            sus_UI.reportButton.color = new Color(255, 255, 255, 0.3f);
        }
    }
}
