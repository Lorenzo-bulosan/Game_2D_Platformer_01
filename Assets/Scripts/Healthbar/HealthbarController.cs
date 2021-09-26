using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// healthbar object control to modify it depending on player health manager ref
public class HealthbarController : MonoBehaviour
{
    // refs
    [SerializeField] private PlayerHealthController player;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealth;

    private void Start()
    {
        // set image fill amount to start
        totalHealthBar.fillAmount = normalizeAmount(player.CurrentHealth);     
    }

    private void Update()
    {
        // change image fill amount to current health
        currentHealth.fillAmount = normalizeAmount(player.CurrentHealth);
        totalHealthBar.fillAmount = normalizeAmount(player.TotalHealth);
    }

    // will evolve into a more complex but for now sufficient
    private float normalizeAmount(float numberToNormalize)
    {
        return numberToNormalize / 10;
    }
}
