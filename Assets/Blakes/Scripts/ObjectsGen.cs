using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsGen : MonoBehaviour
{
    //script based on unity learn tutorial project 2 Junior Programmer
    public GameObject[] obstaclesPrefabs;
    private float xRangeGen = 20f;
    private float yRangeGen = 20f;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 3f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstacles()); //funcion con tiempo en lugar de tecla
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.S)) //para probar que spawnea objetos, NO usar
        //{
        //    int indexSaw = Random.Range(0, sawPrefab.Length);
        //    Vector3 spawnPosition = new Vector3(Random.Range(-xRangeGen, xRangeGen), 0, Random.Range(-yRangeGen, yRangeGen));
        //    Instantiate(sawPrefab[indexSaw], spawnPosition, Quaternion.identity);
        //}   
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);
            int index = Random.Range(0, obstaclesPrefabs.Length); //agregar mas obstaculos en el index de los prefabs
            Vector3 spawnPosition = new Vector3(Random.Range(-xRangeGen, xRangeGen), 0, Random.Range(-yRangeGen, yRangeGen));
            GameObject obstacles = Instantiate(obstaclesPrefabs[index], spawnPosition, Quaternion.identity);
            Destroy(obstacles, 2f);
        }
    }
}
