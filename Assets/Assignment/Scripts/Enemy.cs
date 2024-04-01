using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Tank
{
    //public float speed;
    //public int damage;
    public float rotationSpeed = 60;
    public float moveMinimum = 1;
    public float moveMaximum = 2;
    public float fireTimer = 1;

    private Rigidbody2D rb;

    private void Start()
    {
        hp = 2;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(EnemyAction()); //start the coroutine to make enemy move and shoot
    }

    public override void Fire() //fire bullet
    {
        base.Fire();
    }

    protected override void Die()
    {
        base.Die();
        Tank.Score(1); //update score when this tank is dead
    }

    private IEnumerator EnemyAction()
    {
        while (true) //while true = infinite loop, make enemy tank randomly rotate, wait, move, wait, and fire
        {
            randRotation();
            yield return new WaitForSeconds(1);

            moveRandDistance();
            yield return new WaitForSeconds(1);

            Fire();
            yield return new WaitForSeconds(fireTimer);
        }
    }

    private void randRotation()
    {
        float randomAngle = Random.Range(0f, 360); //roll the dice random angle between 0 ~ 360
        transform.rotation = Quaternion.Euler(0, 0, randomAngle); //setting rotation of the enemy
    }

    private void moveRandDistance()
    {
        float randDistance = Random.Range(moveMinimum, moveMaximum); //generate distance from specified range
        Vector2 movement = transform.up * randDistance; //calculate movement with forward force * distance
        rb.MovePosition(rb.position + movement); //move with calculated movement value
    }
}
