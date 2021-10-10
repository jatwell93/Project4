using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private variables
    private Rigidbody playerRb;
    private Animator playerAnim;
    private bool isTouchingGround = true;

    //public variables
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isGameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        // *= is short hand for variable = variable times modifier
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isTouchingGround && !isGameOver)
        {
            //Forcemode.impulse adds the force immediately and not over any time
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isTouchingGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            //plays the variable jumpSound once at full volume 
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isTouchingGround = true;
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            Debug.Log("GAME OVER");
            //sets values to match conditions in the animator controller in parameters
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);

        }

    }
}
