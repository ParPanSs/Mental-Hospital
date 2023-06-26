using System.Collections.Generic;
using UnityEngine;

public enum Characteristics
{
    Introvert,
    Extravert,
    Rational,
    Irrational,
    Optimist,
    Pessimist,
}

public class Behaviour : MonoBehaviour
{ 
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
