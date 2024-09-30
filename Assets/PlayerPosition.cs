using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField]
   
    List<GameObject> minnions;//Tao
    public GameObject minionPrefab;
    protected float spawnTimer = 0f;
    protected float spawnDelay = 1f;
    private void Start()
    {
        this.minnions = new List<GameObject>(); // Khoi tao

    }
    void Update()
    {
    
        this.Spawn();
        this.CheckMinionDead();
    }
    private void Spawn()
    {
        this.spawnTimer += Time.deltaTime;
        if (this.spawnTimer < this.spawnDelay) return;

            this.spawnTimer = 0;

        if (this.minnions.Count >= 7) return;
        
        int index = this.minnions.Count + 1;
        GameObject minion = Instantiate(this.minionPrefab);
        minion.name = "Bom#" + index;

        minion.transform.position = this.transform.position;
        minion.gameObject.SetActive(true);
        this.minnions.Add(minion);
    }
    void CheckMinionDead()
    {
        GameObject minion;
        for(int i = 0; i < this.minnions.Count; i++)
        {
            minion = this.minnions[i];
            if(minion==null) this.minnions.RemoveAt(i);
        }
    }
}
