using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to subtract the first feather
    void OnTriggerExit2D(Collider2D col){

        // Checks the tag
        if(col.tag == "Ground"){

            // Subtract feathers number by one 
            PlayerMovement.feathersNum--;

        }

    }

    // Method to call landing
    void OnTriggerEnter2D(Collider2D col){

        // Checks the tag
        if(col.tag == "Ground"){

            // Subtract feathers number by one 
            PlayerMovement.OnLanding();

        }

    }

}
