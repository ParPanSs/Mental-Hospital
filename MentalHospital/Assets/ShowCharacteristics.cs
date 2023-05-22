using UnityEngine;

public class ShowCharacteristics : MonoBehaviour
{
    [SerializeField] private GameObject introversion;
    [SerializeField] private GameObject extraversion;
    [SerializeField] private GameObject rationality;
    [SerializeField] private GameObject irrationality;

    private void Start()
    {
        switch (Behaviour.extravert)
        {
            case true:
                extraversion.SetActive(true);
                break;
            default:
                introversion.SetActive(true);
                break;
        }

        switch (Behaviour.rational)
        {
            case true:
                rationality.SetActive(true);
                break;
            default:
                irrationality.SetActive(true);
                break;
        }
    }
}
