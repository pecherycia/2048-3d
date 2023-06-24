using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonScript : MonoBehaviour
{

    public void RestartGame()
    {
      
        int _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(_currentSceneIndex);
    }
}