using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    public GameObject[,] GridArray = new GameObject[35, 20];
    [SerializeField] private GameObject _tile, _bomb;
    [SerializeField] private GameObject _spawner;

    private void Start()
    {
        SpawnerGrid();
    }

    public void SpawnerGrid()
    {

        for (var x = 0; x < GridArray.GetLength(0); x++)
        {
            for (var y = 0; y < GridArray.GetLength(1); y++)
            {

                GridArray[x, y] = Instantiate(Random.Range(0, 100) < 20 ? _bomb : _tile, new Vector3(x, 0, y),
                    Quaternion.identity);
                GridArray[x, y].transform.parent = _spawner.transform;

            }

        }
    }

   
}

