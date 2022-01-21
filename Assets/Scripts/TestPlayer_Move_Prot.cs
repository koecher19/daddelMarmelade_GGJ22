using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer_Move_Prot : MonoBehaviour
{
    public int playerSpeed = 10;
    private bool facingRight = false;
    public int playerJumpPower = 1;
    private float moveX;
    public bool touchingObstacle; // is the palyer touching an obstacle or the ground?
    public SpriteRenderer spriteRenderer;
    // sprides for animations
    public Sprite[] sprites;


    // Start is called before the first frame update
    void Start()
    {
        // set spride renderer
        this.spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMove();
    }
    
    // check for collision with obstacles/ground and set touchingObstacles accordingly
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Ground")
        {
            touchingObstacle = true;
            // stop jumping animation
            changeSprite(this.sprites[0]);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Ground")
        {
            touchingObstacle = false;
        }
    }
    


    void playerMove()
    {
        // controls
        moveX = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && this.touchingObstacle)
        {
            jump();
        }
        // TODO: animations
        // player directions
        if (moveX < 0.0f && facingRight == false)
        {
            flipPlayer();
        }else if(moveX > 0.0f && facingRight == true)
        {
            flipPlayer();
        }
        // physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void jump()
    {
        // add upwards force
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        // change spride to jump
        changeSprite(this.sprites[1]);
    }

    void flipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void changeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }
}
