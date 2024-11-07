using UnityEngine;

public class Gold : MonoBehaviour
{
    public int goldValue = 1; // Số vàng mỗi lần nhặt được

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player")) // Kiểm tra nếu va chạm với Player
        {
            // Gọi hàm AddGold trong PlayerCtrl
            PlayerCtrl.instance.AddGold(goldValue);

            // Hủy đối tượng vàng sau khi nhặt
            Destroy(gameObject);
        }
    }
}
