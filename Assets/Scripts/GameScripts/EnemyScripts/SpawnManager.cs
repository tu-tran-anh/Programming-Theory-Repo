using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private int spawnRangeX = 13;
    private int spawnPosZ = 20;

    private int timeStart=2;
    private float repeatRate=4f;
    // Start is called before the first frame update
    void Start()
    {
        repeatRate /= MenuManager.Instance.mode;
        if (!MenuManager.Instance.gameOver)
        {
            InvokeRepeating("SpawnRandomAnimal", timeStart, repeatRate);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRandomAnimal()
    {
        Vector3 spawnpos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnpos, animalPrefabs[animalIndex].transform.rotation);
    }
}
