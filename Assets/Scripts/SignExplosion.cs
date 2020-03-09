using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignExplosion : MonoBehaviour
{
    public ParticleSystem ps;
    public Material mat;

    void OnBulletCollision(BulletCollision collision)
    {
        ps.Play();
        //GetComponent<MeshRenderer>().materials[2] = mat;
    }
}
