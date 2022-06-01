using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool canSpawn = true;

    public GameObject guestPrefab;

    public List<Transform> guestSpawnPositions = new List<Transform>();

    public float timeBetweenSpawns = 5;

    private List<GameObject> guestList = new List<GameObject>();

    //private bool spawnOnce;
    public GameObject guestGame;
    public Gold Gold;

    // Start is called before the first frame update
    void Start()
    {
        //spawnOnce = true;
        SpawnGuest();
    }

    // void Update()
    // {
    //     if(gameObject.activeSelf)
    //     {
    //         Vector3 randomPosition = guestSpawnPositions[Random.Range(0, guestSpawnPositions.Count)].position;
    //         GameObject guest = Instantiate(guestPrefab, randomPosition, guestPrefab.transform.rotation);
    //         guestList.Add(guest);

    //         //StartCoroutine(SpawnRoutine());

    //         guestGame = guest;
    //         guest.GetComponent<Guest>().SetSpawner(this);
    //     }
    // }


    private void SpawnGuest() {
        if(gameObject.activeSelf)
        {
            Vector3 randomPosition = guestSpawnPositions[Random.Range(0, guestSpawnPositions.Count)].position;

            GameObject guest = Instantiate(guestPrefab, randomPosition, guestPrefab.transform.rotation);

            guestList.Add(guest);

            guestGame = guest;
            guest.GetComponent<Guest>().SetSpawner(this);
        }
    }

    //private IEnumerator SpawnRoutine()
    //{
        // if(canSpawn)
        // {
            //while(canSpawn)
            //{
                //SpawnGuest();
                //yield return new WaitForSeconds(timeBetweenSpawns);
            //}
        // }
    //}

    // public void RemoveGuestsFromList(GameObject guest)
    // {
    //     guestList.Remove(guest);
    // }

    // public void DestroyAllGuests()
    // {
    //     foreach (GameObject guest in guestList)
    //     {
    //         Destroy(guest);
    //     }

    //     guestList.Clear();
    // }
}
