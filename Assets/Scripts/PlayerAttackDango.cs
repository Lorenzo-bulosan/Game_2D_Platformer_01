using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDango : MonoBehaviour
{
    // ref to game obj
    private Animator _animator;
    private PlayerController _playerController;
    private AudioSource _audioSource;

    [SerializeField]
    private Transform firePointOriginLocation;
    [SerializeField]
    private GameObject[] allFireballs;

    [SerializeField]
    private float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;
    private bool leftMouseClick;
   

    // animation parameters
    private string paramAttack = "attack";


    // on start
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        DetectInputAndAttack();
        cooldownTimer += Time.deltaTime; // track cooldown
    }

    private void DetectInputAndAttack()
    {
        leftMouseClick = Input.GetMouseButton(0);

        if (leftMouseClick==true && cooldownTimer > attackCooldown && _playerController.CanAttack())
        {
            Attack();
        }
    }

    private void Attack()
    {
        // reset timer every time you attack
        cooldownTimer = 0;
        _animator.SetTrigger(paramAttack);

        // pooling instead of instantiate/ destroy (because bad for performance) (instead activate and deactive to reuse)
        // 1) reset position of first projectile to origin
        allFireballs[FindFireball()].transform.position = firePointOriginLocation.position;
        // 2) get actual element and send it to correct direction
        float currentDirectionSign = Mathf.Sign(transform.localScale.x);
        allFireballs[FindFireball()].GetComponent<FireBall>().SetDirectionFireball(currentDirectionSign);

        // sound
        _audioSource.Play();
    }

    private int FindFireball()
    {
        for (int i = 0; i < allFireballs.Length; i++)
        {
            if (!allFireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
