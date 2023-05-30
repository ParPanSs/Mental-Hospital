using UnityEngine;
public class Behaviour : MonoBehaviour
{
    public enum FirstCharacteristic
    {
        Introvert,
        Extravert
    }
    public enum SecondCharacteristic
    {
        Rational,
        Irrational
    }
    public enum ThirdCharacteristic
    {
        Optimist,
        Pessimist
    }

    public FirstCharacteristic? firstCharacteristic;
    public SecondCharacteristic? secondCharacteristic;
    public ThirdCharacteristic? thirdCharacteristic;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
