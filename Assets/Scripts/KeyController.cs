using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playeController = collision.gameObject.GetComponent<PlayerController>();
            playeController.PickUpKey();
            Destroy(gameObject);
        }
    }
}
