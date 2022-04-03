using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{

    public float health = 30f;
    public bool isKnockbackable = true;
    public float knockbackSpeed = 5f;
    public bool knockbackPlayerOnHit = true;
    public float invulnerableTime = 0f;
    [SerializeField] private Rigidbody2D rb;
    public UnityEvent onDamaged;
    [SerializeField] bool destroyOnKilled = false;
    public UnityEvent onKilled;
    private float maxHealth;
    private bool isInvulnerable = false;
    [HideInInspector] public bool isDead { get; private set;} = false;

    private void Start() 
    {
        maxHealth = health;
    }

    public bool IsInvulnerable()
    {
        return isInvulnerable;
    }
    public void OnDamaged(float damage, GameObject damager)
    {
        if(isInvulnerable) return;
        health -= damage;
        onDamaged.Invoke();

        if(isKnockbackable && rb)
        {
            Vector2 knockbackVector = damager.transform.position - transform.position;

            rb.velocity = -knockbackVector.normalized * knockbackSpeed;
        }

        if(health <= 0 && !isDead) 
        {
            isDead = true;
            OnKilled();
        }
        else
        {
            StartCoroutine("InvulnerabilityCooldown");
        }
    }

    public void OnKilled()
    {
        onKilled.Invoke();
        if(destroyOnKilled) Destroy(gameObject);
    }

    public void Respawn()
    {
        isDead = false;
        health = maxHealth;
    }


    private IEnumerator InvulnerabilityCooldown()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerableTime);
        isInvulnerable = false;
    }
}
