using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    public float _scoreCount;
    void Start()
    {
        _scoreText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _scoreText.text = _scoreCount.ToString();
    }
}
