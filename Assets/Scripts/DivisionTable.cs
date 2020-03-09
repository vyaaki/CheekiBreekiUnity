using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CheekiBreeki;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DivisionTable : MonoBehaviour
{
    private Transform container, template, divTable;
    private CheekiBreekiClass cheekiBreeki;
    private float update;
    private float templateHeight = 50f;
    private int rowsCounter = 1;
    private int interVal = 1;
    public int TotalRows = 100;
    int nextValue;
    private void Awake()
    {
        nextValue = interVal;
        container = transform.Find("TemplateContainer");
        template = container.Find("TemplateRow");

        cheekiBreeki = new CheekiBreekiClass();
        template.gameObject.SetActive(false);

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        update += Time.deltaTime;
        int intUpdate = (int)Mathf.Floor(update);
        if (update>1 && intUpdate == nextValue && rowsCounter< TotalRows)
        {
            nextValue = intUpdate + interVal;
            rowsCounter++;
            Transform transform = Instantiate(template, container);
            RectTransform rectTransform = transform.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0, -templateHeight * rowsCounter);

            
            Transform numberRect = rectTransform.Find("TemplateNumber");
            numberRect.GetComponent<Text>().text=rowsCounter.ToString();
            Transform answerRect = rectTransform.Find("TemplateAnswer");
            answerRect.GetComponent<Text>().text = cheekiBreeki.CheekiBreekiResult(rowsCounter);
            rectTransform.gameObject.SetActive(true);



            //todo Delete
            //RectTransform divTableRect = divTable.GetComponent<RectTransform>();
            //divTableRect.sizeDelta+=new Vector2(0, 50);
        }
    }
}
