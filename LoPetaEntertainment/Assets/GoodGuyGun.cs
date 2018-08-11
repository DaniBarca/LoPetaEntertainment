using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodGuyGun : MonoBehaviour
{
    public ParticleSystem gun_ps;
    public System.Action<BadGuy> OnEnemyHit;

    public float emitRate = 0.3f;
    private float lastEmit = 0;

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "BadGuy")
        {
            OnEnemyHit(other.GetComponent<BadGuy>());
        }
    }

    public void Shoot()
    {
        if ((Time.time - lastEmit) < emitRate) return;

        gun_ps.Emit(1);
        lastEmit = Time.time;
    }
}
