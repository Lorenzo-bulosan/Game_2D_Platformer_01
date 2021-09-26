using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField]
    private float Speed = 13;
    private bool isHit;
    private float fireballSpeed;
    private float fireballDirection;
    private float lifetime;

    // animation parameters
    private string paramExplode = "explode";

    // references
    private Animator _animator;
    private BoxCollider2D _boxCollider;
    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    // so move fireball horizontally then when collision detected set explode trigger
    private void Update()
    {
        // detect hit
        if (isHit) return;

        // move fireball
        MoveFireball();

        // life of fireball
        lifetime += Time.deltaTime;
        if (lifetime > 5) gameObject.SetActive(false);
    }

    private void MoveFireball()
    {
        fireballSpeed = Speed * Time.deltaTime * fireballDirection;
        transform.Translate(fireballSpeed, 0, 0);
    }

    // check fireball collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isHit = true;
        _boxCollider.enabled = false;
        _animator.SetTrigger(paramExplode);
    }

    public void SetDirectionFireball(float directionSign)
    {
        // first reset attributes
        ResetFireball();

        // compare current facing direction with fireball direction and flips
        fireballDirection = directionSign;
        float localScaleX = transform.localScale.x;

        if (Mathf.Sign(localScaleX) != directionSign)
        {
            localScaleX = -localScaleX;
        }
        
        // make new vector
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void ResetFireball()
    {
        // reset attributes
        lifetime = 0;
        gameObject.SetActive(true);
        isHit = false;
        _boxCollider.enabled = true;
    }

    // function called on event of last animation of explosion 
    private void FiraballDeactivate()
    {
        gameObject.SetActive(false);
    }
}
