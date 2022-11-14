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

    private void Start()
    {
        EventManager.OnClickOnCircle.AddListener(CheckForLevelChange);
        EventManager.OnLevelChange.AddListener(ChangeLevel);
    }

    #region Lavel Change process
    private void ChangeLevel()
    {
        _level++;
        ChangeLevelText();
        _pointsToChangeLevel += 5;
    }

    private void ChangeLevelText()
    {
        _levelText.text = "Level " + _level;
        _levelText.gameObject.SetActive(true);
        StartCoroutine(HideLevelTextAfter3sec());
    }

    IEnumerator HideLevelTextAfter3sec()
    {
        yield return new WaitForSecondsRealtime(3f);
        _levelText.gameObject.SetActive(false);
    }
    #endregion Lavel Change process

    public void ResetLevels()
    {
        _level = 1;
    }

    private void CheckForLevelChange()
    {
        if (PlayerStats.getPoints() >= _pointsToChangeLevel * _level)
        {
            EventManager.SendOnLevelChange();
        }
    }


}
