using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObeliskSpawn : MonoBehaviour {

    public float spawnMinInterval = 4f;
    public float spawnMaxInterval = 10f;
    public bool isSpawning = true;

    public GameObject enemyToSpawn;
    public Vector3 spawnPosition;

    public IEnumerator SpawnObjectAndWait()
    {
        while(isSpawning)
        {
            float nextSpawn = Random.Range(spawnMinInterval, spawnMaxInterval);
            yield return new WaitForSeconds(nextSpawn);

            //does the spawn itself
            //check once again, player may have died or won during your timeout
            if (!TerminationTracker.instance.gameIsOver)
                Instantiate(enemyToSpawn, spawnPosition, transform.rotation);
            else
                isSpawning = false;
        }

    }

    


	// Use this for initialization
	void Start () {
        spawnPosition = transform.position+ new Vector3(0,3);
        StartCoroutine(SpawnObjectAndWait());
	}
	
	// Update is called once per frame
	void Update () {

	}
}
