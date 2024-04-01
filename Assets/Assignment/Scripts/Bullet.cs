using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10;
    //public Transform spawnPoint;
    private Rigidbody2D rb;
    //public GameObject owner;
    //private string ownerTag;
    private bool isMoving = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Move());
        StartCoroutine(BulletTimer());
    }

    private IEnumerator Move() //movement coroutine
    {
        isMoving = true;
        while (isMoving)
        {
            Vector2 movement = transform.up * bulletSpeed * Time.deltaTime; //speed and transform upwards
            rb.position += movement;
            yield return null;
        }
    }
    public void SetDirection(Vector2 direction) //bullet direction
    {
        transform.up = direction.normalized; //setting upward direction into normalized one
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (owner != null && other.gameObject == owner)
        //    return;
        if (other.CompareTag("Wall")) //using comparetag for different bullet reaction
        {
            Reflect();
        }
        else if (other.CompareTag("HardWall"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Block"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Tank"))
        {
            //Tank tank = other.gameObject.GetComponent<Tank>();
            //if (tank != null)
            //{
            //    tank.TookDamage(1); //bullet damage 1
            //    //Debug.Log("Tank took damage");
            //}
            Destroy(gameObject);
        }
    }

    private void Reflect()
    {
        transform.Rotate(0, 0, 180);//reverse direction
    }

    private IEnumerator BulletTimer()
    {
        yield return new WaitForSeconds(2); //destroy after 2 seconds
        Destroy(gameObject);
    }
}
