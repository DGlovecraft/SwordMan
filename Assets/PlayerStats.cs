using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float health;
    private bool canTakeDamage = true;
    private Animator animator;
    private LogicScript logicScript;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        animator = GetComponentInParent<Animator>();
        logicScript= Object.FindFirstObjectByType<LogicScript>();
        logicScript.UpdatePlayerHP(health);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(float damage)
    {
        if (!canTakeDamage)
        return;

    health -= damage;
    animator.SetBool("Damage", true);
    logicScript.UpdatePlayerHP(health);

    if (health <= 0)
    {
        animator.SetBool("dead", true);
        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponentInParent<GatherInput>().OnDisable();
        Debug.Log("Player is dead");

        logicScript.ShowGameOver(); // <<-- เรียก GameOver
    }
    StartCoroutine(DamagePrevention());
    }
    private IEnumerator DamagePrevention()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.15f);
        if (health > 0)
        {
            canTakeDamage = true;
            animator.SetBool("Damage", false);
        }
        else
        {
            animator.SetBool("Damage", true);
        }
    }
}
