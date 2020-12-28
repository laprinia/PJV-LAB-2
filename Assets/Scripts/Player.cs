using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Healthbar Healthbar;
    public Animator Animator;

    private void Start()
    {
        currentHealth = maxHealth;
        Healthbar.SetMaximumHealth(maxHealth);
    }

    IEnumerator AnimationDisableCoroutine()
    {
        yield return new WaitForSeconds(0.8f);
        Animator.SetBool("hurt", false);
    }

    void TakeDamage(int damage)
    {
        Animator.SetBool("hurt", true);
        currentHealth -= damage;
        Healthbar.SetHealth(currentHealth);
        StartCoroutine(AnimationDisableCoroutine());
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.name.Equals("Minotaur"))
        {
            TakeDamage(10);
            ScoreScript.scoreValue += 1;
        }else if (collider.gameObject.name.Equals("Projectile(Clone)"))
        {
            TakeDamage(5);
            Destroy(collider.gameObject);
        }else if (collider.gameObject.name.Equals("Fire Elemental"))
        {
            ScoreScript.scoreValue += 1;
        }else if (collider.gameObject.tag.Equals("Golem"))
        {
            ScoreScript.scoreValue += 1;
            if (collider.gameObject.GetComponent<PeacefulEnemyScript>() != null)
            { 
                StartCoroutine(collider.gameObject.GetComponent<PeacefulEnemyScript>().DeathCoroutine());
            }
            
        }
    }
}
