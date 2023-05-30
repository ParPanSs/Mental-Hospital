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
        if (_behaviour.firstCharacteristic != null)
        {
            switch (_behaviour.firstCharacteristic)
            {
                case Behaviour.FirstCharacteristic.Extravert:
                    extraversion.SetActive(true);
                    break;
                default:
                    introversion.SetActive(true);
                    break;
            }
        }

        if (_behaviour.secondCharacteristic != null)
        {
            switch (_behaviour.secondCharacteristic)
            {
                case Behaviour.SecondCharacteristic.Rational:
                    rationality.SetActive(true);
                    break;
                default:
                    irrationality.SetActive(true);
                    break;
            }
        }
    }
}
