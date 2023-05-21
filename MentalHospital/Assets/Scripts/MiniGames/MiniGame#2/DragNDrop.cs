using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    private bool isDragging;
    private Vector3 startPosition;
    private Transform startParent;

    private void Start()
    {
        startPosition = transform.position;
        startParent = transform.parent;
    }

    private void OnMouseDown()
    {
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, -1f);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);

        bool isOverSlot = false;

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Slot"))
            {
                if (collider.gameObject.transform.childCount == 1)
                {
                    transform.position = startPosition;
                }
                else
                {
                    collider.transform.GetComponent<SpriteRenderer>().enabled = false;
                    transform.position = new Vector3(collider.transform.position.x,
                        collider.transform.position.y, -1);
                    transform.SetParent(collider.transform);
                    isOverSlot = true;
                    break;
                }
            }
        }

        if (!isOverSlot)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }

    }

    
}