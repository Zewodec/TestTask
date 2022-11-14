using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagmentUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private Button startButton;
    [SerializeField] private Button stopButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;

    private bool _flagVisibleUI = true;

    private void Start()
    {
        EventManager.OnUpdateTextUI.AddListener(UpdateScoreText);
        startButton.onClick.AddListener(OnStartClick);
        stopButton.onClick.AddListener(OnStopClick);
    }

    #region Buttons Action

    /// <summary>
    /// Click on start button.
    /// </summary>
    private void OnStartClick()
    {
        ChangeVisibilityUI();

        PlayerStats.resetPoints();
        UpdateScoreText();
        TimerStart();
    }

    /// <summary>
    /// Click on stop button
    /// </summary>
    private void OnStopClick()
    {
        ChangeVisibilityUI();

        TimerStop();
    }

    #endregion Buttons Action

    #region Timer
    private void TimerStart()
    {
        StartCoroutine(TimerUpdate());
    }

    private void TimerStop()
    {
        StopAllCoroutines();
    }

    /// <summary>
    /// Timer Update
    /// </summary>
    private IEnumerator TimerUpdate()
    {
        int hours = 0, minutes = 0, seconds = 0;
        while (true)
        {
            seconds++;

            if (seconds == 60)
            {
                seconds = 0;
                minutes++;
            }

            if (minutes == 60)
            {
                minutes = 0;
                hours++;
            }

            timerText.text = $"{hours}:{minutes}:{seconds}";
            yield return new WaitForSecondsRealtime(1f);
        }
    }
    #endregion Timer

    /// <summary>
    /// Change visibility of UI items.
    /// </summary>
    private void ChangeVisibilityUI()
    {
        titleText.gameObject.SetActive(!_flagVisibleUI);
        startButton.gameObject.SetActive(!_flagVisibleUI);
        stopButton.gameObject.SetActive(_flagVisibleUI);
        scoreText.gameObject.SetActive(_flagVisibleUI);
        timerText.gameObject.SetActive(_flagVisibleUI);
        _flagVisibleUI = !_flagVisibleUI;
    }

    /// <summary>
    /// Update player's score.
    /// </summary>
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + PlayerStats.getPoints();
    }
}