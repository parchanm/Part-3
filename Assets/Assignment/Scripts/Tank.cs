using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    protected static int score;
    protected int hp;
    public GameObject bulletPrefab;
    public SpriteRenderer sr;
    public float offset = 0.7f; //adjusting y value to avoid bullet collision during instantiating
    //more note: figured setting spawnPoint for tank's bullet using public transform wouldn't work because all tanks share same base.Fire();
    //protected Color startColor;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        //startColor = sr.color;
        score = 0;
    }
    public virtual void Fire() //call bullet function and instantiate the prefab when called
    {
        //ran into an issue where bullet hits its spawner's collider when instantiated
        Vector3 spawnPos = transform.position + transform.up * offset; //used this line of code to work with y coordinate values
        //GameObject bulletObject = Instantiate(bulletPrefab, transform.position, transform.rotation);
        GameObject bulletObject = Instantiate(bulletPrefab, spawnPos, transform.rotation);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.SetDirection(transform.up);
    }
    private void OnTriggerEnter2D(Collider2D other) //compare tags with ontriggerenter2d to detect tank, border, bullet
    {
        if (other.CompareTag("Bullet"))
        {
            if (hp <= 1)
            {
                Die();
            }
            TookDamage(1);
            Debug.Log(hp);
        }
        else if (other.CompareTag("Tank"))
        {
            if (hp <= 4)
            {
                Die();
            }
        }
        else if (other.CompareTag("HardWall"))
        {
            Die();
        }
    }

    public void TookDamage(int damage) //damage function
    {
        hp -= damage;
        StartCoroutine(Ouch());
    }

    protected virtual void Die() //protected virtual void Die for various functionality in each enemy and player tanks
    {
        StartCoroutine(Dying());
        //Destroy(gameObject);
    }
    private IEnumerator Ouch() //change color when taking damage, wait, go back to normal color
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        sr.color = Color.white;
        //sr.color = startColor;
    }

    private IEnumerator Dying() //make tank transparent when dying and destroy object
    {
        float fadeTime = 1;
        float timer = 0;
        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            float transparency = Mathf.Lerp(1, 0, timer / fadeTime); //interpolating transparancy
            sr.color = new Color(1, 1, 1, transparency); //apply interpolated transparency
            yield return null;
        }
        Destroy(gameObject);
    }

    public static void Score(int points) //count scores
    {
        score =+ points;
        Debug.Log("score is " + score);
    }
}
