using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Explosion : MonoBehaviour {

    private Rigidbody rigid;

    private float explosionForce;

    private Destruction destruction;

    private bool useUpdate;

    private void Start()
    {
        destruction = FindObjectOfType<Destruction>();
        rigid = GetComponent<Rigidbody>();


        explosionForce = 100;

        rigid.useGravity = false;

        destruction.ExplosionEvent += this.explode;
    }

    private void explode () {
        print("fuvk");


        rigid.AddForce(new Vector3(UnityEngine.Random.Range(-explosionForce, explosionForce), 0, UnityEngine.Random.Range(-explosionForce, explosionForce)), ForceMode.Impulse);
        useUpdate = true;
    }

    private void Update()
    {
        if (!useUpdate)
            return;
        rigid.AddForce(Vector3.down * 10);

        if (this.gameObject.transform.position.y <= -500)
            Destroy(this.gameObject);
    }

}
