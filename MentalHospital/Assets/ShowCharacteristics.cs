using UnityEngine;

public class ShowCharacteristics : MonoBehaviour
{
    [SerializeField] private GameObject introversion;
    [SerializeField] private GameObject extraversion;
    [SerializeField] private GameObject rationality;
    [SerializeField] private GameObject irrationality;

    private Behaviour _behaviour;

    private void Start()
    {
        _behaviour = FindObjectOfType<Behaviour>();
        switch (_behaviour.firstCharacteristic)
        {
            case Behaviour.Characteristics.Extravert:
                extraversion.SetActive(true);
                break;
            case Behaviour.Characteristics.Introvert:
                introversion.SetActive(true);
                break;
        }

        switch (_behaviour.secondCharacteristic)
        {
            case Behaviour.Characteristics.Rational:
                rationality.SetActive(true);
                break;
            case Behaviour.Characteristics.Irrational:
                irrationality.SetActive(true);
                break;
        }

    }
}
