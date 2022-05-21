using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    private bool  isJumping, isPressingSpace;
    private float moveHorizontal;
    private float moveVertical;




    void Start()
    {
        PlayerPrefs.SetInt("Pos", 1);

        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();


        isJumping = false;
        isPressingSpace = false; 
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        //moveVertical = Input.GetAxisRaw("Vertical");


        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPressingSpace = true;
        }
    }

    void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            if (moveHorizontal > 0.1f)
            {
                sr.flipX = false;
                PlayerPrefs.SetInt("Pos", 1);
            }
            if (moveHorizontal < -0.1f)
            {
                sr.flipX = true;
                PlayerPrefs.SetInt("Pos", 0);
            }
            rb.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Force);
        }


        if (!isJumping && isPressingSpace)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
            isPressingSpace = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
        Debug.Log(collision.gameObject.tag);
    }
}
