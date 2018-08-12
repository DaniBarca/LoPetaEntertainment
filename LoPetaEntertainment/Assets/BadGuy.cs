using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuy : MonoBehaviour {
    private bool alive = true;
    public float life = 100.0f;

	void Start () {}
	void Update () {}

    public void Damage(float strength)
    {
        life -= strength;
        alive = life > 0.0f;
        gameObject.SetActive(alive);
    }
}
