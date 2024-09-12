using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

// ���� ���� - �ҷ����⸦ �����ϰ� ����ϱ� ���� Ŭ����
[System.Serializable]
public struct WeaponData
{
    public int index;
    public string name;
    public int attack;
    public int defense;
    public string description;
}

public class CSVparser : MonoBehaviour
{
    // ��� ����
    private void FindAwake()
    {
        // Directory = ����
        //   File    = ����

        // �˻��� ������ ��θ� �����ϰ�,
        string path = "C:\\Users\\USER\\Desktop\\GIT\\��Ÿ\\UnityStudy_URP\\Assets\\Unity 240911 ~ 240922\\240912\\Datatables";
        // �ش� ���� �ȿ� ã���ִ� ������ �����ϴ��� true false�� �Ǵ��� �� �ִ�.
        bool exist = Directory.Exists(path);

        // or �ش� ���α׷��� ��ġ�Ǿ� �ִ� ���� ������ �ڵ����� ������ �� �ִ�.
        // ������Ʈ�� �������� �� �ַ� ������ش�
        string ExPath = Application.dataPath;

        // or ���� ���� ����� ��θ� ���� ������ ã�� ������,
        // ���� ������ �Ϸ�� �Ŀ��� ������ ã�� �ڵ带 �ش� �ڵ�� �ٲ��־�߸� �Ѵ�.
        // (����ڸ��� ���� ��ΰ� �ٸ� �� �ֱ� ����)
        string persPath = Application.persistentDataPath;
    }

    public Dictionary<int, WeaponData> weaponDatas = new Dictionary<int, WeaponData>();

    private void Awake()
    {
        string path = $"{Application.dataPath}/Unity 240911 ~ 240922/240912/Datatables";

        if (Directory.Exists(path) == false) { Debug.LogError("��ΰ� �����ϴ�."); return; }
        if (File.Exists($"{path}/Datatable.csv") == false) { Debug.LogError("������ �����ϴ�."); return; }

        // ������ ã�� ����� ���ϵ��� string �迭�� �����Ѵ�.
        // �߰������� Ȯ����̳�, ���� �̸��� ���� �ش� ������ �����ϴ� ���ϵ鸸 ã���� ���� �ִ�.
        // string[] files = Directory.GetFiles(path, ".csv");

        // �迭�� �ƴ� Ư�� ���ϸ� ������ �о���� �ڵ�
        string file = File.ReadAllText($"{path}/Datatable.csv");

        // Ư���� �������� �ؽ�Ʈ�� �迭���� ������ ������� �� �ִ�.
        // �ش� �ڵ�� �ٹٲ��� �������� �ּ� �ؽ�Ʈ�� ��������.
        string[] lines = file.Split('\n');

        // Datatable.csv�� �ۼ��� ������ ���� ������� �������� �������� for �ݺ���
        for (int y = 1; y < lines.Length; y++)
        {
            WeaponData weaponData = new WeaponData();

            // , �� �� �������� �Ͽ�, ������ ���� �迭�� �� �� �� ��������.
            string[] values = lines[y].Split(',', '\t');

            // �� ������ �������� �Է� ��,
            weaponData.index = int.Parse(values[0]);
            weaponData.name = values[1];
            weaponData.attack = int.Parse(values[2]);
            weaponData.defense = int.Parse(values[3]);
            weaponData.description = values[4];
           
            // ������ �����Ͽ��� List�� �����Ѵ�.
            weaponDatas.Add(weaponData.index, weaponData);
        }
    }
}