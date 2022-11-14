using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _widthSpawnPostion = 9f;

    private static float _levelSpeedBonus = 0f;

    [Header("Size of Circle")]
    [Range(1f, 3f)]
    [SerializeField] private float _maxSize = 3f;
    [Range(0.1f, 1f)]
    [SerializeField] private float _minSize = 0.25f;

    private float _radius = 1f;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _transform = _rigidbody.transform;
    }

    private void Start()
    {
        // Adding events to listeners
        EventManager.OnClickOnCircle.AddListener(AddPointsToPlayer);
        EventManager.OnLevelChange.AddListener(OnLevelChangeDecreaseMaxSize);
        EventManager.OnLevelChange.AddListener(OnLevelChangeIncreaseSpeed);

        setRandomColor();
        setRandomSize();
        setRandomPosition();
        setCircleSpeed();
    }

    private void FixedUpdate()
    {
        MoveCircleDown();
    }

    private void OnLevelChangeDecreaseMaxSize()
    {
        if (_maxSize > _minSize)
        {
            _maxSize -= 0.25f;
        }
    }

    private void OnLevelChangeIncreaseSpeed()
    {
        _levelSpeedBonus += 0.25f;
    }

    #region Start sets for Circle

    /// <summary>
    /// Set circle's speed depends on size.
    /// Also add speed when level is higher.
    /// </summary>
    private void setCircleSpeed()
    {
        float sumMaxMinSize = _maxSize + _minSize;
        _speed = sumMaxMinSize - _radius + _levelSpeedBonus;
    }

    private void setRandomPosition()
    {
        Vector3 newPosition = _transform.position;
        float safeSpawnZone = _widthSpawnPostion - (_radius / 2);
        newPosition.x = Random.Range(-safeSpawnZone, safeSpawnZone);
        _transform.position = newPosition;
    }

    private void setRandomSize()
    {
        _radius = Random.Range(_minSize, _maxSize);
        Vector3 circleSize = new Vector3(_radius, _radius, 1);
        _transform.localScale = circleSize;
    }

    /// <summary>
    /// Set new color for sprite renderer.
    /// </summary>
    private void setRandomColor()
    {
        Color newColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        _spriteRenderer.color = newColor;
    }

    #endregion Start sets for Circle

    /// <summary>
    /// Set the velocity of circle to move down.
    /// </summary>
    private void MoveCircleDown()
    {
        Vector2 velocity = Vector2.down;
        _rigidbody.MovePosition(_rigidbody.position + velocity * _speed * Time.fixedDeltaTime);
    }

    /// <summary>
    /// Add points depends on size of circle.
    /// </summary>
    private void AddPointsToPlayer()
    {
        int amountToAdd = (int)Mathf.Round((_maxSize + _minSize) - _radius);
        PlayerStats.AddAmountPoints(amountToAdd);
    }
}