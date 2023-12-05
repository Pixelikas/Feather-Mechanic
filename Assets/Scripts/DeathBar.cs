using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to checks death bar colision
    void OnTriggerEnter2D(Collider2D other){

        // Checks the tag
        if(other.tag == "Player"){

            // Destroy player
            Destroy(other.gameObject);

            // Play death sfx
            AudioManager.audioSrc.PlayOneShot(AudioManager.deathSound);

            // Reset feathers values
            PlayerMovement.feathersNum = 3;
            PlayerMovement.feathersItem = 3;

            // Call restart method
            Invoke("RestartScene", 1f);

        }

    }

    // Method to restart scene
    void RestartScene(){

        // Reload scene
        SceneManager.LoadScene(0);

    }
}
