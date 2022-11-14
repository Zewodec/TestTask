using System.Collections;
using TMPro;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [Header("Level parameters")]
    [SerializeField] private int _level = 1;

    [SerializeField] private int _pointsToChangeLevel = 25;

    [Header("UI Elements")]
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private BackgroundLoader _backgroundLoader;

    private void Start()
    {
        EventManager.OnClickOnCircle.AddListener(CheckForLevelChange);
        EventManager.OnLevelChange.AddListener(ChangeLevel);
    }

    #region Lavel Change process

    /// <summary>
    /// Changing level (make harder)
    /// </summary>
    private void ChangeLevel()
    {
        _level++;                           // Add num to level
        ChangeLevelText();                  // Change Level
        _pointsToChangeLevel += 2;          // Increase the condition to new level
        _backgroundLoader.nextBackground(); // Set new background
    }

    /// <summary>
    /// Show the text that level changed.
    /// </summary>
    private void ChangeLevelText()
    {
        _levelText.text = "Level " + _level;
        _levelText.gameObject.SetActive(true);
        StartCoroutine(HideLevelTextAfter3sec());
    }

    /// <summary>
    /// Hide info about level after 3 seconds
    /// </summary>
    private IEnumerator HideLevelTextAfter3sec()
    {
        yield return new WaitForSecondsRealtime(3f);
        _levelText.gameObject.SetActive(false);
    }

    #endregion Lavel Change process

    public void ResetLevels()
    {
        _level = 1;
    }

    /// <summary>
    /// If play get enough points - level change.
    /// </summary>
    private void CheckForLevelChange()
    {
        if (PlayerStats.getPoints() >= _pointsToChangeLevel * _level)
        {
            EventManager.SendOnLevelChange();
        }
    }
}