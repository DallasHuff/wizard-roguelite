using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Director : MonoBehaviour
{
    [SerializeField] private float mapXMax;
    [SerializeField] private float mapXMin;
    [SerializeField] private float mapZMax;
    [SerializeField] private float mapZMin;
    [SerializeField] private List<GameObject> enemyList;
    [SerializeField] private List<GameObject> enemyObjects;
    [SerializeField] private int enemyCount;


    private static int environmentLayer = 6;
    private int layerMask = 1 << environmentLayer;

    private RaycastHit hit;
    private void Awake()
    {
        
    }

    private void Update()
    {
        if (enemyObjects.Count < enemyCount)
        {

        }
    }

    private void SpawnGroundEnemy(GameObject enemy)
    {
        float rX = Random.Range(mapXMin, mapXMax);
        float rZ = Random.Range(mapZMin, mapZMax);
        
        if (Physics.Raycast(new Vector3(rX, 10000, rZ), Vector3.down, out hit, Mathf.Infinity, layerMask))
        {
            Instantiate(enemy, hit.point, Quaternion.identity);
        }
        // Raycast didn't hit the environment, try spawning again
        else
        {
            Debug.Log("Raycast didn't hit");
            SpawnGroundEnemy(enemy);
        }
    }

    public void RemoveFromList(GameObject e)
    {
        if (enemyList.Contains(e))
        {
            enemyList.Remove(e);
        }
    }
}
