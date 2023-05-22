using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI smileCounter;
    [SerializeField] private TextMeshProUGUI sadCounter;
    [SerializeField] private Sprite[] headSprites;
    [SerializeField] private GameObject[] heads;
    [SerializeField] private Animator pessimistCharacteristic;
    [SerializeField] private Animator optimistCharacteristic;
    [SerializeField] private Animator blackBack;

    private void Start()
    {
        PlayerPrefs.SetInt("DayCounter", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
    }
    private void Update()
    {
        for (int i = 0; i < heads.Length; i++)
        {
            var smile = heads.Where(d => d.GetComponent<SpriteRenderer>().sprite == headSprites[0]).ToList();
            var sad = heads.Where(d => d.GetComponent<SpriteRenderer>().sprite == headSprites[1]).ToList();
            smileCounter.text = smile.Count + "/5";
            sadCounter.text = sad.Count + "/5";
        }

        if (smileCounter.text == "5/5" || sadCounter.text == "5/5")
        {
            blackBack.enabled = true;
            if (smileCounter.text == "5/5")
            {
                Behaviour.optimist = true;
                optimistCharacteristic.enabled = true;
            }
            else
            {
                pessimistCharacteristic.enabled = true;
            }
        }
    }
}
