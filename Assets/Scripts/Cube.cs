using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float Value;

    private ScoreManager _scoreManager;

    private void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();

    }
    private void OnDestroy()
    {
        if (_scoreManager != null)
        {
            if (Value != 16)
            {
                _scoreManager._scoreCount += Value / 4f;
            }
            else
            {
                _scoreManager._scoreCount += Value / 2f;
            }

        }

    }
}
