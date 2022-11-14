using UnityEngine;

/// <summary>
/// Class generates texture for Circle.
/// W.I.P.
/// </summary>
public class GenerateTexture : MonoBehaviour
{
    [SerializeField] private Texture2D _circleTexture;
    [SerializeField] private int _resolution = 64;

    private void Start()
    {
        if (_circleTexture == null)
        {
            _circleTexture = new Texture2D(_resolution, _resolution);
            GetComponent<SpriteRenderer>().material.mainTexture = _circleTexture;
        }

        if (_circleTexture.width != _resolution)
        {
            _circleTexture.Reinitialize(_resolution, _resolution);
        }

        _circleTexture.filterMode = FilterMode.Trilinear;

        Color newColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);

        for (int y = 0; y < _resolution; y++)
        {
            for (int x = 0; x < _resolution; x++)
            {
                _circleTexture.SetPixel(x, y, newColor);
            }
        }
        _circleTexture.Apply();
    }
}