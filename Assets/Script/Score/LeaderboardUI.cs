using TMPro;
using UnityEngine;

public class LeaderboardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _firstScoreText;
    [SerializeField] private TextMeshProUGUI _secondScoreText;
    [SerializeField] private TextMeshProUGUI _thirdScoreText;

    public void SetLeaderboardUI()
    {
        _firstScoreText.text = PlayerPrefs.GetInt("FirstScore").ToString();
        _secondScoreText.text = PlayerPrefs.GetInt("SecondScore").ToString();
        _thirdScoreText.text = PlayerPrefs.GetInt("ThirdScore").ToString();
    }

    public void ResetLeaderboardUI()
    {
        PlayerPrefs.SetInt("FirstScore", 0);
        PlayerPrefs.SetInt("SecondScore", 0);
        PlayerPrefs.SetInt("ThirdScore", 0);

        _firstScoreText.text = PlayerPrefs.GetInt("FirstScore").ToString();
        _secondScoreText.text = PlayerPrefs.GetInt("SecondScore").ToString();
        _thirdScoreText.text = PlayerPrefs.GetInt("ThirdScore").ToString();
    }
}
