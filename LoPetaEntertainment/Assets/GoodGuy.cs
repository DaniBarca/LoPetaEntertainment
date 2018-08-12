﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodGuy : MonoBehaviour {
    public float speed = 10.0f;

    ParticleSystem gun_ps;
    public GoodGuyGun gun;

    public Animator animator;

    public float life = 100.0f;

    public HealthBar healthBar;

    void Start () {
        gun.OnEnemyHit += OnEnemyHit;
        animator = GetComponent<Animator>();
    }

	void Update () {
        healthBar.curHealth = life;
        healthBar.curIce = gun.ammo;

        if (Input.GetButton("Fire1"))
        {
            gun.Shoot();
        }

        animator.SetFloat("dx", Input.GetAxis("Horizontal"));
        animator.SetFloat("dy", Input.GetAxis("Vertical"));

        //if (!Mathf.Approximately(0.0f, Input.GetAxis("Horizontal")) || !Mathf.Approximately(0.0f, Input.GetAxis("Vertical")) )
        //{
        //    transform.position += new Vector3(
        //        Input.GetAxis("Horizontal") * Time.deltaTime * speed,
        //        0.0f,
        //        Input.GetAxis("Vertical") * Time.deltaTime * speed
        //    );
        //}

        Vector3 world_mousePos = MainCamera.Instance.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition + Vector3.forward * MainCamera.Instance.transform.position.y);
        transform.LookAt(Vector3.Scale(Vector3.forward + Vector3.right, world_mousePos));
        transform.eulerAngles = Vector3.Scale(transform.eulerAngles, Vector3.up);
    }

    void OnEnemyHit(BadGuy enemy)
    {
        enemy.Damage(gun.bulletDamage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            life = 0.0f;
        }
    }
}
