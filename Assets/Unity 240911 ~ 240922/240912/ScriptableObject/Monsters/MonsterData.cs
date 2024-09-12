using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Monster")]
public class MonsterData : ScriptableObject
{
    // public int hp와 같이, 각자 다른 데이터를 가지거나 데이터 변동이 있을 경우엔 사용을 지양한다.

    public int maxHP;

    public int attack;
    public int defense;
    public float speed;
    public const float range = 3;

    public Sprite icon;
    public GameObject prefab;

}
