using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    private Vector2 direction;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        UpdateAnimation();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Events.ChangeCharacter?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

    private void UpdateAnimation()
    {
        if(direction == Vector2.zero)
        {
            animator.SetBool("Walking_up", false);
            animator.SetBool("Walking_down", false);
            animator.SetBool("Walking_right", false);
            animator.SetBool("Walking_left", false);
            animator.SetBool("Idle", true);
            return;
        }

        if (direction.y > 0)
        {
            animator.SetBool("Walking_up", true);
            animator.SetBool("Walking_down", false);
            animator.SetBool("Walking_right", false);
            animator.SetBool("Walking_left", false);
            animator.SetBool("Idle", false);
        }
        else if (direction.y < 0)
        {
            animator.SetBool("Walking_up", false);
            animator.SetBool("Walking_down", true);
            animator.SetBool("Walking_right", false);
            animator.SetBool("Walking_left", false);
            animator.SetBool("Idle", false);
        }

        if (direction.x > 0)
        {
            animator.SetBool("Walking_up", false);
            animator.SetBool("Walking_down", false);
            animator.SetBool("Walking_right", true);
            animator.SetBool("Walking_left", false);
            animator.SetBool("Idle", false);
        }
        else if (direction.x < 0)
        {
            animator.SetBool("Walking_up", false);
            animator.SetBool("Walking_down", false);
            animator.SetBool("Walking_right", false);
            animator.SetBool("Walking_left", true);
            animator.SetBool("Idle", false);
        }
    }

    /**private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
            Rigidbody2D collRb2D = collision.gameObject.GetComponent<Rigidbody2D>();
            collRb2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }*/
}
