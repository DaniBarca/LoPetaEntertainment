using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodGuyGun : MonoBehaviour
{
    public float bulletDamage = 10;
    public ParticleSystem gun_ps;
    public System.Action<BadGuy> OnEnemyHit;

    public float emitRate = 0.3f;
    private float lastEmit = 0;

    public float ammo = 100.0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Camera c = MainCamera.Instance.GetComponent<Camera>();
            Ray r = c.ScreenPointToRay(Input.mousePosition);
            RaycastHit rh;
            Physics.Raycast(r, out rh, LayerMask.GetMask("Hex"));

            HexTile hitTile = rh.collider.gameObject.GetComponent<HexTile>();
            hitTile.IVEBEENHIT();

            ammo += 50.0f;
            ammo = Mathf.Clamp(ammo, 0.0f, 100.0f);
        }
    }

    public void OnParticleCollision(GameObject other)
    {
        if (other.layer == LayerMask.NameToLayer("BadGuy"))
        {
            OnEnemyHit(other.GetComponent<BadGuy>());
        }
    }

    public void Shoot()
    {
        if ((Time.time - lastEmit) < emitRate) return;

        if (ammo > 0)
        {
            gun_ps.Emit(1);
            ammo--;
            lastEmit = Time.time;
        }
    }
}
