using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeControle : MonoBehaviour
{
    //Скрипт для метания ножа. Изначально думал сделать через ивенты, но там что-то пошло не по плану, а решение я нашел уже после
    public float Speed;

    private void OnMouseDown()
    {
        GetComponentInParent<Rigidbody>().AddForce(new Vector3(0, Speed, 0), ForceMode.Impulse);
    }
}
