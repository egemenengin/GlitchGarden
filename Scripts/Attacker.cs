// Egemen Engin 
// https://github.com/egemenengin

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 1;
    Animator anim;

    [Header("HEALTH")]
    [SerializeField] float healthOfAttacker = 100f;
    [SerializeField] GameObject deathVFX;


    GameObject currentTarget;
    
    private void OnDestroy()
    {
        if(FindObjectOfType<LevelController>())
          FindObjectOfType<LevelController>().AttackerKilled();
    }
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }


    void Update()
    {
        
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime); //walking trough left 
        UpdateAnimationState();

    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("isAttacking", true);

        }
    }

    public void setMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }
    public void dealDamage(float damage)
    {
        healthOfAttacker -= damage;
        if(healthOfAttacker <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }
    private void TriggerDeathVFX()
    {
        if (!deathVFX)
        {
            return;
        }
        else
        {
            GameObject deathVFCObject=Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(deathVFCObject,1f);
        }
    }
    public void targetLocated(GameObject target)
    {       
        currentTarget = target;
    }
    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget)
        {
            return;
        }
        Defender def = currentTarget.GetComponent<Defender>();
        if (def)
        {
            def.dealDamage(damage);
        }
        
    }
}
