using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sus_UI_controller : MonoBehaviour
{
    public Image killButtton, reportButton, useButton;
    public RawImage map; 


    private void Start() {
        
        
    } 
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Tab))   map.enabled = true;
        if(Input.GetKeyUp(KeyCode.Tab)) map.enabled = false;
    }
}
