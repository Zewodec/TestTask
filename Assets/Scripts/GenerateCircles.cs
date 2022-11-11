using UnityEngine;

public class GenerateCircles : MonoBehaviour
{
    [SerializeField] private GameObject _circle;

    [SerializeField] private float _radius = 1f;
    [SerializeField] private float _width = 9f;
    
    private Vector3 _spawnPosition = new Vector3(0, 0, 0);

    private void Start()
    {
        InvokeRepeating("GenerateCircle", 1f, 3f);
    }

    private void GenerateCircle()
    {
        float safeWidth = _width - (_radius / 2);
        _spawnPosition.x = Random.Range(-safeWidth, safeWidth);
        Instantiate(_circle, _spawnPosition, Quaternion.identity);
    }
}
