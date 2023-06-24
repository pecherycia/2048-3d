using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    private bool _canSpawn = true;
    public GameObject[] objectPrefabs;

    public float spawnCheckRadius = 1f;

    private void Start()
    {
        SpawnCube();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _canSpawn = false;
        }
        else
        {
     if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(InvokeFunctionAfterDelay(0.5f));

        }
            _canSpawn = true;
        }
    }

    IEnumerator InvokeFunctionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
          
        SpawnCube();
    }

    public void SpawnCube()
    {
        if (_canSpawn && CheckSpawnLocation())
        {
            float randomValue = Random.value;
            GameObject objectToSpawn;

            if (randomValue <= 0.75f)
            {
                objectToSpawn = objectPrefabs[0];
            }
            else
            {
                objectToSpawn = objectPrefabs[1];
            }

            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
    }


private bool CheckSpawnLocation()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(spawnCheckRadius, spawnCheckRadius, spawnCheckRadius));

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Cube"))
            {
                return false;
            }
        }
        return true;
    }
}
    
