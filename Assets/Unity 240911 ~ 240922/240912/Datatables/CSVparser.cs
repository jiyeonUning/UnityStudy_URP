using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

// 값을 저장 - 불러오기를 용이하게 사용하기 위한 클래스
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
    // 사용 예제
    private void FindAwake()
    {
        // Directory = 폴더
        //   File    = 파일

        // 검색할 폴더의 경로를 복사하고,
        string path = "C:\\Users\\USER\\Desktop\\GIT\\기타\\UnityStudy_URP\\Assets\\Unity 240911 ~ 240922\\240912\\Datatables";
        // 해당 폴더 안에 찾고있는 파일이 존재하는지 true false로 판단할 수 있다.
        bool exist = Directory.Exists(path);

        // or 해당 프로그램이 설치되어 있는 곳의 정보를 자동으로 가져올 수 있다.
        // 프로젝트를 개발중일 때 주로 사용해준다
        string ExPath = Application.dataPath;

        // or 개인 로컬 저장소 경로를 통해 파일을 찾기 때문에,
        // 게임 제작이 완료된 후에는 파일을 찾는 코드를 해당 코드로 바꿔주어야만 한다.
        // (사용자마다 저장 경로가 다를 수 있기 때문)
        string persPath = Application.persistentDataPath;
    }

    public Dictionary<int, WeaponData> weaponDatas = new Dictionary<int, WeaponData>();

    private void Awake()
    {
        string path = $"{Application.dataPath}/Unity 240911 ~ 240922/240912/Datatables";

        if (Directory.Exists(path) == false) { Debug.LogError("경로가 없습니다."); return; }
        if (File.Exists($"{path}/Datatable.csv") == false) { Debug.LogError("파일이 없습니다."); return; }

        // 위에서 찾은 경로의 파일들을 string 배열로 나열한다.
        // 추가적으로 확장명이나, 파일 이름을 통해 해당 조건을 만족하는 파일들만 찾아줄 수도 있다.
        // string[] files = Directory.GetFiles(path, ".csv");

        // 배열이 아닌 특정 파일만 가져와 읽어내리는 코드
        string file = File.ReadAllText($"{path}/Datatable.csv");

        // 특정한 기준으로 텍스트를 배열별로 나누어 사용해줄 수 있다.
        // 해당 코드는 줄바꿈을 기준으로 둬서 텍스트를 나누었다.
        string[] lines = file.Split('\n');

        // Datatable.csv에 작성된 내용을 토대로 무기들의 정보값을 가져오는 for 반복문
        for (int y = 1; y < lines.Length; y++)
        {
            WeaponData weaponData = new WeaponData();

            // , 와 를 기준으로 하여, 위에서 나눈 배열을 한 번 더 나누었다.
            string[] values = lines[y].Split(',', '\t');

            // 각 내용의 정보값을 입력 후,
            weaponData.index = int.Parse(values[0]);
            weaponData.name = values[1];
            weaponData.attack = int.Parse(values[2]);
            weaponData.defense = int.Parse(values[3]);
            weaponData.description = values[4];
           
            // 위에서 선언하였던 List에 보관한다.
            weaponDatas.Add(weaponData.index, weaponData);
        }
    }
}