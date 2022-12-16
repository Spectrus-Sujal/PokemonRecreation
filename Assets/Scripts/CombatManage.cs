using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class CombatManage : MonoBehaviour
{
    MonsterDatabase monsterData;
    AttributeDatabase attributeData;

    static Monster player;
    private static int playerIndex = 0;
    static Monster enemy;
    private static int enemyIndex = 0;

    private bool gameOver = false;

   // private bool isPlayerFirst = false;


    // Start is called before the first frame update
    void Awake()
    {
        attributeData = GetComponent<AttributeDatabase>();
        monsterData = GetComponent<MonsterDatabase>();
    }

    void Start()
    {
        Random rand = new Random();

        enemyIndex = rand.Next(monsterData.MonstersList.Count);

        enemy = new Monster(monsterData.MonstersList[enemyIndex]);

        player = new Monster(monsterData.MonstersList[playerIndex]);
    }

    public Monster getPlayer()
    {
        return player;
    }

    public Monster getEnemy()
    {
        return enemy;
    }

    public int getPlayerIndex()
    {
        return playerIndex;
    }

    public int getEnemyIndex()
    {
        return enemyIndex;
    }

    public void assignPlayer(Monster p)
    {
        player = new Monster(p);
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
                doMove(playerMove, player, enemy);
            }
        }
        else
        {
            Debug.Log(player.monsterName + " Turn");
            doMove(playerMove,  player,  enemy);

            if (!gameOver)
            {
                Debug.Log(enemy.monsterName + " turn");
                autoSelectMove(ref enemy, ref player);
            }
        }

        Debug.Log("Round Over");
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

        doMove(moveChosen, attacker, target);

    }

    void doMove(Move move, Monster attacker, Monster target)
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
                dealDamage(attacker.getAttack(), target, move);
                break;
        }
    }

    void dealDamage(int attack, Monster target, Move move)
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
