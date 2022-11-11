using System.Collections;
using UnityEngine;

public class GenerateCircles : MonoBehaviour
{
    [SerializeField] private GameObject _circle;

    //[SerializeField] private float _radius = 1f;
    //[SerializeField] private static float _width = 9f;
    
    private Vector3 _spawnPosition = new Vector3();

    private void Start()
    {
        _spawnPosition.y = gameObject.transform.position.y;
        StartCoroutine(SpawnCircle());
    }

    IEnumerator SpawnCircle()
    {
        while (true)
        {
            //float safeWidth = _width - (_radius / 2);
            //_spawnPosition.x = Random.Range(-safeWidth, safeWidth);
            Instantiate(_circle, _spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(3);
        }
    }
}
