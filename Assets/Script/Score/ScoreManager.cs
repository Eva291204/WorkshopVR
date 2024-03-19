using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

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

    [SerializeField] public int Score;

    public event Action<int> UpdateScore;

    public void SetScore(int newScore)
    {
        Score += newScore;
        UpdateScore?.Invoke(Score);
    }

    public void SetPodium()
    {
        List<int> tempList = new List<int>();
        tempList.Add(PlayerPrefs.GetInt("ThirdScore"));
        tempList.Add(PlayerPrefs.GetInt("SecondScore"));
        tempList.Add(PlayerPrefs.GetInt("FirstScore"));

        for (int i = 0; i < tempList.Count; i++)
        {
            int oldScore = tempList[i];
            if(Score > tempList[i])
            {
                if(i - 1 >= 0)
                {
                    tempList[i] = Score;
                    tempList[i - 1] = oldScore;
                }
                else
                {
                    tempList[i] = Score;
                }
            }
        }

        PlayerPrefs.SetInt("ThirdScore", tempList[0]);
        PlayerPrefs.SetInt("SecondScore", tempList[1]);
        PlayerPrefs.SetInt("FirstScore", tempList[2]);

        Debug.Log(PlayerPrefs.GetInt("FirstScore"));
    }
}