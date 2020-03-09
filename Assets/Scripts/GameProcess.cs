using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CheekiBreeki;
using Network;
using System.Diagnostics;

public class GameProcess : MonoBehaviour
{
    Stopwatch sw = new Stopwatch();
    public int MinRndVal = 1;
    public int MaxRndVal = 100;
    private string answer = "";
    private int newNumber;
    private int ScoreCounter = 0;
    Transform newNumberTransform, numberButtonTransform;
    Text textField, numButtonText;
    CheekiBreekiClass cheekiBreeki;
    // Start is called before the first frame update
    void Start()
    {
        newNumberTransform = transform.Find("NumericValue");
        textField = newNumberTransform.GetComponent<Text>();
        numberButtonTransform = transform.Find("NumberButton");
        numButtonText = numberButtonTransform.GetComponentInChildren<Text>();
        GenerateAndShowNewNumber();
        sw.Start();
        cheekiBreeki = new CheekiBreekiClass();
    }


    void GenerateAndShowNewNumber()
    {
        newNumber = Random.Range(MinRndVal, MaxRndVal);
        textField.text = newNumber.ToString();
        numButtonText.text = newNumber.ToString();
    }

    public void OnEnterButtonClick(Button btn)
    {
        string CorrectAnswer = cheekiBreeki.CheekiBreekiResult(newNumber).ToLower();
        answer = btn.GetComponentInChildren<Text>().text.ToLower();

        if(answer != CorrectAnswer)
        {
            sw.Stop();
            DataHttpSender.CreateUserScore(new LeaderBoard((sw.Elapsed).TotalSeconds, ScoreCounter));
            SceneManager.LoadScene(0);
        }
        else {
            ScoreCounter++;
            GenerateAndShowNewNumber();
        }
    }
}
