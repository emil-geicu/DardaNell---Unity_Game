using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Attack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs2;  
    private Animator anim;
    private Player2Movement playerMovement; 
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<Player2Movement>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.L) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");  
        cooldownTimer = 0;

        fireballs2[0].transform.position = firePoint.position;
        fireballs2[0].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    }    
}
