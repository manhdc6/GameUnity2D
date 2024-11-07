using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;    // Prefab của Enemy
    [SerializeField] private GameObject enemyPrefab1;   // Prefab của Enemy1
    [SerializeField] private Transform enemySpawnPoint; // Vị trí spawn cho EnemyPrefab
    [SerializeField] private Transform treeHouseSpawnPoint; // Vị trí spawn cho EnemyPrefab1
    private float timer = 0;
    private float delay = 2f;
    public Transform player; // Tham chiếu đến Player

    private void Awake()
    {
        // Vô hiệu hóa prefab ban đầu nếu cần thiết
        if (enemyPrefab != null) enemyPrefab.SetActive(false);
        if (enemyPrefab1 != null) enemyPrefab1.SetActive(false);
    }

    private void Update()
    {
        this.Spawn();
    }

    protected virtual void Spawn()
    {
        if (PlayerCtrl.instance.damgeReceiver.IsDead()) return;

        this.timer += Time.deltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0;

        // Tạo EnemyPrefab tại vị trí enemySpawnPoint
        if (enemyPrefab != null && enemySpawnPoint != null)
        {
            GameObject enemy = Instantiate(this.enemyPrefab, enemySpawnPoint.position, this.enemyPrefab.transform.rotation);
            enemy.SetActive(true);
        }

        // Tạo EnemyPrefab1 tại vị trí treeHouseSpawnPoint với rotation của prefab
        if (enemyPrefab1 != null && treeHouseSpawnPoint != null)
        {
            GameObject enemy1 = Instantiate(this.enemyPrefab1, treeHouseSpawnPoint.position, this.enemyPrefab1.transform.rotation);
            enemy1.SetActive(true);
        }
    }
}
