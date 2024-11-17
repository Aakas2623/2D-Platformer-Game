using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public GameOverController gameOverController;
    
    
    [SerializeField] private Animator animator;

    public float speed;
    [SerializeField] private float jump;

    [SerializeField] private Rigidbody2D rb2d;

    bool isGrounded = false;
    bool isDead = false;

    Camera mainCamera;

    [SerializeField] private int playerLives;

    [SerializeField] private BoxCollider2D boxCol;
    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;

    //private void Awake()
    //{
    //    rb2d = gameObject.GetComponent<Rigidbody2D>();
    //}


    private void Start()
    {
        mainCamera = Camera.main;
        boxColInitSize = boxCol.size;
        boxColInitOffset = boxCol.offset;
    }

    //private void Update()
    //{
    //    float horizontal = Input.GetAxisRaw("Horizontal");
    //    bool vertical = Input.GetKeyDown(KeyCode.Space);

    //    HorizontalAnimation(horizontal);
    //    MoveCharacter(horizontal);
    //    MovePlayerVertically(vertical);



    //    PlayJumpAnimation(VerticalInput);

    //    if (Input.GetKey(KeyCode.LeftControl))
    //    {
    //        Crouch(true);
    //    }
    //    else
    //    {
    //        Crouch(false);
    //    }

    //}

    //private void MoveCharacter(float horizontal)
    //{
    //     Horizontal character movement
    //    Vector3 newPosition = transform.position;
    //    newPosition.x += horizontal * speed * Time.deltaTime;
    //    transform.position = newPosition;
    //}

    //private void HorizontalAnimation(float horizontal)
    //{
    //    Horizontal animation
    //    animator.SetFloat("Speed", Mathf.Abs(horizontal));

    //    Flipping the player
    //    Vector2 scale = transform.localScale;
    //    if (horizontal < 0)
    //    {
    //        scale.x = -1f * Mathf.Abs(scale.x);
    //    }
    //    else if (horizontal > 0)
    //    {
    //        scale.x = Mathf.Abs(scale.x);
    //    }
    //    transform.localScale = scale;
    //}

    //public void MovePlayerVertically(bool vertical)
    //{
    //    if (vertical)
    //    {
    //        Debug.Log("pressing space key");
    //    }

    //    if (vertical && isGrounded)
    //    {
    //        Debug.Log("Jumping");

    //        rb2d.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
    //        animator.SetBool("isGrounded", false);
    //    }
    //}

    //private void OnCollisionStay2D(Collision2D other)
    //{
    //    if (other.transform.tag == "Ground")
    //    {
    //        animator.SetBool("isGrounded", true);
    //        Debug.Log("on Ground");
    //        isGrounded = true;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.transform.tag == "Ground")
    //    {
    //        animator.SetBool("isGrounded", false);
    //        Debug.Log("In air");
    //        isGrounded = false;
    //        animator.SetTrigger("Jump");
    //    }
    //}

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (isDead == false)
        {
            PlayerMovement(horizontalInput);
            PlayerAnimation(horizontalInput);
        }

    }

    public void PlayerMovement(float horizontalInput)
    {
        rb2d.linearVelocity = new Vector2(horizontalInput * speed, rb2d.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jump);
        }
        if (Input.GetButtonUp("Jump") && rb2d.linearVelocity.y > 0f)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, rb2d.linearVelocity.y * -0.5f);
        }

    }

    private void MoveCharacter(float horizontal)
    {
        // Horizontal character movement
        Vector3 newPosition = transform.position;
        newPosition.x += horizontal * speed * Time.deltaTime;
        transform.position = newPosition;
    }

    private void PlayerAnimation(float horizontal)
    {
        //Horizontal animation
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        //Flipping the player
        Vector2 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            PlayCrouchAnimation(true);
        }
        else
        {
            PlayCrouchAnimation(false);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            PlayJumpAnimation();
        }
    }



    public void PlayCrouchAnimation(bool crouchValue)
    {
        if (crouchValue == true)
        {
            float offX = -0.12038f;
            float offY = 0.56309f;

            float sizeX = 0.91509f;
            float sizeY = 1.2508f;

            boxCol.size = new Vector2(sizeX, sizeY);
            boxCol.offset = new Vector2(offX, offY);
        }

        else
        {
            boxCol.size = boxColInitSize;
            boxCol.offset = boxColInitOffset;
        }

        animator.SetBool("Crouch", crouchValue);
    }

    public void PlayJumpAnimation()
    {
        animator.SetTrigger("Jump");
    }


    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void PickUpKey()
    {
        Debug.Log("Pick up the key");
        scoreController.IncreaseScore(10);
    }

    public int getPlayerLives()
    {
        return playerLives;
    }

    public void DecreaseHealth(int damageValue)
    {
        playerLives -= damageValue;
        CheckPlayerDeath();
    }

    public void CheckPlayerDeath()
    {
        if (playerLives < 1)
        {
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        Debug.Log("Kill Player");
        animator.SetTrigger("DeathTrigger");
        //gameOverController.PlayerDied();
        this.enabled = false;

        scoreController.ActivateGameOverPanel();
    }



    //public void Crouch(bool crouch)
    //{
    //    if (crouch == true)
    //    {
    //        float offX = -0.12038f;     //Offset X
    //        float offY = 0.56309f;      //Offset Y

    //        float sizeX = 0.91509f;     //Size X
    //        float sizeY = 1.2508f;     //Size Y

    //        boxCol.size = new Vector2(sizeX, sizeY);   //Setting the size of collider
    //        boxCol.offset = new Vector2(offX, offY);   //Setting the offset of collider
    //    }

    //    else
    //    {
    //        //Reset collider to initial values
    //        boxCol.size = boxColInitSize;
    //        boxCol.offset = boxColInitOffset;
    //    }

    //    //Play Crouch animation
    //    animator.SetBool("Crouch", crouch);
    //}



}







