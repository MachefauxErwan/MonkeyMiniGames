using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monkey", menuName = "Monkey/New monkey")]
public class MonkeyData : ScriptableObject
{
        public string MonkeyName;
        public Sprite visualIcone;
        public Sprite panelMonkey;
        public GameObject prefab3D;
}
