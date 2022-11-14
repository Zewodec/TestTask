using UnityEngine;

public class DeleteZone : MonoBehaviour
{
    /// <summary>
    /// Delete object if the object is circle.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Circle"))
        {
            Destroy(collision.gameObject);
        }
    }
}