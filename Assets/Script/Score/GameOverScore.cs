using TMPro;
using UnityEngine;

public class GameOverScore : MonoBehaviour
{
    public TextMeshProUGUI EndScore;
    public void Start()
    {
        EndScore.text = PlayerPrefs.GetInt("PlayerScore").ToString();
    }
}
