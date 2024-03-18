using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Start()
    {
        ScoreManager.Instance.UpdateScore += Notify;
    }
    public void Notify(int newScore)
    {
        _scoreText.text = newScore.ToString();
    }    
}