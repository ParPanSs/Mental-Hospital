using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI smileCounter;
    [SerializeField] private TextMeshProUGUI sadCounter;

    [SerializeField] private GameObject[] heads;

    void Update()
    {
        for (int i = 0; i < heads.Length; i++)
        {
            var smile = heads.Where(d => d.GetComponent<SpriteRenderer>().color == Color.green).ToList();
            var sad = heads.Where(d => d.GetComponent<SpriteRenderer>().color == Color.red).ToList();
            smileCounter.text = smile.Count + "/5";
            sadCounter.text = sad.Count + "/5";
        }
    }
}
