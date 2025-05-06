using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Animator animator;

    public float speed;
    private Rigidbody2D rb2d;
    public float jump;

    private void Awake()
    {
        Debug.Log("Player_Controller Awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        //SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        bool isCrouching = Input.GetKey(KeyCode.LeftControl);
        MoveCharacter(horizontal, vertical, isCrouching);
        PlayMovementAnimation(horizontal, vertical, isCrouching);
    }
    private void MoveCharacter(float horizontal, float vertical, bool isCrouching)
    {
        // Move the character horizontally
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        // Move the character vertically
        if (vertical > 0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }

       
        if (isCrouching)
        {
            speed *= 0.5f;
        }
    }

    private void PlayMovementAnimation(float horizontal, float vertical, bool isCrouching)
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

        // Jump Animation
        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        // Crouch Animation
        animator.SetBool("Crouch", isCrouching);
    }
}

