using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 velocity = Vector2.down;
        _rigidbody.MovePosition(_rigidbody.position + velocity * _speed * Time.fixedDeltaTime);
    }
}
