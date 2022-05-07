using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{

    public float health = 100f;
    private float xDeath = -90f;
    private float deathSmooth = 0.9f;
    private float rotateTime = 0.23f;
    private bool playerDied;

    [SerializeField]
    private Image healthBar;

    public bool isPlayer;

    [HideInInspector]
    public bool shieldActivated;

    private CharacterSoundFX soundFX;

    private void Awake()
    {
        soundFX = GetComponentInChildren<CharacterSoundFX>();
    }

    private void Update()
    {
        if (playerDied)
        {
            RotateAfterDeath();
        }
    }

    public void ApplyDamage(float damage)
    {
        if (shieldActivated)
        {
            return;
        }

        health -= damage;

        if (healthBar != null)
        {
            healthBar.fillAmount = health / 100f;
        }

        if (health <= 0)
        {
            soundFX.Die();

            GetComponent<Animator>().enabled = false;

            StartCoroutine(AllowRotate());

            if(isPlayer)
            {
                GetComponent<PlayerMove>().enabled = false;
                GetComponent<PlayerAttackInput>().enabled = false;

                Camera.main.transform.SetParent(null);
                GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>().enabled = false;
            }
            else
            {
                GetComponent<EnemyController>().enabled = false;
                GetComponent<NavMeshAgent>().enabled = false;

                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().enabled = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttackInput>().enabled = false;
            }
        }
    }

    void RotateAfterDeath()
    {
        transform.eulerAngles = new Vector3(
            Mathf.Lerp(transform.eulerAngles.x, xDeath, Time.deltaTime * deathSmooth), 
            transform.eulerAngles.y, 
            transform.eulerAngles.z
           );
    }
    IEnumerator AllowRotate()
    {
        playerDied = true;

        yield return new WaitForSeconds(rotateTime);

        playerDied = false;
    }

}
