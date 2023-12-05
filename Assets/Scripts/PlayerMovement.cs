using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Sets player speed, jump and horizontal move variables
    [SerializeField] private float horizontalMove = 0f;
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float playerJump = 12f;

    // Sets variable to reference physics component  
    public Rigidbody2D playerPhysics;

    // Sets variables to control onGround state
    public Transform checkGround;
    public bool onGround;
    public LayerMask Ground;

    // Sets boolean variable to jump state
    public static bool onJump;

    // Sets variables to control feathers (current) number and feathers max number
    public static int feathersNum;
    public static int feathersItem;

    // Sets variable to reference animator component  
    public static Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        // Sets some initial variable values
        feathersNum = 3;
        feathersItem = 3;

        // Get animator component
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        // Sets a variable to get horizontal input
        float x = Input.GetAxisRaw("Horizontal");

        // Sets velocity with horizontal inputs and player speed
        playerPhysics.velocity = new Vector2(x * playerSpeed, playerPhysics.velocity.y);

        // Sets horizontal movement value to a variable
        horizontalMove = x * playerSpeed;

        // Sets horizontal movement value to float animator parameter
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // Checks player movement diretion by position
        if(x < 0){

            // Flips player sprite to left
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        
        }

        // Checks player movement diretion by position
        if (x > 0){

            // Flips player sprite to right
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        }

        // Checks player input and feathers number, conditions to jump or fly
        if(Input.GetKeyDown(KeyCode.Z) && feathersNum != 0){    

            // Checks if player is on ground
            if(onGround){

                // Call jump method    
                Jump();

                // Play jump sfx
                AudioManager.audioSrc.PlayOneShot(AudioManager.jumpSound);

            }else{

                // Call fly method 
                Fly();

                // Play flight sfx
                AudioManager.audioSrc.PlayOneShot(AudioManager.flightSound);

            }

        }

        // Sets value to onGround state
        onGround = Physics2D.OverlapCircle(checkGround.position, 0.2f, Ground);
        
        // Checks if player is onGround
        if(onGround){

            // Reset feathers count
            feathersNum = feathersItem;

        }
        
    }

    // Method to player jump
    void Jump(){

        // Subtract feathers by one
        feathersNum--;

        // Sets vertical velocity and does the jump
        playerPhysics.velocity = new Vector2(playerPhysics.velocity.x, playerJump);

        // Sets boolean jump to true
        onJump = true;

        // Sets jump animation
        animator.SetBool("isJumping", true);

    }

    // Method to player land
    public static void OnLanding(){

        // Sets boolean jump to false
        onJump = false;

        // Sets jump animation end
        animator.SetBool("isJumping", false);

    }

    // Method to player flight
    void Fly(){

        // Sets jump animation end
        animator.SetBool("isJumping", false);

        // Subtract feathers by one
        feathersNum--;

        // Sets vertical velocity and does a new jump (flight)
        playerPhysics.velocity = new Vector2(playerPhysics.velocity.x, playerJump);

        // Sets flight animation 
        animator.SetTrigger("isFlying");

    }

}