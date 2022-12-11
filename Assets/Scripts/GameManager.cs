using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    MovesDatabase moveData;
    MonsterDatabase monsterData;


    // Start is called before the first frame update
    void Start()
    {
        moveData = transform.GetComponent<MovesDatabase>();
        monsterData = transform.GetComponent<MonsterDatabase>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(monsterData.MonstersList[(int)MonsterDatabase.Monsters.Treeko].monsterName);
        Debug.Log(moveData.MovesList[(int)MovesDatabase.Moves.Pound].moveName);
    }
}
