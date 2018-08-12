using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodGuy : MonoBehaviour {
    public float speed = 10.0f;

    ParticleSystem gun_ps;
    public GoodGuyGun gun;

    private Vector3 targetPosition;
    private Vector3 lastUpdatePosition;
    private float lastUpdateTime;
    private float LerpTime = 0.05f;

    void Start () {
        gun.OnEnemyHit += OnEnemyHit;
        targetPosition = transform.position;
        lastUpdatePosition = targetPosition;
    }

	void Update () {
        if (Input.GetButton("Fire1"))
        {
            gun.Shoot();
        }

        if (!Mathf.Approximately(0.0f, Input.GetAxis("Horizontal")) || !Mathf.Approximately(0.0f, Input.GetAxis("Vertical")) )
        {
            targetPosition += new Vector3(
                Input.GetAxis("Horizontal") * Time.deltaTime * speed,
                0.0f,
                Input.GetAxis("Vertical") * Time.deltaTime * speed
            );

            lastUpdatePosition = transform.position;
            lastUpdateTime = Time.time;
            MainCamera.Instance.UpdateFollowCamera();
        }

        Vector3 world_mousePos = MainCamera.Instance.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition + Vector3.forward * MainCamera.Instance.transform.position.y);
        transform.LookAt(Vector3.Scale(Vector3.forward + Vector3.right, world_mousePos));
        transform.eulerAngles = Vector3.Scale(transform.eulerAngles, Vector3.up);

        transform.position = Vector3.Lerp(lastUpdatePosition, targetPosition, (Time.time - lastUpdateTime) / LerpTime );
    }

    void OnEnemyHit(BadGuy enemy)
    {
        enemy.Damage(gun.bulletDamage);
    }
}
