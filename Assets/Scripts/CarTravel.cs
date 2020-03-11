using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarTravel : MonoBehaviour
{
    Rigidbody rb;

    public float speed = 100;
    public float timeToDie = 10;
    private Vector3 initialPos;

    private void Start()
    {
        initialPos = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
        StartCoroutine(resetPos());
    }

    private void FixedUpdate()
    {
        var vel = transform.forward * speed;
        rb.position = rb.position + vel * Time.fixedDeltaTime;
    }

    private IEnumerator resetPos()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToDie);
            rb.position = initialPos;
        }
    }
}
