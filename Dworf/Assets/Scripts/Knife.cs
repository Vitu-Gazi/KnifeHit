using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    //Висит на сомом ноже для регистрации попаданий и прочего

    public float Speed;

    public delegate void KnifesDelegate();
    public static KnifesDelegate KnifesLose;
    public static KnifesDelegate OtherKnife;

    public static KnifesDelegate PlusApple;

    private void Start()
    {
        Vibration.Init();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Knife"))
        {
            KnifesLose();
        }
        else
        {
            Vibration.VibratePop();
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
