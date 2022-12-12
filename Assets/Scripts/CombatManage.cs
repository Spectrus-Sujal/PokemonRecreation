using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManage : MonoBehaviour
{
    MovesDatabase moveData;
    MonsterDatabase monsterData;

    private Monster player;
    private Monster enemy;

    public Transform PlayerObject;
    public Transform EnemyObject;


    // Start is called before the first frame update
    void Start()
    {
        moveData = GetComponent<MovesDatabase>();
        monsterData = GetComponent<MonsterDatabase>();

        player = PlayerObject.GetComponent<ThisMonster>().me;
        enemy = EnemyObject.GetComponent<ThisMonster>().me;

        if (enemy.speed < player.speed)
        {
            enemy.isTurn = true;
        }
        else
        {
            player.isTurn = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            dealDamage(ref player, MovesDatabase.Moves.Ember);
        }
    }

    void dealDamage( ref Monster target, MovesDatabase.Moves move)
    {
        target.takeDamage(moveData.MovesList[(int)move]);
    }

    void changeTurn()
    {
        player.isTurn = !player.isTurn;
        enemy.isTurn = !enemy.isTurn;
    }
}
