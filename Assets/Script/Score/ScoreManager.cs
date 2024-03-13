using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _scoreInstance;
    public static ScoreManager Instance
    {
        get
        {
            if (_scoreInstance == null)
            {
                Debug.Log("ScoreManager is null");
            }
            return _scoreInstance;
        }
    }
    public void Awake()
    {
        if (_scoreInstance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _scoreInstance = this;
        }
    }

    [SerializeField] private int _score;

    public event Action<int> UpdateScore;

    public void SetScore(int newScore)
    {
        _score += newScore;
        UpdateScore?.Invoke(_score);
    }
}