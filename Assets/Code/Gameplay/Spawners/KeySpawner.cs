using UnityEngine;
using System.Collections.Generic;

public class KeySpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject keyPrefab;
    [SerializeField] private RoomData[] rooms;
    [SerializeField] private int maxKeysToSpawn = 2;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnInitialKeys();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnInitialKeys()
    {
        List<RoomData> availableRooms = new List<RoomData>(rooms);


        if (maxKeysToSpawn > rooms.Length)
        {
            Debug.LogError("Hay más llaves que habitaciones disponibles");
            return;
        }

        for (int i=0; i<maxKeysToSpawn; i++)
        {
            SpawnKey(availableRooms);
        }
    }

    void SpawnKey(List<RoomData> availableRooms)
    {
       
        if (availableRooms.Count == 0)
        {
            Debug.LogWarning("No hay puntos de spawn disponibles");
            return;
        }

        int randomRoomIndex = Random.Range(0, availableRooms.Count);
        RoomData selectedRoom = availableRooms[randomRoomIndex];

        int randomSpawnIndex = Random.Range(0, selectedRoom.spawnPoints.Length);
        GameObject selectedSpawn = selectedRoom.spawnPoints[randomSpawnIndex];

        Vector3 spawnPosition = selectedSpawn.transform.position;

        Instantiate(keyPrefab, spawnPosition, Quaternion.identity);

        availableRooms.RemoveAt(randomRoomIndex);
    }


}
