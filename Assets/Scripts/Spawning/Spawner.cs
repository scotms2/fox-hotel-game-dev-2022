using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spawner : MonoBehaviour
{
    public bool canSpawn = true;

    public GameObject guestPrefab;

    public List<Transform> guestSpawnPositions = new List<Transform>();

    public float timeBetweenSpawns;

    private List<GameObject> guestList = new List<GameObject>();
    public Gold Gold;

    public GameObject guestGame;

    // Start is called before the first frame update
    void Start()
    {
        SpawnGuest();
    }

    public void SpawnGuest()
    {
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
    //    while(canSpawn)
    //    {
    //        SpawnGuest();
    //        yield return new WaitForSeconds(timeBetweenSpawns);
    //    }
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
