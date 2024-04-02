using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : Tank
{
    //public int lives;
    public float moveSpeed = 20;
    //public float moveDistance = 1f;
    //public bool isMoving = false;
    public bool isFiring = false;
    public float rotationSpeed = 200;
    private Rigidbody2D rb;
    private bool canFire = true;
    //private bool canMove = true;
    private bool isRotating = false;
    //public SpriteRenderer sr;
    //public TextMeshProUGUI loseText;

    private void Start()
    {
        hp = 3;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(InputControl());

        //sr = GetComponent<SpriteRenderer>();
        //startColor = sr.color;
    }
    private void Update()
    {
        YouLost();
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

    public override void Fire() //call fire from tank parent class
    {
        base.Fire();

    }

    protected override void Die() //call die function and turn player dead check bool on
    {
        base.Die();
        playerDed = true;
    }

    public void YouLost() //check if player's dead and show game over text when player's dead
    {
        if (endGameText != null)
        {
            if (playerDed == true)
            {
                endGameText.text = "Game Over";
            }
        }
    }
}
