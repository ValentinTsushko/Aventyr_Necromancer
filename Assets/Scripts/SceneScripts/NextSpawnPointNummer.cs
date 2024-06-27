using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSpawnPointNummer : MonoBehaviour
{
    private int SpawnPointNummer = 0;

    public int GetSpawnPointNummer()
    {
        return SpawnPointNummer;
    }
    public void SetSpawnPointNummer(int newNummer)
    {
        SpawnPointNummer = newNummer;
    }
}
