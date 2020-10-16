using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class playermovement : NetworkBehaviour
{   
    
    bool triggered = false;
    
    public override void OnStartLocalPlayer()
        {
        GetComponent<MeshRenderer>().material.color = Color.red;
        }

        [Command]
        void CmdArriba()
        {   
            Vector3 myVar = new Vector3 (0,0,0);
            Vector3 targetPos = new Vector3 (0,0,0);
            Debug.Log(transform.position);
            // Crea una instancia de un objeto a la derecha del objeto actual
            //Vector3 thePosition = transform.TransformPoint (2, 0, 0); 
            //var transformedpos=this transform.InverseTransformPoint(transform.position.<playermovement>);
            myVar=GameObject.Find("playermovement").transform.position;
            targetPos = new Vector3(myVar.x, myVar.y + 10,myVar.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 5);
            Debug.Log(targetPos);
        
            //Destroy(gameObject);
        }
     void OnCollisionEnter(Collision collision)
        {   
            var hit = collision.gameObject;
            var hitPlayer = hit.GetComponent<playermovement>();
            if (hitPlayer != null )
            {
                triggered = true;
    
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
         //update the position
        //transform.position = transform.position + new Vector3(x * 0.1f * Time.deltaTime,0,z * 0.1f * Time.deltaTime);

        //output to log the position change
        //Debug.Log(transform.position);
        
        if (Input.GetKeyDown(KeyCode.Space) && triggered)
        {
            // Command function is called from the client, but invoked on the server
            CmdArriba();

        }
        
          
    }
    
}