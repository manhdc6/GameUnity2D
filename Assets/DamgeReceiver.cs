using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgeReceiver : MonoBehaviour
{
    [SerializeField]
    public int hp = 2; // Đảm bảo lượng máu ban đầu đủ lớn

    // Kiểm tra nếu đối tượng đã chết
    public virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    // Nhận sát thương
    public virtual void Receiver(int damage)
    {
        this.hp -= damage;
        // Kiểm tra nếu đối tượng đã chết sau khi nhận sát thương
        if (IsDead())
        {
            Die(); // Nếu máu <= 0, gọi hàm Die()
        }
    }

    // Hành động khi đối tượng chết
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
