using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private GameObject spawnPointNewNummer;

    void Start()
    {
        SpawnObject();
    }

    private void SpawnObject()
    {
        if (objectToSpawn != null && spawnPoints[spawnPointNewNummer.GetComponent<NextSpawnPointNummer>().GetSpawnPointNummer()] != null)
        {
            Debug.Log("spawnPointNewNummer.GetComponent<NextSpawnPointNummer>().GetSpawnPointNummer()  " + spawnPointNewNummer.GetComponent<NextSpawnPointNummer>().GetSpawnPointNummer());
            Instantiate(objectToSpawn, spawnPoints[spawnPointNewNummer.GetComponent<NextSpawnPointNummer>().GetSpawnPointNummer()].position
                , spawnPoints[spawnPointNewNummer.GetComponent<NextSpawnPointNummer>().GetSpawnPointNummer()].rotation);
        }
    }
}
