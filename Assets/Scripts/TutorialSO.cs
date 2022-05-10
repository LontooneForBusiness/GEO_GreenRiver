using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "tutorial")]
public class TutorialSO : ScriptableObject
{
    public string title;
    public string titleEng;
    [TextArea(20,30)]
    public string content;
}
