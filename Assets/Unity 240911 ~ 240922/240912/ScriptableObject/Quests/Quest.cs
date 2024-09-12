using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ũ���ͺ� ������Ʈ�� ����Ϸ��� �ʼ������� ���ο� ������ ������ �ʿ��ϱ� ������,
// �ش� ������ CreateAssetMenu ��Ʈ����Ʈ�� ���Ͽ� �������� �� �ִ�.
// �ش� ������ ����, ������Ʈ â���� ��Ŭ�� - Createâ�� ���ο� ������ �߰��� ���� �� �� �ִ�.
[CreateAssetMenu(menuName = "Quest/NormalQuestFolder", fileName = "NormalQuest")]
public class Quest : ScriptableObject // = ���� ������Ʈ�ʹ� ������ ������ ���� Ŭ������ �������� �� �ִ� ��� Ŭ����
{
    public string title;
    [TextArea(3, 5)]
    public string description;
    public int exp;
    public int gold;

    public GameObject[] reward;
    public Sprite icon;
    public Color color;
}
