using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blowerps : MonoBehaviour {
    private void OnParticleCollision(GameObject other)
    {
        transform.parent.GetComponent<GoodGuyGun>().OnParticleCollision(other);
    }
}
