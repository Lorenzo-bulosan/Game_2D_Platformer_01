using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    [SerializeField]
    private float startingHealth;
    public float CurrentHealth { get; private set; }
    public float TotalHealth { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        // initial parameterss
        startingHealth = 3;
        TotalHealth = startingHealth;
        CurrentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DecreaseHealth(1);
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
            
        }
        // dead
        else if (CurrentHealth <= 0)
        {
            OnPlayerDeath();
        }
    }

    public void OnPlayerDeath()
    {

    }
}
