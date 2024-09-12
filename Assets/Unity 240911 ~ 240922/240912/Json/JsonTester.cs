using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// ���� ���� - �ҷ����⸦ �����ϰ� ����ϱ� ���� Ŭ����
[System.Serializable]
public class GameData
{
    public string name;
    public int level;
    public int exp;
    public float rate;
}

public class JsonTester : MonoBehaviour
{
    [SerializeField] GameData gameData;

    // ��� ����
    private void exStart()
    {
        // �ؽ�Ʈ���� ������ �� �ִ�.
        string json = JsonUtility.ToJson(gameData);

        // �ؽ�Ʈ�� ���� �ۼ�
        string Writejson = "{\"name\":\"������\",\"level\":1,\"rate\":0.5}";
        // ������ �ۼ��� ���� �ؽ�Ʈ�� ��ȯ�Ѵ�.
        gameData = JsonUtility.FromJson<GameData>(json);
    }

    //================================================================================
    //                          Save & Load ��� ���� ����

    private void Update()
    {
        // A Ű �Է� ��, ���̺갡 ����ȴ�.
        if (Input.GetKeyDown(KeyCode.A)) { Save(); }
        // D Ű �Է� ��, ���� �ֱ� �̷���� ���̺� ���Ͽ� ���� �ε尡 ����ȴ�.
        if (Input.GetKeyDown(KeyCode.D)) { Load(); }
    }

    [ContextMenu("Save")]
    void Save()
    {
        // Save�� ���Ϸ� �����صα� ����, �ش� ������ ������ ������ Ž���Ѵ�.
        string path = $"{Application.dataPath}/Unity 240911 ~ 240922/240912/Json/makeFolder/Save";
        // ��ο� �ش� ������ �������� �ʴ´ٸ�, �ش� ��ο� Save ������ �߰��Ѵ�.
        if (Directory.Exists(path) == false) { Directory.CreateDirectory(path); }

        // ���� �������� ������ json�� �����ϰ�,
        string json = JsonUtility.ToJson(gameData);
        // ������ json ���� ���̺� ���Ͽ� �Ű��������ν� ���� ������ �� �ִ�.
        File.WriteAllText($"{path}/save.txt", json);
    }

    [ContextMenu("Load")]
    void Load()
    {
        // ������ ���� ������ ���̺� ������ Ž���Ѵ�.
        string path = $"{Application.dataPath}/Unity 240911 ~ 240922/240912/Json/makeFolder/Save/save.txt";
        // Ž�� ����� ������ ��, �ε带 �������� �ʴ´�.
        if (File.Exists(path) == false) { Debug.Log("�ҷ��� ���̺� ������ �������� �ʽ��ϴ�."); return; }

        // ã�� ���̺� ������ ���� �о����,
        string json = File.ReadAllText(path);
        // ���� �����Ϳ� �ش� ���� ������ ���� ���� �ٿ��������ν� �ҷ����⸦ ������ �� �־���.
        gameData = JsonUtility.FromJson<GameData>(json);
    }
}
