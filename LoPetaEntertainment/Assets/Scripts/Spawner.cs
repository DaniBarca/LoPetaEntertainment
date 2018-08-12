using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] fokis;

    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;

    private float startTime;
    private float firstLevelSpawnMostWait;
    public float lastLevelStartWait;
    public float lastLevelTime;

    int randEnemy;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        firstLevelSpawnMostWait = spawnMostWait;
        lastLevelTime = startTime + lastLevelTime;
        StartCoroutine(waitSpawner());
	}
	
	// Update is called once per frame
	void Update () {
        spawnMostWait = Mathf.Lerp(firstLevelSpawnMostWait, lastLevelStartWait, (Time.time - startTime) / (lastLevelTime - startTime));
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
	}

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);
        while (!stop)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(0.0f,128.0f), 0.0f, Random.Range(0.0f,128.0f));
            GameObject lastInstance = Instantiate(fokis[randEnemy], spawnPosition, gameObject.transform.rotation);
            lastInstance.SetActive(true);
            yield return new WaitForSeconds(spawnWait);
        }
    }

}
