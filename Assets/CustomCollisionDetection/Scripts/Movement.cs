using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float rotationSpeed = 200f;

    void Update()
    {
        base.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        base.transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
}
