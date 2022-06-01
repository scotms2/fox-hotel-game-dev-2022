using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool canSpawn;

    public GameObject guestPrefab;

    public List<Transform> guestSpawnPositions = new List<Transform>();

    public float timeBetweenSpawns = 5;

    private List<GameObject> guestList = new List<GameObject>();



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    void Update()
    {
        if(GameObject.Find("Canvas").gameObject.GetComponent<DayTimer>().day == true)
        {
            canSpawn = true;
            Debug.Log("can spawn");
        }
        else
        {
            canSpawn = false;
            Debug.Log("can not spawn");

        }

        // StartCoroutine(SpawnRoutine());

    }


    private void SpawnGuest() {
        // if(spawnOnce =true)
        // {
        Vector3 randomPosition = guestSpawnPositions[Random.Range(0, guestSpawnPositions.Count)].position;

        GameObject guest = Instantiate(guestPrefab, randomPosition, guestPrefab.transform.rotation);

        guestList.Add(guest);

        guest.GetComponent<Guest>().SetSpawner(this);
        // spawnOnce =false;
        // }
    }

    private IEnumerator SpawnRoutine()
    {
        // if(canSpawn)
        // {
            while(canSpawn)
            {
                SpawnGuest();
                yield return new WaitForSeconds(timeBetweenSpawns);
            }
        // }
    }

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
