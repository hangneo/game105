using UnityEngine;

public class AttackController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra xem đối tượng có tag là "Enemy" không
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Chém trúng: " + other.gameObject.name);
            // Xóa GameObject của quái vật ngay lập tức
            Destroy(other.gameObject);
        }
    }
}
