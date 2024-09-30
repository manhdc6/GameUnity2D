using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayMovement : MonoBehaviour
{   
    public Animator animator;
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
        this.velocity.x = this.pressHorizontal * this.moveSpeed;

        // Kiểm tra xem có cần quay hướng nhân vật không
        if (this.IsFacingRight && this.pressHorizontal < 0)
        {
            // Quay hướng nhân vật sang trái
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            IsFacingRight = false;
        }
        else if (!this.IsFacingRight && this.pressHorizontal > 0)
        {
            // Quay hướng nhân vật sang phải
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            IsFacingRight = true;
        }

        this.velocity.y = this.pressVertical * this.moveSpeed;
        this.rb2d.MovePosition(this.rb2d.position + this.velocity * Time.fixedDeltaTime);
        animator.SetFloat("Movement", Mathf.Abs(pressHorizontal));
    }
}
