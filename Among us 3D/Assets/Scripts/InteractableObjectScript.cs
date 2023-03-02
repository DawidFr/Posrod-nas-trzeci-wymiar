using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectScript : MonoBehaviour
{
    public InteractionType interactionType;
    [Header ("Normal doot")]
    private Collider col;
    private Animator animator;
    public bool isOpen = true;


    [Header ("Decompresion door")]
    public InteractableObjectScript secondDoor;
    public float timeTilClose, timeTilOpen;
    public bool isDecomresing;
    public ParticleSystem decompresionParticle;
    public enum InteractionType{
        door,
        decompresionDoor,

    }


    private void Awake() {
        col = GetComponent<Collider>(); 
        animator = GetComponent<Animator>();
        
    }
    private void Start() {
        
        if(interactionType == InteractionType.decompresionDoor){
            secondDoor.CloseDoor();
            CloseDoor();
        }
    }

    public void Interact(){
        switch (interactionType)
        {
            case InteractionType.door: {
                DoorInteraction();
                break;
            }
            case InteractionType.decompresionDoor: {
                if(isOpen) return;
                if(isDecomresing || secondDoor.isDecomresing) return;
                isDecomresing = true;
                if(!secondDoor.isOpen){
                    OpenDoor(); 
                    StartCoroutine(Decomresion(secondDoor));
                }
                else StartCoroutine(Decomresion(this));
                               
                break;
            }
            default: return;
        }
    }

    void DoorInteraction(){
        if(isOpen){
            CloseDoor();
        }
        else{
            OpenDoor();
        }
    }
    public void OpenDoor(){
        if(isOpen) return;
        animator.SetTrigger("Open");    
        isOpen = true;
        col.isTrigger = true;

    }
    public void CloseDoor(){
        if(!isOpen) return;
        animator.SetTrigger("Close");
        isOpen = false;
        col.isTrigger = false;
    }   
    
    IEnumerator Decomresion(InteractableObjectScript doorToOpen){
            
        secondDoor.CloseDoor();
        yield return new WaitForSeconds(timeTilClose);
        CloseDoor();
        decompresionParticle.Play();
        yield return new WaitForSeconds(timeTilOpen);
        //OpenDoor();
        doorToOpen.OpenDoor();
        isDecomresing = false;
    
    }  
}
