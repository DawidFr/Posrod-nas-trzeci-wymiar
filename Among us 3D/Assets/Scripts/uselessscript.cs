using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uselessscript : MonoBehaviour
{
    public Transform player;
    public Vector3 spacing;

    
    void Update()
    {

        transform.position = player.position + spacing;
    }
}
