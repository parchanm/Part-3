using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building : MonoBehaviour
{
    public Transform buildingTf;
    public Transform buildingTf2;
    public Transform buildingTf3;

    public float time = 0;
    public float timerSpeed = 0.2f;

    //Coroutine startBuilding;

    void Start()
    {
        buildingTf.transform.localScale = new Vector3(1, 0, 0);
        buildingTf2.transform.localScale = new Vector3(1, 0, 0);
        buildingTf3.transform.localScale = new Vector3(1, 0, 0);

        StartCoroutine(BuildingCoroutine());
    }

    IEnumerator BuildingCoroutine()
    {
        while (buildingTf3.transform.localScale.y < 1)
        {
            buildingTf.transform.localScale = Vector3.Lerp(new Vector3(1, 0, 0), new Vector3(1, 1, 0), time);
            yield return new WaitForSeconds(0.3f);
            buildingTf2.transform.localScale = Vector3.Lerp(new Vector3(1, 0, 0), new Vector3(1, 1, 0), time);
            yield return new WaitForSeconds(0.3f);
            buildingTf3.transform.localScale = Vector3.Lerp(new Vector3(1, 0, 0), new Vector3(1, 1, 0), time);
            time += timerSpeed;
            yield return null;
        }
        time = 0;
        //yield return new WaitForSeconds(0.1f);
        //Instantiate(buildingPrefab);
        //yield return new WaitForSeconds(1f);
        //Instantiate(buildingPrefab2);
        //yield return new WaitForSeconds(1f);
        //Instantiate(buildingPrefab3);
    }
}
