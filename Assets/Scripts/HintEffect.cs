using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HintEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sp =gameObject.GetComponent<SpriteRenderer>();
        Color _c = sp.color;
        sp.color = new Color();
    }

}
