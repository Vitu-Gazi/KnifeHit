using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalkScript : MonoBehaviour
{
    [SerializeField]
    Apple apple;

    int random;

    private void Start()
    {
        System.Random r = new System.Random();
        random = r.Next(-3, 3);
        if (random == 0)
        {
            random += 3;
        }
        CreateApple(gameObject, apple, apple.MaxNumber);
    }

    private void Update()
    {
        transform.rotation *= Quaternion.Euler(0, 0, random);
    }

    //Скрипт создающий яблоко
    void CreateApple(GameObject balk, Apple apple, int MaxNumber)
    {
        System.Random r = new System.Random();
        if (r.Next(0, MaxNumber) == 0)
        {
            Instantiate(apple.AppleObj, new Vector3(0, 3.36f, 0), new Quaternion()).transform.parent = gameObject.transform;
        }
    }


    //Коруина, хотелсделать через неё изменение вращения балки
    IEnumerator RotationTime ()
    {
        transform.rotation *= Quaternion.Euler(0, 0, random);
        yield return new WaitForSeconds(2);
        System.Random r = new System.Random();
        random = r.Next(-3, 3);
    }
}
