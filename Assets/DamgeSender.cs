using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamgeSender : MonoBehaviour
{
    public EnemyCtrl enemyCtrl; // Tham chiếu đến bộ điều khiển kẻ thù
    public string explosionEffectName = "Explosion_A"; // Tên của hiệu ứng nổ
    public LayerMask bombLayer;
    public PlayerCtrl playerCtrl;

    private void Awake()
    {
        this.enemyCtrl = GetComponent<EnemyCtrl>();
        this.playerCtrl = GetComponent<PlayerCtrl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu đối tượng va chạm nằm trên Layer "Bomb"
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bomb"))
        {
            SelfDestroy selfDestroy = collision.GetComponent<SelfDestroy>();
            if (selfDestroy != null)
            {
                selfDestroy.Destroy(); // Hủy đối tượng nếu có SelfDestroy
            }

            if (enemyCtrl != null && enemyCtrl.despawner != null)
            {
                this.enemyCtrl.despawner.Despawer(); // Sử dụng despawner để hủy đối tượng
            }
            else
            {
                Destroy(gameObject); // Hủy đối tượng (bom) sau va chạm
            }

            // Tạo hiệu ứng nổ tại vị trí va chạm
            EffectManager.instance.SpawnVFX(explosionEffectName, transform.position, transform.rotation);

            // Hủy bom sau khi va chạm với đối tượng thuộc Layer Bomb
            Destroy(gameObject); // Hủy bom sau khi hiệu ứng nổ
        }
        else if (collision.CompareTag("player"))
        {
            // Giả sử Player có component PlayerCtrl để quản lý máu
            PlayerCtrl player = collision.GetComponent<PlayerCtrl>();
            if (player != null && player.damgeReceiver != null)
            {
                // Player mất máu khi va chạm với enemy
                player.damgeReceiver.Receiver(1); // Gây sát thương cho player
              
                // Kiểm tra nếu Player còn sống
                if (!player.damgeReceiver.IsDead())
            
                // Enemy chết sau va chạm với Player
                if (enemyCtrl != null)
                {
                    enemyCtrl.despawner.Despawer(); // Gọi hàm despawner của enemy để hủy enemy
                }
                else
                {
                    Destroy(gameObject); // Nếu không có despawner, hủy enemy
                }

                // Tạo hiệu ứng nổ khi enemy chết
                EffectManager.instance.SpawnVFX(explosionEffectName, transform.position, transform.rotation);
            }
        }
    }
}
