using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển

    private Rigidbody2D rb; // Tham chiếu đến Rigidbody2D
    private Vector2 movement; // Lưu trữ hướng di chuyển
    private Animator animator; // Tham chiếu đến Animator
    public GameObject attackPos; //Tham chiếu đến vị trí tấn công

    // Start is called before the first frame update
    void Start()
    {
        // Lấy Rigidbody2D của đối tượng
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        attackPos.SetActive(false); // Đảm bảo AttackPos bắt đầu ở trạng thái không hoạt động
    }

    // Update is called once per frame
    void Update()
    {
        // Nhận đầu vào từ bàn phím
        movement.x = Input.GetAxis("Horizontal"); // Phím trái/phải
        movement.y = Input.GetAxis("Vertical");   // Phím lên/xuống

        // Normalize để đảm bảo tốc độ không vượt quá 1
        movement.Normalize();

        // Gọi hàm flip nếu cần thiết
        if (movement.x > 0)
        {
            Flip(false); // Quay phải
        }
        else if (movement.x < 0)
        {
            Flip(true); // Quay trái
        }

        // Cập nhật animation
        UpdateAnimation();

        // Xử lý các phím nhấn cho swing
        if (Input.GetKeyDown(KeyCode.P))
        {
            animator.SetTrigger("swing1");
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            animator.SetTrigger("swing2");
        }



    }

    void FixedUpdate()
    {
        // Sử dụng SetVelocity để di chuyển nhân vật
        rb.linearVelocity = movement * moveSpeed;
    }

    void Flip(bool facingLeft)
    {
        // Thay đổi scale của sprite để flip
        Vector3 theScale = transform.localScale;
        theScale.x = facingLeft ? -1 : 1; // Nếu quay trái, scale x là -1, ngược lại là 1
        transform.localScale = theScale;
    }

    void UpdateAnimation()
    {
        // Cập nhật trạng thái animation
        animator.SetBool("isRunning", movement != Vector2.zero);
    }

    //Thiết lập trạng thái tấn công
    public void EnableAttackPos()
    {
        attackPos.SetActive(true);
    }
    
    //Tắt trạng thái tấn công
    public void DisableAttackPos()
    {
        attackPos.SetActive(false);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Va chạm với: " + collision.gameObject.name);
    }
}
