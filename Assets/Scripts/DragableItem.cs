using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DragableItem : MonoBehaviour
{
    public bool isGrabbing = false;
    public string anwser = "";
    public SpriteRenderer img;
    private Vector3 originPos;
    //private const int targetOrder=5;
    //private int originOrder;
    private SpriteRenderer sp;

    Camera camera;
    public void SetAnwser(string _anwser, Sprite _sp)
    {
        anwser = _anwser;
        img.sprite = _sp;
        img.gameObject.SetActive(true);

    }
    private void Start()
    {
        camera = Camera.main;
        originPos = transform.position;
        sp = GetComponent<SpriteRenderer>();
        //originOrder = sp.sortingOrder;

        TouchDetecet.OnTouched += OnGrabStart;
        TouchDetecet.OnTouchEnded += OnGrabEnd;
    }
    private void OnDestroy()
    {
        TouchDetecet.OnTouched -= OnGrabStart;
        TouchDetecet.OnTouchEnded -= OnGrabEnd;
    }

    private void FixedUpdate()
    {

        if (isGrabbing)
        {
            Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }
    }

    private void OnEnable()
    {
        isGrabbing = false;
    }

    public void OnGrabStart(GameObject obj)
    {
        if (obj == gameObject)
        {
            isGrabbing = true;
            //sp.sortingOrder = targetOrder;
            img.color = new Color(1,1,1,0.5f);
        }
    }
    public void OnGrabEnd(GameObject obj)
    {
        if (obj == gameObject)
        {
            isGrabbing = false;
            transform.DOMove(originPos, 0.5f);
            //sp.sortingOrder = originOrder;
            img.color = new Color(1, 1, 1, 1f);
        }
    }

    public void Correct()
    {
        //sp.transform.DOPunchScale(new Vector3(1.5f, 0.5f), 0.2f, vibrato: 5);
        //Invoke("Destory", 0.25f);
        img.gameObject.SetActive(false);
    }

}
