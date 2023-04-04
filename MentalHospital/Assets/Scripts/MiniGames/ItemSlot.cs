using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    /*private bool isOccupied = false;
    private DragNDrop draggableObject;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<DragNDrop>() != null && !isOccupied)
        {
            draggableObject = col.gameObject.GetComponent<DragNDrop>();
            isOccupied = true;
            draggableObject.transform.position = transform.position;
            draggableObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<DragNDrop>() != null)
        {
            isOccupied = false;
            draggableObject.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }*/
}