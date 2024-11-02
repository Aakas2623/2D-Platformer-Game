using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public float speed;
    public float jump;

    private Rigidbody2D rb2d;
    
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
        if(vertical > 0)
        {
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
        
        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else 
        {
            animator.SetBool("Jump", false);
        }

    }

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





