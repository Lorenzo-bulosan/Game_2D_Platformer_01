using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    // ref
    private Animator animator;

    [SerializeField]
    private float startingHealth = 3;
    public float CurrentHealth { get; private set; }
    public float TotalHealth { get; private set; }

    // sprite image contains 10 hearts
    private float spriteMaxImage = 10;


    // animation parameters
    private string paramHurt = "hurt";
    private string paramDeath = "death";

    // Start is called before the first frame update
    void Start()
    {
        // initial parameters
        TotalHealth = startingHealth;
        CurrentHealth = startingHealth;

        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DecreaseHealth(1);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            IncreaseHealth(1);
        }
    }

    public void DecreaseHealth(float damageTaken)
    {
        // Take damage but max out at 0hp and total hp
        CurrentHealth = CurrentHealth - damageTaken;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, TotalHealth);

        // full health
        if (CurrentHealth == TotalHealth)
        {
            // maybe add power only usable at full health
        }
        // hurt
        else if (CurrentHealth > 0 && CurrentHealth < TotalHealth)
        {
            animator.SetTrigger(paramHurt);
        }
        // dead
        else if (CurrentHealth <= 0)
        {
            OnPlayerDeath();
        }
    }

    public void IncreaseHealth(float acquiredHealth)
    {
        // clip on max out
        if (CurrentHealth == spriteMaxImage) return;

        // if full increase total and current
        if (CurrentHealth == TotalHealth)
        {
            TotalHealth += acquiredHealth;
        }

        CurrentHealth += acquiredHealth;
    }

    public void OnPlayerDeath()
    {
        animator.SetTrigger(paramDeath);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<PlayerController>().CanAttack = false;
    }
}
