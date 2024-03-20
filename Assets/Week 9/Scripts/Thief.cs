using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public GameObject knifePrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public float dashSpeed = 7;
    Coroutine dashing;

    protected override void Attack()
    {
        //dash towards mouse
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(dashing != null ) // doing this to initiate one coroutine at a time
        {
            StopCoroutine(dashing);
            StopAllCoroutines(); //nuclear option to stop all coroutines
        }
        dashing = StartCoroutine(Dash());
        //StartCoroutine(Dash());
        //StartCoroutine("Dash"); // this works too
    }
    IEnumerator Dash()
    {//watch out for the spelling IEnumerator -> this is for Coroutine
        speed += dashSpeed;
        while (speed > 3)
        {
            yield return null; //return the code while . . .
        }
        base.Attack();
        yield return new WaitForSeconds(0.1f); //wait for 0.1 seconds
        Instantiate(knifePrefab, spawnPoint1.position, spawnPoint1.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(knifePrefab, spawnPoint2.position, spawnPoint2.rotation);

    }
    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }
}
