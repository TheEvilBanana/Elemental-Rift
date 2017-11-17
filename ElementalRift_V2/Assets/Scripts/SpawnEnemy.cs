using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public GameObject enemy;

    public float spawnTimer = 3.0f;

    public GameObject button;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnTimer, spawnTimer);
    }

    private void Update()
    {
        if (!button.activeInHierarchy)
        {
            Destroy(gameObject);
        }
    }
    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, 3);

        
        Instantiate(enemy, gameObject.transform.position, gameObject.transform.rotation);
    }
}
