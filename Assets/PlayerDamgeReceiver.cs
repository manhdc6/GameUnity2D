using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamgeReceiver : DamgeReceiver
{
    protected PlayerCtrl PlayerCtrl;
    private void Awake()
    {
        this.PlayerCtrl = GetComponent<PlayerCtrl>();
    }
    public override void Receiver(int damege)
    {
        base.Receiver(damege);
        if (this.IsDead())
        {
            this.PlayerCtrl.playerStatus.Dead();
            UIManager.instance.bnGameOver.SetActive(true);
        }
    }
}
