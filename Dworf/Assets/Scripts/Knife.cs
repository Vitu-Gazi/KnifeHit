using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float Speed;

    public delegate void KnifesDelegate();
    public static KnifesDelegate KnifesLose;
    public static KnifesDelegate OtherKnife;

    public static KnifesDelegate PlusApple;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Knife"))
        {
            KnifesLose();
        }
        else if (collision.gameObject.CompareTag("Apple"))
        {
            PlusApple();
        }
        else
        {
            Handheld.Vibrate();
            gameObject.transform.parent = collision.gameObject.transform;
            Destroy(GetComponentInChildren<KnifeControle>().gameObject);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            OtherKnife();
            collision.gameObject.GetComponent<Animation>().Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            PlusApple();
            other.transform.parent = null;
            Destroy(other);
            other.gameObject.AddComponent<Rigidbody>();
        }
    }
}
