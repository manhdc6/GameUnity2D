using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayMovement : MonoBehaviour
{
    protected Rigidbody2D rb2d;
    public Vector2 velocity = new Vector2(0f,0f);
    public float pressHorizontal = 0f;
    public float pressVertical = 0f;
    public float moveSpeed = 5f;  // Tốc độ di chuyển
    public bool IsFacingRight = true;
    private void Awake()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        this.pressHorizontal = Input.GetAxis("Horizontal");
        this.pressVertical = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        this.UpdateSpeed();
    }
    protected virtual void UpdateSpeed()
    {
        this.velocity.x = this.pressHorizontal*this.moveSpeed;
        if (this.IsFacingRight == false && this.pressHorizontal == 4)
        {
            transform.localScale = new Vector3(4, 3, 1);
        }
        this.velocity.y = this.pressVertical * this.moveSpeed;
        this.rb2d.MovePosition(this.rb2d.position+this.velocity * Time.fixedDeltaTime);
        
    }
}
