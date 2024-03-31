using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Tank
{
    public int lives;
    public float moveSpeed = 20;
    //public float moveDistance = 1f;
    //public bool isMoving = false;
    public bool isFiring = false;
    public float rotationSpeed = 200;
    private Rigidbody2D rb;
    private bool canFire = true;
    //private bool canMove = true;
    private bool isRotating = false;

    private void Start()
    {
        hp = 3;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(InputControl());
    }

    private IEnumerator InputControl()
    {
        while (true) //while true (which is always true), loop repeats
        {
            float verticalVal = Input.GetAxis("Vertical");
            float horizontalVal = Input.GetAxis("Horizontal");

            if (horizontalVal != 0) //detect input and rotate the tank
            //if (!isFiring)
            {
                //Debug.Log(horizontalVal);
                isRotating = true;
                transform.Rotate(0, 0, -horizontalVal * rotationSpeed * Time.deltaTime);
            }
            else
            {
                isRotating = false;
            }

            if (!isRotating) //check rotation and vertical input to move the tank forward/backward
            {
                Vector2 movement = transform.up * verticalVal * moveSpeed * Time.deltaTime;
                rb.MovePosition(rb.position + movement);
            }

            if (Input.GetKeyDown(KeyCode.Space) && canFire) //press space to fire and start timer coroutine
            {
                //isFiring = true;
                Fire();
                canFire = false;
                StartCoroutine(FireTimer());
            }

            yield return null;
        }
    }

    private IEnumerator FireTimer() //fire timer .5 seconds
    {
        yield return new WaitForSeconds(0.5f);
        canFire = true;
        //isFiring = false;
    }

    public override void Fire()
    {
        base.Fire();
        //color sr change white
    }

    protected override void Die()
    {
        base.Die();
        //game over text or UI
        //
    }
}
