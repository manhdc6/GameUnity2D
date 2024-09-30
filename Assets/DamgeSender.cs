using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamgeSender : MonoBehaviour
{
    public EnemyCtrl enemyCtrl;
    private void Awake()
    {
        this.enemyCtrl = GetComponent<EnemyCtrl>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamgeReceiver damgeReceiver = collision.GetComponent<DamgeReceiver>();
        if (damgeReceiver != null)
            damgeReceiver.Receiver(1);
        SelfDestroy selfDestroy = collision.GetComponent<SelfDestroy>();

        if (selfDestroy != null)
            selfDestroy.Destroy();

        if (enemyCtrl != null && enemyCtrl.despawner != null)
            this.enemyCtrl.despawner.Despawer();
        else
            Destroy(gameObject);
    }
}

