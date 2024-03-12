using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject gameObjectToSpawn;
    [SerializeField] private Transform SpawnPoint;

    public void SpawnGameObject()
    {
        gameObjectToSpawn.transform.position = SpawnPoint.position;
    }
}
