using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f; // Tốc độ di chuyển
    public float moveInterval = 2f; // Thời gian giữa các lần di chuyển
    public Vector2 moveRange = new Vector2(10f, 10f); // Phạm vi di chuyển

    private Vector2 targetPosition;
    private Rigidbody2D rb;

    private bool facingRight = true; // Biến theo dõi hướng

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        SetRandomTargetPosition();
        InvokeRepeating("SetRandomTargetPosition", moveInterval, moveInterval);
    }

    // Update is called once per frame
    void Update()
    {
        // Tính toán hướng di chuyển
        Vector2 direction = (targetPosition - rb.position).normalized;

        // Cập nhật velocity
        rb.linearVelocity = direction * moveSpeed;

        // Kiểm tra nếu đã đến vị trí mục tiêu
        if (Vector2.Distance(rb.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }

        // Flip sprite nếu cần
        if (direction.x < 0 && facingRight)
        {
            Flip();
        }
        else if (direction.x > 0 && !facingRight)
        {
            Flip();
        }
    }

    void SetRandomTargetPosition()
    {
        // Tạo vị trí mục tiêu ngẫu nhiên trong phạm vi xác định
        float randomX = Random.Range(-moveRange.x / 2, moveRange.x / 2);
        float randomY = Random.Range(-moveRange.y / 2, moveRange.y / 2);
        targetPosition = new Vector2(randomX, randomY);
    }

    void Flip()
    {
        // Đảo ngược hướng nhân vật
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
