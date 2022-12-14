using System.Collections;
using UnityEngine;

public class GenerateCircles : MonoBehaviour
{
    // Circle object
    [SerializeField] private GameObject _circle;

    [Header("Time Range")]
    [Range(1f, 3f)]
    [SerializeField] private float _minDelayTime = 1.5f;
    [Range(3f, 5f)]
    [SerializeField] private float _maxDelayTime = 3f;

    private Vector3 _spawnPosition = new Vector3();

    private void Start()
    {
        // Set spawn above the screen
        _spawnPosition.y = gameObject.transform.position.y;
        EventManager.OnLevelChange.AddListener(OnLevelChangeDecreaseDelay);
    }

    /// <summary>
    /// Decrease delay beetween spawning circles.
    /// </summary>
    private void OnLevelChangeDecreaseDelay()
    {
        if (_minDelayTime > 0.15f)
        {
            _minDelayTime -= 0.2f;
        }

        if (_maxDelayTime > 0.5f)
        {
            _maxDelayTime -= 0.2f;
        }
    }

    #region Spawn Circle Process

    /// <summary>
    /// Start to spawn circles on game object activate.
    /// </summary>
    private void OnEnable()
    {
        StartCoroutine(SpawnCircle());
    }

    /// <summary>
    /// Stop spawning circles on game object deactivate.
    /// </summary>
    private void OnDisable()
    {
        StopCoroutine(SpawnCircle());
    }

    private IEnumerator SpawnCircle()
    {
        while (true)
        {
            Instantiate(_circle, _spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(_minDelayTime, _maxDelayTime));
        }
    }

    #endregion Spawn Circle Process
}