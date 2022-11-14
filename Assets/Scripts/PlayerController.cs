using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        // Get Mouse input
        if (Input.GetMouseButtonDown(0))
        {
            // Get mouse positon on click
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Convert to x, y positions
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            // Make a raycast
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            // As detect object deletes it.
            if (hit.collider != null)
            {
                EventManager.SendOnClickOnCircle();
                DestroyCircle(hit.collider);
            }
        }
    }

    /// <summary>
    /// Destroy circle object.
    /// </summary>
    /// <param name="collider">Collider of hitted object</param>
    private void DestroyCircle(Collider2D collider)
    {
        Destroy(collider.gameObject);
    }
}