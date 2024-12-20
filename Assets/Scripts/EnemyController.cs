using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private Animator enemyAnimator;

    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject groundDetector;
    [SerializeField] private float rayDistance;

    private int directionChanger = 1;



    void Update()
    {
        patrolEnemy();
    }

    private void patrolEnemy()
    {
        enemyAnimator.SetBool("IsPatrol", true);

        transform.Translate(directionChanger * Vector2.right * moveSpeed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(groundDetector.transform.position, Vector2.down, rayDistance);

        if (!hit)
        {
            Vector3 scaleVector = transform.localScale;
            scaleVector.x *= -1;
            transform.localScale = scaleVector;
            directionChanger *= -1;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.GetComponent<PlayerController>() != null)
    //    {
    //        PlayerController playeController = collision.gameObject.GetComponent<PlayerController>();
    //        playeController.DecreaseHealth(1);
    //        //playeController.KillPlayer();
            
    //    }
        private void OnCollisionEnter2D(Collision2D other)
        {
            PlayerController playerObject = other.gameObject.GetComponent<PlayerController>();

            if (playerObject != null)
            {
                playerObject.DecreaseHealth(1);
            }
        }


    
}
