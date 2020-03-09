using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Network;

public class LeaderBoardScript : MonoBehaviour
{
    private Transform container, template;
    private int rowsCounter = 0;
    private float templateHeight = 50f;
    void Start()
    {
        container = transform.Find("TemplateContainer");
        template = container.Find("TemplateRow");
        template.gameObject.SetActive(false);
        List<LeaderBoard> leaderBoard = Network.DataHttpSender.GetLeaderBoard();
        foreach(LeaderBoard userScore in leaderBoard)
        {
            rowsCounter++;
            Transform transform = Instantiate(template, container);
            RectTransform rectTransform = transform.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0, -templateHeight * rowsCounter);


            Transform numberRect = rectTransform.Find("TemplateNumber");
            numberRect.GetComponent<Text>().text = rowsCounter.ToString();
            Transform scoreRect = rectTransform.Find("TemplateScore");
            scoreRect.GetComponent<Text>().text = userScore.Score.ToString();
            Transform timeRect = rectTransform.Find("TemplateTime");
            timeRect.GetComponent<Text>().text = userScore.Time.ToString();
            rectTransform.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
