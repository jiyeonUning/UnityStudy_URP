using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill")]
public class Skill : ScriptableObject
{
    public string skillName;
    public float coolTime;
    public Sprite icon;

    // 스크립터블 오브젝트는 함수 실행 시에만 한정하여 직렬화를 풀기 때문에, 함수 사용 또한 가능하다.
    // 다만, 코루틴과 같은 일부 유니티 함수는 사용해줄 수 없다.
    public void Use(PlayerController user)
    {
        Debug.Log($"{skillName} 스킬 사용!");
    }
}
