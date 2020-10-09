using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class playermovement : NetworkBehaviour
{   
    
    public override void OnStartLocalPlayer()
        {
        GetComponent<MeshRenderer>().material.color = Color.red;
        }


     void OnCollisionEnter(Collision collision)
        {   
            var hit = collision.gameObject;
            var hitPlayer = hit.GetComponent<playermovement>();
            if ((hitPlayer != null) )
            {
                Destroy(gameObject);
                //transform.position = new Vector3(10,0,10);
            //Destroy(gameObject);
            }
        }  
        
    
    void Update()
    {
        
        if (!isLocalPlayer)
            return;

        var x = Input.GetAxis("Horizontal") * 0.1f;
        var z = Input.GetAxis("Vertical") * 0.1f;

        transform.Translate(x, 0, z);
        
        
          
    }
    
}