using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public bool canSpawn = true;

    public GameObject foxPrefab;

    public List<Transform> foxSpawnPositions = new List<Transform>();

    public float timeBetweenSpawns;

    private List<GameObject> foxList = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private void SpawnFox() {
        Vector2 randomPosition = foxSpawnPositions[Random.Range(0, foxSpawnPositions.Count)].position;

        GameObject fox = Instantiate(foxPrefab, randomPosition, foxPrefab.transform.rotation);

        foxList.Add(fox);

        fox.GetComponent<Fox>().SetSpawner(this);
    }

    private IEnumerator SpawnRoutine()
    {
        while(canSpawn)
        {
            SpawnFox();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    public void RemoveFoxesFromList(GameObject fox)
    {
        foxList.Remove(fox);
    }

    public void DestroyAllFoxes()
    {
        foreach (GameObject fox in foxList)
        {
            Destroy(fox);
        }

        foxList.Clear();
    }
}
