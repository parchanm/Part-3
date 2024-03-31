using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    protected static int score;
    protected int hp;
    public GameObject bulletPrefab;
    public float offset = 0.7f; //adjusting y value to avoid bullet collision during instantiating
    //more note: figured setting spawnPoint for tanks using public transform wouldn't work because all tanks share same base.Fire();

    public virtual void Fire()
    {
        //ran into an issue where bullet hits its spawner's collider when instantiated
        Vector3 spawnPos = transform.position + transform.up * offset; //used this line of code to work with y coordinate values
        //GameObject bulletObject = Instantiate(bulletPrefab, transform.position, transform.rotation);
        GameObject bulletObject = Instantiate(bulletPrefab, spawnPos, transform.rotation);//
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.SetDirection(transform.up);
    }

    public void TookDamage(int damage) //damage function
    {
        hp -= damage; //placeholder for now
    }

    protected virtual void Die()
    {
        //placeholder for now
    }

    public static void Score(int points)
    {
        score =+ points;
        //placeholder for now
    }
}
