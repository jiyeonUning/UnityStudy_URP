using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill")]
public class Skill : ScriptableObject
{
    public string skillName;
    public float coolTime;
    public Sprite icon;

    // ��ũ���ͺ� ������Ʈ�� �Լ� ���� �ÿ��� �����Ͽ� ����ȭ�� Ǯ�� ������, �Լ� ��� ���� �����ϴ�.
    // �ٸ�, �ڷ�ƾ�� ���� �Ϻ� ����Ƽ �Լ��� ������� �� ����.
    public void Use(PlayerController user)
    {
        Debug.Log($"{skillName} ��ų ���!");
    }
}
