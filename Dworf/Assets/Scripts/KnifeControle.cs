using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeControle : MonoBehaviour
{
    public float Speed;

    private void OnMouseDown()
    {
        GetComponentInParent<Rigidbody>().AddForce(new Vector3(0, Speed, 0), ForceMode.Impulse);
    }
}
