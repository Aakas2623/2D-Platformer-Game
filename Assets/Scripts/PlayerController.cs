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

    private bool isGrounded = false;

    //[SerializeField] private SpriteRenderer[] hearts;
    //[SerializeField] private GameObject deathUIPanel;
    //[SerializeField] private CanvasRenderer[] hearts;

    //private int health;
    private Camera mainCamera;

    //private bool isDead = false;

    //private bool playerJumpRequest = false;

    //public Vector2 boxSize;
    //public float castDistance;
    //public LayerMask groundLayer;

    /*private BoxCollider2D boxCol;
    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;*/

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*void Start()
    {
        //Fetching initial collider properties
        boxColInitSize = boxCol.size;
        boxColInitOffset = boxCol.offset;
    }*/

    // Update is called once per frame

   // private void Start()
    //{
    //    //Initializing health with the number of hearts
    //    health = hearts.Length;

        //mainCamera = Camera.main;
    //}
    //public void DecreaseHealth()
    //{
    //    health--;

    //    HandleHealthUI();
    //    if (health <= 0)
    //    {
    //        PlayDeathAnimation();
    //        PlayerDeath();
    //    }
    //}

    //public void PlayerDeath()
    //{
    //    isDead = true;
    //    mainCamera.transform.parent = null;
    //    deathUIPanel.gameObject.SetActive(true);
    //    rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
    //    ReloadLevel();
    //}

    //public void PlayDeathAnimation()
    //{
    //    animator.SetTrigger("Die");
    //}

    //private void ReloadLevel()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}

    //public void HandleHealthUI()
    //{
    //    for (int i = 0; i < hearts.Length; i++)
    //    {
    //        hearts[i].color = (i < health) ? Color.red : Color.black;
    //    }
    //}

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        MoveCharacter(horizontal, vertical);
        PlayMovementAnimation(horizontal, vertical);

        /*float VerticalInput = Input.GetAxis("Vertical");

        PlayJumpAnimation(VerticalInput);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch(true);
        }
        else
        {
            Crouch(false);
        }*/

    }

   

    private void MoveCharacter(float horizontal, float vertical)
    {
        //move player hoizonatlly
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //move player vertically
        if (vertical > 0 && isGrounded)
        {
            Debug.Log(vertical);
            animator.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }

    }

    private void PlayMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //Jump


        //if (vertical > 0)
        //{
        //    animator.SetTrigger("Jump");
        //}
        //else
        //{
        //    animator.SetTrigger("Jump");
        //}


    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    public void PickUpKey()
    {
        Debug.Log("Pick up the key");
        scoreController.IncreaseScore(10);
    }

    public void KillPlayer()
    {
        Debug.Log("Kill Player");
        animator.SetTrigger("DeathTrigger");
        //Destroy(gameObject);
        gameOverController.PlayerDied();
        this.enabled = false;
        //ReloadLevel();
    }

    public void MoveToNextlevel()
    {
        Debug.Log("n");
        gameOverController.NextLevel();
        this.enabled = true;
    }

    //private void ReloadLevel()
    //{
    //    SceneManager.LoadScene(0);
    //}

    /*public void Crouch(bool crouch)
    {
        if (crouch == true)
        {
            float offX = -0.12038f;     //Offset X
            float offY = 0.56309f;      //Offset Y

            float sizeX = 0.91509f;     //Size X
            float sizeY = 1.2508f;     //Size Y

            boxCol.size = new Vector2(sizeX, sizeY);   //Setting the size of collider
            boxCol.offset = new Vector2(offX, offY);   //Setting the offset of collider
        }

        else
        {
            //Reset collider to initial values
            boxCol.size = boxColInitSize;
            boxCol.offset = boxColInitOffset;
        }

        //Play Crouch animation
        animator.SetBool("Crouch", crouch);
    }


    public void PlayJumpAnimation(float vertical)
    {
        if (vertical > 0)
        {
            animator.SetTrigger("Jump");
        }
    }*/



}





