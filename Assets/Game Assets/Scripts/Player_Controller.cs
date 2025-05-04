using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        Debug.Log("Player_Controller Awake");
    }

    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));

        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }
    }

    private void Jump()
    {
        animator.SetTrigger("Jump");
        Debug.Log("Player jumped");
    }

    private void Crouch()
    {
        animator.SetTrigger("Crouch");
        Debug.Log("Player crouched");
    }
}
