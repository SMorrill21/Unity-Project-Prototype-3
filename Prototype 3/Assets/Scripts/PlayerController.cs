using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;

    private Rigidbody playerRB;
    private Animator playerAnim;
    private AudioSource playerAudioSource;
    private bool isOnGround = true;
    private int jumpNumber = 0;

    public int score = 0;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool gameOver = false;
    public bool sprint = false;
    public ParticleSystem explosionParticale;
    public ParticleSystem dirtParticale;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && jumpNumber < 2)
        {
            jumpNumber++;
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticale.Stop();
            playerAudioSource.PlayOneShot(jumpSound);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerAnim.speed = 1.6f;
            sprint = true;
        }
        else
        {
            playerAnim.speed = 1.25f;
            sprint = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (!gameOver && collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            jumpNumber = 0;
            dirtParticale.Play();
        }
        else if (!gameOver && collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticale.Play();
            dirtParticale.Stop();
            playerAudioSource.PlayOneShot(crashSound);
        }
    }

}
