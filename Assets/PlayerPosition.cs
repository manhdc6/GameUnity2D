using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField]
    List<GameObject> minnions; // Tạo danh sách các minion
    public GameObject minionPrefab;
    protected float spawnDelay = 1f;

    private void Start()
    {
        this.minnions = new List<GameObject>(); // Khởi tạo danh sách
    }

    void Update()
    {
        // Kiểm tra nếu phím E được nhấn
        if (Input.GetKeyDown(KeyCode.E))
        {
            Spawn(); // Tạo minion khi nhấn phím E
        }
        CheckMinionDead(); // Kiểm tra minion đã chết
    }

    private void Spawn()
    {
        // Kiểm tra số lượng minion trước khi tạo
        if (this.minnions.Count >= 7) return;

        GameObject minion = Instantiate(this.minionPrefab); // Tạo minion mới
        minion.name = "Bom#" + (this.minnions.Count + 1); // Đặt tên cho minion

        minion.transform.position = this.transform.position; // Đặt vị trí cho minion
        minion.SetActive(true); // Kích hoạt minion
        this.minnions.Add(minion); // Thêm vào danh sách
    }

    void CheckMinionDead()
    {
        for (int i = this.minnions.Count - 1; i >= 0; i--) // Lặp từ cuối đến đầu
        {
            if (this.minnions[i] == null) // Nếu minion đã chết
            {
                this.minnions.RemoveAt(i); // Xóa minion khỏi danh sách
            }
        }
    }
}
