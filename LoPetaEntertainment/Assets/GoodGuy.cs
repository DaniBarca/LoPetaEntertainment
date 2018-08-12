using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoodGuy : MonoBehaviour {
    public float speed = 10.0f;

    ParticleSystem gun_ps;
    public GoodGuyGun gun;

    public Animator animator;

    public float life = 100.0f;

    public HealthBar healthBar;

    public bool inmortal = false;

    void Start () {
        gun.OnEnemyHit += OnEnemyHit;
        animator = GetComponent<Animator>();
    }

	void Update () {
        if(life <= 0.0f)
        {
            SceneManager.LoadScene("MenuInicial");
        }

        healthBar.curHealth = life;
        healthBar.curIce = gun.ammo;

        Camera cam = MainCamera.Instance.GetComponent<Camera>();

        Vector3 world_mousePos = cam.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * MainCamera.Instance.transform.position.y);
        transform.LookAt(Vector3.Scale(Vector3.forward + Vector3.right, world_mousePos));
        transform.eulerAngles = Vector3.Scale(transform.eulerAngles, Vector3.up);

        Vector3 v_keys = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")).normalized;
        Vector3 v_mouse = (world_mousePos - transform.position);
        v_mouse.y = 0.0f;
        v_mouse.Normalize();    
        Vector3 v = transform.InverseTransformPoint(transform.position + v_keys);
        v.y = 0.0f;
        v.Normalize();
        animator.SetFloat("dx", v.x);
        animator.SetFloat("dy", v.z);

        if (Input.GetButton("Fire1"))
        {
            gun.Shoot();
        }

        //if (!Mathf.Approximately(0.0f, Input.GetAxis("Horizontal")) || !Mathf.Approximately(0.0f, Input.GetAxis("Vertical")) )
        //{
        //    transform.position += new Vector3(
        //        Input.GetAxis("Horizontal") * Time.deltaTime * speed,
        //        0.0f,
        //        Input.GetAxis("Vertical") * Time.deltaTime * speed
        //    );
        //}
       
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

    public void ReceiveDamage()
    {
        if(!inmortal)
            life -= 20.0f;
    }
}
