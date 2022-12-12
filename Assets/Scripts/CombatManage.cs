using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CombatManage : MonoBehaviour
{
    MovesDatabase moveData;
    MonsterDatabase monsterData;
    AttributeDatabase attributeData;

    private Monster player;
    private Monster enemy;

    public Transform PlayerObject;
    public Transform EnemyObject;

   // private bool isPlayerFirst = false;


    // Start is called before the first frame update
    void Awake()
    {
        attributeData = GetComponent<AttributeDatabase>();
        moveData = GetComponent<MovesDatabase>();
        monsterData = GetComponent<MonsterDatabase>();
    }

    void Start()
    {
        Invoke("assignMonsters", 0.1f);
    }

    void assignMonsters()
    {
        player = PlayerObject.GetComponent<ThisMonster>().monster;
        enemy = EnemyObject.GetComponent<ThisMonster>().monster;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            autoSelectMove(ref player, ref enemy);
        }
    }

    void startRound(MovesDatabase.Moves playerMove)
    {
        if (enemy.getSpeed() < player.getSpeed())
        {
            autoSelectMove(ref enemy, ref player);
        }
    }

    void autoSelectMove(ref Monster attacker, ref Monster target)
    {
        int[] weight = {1, 1, 1, 1};


        for (int i = 0; i < 4; i++)
        {
            if (target.isWeakTo(attributeData, attacker.moves[i].damageType))
            {
                weight[i]--;
            }
            else if (attacker.isGoodAgainst(attributeData, target.moves[i].damageType))
            {
                weight[i]++;
            }

            if (attacker.moves[i].effect == Move.attackType.Regular)
            {
                weight[i]++;
            }

            for (int j = 0; j < 4; j++)
            {
                if (attacker.moves[i].uses > attacker.moves[j].uses)
                {
                    weight[i]++;
                }
            }
        }

        int heaviest = 0;

        for (int i = 1; i < weight.Length; i++)
        {
            if (weight[i] > weight[heaviest])
            {
                heaviest = i;
            }
        }

        Move moveChosen = attacker.moves[heaviest];

        switch (moveChosen.effect)
        {
            case Move.attackType.Buff:
                buff(ref attacker, moveChosen);
                break;
            case Move.attackType.Debuff:
                debuff(ref target, moveChosen);
                break;
            default:
                dealDamage(ref target, moveChosen);
                break;
        }

    }

    void dealDamage( ref Monster target, Move move)
    {
        if (target.takeDamage(move, attributeData))
        {
            if (target == player) loseGame();
            else winGame();
        }
    }

    void debuff(ref Monster target, Move move)
    {
        target.debuff(move);
    }

    void buff(ref Monster target, Move move)
    {
        target.buff(move);
    }

    void winGame()
    {
        Debug.Log("Game Won");
    }

    void loseGame()
    {
        Debug.Log("Game Lost");
    }

    void showGame()
    {

    }

}
