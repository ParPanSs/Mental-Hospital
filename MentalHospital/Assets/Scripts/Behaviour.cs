using System.Collections.Generic;
using UnityEngine;
public class Behaviour : MonoBehaviour
{
    // public enum FirstCharacteristic
    // {
    //     Introvert,
    //     Extravert
    // }
    // public enum SecondCharacteristic
    // {
    //     Rational,
    //     Irrational
    // }
    // public enum ThirdCharacteristic
    // {
    //     Optimist,
    //     Pessimist
    // }

    public enum Characteristics
    {
        Introvert,
        Extravert,
        Rational,
        Irrational,
        Optimist,
        Pessimist,
    }

    public Characteristics? firstCharacteristic;
    public Characteristics? secondCharacteristic;
    public Characteristics? thirdCharacteristic;

    public List<Characteristics?> characteristicsList;

    private void Start()
    {
        characteristicsList = new List<Characteristics?>();
        DontDestroyOnLoad(gameObject);
    }

    public void AddCharacteristic(Characteristics? characteristic)
    {
        characteristicsList.Add(characteristic);
    }
}
