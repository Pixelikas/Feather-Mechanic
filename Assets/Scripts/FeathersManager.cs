using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeathersManager : MonoBehaviour
{

    // Sets variables to control feathers (current) number and feathers max number
    public int feather;
    public int feathersMax;

    // Sets Image array to feathers 
    public Image[] feathers;

    // Sets variables to feathers sprites (full and empty) 
    public Sprite featherFull;
    public Sprite featherEmpty; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Sets variables values from static variables  
        feather = PlayerMovement.feathersNum;
        feathersMax = PlayerMovement.feathersItem;

        // Checks if feathers number is greater than feathers max
        if(feather > feathersMax){

            // Sets feathers number to limit (feathers max)
            feather = feathersMax;

        }

        // Create a loop to feather array 
        for(int i=0; i < feathers.Length; i++){

            // Checks if feather position is less than feather number
            if(i < feather){

                // Sets feather full sprite
                feathers[i].sprite = featherFull;

            }else{

                // Sets feather empty sprite
                feathers[i].sprite = featherEmpty;

            }

            // Checks if feather position is less than feather max
            if(i < feathersMax){

                // Sets (current) feather visible
                feathers[i].enabled = true;

            }else{

                // Sets (current) feather invisible
                feathers[i].enabled = false;

            }

        }
       
    }
    
}
