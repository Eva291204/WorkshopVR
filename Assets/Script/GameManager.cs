using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _Instance;
    public static GameManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                Debug.Log("ScoreManager is null");
            }
            return _Instance;
        }
    }
    public void Awake()
    {
        if (_Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _Instance = this;
        }
    }

    [SerializeField] CustomerObjectPool _customerPool;
    [SerializeField] CustomerMain _ctmMain;

    [SerializeField] float _gameTimer;
    [SerializeField] int _gameTimerRounded;
    [SerializeField] bool _gameLaunched;

    [SerializeField] TextMeshProUGUI _timerText;

    public float easy = 60f;
    public float normal = 40f;
    public float hard = 25f;

    private void Start()
    {
        StartCoroutine(StartTheGame());
    }

    public void LaunchGame() {
        SendNewCustomer();
        StartGameTimer();
    }

    public void StartGameTimer() {
        _gameLaunched = true;
        ScoreManager.Instance.SetScore(0);
    }

    public void StopGameTimer() {
        _gameLaunched = false;
        // Stopper le jeu
    }

    public void SetGameTimerEvent() {
        _gameTimer -= Time.deltaTime;
        _gameTimerRounded = Mathf.RoundToInt(_gameTimer);

        _timerText.text = _gameTimerRounded.ToString();
        if(_gameTimerRounded <= 0)
        {
            StopGameTimer();
        }
    }

    public void Update() {
        if(_gameLaunched) {
            SetGameTimerEvent();
        }
    }

    public void SendNewCustomer() {
        _ctmMain = _customerPool.GetObjectFromPool();
        if (_ctmMain != null) {
            _ctmMain.gameObject.transform.SetPositionAndRotation(_customerPool.gameObject.transform.position, Quaternion.Euler(0, 90, 0));
            _ctmMain.gameObject.SetActive(true);

            _ctmMain.GetComponent<CustomerAnim>().GoToFoodOutlet();
        }
    }
    public IEnumerator StartTheGame()
    {
        yield return new WaitForSeconds(1);
        LaunchGame();
    }
}
