using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    protected float speed = 5f;
    protected float disLimit = 0.65f;

    void Start()
    {
        InvokeRepeating("Follow", 3f, Time.deltaTime);
    }

    void Update()
    {
        this.Follow();
    }

    void Follow()
    {
        // Kiểm tra nếu đối tượng player đã bị phá hủy hoặc null
        if (player == null)
        {
            return; // Thoát khỏi hàm nếu player không còn tồn tại
        }

        Vector3 distance = this.player.position - transform.position;

        if (distance.magnitude >= this.disLimit)
        {
            Vector3 targetPoint = this.player.position - distance.normalized * this.disLimit;

            gameObject.transform.position =
                Vector3.MoveTowards(gameObject.transform.position, targetPoint, this.speed * Time.deltaTime);
        }
    }
}
