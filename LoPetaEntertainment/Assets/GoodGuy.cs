using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodGuy : MonoBehaviour {
    public float speed = 10.0f;

    ParticleSystem gun_ps;
    public GoodGuyGun gun;

	void Start () {
        gun.OnEnemyHit += OnEnemyHit;
    }

	void Update () {
        if (Input.GetButton("Fire1"))
        {
            gun.Shoot();
        }

        transform.Translate(new Vector3(
            Input.GetAxis("Horizontal") * Time.deltaTime * speed,
            0.0f,
            Input.GetAxis("Vertical") * Time.deltaTime * speed
        ));
    }

    void OnEnemyHit(BadGuy enemy)
    {
        
    }
}
