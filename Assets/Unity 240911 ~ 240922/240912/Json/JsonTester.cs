using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// 값을 저장 - 불러오기를 용이하게 사용하기 위한 클래스
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

    // 사용 예제
    private void exStart()
    {
        // 텍스트값을 가져올 수 있다.
        string json = JsonUtility.ToJson(gameData);

        // 텍스트로 값을 작성
        string Writejson = "{\"name\":\"김전사\",\"level\":1,\"rate\":0.5}";
        // 위에서 작성한 값을 텍스트로 변환한다.
        gameData = JsonUtility.FromJson<GameData>(json);
    }

    //================================================================================
    //                          Save & Load 기능 구현 예제

    private void Update()
    {
        // A 키 입력 시, 세이브가 진행된다.
        if (Input.GetKeyDown(KeyCode.A)) { Save(); }
        // D 키 입력 시, 가장 최근 이루어진 세이브 파일에 대한 로드가 진행된다.
        if (Input.GetKeyDown(KeyCode.D)) { Load(); }
    }

    [ContextMenu("Save")]
    void Save()
    {
        // Save를 파일로 저장해두기 위해, 해당 파일을 저장할 폴더를 탐색한다.
        string path = $"{Application.dataPath}/Unity 240911 ~ 240922/240912/Json/makeFolder/Save";
        // 경로에 해당 폴더가 존재하지 않는다면, 해당 경로에 Save 파일을 추가한다.
        if (Directory.Exists(path) == false) { Directory.CreateDirectory(path); }

        // 현재 정보값을 가져와 json에 저장하고,
        string json = JsonUtility.ToJson(gameData);
        // 저장한 json 값을 세이브 파일에 옮겨적음으로써 값을 저장할 수 있다.
        File.WriteAllText($"{path}/save.txt", json);
    }

    [ContextMenu("Load")]
    void Load()
    {
        // 저장한 값을 보관한 세이브 파일을 탐색한다.
        string path = $"{Application.dataPath}/Unity 240911 ~ 240922/240912/Json/makeFolder/Save/save.txt";
        // 탐색 결과가 없었을 때, 로드를 진행하지 않는다.
        if (File.Exists(path) == false) { Debug.Log("불러올 세이브 파일이 존재하지 않습니다."); return; }

        // 찾은 세이브 파일의 값을 읽어내리고,
        string json = File.ReadAllText(path);
        // 게임 데이터에 해당 값을 가져와 현재 값에 붙여넣음으로써 불러오기를 진행할 수 있었다.
        gameData = JsonUtility.FromJson<GameData>(json);
    }
}
