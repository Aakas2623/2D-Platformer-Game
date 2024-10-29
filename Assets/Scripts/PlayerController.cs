using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        float Speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(Speed));

        Vector3 scale = transform.localScale;
        if (Speed  < 0)
        {
            scale.x = -1f* Mathf.Abs(scale.x);
        }
        else if (Speed > 0) {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
}
