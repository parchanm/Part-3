using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public GameObject daggerPrefab;
    public Transform spawnPoint;
    public Transform spawnPoint2;
    public float dashSpeed = 1;

    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }

    /*protected override void Update()
    {
        base.Update();
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePos - (Vector2)transform.position);
            rb.velocity = direction * dashSpeed;
        }
    }*/

    protected override void Attack()
    {
        destination = transform.position;
        base.Attack();

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - (Vector2)transform.position;
        rb.position = rb.position + direction.normalized * dashSpeed;

        Instantiate(daggerPrefab, spawnPoint.position, spawnPoint.rotation);
        Instantiate(daggerPrefab, spawnPoint2.position, spawnPoint2.rotation);
    }
}
