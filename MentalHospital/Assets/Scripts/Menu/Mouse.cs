using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour
{
    private void OnMouseOver()
    {
        GetComponent<Image>().enabled = true;
    }
    private void OnMouseExit()
    {
        GetComponent<Image>().enabled = false;
    }
}
