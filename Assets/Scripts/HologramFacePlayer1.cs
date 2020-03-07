using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramFacePlayer1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;

    void OnTriggerStay(Collider other)
    {
        transform.LookAt(target);
    }

}
