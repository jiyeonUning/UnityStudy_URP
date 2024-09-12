using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Monster")]
public class MonsterData : ScriptableObject
{
    // public int hp�� ����, ���� �ٸ� �����͸� �����ų� ������ ������ ���� ��쿣 ����� �����Ѵ�.

    public int maxHP;

    public int attack;
    public int defense;
    public float speed;
    public const float range = 3;

    public Sprite icon;
    public GameObject prefab;

}
