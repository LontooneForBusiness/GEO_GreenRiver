using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class AnwserSlot : MonoBehaviour
{
    //public GameObject correctObj;
    public string anwser = "";
    public Collider2D checkRange;

    public UnityEvent OnCorrect;
    public UnityEvent OnWrong;

    public static event Action OnCorrectGolbal;

    private void Start()
    {
        //correctObj.SetActive(false);
        //checkRange = GetComponent<Collider2D>();
        TouchDetecet.OnTouchEnded += Check;
    }
    private void OnDestroy()
    {
        TouchDetecet.OnTouchEnded -= Check;
    }
    private void Check(GameObject obj)
    {
        //檢查滑鼠位置
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!checkRange.OverlapPoint(mouseWorldPos))
        {
            return;
        }


        DragableItem _itme = obj.GetComponent<DragableItem>();
        if (_itme != null && _itme.anwser == anwser )
        {
            //答對
            //correctObj.SetActive(true);
            _itme.Correct();
            OnCorrect?.Invoke();
            OnCorrectGolbal?.Invoke();
            PointController.AddPoint(1, 0);
        }
        else {
            //答錯
            OnWrong?.Invoke();
        }
    }


}
