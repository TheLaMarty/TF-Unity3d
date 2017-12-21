using UnityEngine;

public class LivingEntity : MonoBehaviour, IInjurable {

    public float StartingHealth;
    protected float health;
    protected bool dead;

    protected virtual void Start()
    {
        health = StartingHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0 && !dead)
        {
            Die();
        }
            
    }

    public virtual void TakeHit(float damage, Vector3 hitPoint, Vector3 hitDirection){
        TakeDamage(damage);
    }

    protected void Die()
    {
        dead = true;
        Destroy(gameObject);
    }

}
