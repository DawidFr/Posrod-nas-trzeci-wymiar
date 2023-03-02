using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sus_Interaction : MonoBehaviour
    {
    public TriggerAndInteractionHandler trig;



    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)){
            if(trig.target != null)  trig.target.GetComponent<InteractableObjectScript>().Interact();
        }    
    }
}
