using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamgeReceiver : DamgeReceiver
{
    protected PlayerCtrl PlayerCtrl;
    private AudioSource audioSource;        // Reference to the AudioSource
    public AudioClip damageSound;           // Sound effect for taking damage
    private void Awake()
    {
        this.PlayerCtrl = GetComponent<PlayerCtrl>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }
    public override void Receiver(int damege)
    {
        if (damageSound != null) // Ensure damageSound is assigned
        {
            audioSource.PlayOneShot(damageSound); // Play damage sound effect immediately
        }
        base.Receiver(damege);// Play damage sound effect
        if (this.IsDead())
        {
            this.PlayerCtrl.playerStatus.Dead();
            UIManager.instance.bnGameOver.SetActive(true);
        }

    }
}
