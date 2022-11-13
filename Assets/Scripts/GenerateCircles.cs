using System.Collections;
using UnityEngine;

public class GenerateCircles : MonoBehaviour
{
    [SerializeField] private GameObject _circle;

    [Header("Time Range")]
    [Range(1f, 3f)]
    [SerializeField] private float _minDelayTime = 1.5f;

    [Range(3f, 5f)]
    [SerializeField] private float _maxDelayTime = 3f;

    private Vector3 _spawnPosition = new Vector3();

    private void Start()
    {
        _spawnPosition.y = gameObject.transform.position.y;
    }

    private IEnumerator SpawnCircle()
    {
        while (true)
        {
            Instantiate(_circle, _spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(_minDelayTime, _maxDelayTime));
        }
    }

    private void OnEnable()
    {
        StartCoroutine(SpawnCircle());
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnCircle());
    }
}