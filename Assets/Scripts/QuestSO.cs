using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName ="quest")]
public class QuestSO : ScriptableObject
{
    public string title;

    public string bgPosName;

    public opt[] opts;
    [System.Serializable]
    public struct opt
    {
        public Sprite img;
        public string anwserName;
        public string infoText;
    }

}


