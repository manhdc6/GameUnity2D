using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgeReceiver : MonoBehaviour
{
    [SerializeField]
    public  int hp = 2;
    public virtual bool IsDead()
    {
        return this.hp <= 0;
    }
    public virtual void Receiver(int damege)
    {
        this.hp -= damege;
    }
}
