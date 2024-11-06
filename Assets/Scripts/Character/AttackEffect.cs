using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Gọi hàm Destroy sau 0.2 giây
        Destroy(gameObject, 0.2f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu đối tượng va chạm có tag là "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // Hủy đối tượng Enemy
            Destroy(other.gameObject, 0.05f);

            // Hủy hiệu ứng tấn công sau khi va chạm (nếu bạn muốn)
            Destroy(gameObject, 0.05f);
        }
    }
}
