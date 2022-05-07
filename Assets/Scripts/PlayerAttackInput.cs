using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{

    private CharacterAnimations playerAnimation;

    private HealthScript healthScript;

    public GameObject attackPoint;

    private CharacterSoundFX soundFX;

    private void Awake()
    {
        playerAnimation = GetComponent<CharacterAnimations>();
        healthScript = GetComponent<HealthScript>();
        soundFX = GetComponentInChildren<CharacterSoundFX>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Random.Range(0, 2) > 0)
            {
                playerAnimation.Attack1();
                //soundFX.Attack1();
            }
            else
            {
                playerAnimation.Attack2();
                //soundFX.Attack2();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            playerAnimation.Defend(true);
            healthScript.shieldActivated = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            playerAnimation.UnfreezeAnimation();
            playerAnimation.Defend(false);
            healthScript.shieldActivated = false;
        }
    }

    void ActivateAttackPoint()
    {
        attackPoint.SetActive(true);
    }

    void DeactivateAttackPoint()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }

}
