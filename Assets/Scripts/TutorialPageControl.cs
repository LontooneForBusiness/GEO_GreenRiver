using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TutorialPageControl : MonoBehaviour
{
    public TutorialSO[] datas;

    public Text title, title_eng;
    public TextMeshProUGUI contentText;

    private int _currentPage = 0;

    private void Start()
    {
        NextPage(0);
    }

    public void NextPage(int opt)
    {
        _currentPage = Mathf.Clamp(_currentPage + opt, 0, datas.Length - 1);

        title.text = datas[_currentPage].title;
        title_eng.text = datas[_currentPage].titleEng;
        contentText.text = datas[_currentPage].content;
    }
}
