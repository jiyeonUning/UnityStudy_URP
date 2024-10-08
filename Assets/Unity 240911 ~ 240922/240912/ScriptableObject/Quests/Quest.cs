using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 스크립터블 오브젝트를 사용하려면 필수적으로 새로운 폴더와 파일이 필요하기 때문에,
// 해당 조건을 CreateAssetMenu 어트리뷰트를 통하여 생성해줄 수 있다.
// 해당 과정을 통해, 프로젝트 창에서 우클릭 - Create창에 새로운 에셋이 추가된 것을 알 수 있다.
[CreateAssetMenu(menuName = "Quest/NormalQuestFolder", fileName = "NormalQuest")]
public class Quest : ScriptableObject // = 게임 오브젝트와는 별개의 정보를 지닌 클래스를 생성해줄 수 있는 상속 클래스
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

// 스크립터블 오브젝트 주의사항 :
// 1. 스크립터블 오브젝트는 값의 변경에 매우 민감하기 때문에, 값 변경에 유의해야 한다.
// 2. 스크립터블 오브젝트는 기본적으로 파일 형식으로 생성이 되기 때문에, 플레이 진행 중 변경된 에셋값은 초기화 되지 않으므로 변경에 유의해야한다.
