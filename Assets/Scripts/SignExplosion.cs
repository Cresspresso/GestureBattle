using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignExplosion : MonoBehaviour
{
    public ParticleSystem ps;
    public Material[] explodedMaterials = new Material[0];

    void OnBulletCollision(BulletCollision collision)
    {
        if (ps) { ps.Play(); }

        var mr = GetComponent<MeshRenderer>();
        //var mats = mr.materials;
        //mats[2] = mat;
        mr.materials = explodedMaterials;

        Destroy(this);
    }
}
