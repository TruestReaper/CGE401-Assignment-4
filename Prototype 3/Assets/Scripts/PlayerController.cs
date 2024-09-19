/*
* John Chirayil
* Assignment 4 - Prototype 3
* Description: Controls player movement and
* manages player's animations and SFX.
* in game.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public ForceMode jumpForceMode;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public Animator playerAnimator;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip deathSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetFloat("Speed_f", 1.0f);
        playerAudio = GetComponent<AudioSource>();

        // set a reference to rigidbody component
        rb = GetComponent<Rigidbody>();

        // Modify gravity
        if (Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }

        jumpForceMode = ForceMode.Impulse;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            //Debug.Log("Game Over");
            gameOver = true;

            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            explosionParticle.Play(); 
            dirtParticle.Stop();
            playerAudio.PlayOneShot(deathSound, 1.0f);
        }
    }
}
