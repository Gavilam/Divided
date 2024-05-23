using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    private Vector2 direction;
    private Rigidbody2D rb;

    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (Input.GetKeyDown(KeyCode.Space)){
            Events.ChangeCharacter?.Invoke();
        }
    }

    private void FixedUpdate(){
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

    /**private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
            Rigidbody2D collRb2D = collision.gameObject.GetComponent<Rigidbody2D>();
            collRb2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }*/
}
