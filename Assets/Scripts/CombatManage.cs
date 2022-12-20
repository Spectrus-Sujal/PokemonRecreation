using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class CombatManage : MonoBehaviour
{
    MovesDatabase moveData;
    MonsterDatabase monsterData;
    AttributeDatabase attributeData;

    [SerializeField] private TextMeshProUGUI dialogue;
    [SerializeField] private GameObject playerGO;
    [SerializeField] private GameObject enemyGO;

    static Monster player;
    private static int playerIndex = 0;
    static Monster enemy;
    private static int enemyIndex = 0;

    private bool gameOver = false;
    public bool gamePaused = false;

   // private bool isPlayerFirst = false;


    // Start is called before the first frame update
    void Awake()
    {
        attributeData = GetComponent<AttributeDatabase>();
        monsterData = GetComponent<MonsterDatabase>();
        moveData = GetComponent<MovesDatabase>();
    }

    void Start()
    {
        Random rand = new Random();

        enemyIndex = rand.Next(monsterData.MonstersList.Count);

        enemy = new Monster(monsterData.MonstersList[enemyIndex]);

        player = new Monster(monsterData.MonstersList[playerIndex]);
    }

    public Monster getPlayer() { return player; }

    public Monster getEnemy() { return enemy; }

    public void assignPlayer(Monster p, int index)
    {
        player = new Monster(p);
        playerIndex = index;
    }

    public IEnumerator startRound(MovesDatabase.Moves playerMove)
    {
        gamePaused = true;

        if (enemy.getSpeed() > player.getSpeed())
        {
            autoSelectMove(ref enemy, ref player);

            yield return new WaitForSeconds(2f);

            if (!gameOver)
            {
                doMove(playerMove, player, enemy);

                yield return new WaitForSeconds(2f);
            }
            else
            {
                dialogue.text = player.monsterName + " has fainted";
                playerGO.SetActive(false);
                yield return new WaitForSeconds(2f);
                
                SceneManager.LoadScene("");
            }
        }
        else
        {
            doMove(playerMove,  player,  enemy);

            yield return new WaitForSeconds(2f);

            if (!gameOver)
            {
                autoSelectMove(ref enemy, ref player);
                yield return new WaitForSeconds(2f);
            }
            else
            {
                dialogue.text = enemy.monsterName + " has fainted";
                enemyGO.SetActive(false);
                yield return new WaitForSeconds(2f);

                SceneManager.LoadScene("");
            }
        }

        dialogue.text = "Choose your next Move";
        gamePaused = false;

        
    }

    void autoSelectMove(ref Monster attacker, ref Monster target)
    {
        int[] weight = {1, 1, 1, 1};

        Random rand = new Random();
        if (attacker.getHealthPercent() < 30 && rand.Next(100) < 70)
        {
            doMove(MovesDatabase.Moves.Potion, attacker, target);
            return;
        }

        for (int i = 0; i < 4; i++)
        {
            Move currentMove = moveData.MovesList[(int)attacker.moves[i]];
            if (target.isWeakTo(attributeData, currentMove.damageType))
            {
                weight[i]--;
            }
            else if (attacker.isGoodAgainst(attributeData, currentMove.damageType))
            {
                weight[i]++;
            }

            if (currentMove.effect == Move.attackType.Regular)
            {
                weight[i]++;
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

        MovesDatabase.Moves moveChosen = attacker.moves[heaviest];

        doMove(moveChosen, attacker, target);  

    }

    void doMove(MovesDatabase.Moves moveName, Monster attacker, Monster target)
    {
        Move move = moveData.MovesList[(int)moveName];
        dialogue.text = attacker.monsterName + " used " + move.moveName;
        switch (move.effect)
        {
            case Move.attackType.Buff:
                dialogue.text += " and buffed itself";
                target.buff(move);
                break;

            case Move.attackType.Debuff:
                dialogue.text += " and put a debuff on  " + target.monsterName;
                target.debuff(move);
                break;

            case Move.attackType.Heal:
                dialogue.text = attacker.monsterName + " used a potion";
                attacker.healthIncrease(move);
                break;

            case Move.attackType.Run:
                Random rand = new Random();
                if (rand.Next(10) < 5)
                {
                    dialogue.text = attacker.monsterName + " ran away successfully";
                }
                else
                {
                    dialogue.text = attacker.monsterName + " could not run away";
                }
                break;

            default:
                dialogue.text += " to attack " + target.monsterName;
                if (target.takeDamage(move.damage, move, attributeData))
                {
                    gameOver = true;
                }
                break;
        }
    }

}
