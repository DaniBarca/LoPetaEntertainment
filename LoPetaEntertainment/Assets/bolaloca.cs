using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolaloca : MonoBehaviour {
    float t;
	void Start () {
        t = 0;
    }
	
	void Update () {
        transform.position = Vector3.up * 20f * (Time.deltaTime * Mathf.Sin(t += 0.5f));
    }
}
