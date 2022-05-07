using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{

    private Animator anim;

    private CharacterSoundFX soundFX;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        soundFX = GetComponentInChildren<CharacterSoundFX>();
    }

    public void Walk(bool walk)
    {
        anim.SetBool("Walk", walk);
    }

    public void Defend(bool defend)
    {
        anim.SetBool("Defend", defend);
    }

    public void Attack1()
    {
        anim.SetTrigger("Attack1");
        soundFX.Attack1();
    }

    public void Attack2()
    {
        anim.SetTrigger("Attack2");
        soundFX.Attack2();
    }

    void FreezeAnimation()
    {
        anim.speed = 0f;
    }

    public void UnfreezeAnimation()
    {
        anim.speed = 1f;
    }
}
