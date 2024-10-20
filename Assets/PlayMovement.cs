using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayMovement : MonoBehaviour
{
    public Animator animator;
    protected Rigidbody2D rb2d;

    [SerializeField]
    Collider2D standingCollider2D;
    [SerializeField]
    public Transform groundCheckCollider;
    public Transform overheadCheckCollider;
    [SerializeField] LayerMask groundLayer;

    public float groundCheckRadius = 0.2f;
    public float overheadCheckRadius = 0.2f;
    public Vector2 velocity = new Vector2(0f, 0f);
    public float pressHorizontal = 0f;
    public float crouchSpeedModifier = 0.5f;
    public float moveSpeed = 5;
    public float jumpPower = 5000f;
    public bool isGrounded;
    public bool jump;
    public bool fall; // Khai báo biến fall
    public bool isFacingRight = true;
    [SerializeField] public bool IsCrouch;

    // Khai báo biến trạng thái Idle
    public bool isIdle;

    private void Awake()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        // Lấy giá trị điều khiển từ người chơi
        this.pressHorizontal = Input.GetAxisRaw("Horizontal");

        // Kiểm tra xem người chơi có nhấn nhảy không
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jump = true;  // Đặt cờ jump thành true
             // Kích hoạt trạng thái nhảy trong Animator
        }

        // Kiểm tra trạng thái ngồi
        if (Input.GetButtonDown("Crouch"))
            IsCrouch = true;
        else if (Input.GetButtonUp("Crouch"))
            IsCrouch = false;
    }

    void FixedUpdate()
    {
        GroundCheck();
        Move(jump, IsCrouch);
    }

    void GroundCheck()
    {
        // Kiểm tra xem nhân vật có đang đứng trên mặt đất không
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        isGrounded = colliders.Length > 0;

        // Cập nhật trạng thái fall
        fall = !isGrounded && rb2d.velocity.y < 0; // Khởi tạo trạng thái rơi
        animator.SetBool("Fall", fall); // Cập nhật animator với trạng thái fall

        // Cập nhật trạng thái Idle nếu nhân vật đứng yên trên mặt đất
        if (isGrounded && Mathf.Abs(pressHorizontal) == 0)
        {
            isIdle = true; // Thiết lập trạng thái Idle
            animator.SetBool("Idle", true);  // Bật trạng thái "Idle"
        }
        else
        {
            isIdle = false; // Tắt trạng thái Idle
            animator.SetBool("Idle", false); // Tắt trạng thái "Idle" nếu nhân vật đang di chuyển
        }
    }

    protected virtual void Move(bool JumpFlag, bool CrouchFlag)
    {
        #region Jump & Crouch
        // Kiểm tra nếu có vật trên đầu và không thể đứng dậy
        if (!CrouchFlag)
        {
            if (Physics2D.OverlapCircle(overheadCheckCollider.position, overheadCheckRadius, groundLayer))
                CrouchFlag = true;
        }

        if (isGrounded)
        {
            standingCollider2D.enabled = !CrouchFlag;

            if (JumpFlag)
            {
                isGrounded = false;
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0); // Reset vận tốc Y trước khi nhảy
                rb2d.AddForce(new Vector2(0f, jumpPower));
                animator.SetTrigger("Jump");
                jump = false; // Đặt lại trạng thái nhảy sau khi nhảy
                animator.SetTrigger("Jump");
            }
        }

        animator.SetBool("Crouch", CrouchFlag);
        #endregion

        #region Run & Fall Movement
        // Xử lý di chuyển
        this.velocity.x = this.pressHorizontal * this.moveSpeed;
        if (CrouchFlag)
            velocity.x *= crouchSpeedModifier;

        // Kiểm tra nếu nhân vật đang rơi, vẫn giữ lại vận tốc ngang
        if (!isGrounded && fall)
        {
            // Giữ lại vận tốc ngang trong khi rơi
            rb2d.velocity = new Vector2(pressHorizontal * moveSpeed, rb2d.velocity.y);
        }
        else if (isGrounded) // Khi tiếp đất, nhân vật sẽ tiếp tục di chuyển
        {
            rb2d.MovePosition(rb2d.position + this.velocity * Time.fixedDeltaTime);
        }

        // Đổi hướng nhân vật
        if (this.isFacingRight && this.pressHorizontal < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            isFacingRight = false;
        }
        else if (!this.isFacingRight && this.pressHorizontal > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            isFacingRight = true;
        }

        // Cập nhật animator với chuyển động
        animator.SetFloat("Movement", Mathf.Abs(pressHorizontal));
        #endregion
    }
}