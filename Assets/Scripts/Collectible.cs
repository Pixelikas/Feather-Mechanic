using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to checks feather item colision
    void OnTriggerEnter2D(Collider2D col){

        // Checks the tag
        if(col.tag == "Player"){

            // Destroy feather item
            Destroy(this.gameObject);

            // Play collectible sfx
            AudioManager.audioSrc.PlayOneShot(AudioManager.itemSound);

            // Add new feather "slot" to UI
            PlayerMovement.feathersItem++;

        }

    }

}
