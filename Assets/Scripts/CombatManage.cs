using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
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

    [SerializeField] private Slider playerHealth;
    [SerializeField] private Slider enemyHealth;

    private bool gameOver = false;

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
        
    }

    public void startRound(Move playerMove)
    {
        if (enemy.getSpeed() < player.getSpeed())
        {
            Debug.Log(enemy.monsterName + " Turn");
            autoSelectMove(ref enemy, ref player);

            if (!gameOver)
            {
                Debug.Log(player.monsterName + " turn");
                doMove(playerMove, ref player, ref enemy);
            }
        }
        else
        {
            Debug.Log(player.monsterName + " Turn");
            doMove(playerMove, ref player, ref enemy);

            if (!gameOver)
            {
                Debug.Log(enemy.monsterName + " turn");
                autoSelectMove(ref enemy, ref player);
            }
        }

        playerHealth.value = (float)player.getHealthPercent();
        enemyHealth.value = (float)enemy.getHealthPercent();

        Debug.Log("Next Turn");
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

        doMove(moveChosen, ref attacker, ref target);

    }

    void doMove(Move move, ref Monster attacker, ref Monster target)
    {
        switch (move.effect)
        {
            case Move.attackType.Buff:
                Debug.Log("Buffed " + attacker.monsterName);
                buff(ref attacker, move);
                break;
            case Move.attackType.Debuff:
                Debug.Log("DeBuffed " + target.monsterName);
                debuff(ref target, move);
                break;
            default:
                Debug.Log("Attacked " + target.monsterName);
                dealDamage(attacker.getAttack(), ref target, move);
                break;
        }
    }

    void dealDamage(int attack, ref Monster target, Move move)
    {
        if (target.takeDamage(attack, move, attributeData))
        {
            if (target == player) loseGame();
            else winGame();
            gameOver = true;
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
