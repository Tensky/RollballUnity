using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawnController : MonoBehaviour
{   
    public GameObject collectables;
    private float timeSinceLastSpawned;
    // Start is called before the first frame update
    void Start()
    {
        SpawnCollectables();
    }

    void SpawnCollectables(){
        timeSinceLastSpawned = 0;
        collectables.SetActive(true);
        var randomX = Random.Range(-19, 19);
        var randomZ = Random.Range(-19, 19);
        collectables.transform.position = new Vector3(randomX, 0.5f, randomZ);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if(timeSinceLastSpawned >= 10 || !collectables.activeInHierarchy){
            SpawnCollectables();
            return;
        }
    }
}
