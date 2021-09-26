using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    [SerializeField]
    private float startingHealth;
    private float totalHealth, currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        // initial parameterss
        startingHealth = 100;
        totalHealth = startingHealth;
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseHealth(float damageTaken)
    {
        // Take damage but max out at 0hp and total hp
        currentHealth = currentHealth - damageTaken;
        currentHealth = Mathf.Clamp(currentHealth, 0, totalHealth);

        if (currentHealth <= 0)
        {
            OnPlayerDeath();
        }
    }

    public void OnPlayerDeath()
    {

    }
}
