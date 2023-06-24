using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public GameObject GameOverPanel;

    void Update()
    {
        if (CheckCubesInSpawnLocation())
        {
            GameOverPanel.SetActive(true);                        
        }     
    }

    private bool CheckCubesInSpawnLocation()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(2, 1f, 10));

        int _cubesNumber = 0;

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Cube"))
            {
                _cubesNumber++;
            }
        }

        if (_cubesNumber > 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
