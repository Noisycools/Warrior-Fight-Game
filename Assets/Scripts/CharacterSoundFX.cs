using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundFX : MonoBehaviour
{

    private AudioSource soundFX;

    [SerializeField]
    private AudioClip attackSound1, attackSound2, dieSound;

    private void Awake()
    {
        soundFX = GetComponent<AudioSource>();
    }

    public void Attack1()
    {
        if (!soundFX.isPlaying)
        {
            soundFX.clip = attackSound1;
            soundFX.Play();
        }
    }

    public void Attack2()
    {
        if (!soundFX.isPlaying)
        {
            soundFX.clip = attackSound2;
            soundFX.Play();
        }
    }

    public void Die()
    {
        soundFX.clip = dieSound;
        soundFX.Play();
    }

}
