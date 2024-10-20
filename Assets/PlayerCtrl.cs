using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    static public PlayerCtrl instance;
    public DamgeReceiver damgeReceiver;
    public PlayerStatus playerStatus;
    private void Awake()
    {
        PlayerCtrl.instance = this;
        this.damgeReceiver = GetComponent<DamgeReceiver>();
        this.playerStatus = GetComponent<PlayerStatus>();
    }
}   
