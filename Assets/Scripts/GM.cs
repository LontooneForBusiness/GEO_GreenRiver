using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class GM : MonoBehaviour
{
    //問題集
    public QuesetSet[] quests;
    public TextMeshProUGUI title;
    public Text opt1Text, opt2Text;
    public SpriteRenderer optSp1, optSp2;
    public DragableItem opt1, opt2;
    private int currentIndex = 0;

    public Transform[] bgPos;
    public Transform bg;

    public Text counterText;

    public static int s_timeUsed = 0;
    private float _startTime;
    private float timeCounter;

    public void Start()
    {
        AnwserSlot.OnCorrectGolbal += Correct;
        s_timeUsed = 0;
        _startTime = Time.time;

        CloseHints();
        OpenHints(0);
        //開始
        NextQuestion();
    }

    private void FixedUpdate()
    {
        timeCounter += Time.fixedDeltaTime;
        counterText.text = Mathf.FloorToInt(Time.time - _startTime).ToString();
        //Debug.Log(Time.time - _startTime);
    }
    private void OnDestroy()
    {
        AnwserSlot.OnCorrectGolbal -= Correct;
    }

    private void Correct()
    {
        Debug.Log("答對");

        CloseHints();
        currentIndex++;
        if (currentIndex < quests.Length)
        {
            OpenHints(currentIndex);
            NextQuestion();
        }
        else
        {
            //結束
            s_timeUsed =(int) (Time.time - _startTime);
            SceneManager.LoadScene("End");
        }
    }

    private void NextQuestion()
    {
        //currentIndex++;
        //抽下一題型
        int _randIndex = Random.Range(0, quests[currentIndex].sets.Length);

        //設定題目
        var _currentQuest = quests[currentIndex].sets[_randIndex];
        title.text = _currentQuest.title;
        opt1.SetAnwser(_currentQuest.opts[0].anwserName, _currentQuest.opts[0].img);
        opt2.SetAnwser(_currentQuest.opts[1].anwserName, _currentQuest.opts[1].img);

        opt1Text.text = _currentQuest.opts[0].infoText;
        opt2Text.text = _currentQuest.opts[1].infoText;

        MoveBG(_currentQuest.bgPosName);
    }

    private void CloseHints()
    {
        for (int i = 0; i < quests.Length; i++)
        {
            quests[i].anwserHint.gameObject.SetActive(false);
        }
        //quests[_i].anwserHint.gameObject.SetActive(false);
    }
    private void OpenHints(int _i)
    {
        quests[_i].anwserHint.gameObject.SetActive(true);
    }

    public void MoveBG(string posName)
    {
        //找到目的
        Transform target = bgPos.First(x => x.gameObject.name == posName);

        //移動地圖
        bg.transform.DOMove(target.position, 1.5f);

    }


    //每題有多個隨機題型
    [System.Serializable]
    public struct QuesetSet
    {
        public QuestSO[] sets;
        public Transform anwserHint;
    }
}
