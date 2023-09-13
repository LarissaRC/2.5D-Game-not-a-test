using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private GameObject _slotPrefab;
    //private int[,] grid = new int[,] {{0, 0, 1}, {0, 0, 0}, {1, 0, 0}};

    void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid() {
        for(int x = 0; x < _width; x++) {
            for(int z = 0; z < _height; z++) {
                //if(grid[x, z] == 1)
                //    continue;
                    
                GameObject spawnedSlot = Instantiate(_slotPrefab, transform.position, Quaternion.identity);
                spawnedSlot.transform.position = new Vector3((spawnedSlot.transform.position.x + (x/2f)),
                                                                spawnedSlot.transform.position.y + 0.15f,
                                                                (spawnedSlot.transform.position.z + (z/2f)));
                spawnedSlot.transform.SetParent(transform);
                spawnedSlot.name = $"Slot {x} {z}";
            }
        }
    }
}
