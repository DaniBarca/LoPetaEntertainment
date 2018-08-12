using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HexTile : MonoBehaviour
{

	public float wavingStrenght;
	public float waveSpeed;
	public float rotationAmplitude;
	public float rotationSpeed;

	private Vector2 rotationAxis;
	private float ts;

	public float intensity = 1.0f;

	private float initialHeight;

	public float pressedHeightModifier;
	public float sinkSpeed;
	private bool isStep=false;
	private float stepUpon;
	
	// Use this for initialization
	void Start ()
	{
		ts = Random.Range(0.0f,0.50f);
		rotationAxis.x = Random.Range(-0.5f,0.5f);
		rotationAxis.y = Random.Range(-0.5f,0.5f);
		initialHeight = transform.position.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!isStep)
		{
			stepUpon -= stepUpon * (Time.deltaTime * sinkSpeed) + (Time.deltaTime * sinkSpeed);
			;
		}
		else
		{
			stepUpon += stepUpon * (Time.deltaTime * sinkSpeed) + (Time.deltaTime * sinkSpeed);
		}
		stepUpon=Mathf.Clamp01(stepUpon);

		ts += Time.deltaTime*waveSpeed*intensity;

		Vector3 position = transform.position;
		position.y = wavingStrenght * Mathf.Cos( ts + position.x/3.0f) * intensity + initialHeight + stepUpon*pressedHeightModifier;

		transform.position = position;
		
		Vector2 angle = (rotationAmplitude * Mathf.Cos( ts * rotationSpeed ) * intensity + initialHeight + stepUpon*pressedHeightModifier) * rotationAxis;

		transform.rotation = Quaternion.Euler(angle.x, 0.0f, angle.y);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" || other.tag == "Enemy")
		{
			isStep = true;
		}
	}
	
	private void OnTriggerExit(Collider other)	{
		if (other.tag == "Player" || other.tag == "Enemy")
		{
			isStep = false;
		}
	}

    public void IVEBEENHIT()
    {
        gameObject.SetActive(false);
    }
}
