using System.Collections;
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
    private Behaviour _behaviour;

    private void Start()
    {
        _behaviour = FindObjectOfType<Behaviour>();
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
                _behaviour.AddCharacteristic(Characteristics.Optimist);
                _behaviour.thirdCharacteristic = Characteristics.Optimist;
                optimistCharacteristic.enabled = true;
            }
            else
            {
                _behaviour.AddCharacteristic(Characteristics.Pessimist);
                _behaviour.thirdCharacteristic = Characteristics.Pessimist;
                pessimistCharacteristic.enabled = true;
            }

        }
    }

    private IEnumerator NextDay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
