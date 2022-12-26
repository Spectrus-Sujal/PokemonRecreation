using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class CombatManager : MonoBehaviour
{
    //
    [SerializeField] private TextMeshProUGUI dialogue;
    [SerializeField] private GameObject playerGO;
    [SerializeField] private GameObject enemyGO;

    static Pokemon player;
    private static int playerIndex = 0;
    static Pokemon enemy;
    private static int enemyIndex = 0;

    private bool gameOver = false;
    public bool gamePaused = false;

   // private bool isPlayerFirst = false;

    void Start()
    {
        Random rand = new Random();

        enemyIndex = rand.Next(PokemonDatabase.PokemonList.Count);

        enemy = new Pokemon(PokemonDatabase.PokemonList[enemyIndex]);

        player = new Pokemon(PokemonDatabase.PokemonList[playerIndex]);
    }

    public Pokemon getPlayer() { return player; }

    public Pokemon getEnemy() { return enemy; }

    public void assignPlayer(Pokemon p, int index)
    {
        player = new Pokemon(p);
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
                
                SceneManager.LoadScene("Fight");
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

                SceneManager.LoadScene("Fight");
            }
        }

        dialogue.text = "Choose your next Move";
        gamePaused = false;

    }

    void autoSelectMove(ref Pokemon attacker, ref Pokemon target)
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
            Move currentMove = MovesDatabase.MovesList[(int)attacker.moves[i]];
            if (target.isWeakTo(currentMove.damageType))
            {
                weight[i]++;
            }
            else if (attacker.isGoodAgainst(currentMove.damageType))
            {
                weight[i]--;
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

    void doMove(MovesDatabase.Moves moveName, Pokemon attacker, Pokemon target)
    {
        Move move = MovesDatabase.MovesList[(int)moveName];
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
                if (target.takeDamage(move.damage, move))
                {
                    gameOver = true;
                }
                break;
        }
    }

}
