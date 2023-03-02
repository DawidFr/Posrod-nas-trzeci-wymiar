using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sus_Movement : MonoBehaviour
{

    public enum PlayerType{
        crewmate,
        impostor,
    }
    public PlayerType playerType;
    
    private ImpostorControler impostorControler;
    private bool dead;
    public bool test;   
    [Header ("Mesh")]

    public GameObject deadAmongus;



    [Header ("Movement")]
    public float speed;
    public float groundDrag;
    
    [Header ("GrounCheck")]
    public float playerHeight;
    public LayerMask groundLayer;
    private bool grounded;


    [Header ("Camera")]
    public Transform orientation;
    float horInput, verInput;
    Vector3 dir;
    Rigidbody rb;


    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        if(playerType == PlayerType.impostor){
            impostorControler = GetComponent<ImpostorControler>();
            impostorControler.enabled = true;
            transform.parent.tag = "Impostor";
        } 
        
    }

    private void Update() {
        if(dead || test)return;
        MyInput();
        SpeedControl();

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);

        if(grounded) rb.drag = groundDrag;
        else rb.drag = 0;
    }
    private void FixedUpdate() {
        if(dead || test)return;
        PlayerMove();
    }


    void MyInput(){
        horInput = Input.GetAxisRaw("Horizontal");
        verInput = Input.GetAxisRaw("Vertical");
        
    }

    void PlayerMove(){
        dir = orientation.forward * verInput + orientation.right * horInput;
        rb.AddForce(dir.normalized * speed * 10f, ForceMode.Force);
        transform.rotation = orientation.rotation;
    }

    private void SpeedControl(){

        Vector3 flatVel = new Vector3(rb.velocity.x , 0 , rb.velocity.y);
        
        if(flatVel.magnitude > speed){
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y , limitedVel.z);
        }
    }
    public void killCrewmate(){
        GameObject corps = Instantiate(deadAmongus, transform.position - new Vector3(0 , .5f ,0), transform.rotation);
        corps.GetComponentInChildren<MeshRenderer>().material = GetComponentInChildren<MeshRenderer>().material;
        Destroy(transform.parent.gameObject);
    }

}
