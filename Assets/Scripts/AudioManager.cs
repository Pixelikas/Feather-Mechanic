using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    // Sets variables to sound component and sfx's
    public static AudioSource audioSrc;
    public static AudioClip jumpSound;
    public static AudioClip walkSound;
    public static AudioClip flightSound;
    public static AudioClip itemSound;
    public static AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {

        // Get audio component
        audioSrc = GetComponent<AudioSource>();

         // Set sound sources to variables
        jumpSound = Resources.Load<AudioClip>("JumpSound");
        flightSound = Resources.Load<AudioClip>("FlightSound");
        walkSound = Resources.Load<AudioClip>("WalkSound");
        itemSound = Resources.Load<AudioClip>("ItemSound");
        deathSound = Resources.Load<AudioClip>("DeathSound");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
