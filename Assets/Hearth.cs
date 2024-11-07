using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearth : DamgeReceiver
{
    public PlayerCtrl playerCtrl;
    public Sprite[] sprites;
    public UnityEngine.UI.Image imageHearth;
    private  void Awake()
    {
        this.playerCtrl = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerCtrl>();
    }
    public void FixedUpdate()
    {
        int hp = playerCtrl.damgeReceiver.hp;

        // Kiểm tra giá trị hp
        if (hp >= 0 && hp < sprites.Length)
        {
            imageHearth.sprite = sprites[hp];
        }
        else
        { 
            // Gán sprite mặc định hoặc xử lý khác
            imageHearth.sprite = sprites[0]; // hoặc sprite mặc định khác
        }
    }
}
