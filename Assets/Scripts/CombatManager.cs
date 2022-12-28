using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

/// <summary>
/// Handle all aspects of turn-based combat between two Pokemon.
/// This includes executing all moves as well as update the state of both Pokemon.
/// As well as handle player input if they try to escape from the other pokemon,
/// Attack it, or heal themselves.
/// </summary>
public class CombatManager : MonoBehaviour
{
    //Visual indication of change in state
    [SerializeField] private TextMeshProUGUI dialogue;

    //Used for making one invisible when lose
    [SerializeField] private GameObject playerGO;
    [SerializeField] private GameObject enemyGO;

    //Player reference in PokemonDatabase
    static Pokemon player;
    private static int playerIndex = 0;
    static Pokemon enemy;
    private static int enemyIndex = 0;

    //Game state
    private bool gameOver = false;
    public bool gamePaused = false;

   // private bool isPlayerFirst = false;

    void Start()
    {
        // Fail safe if player is not assigned
        // Default to first Pokemon in PokemonList
        if (player == null)
        {
            assignPlayer(playerIndex);
        }

        // Assign a new enemy whenever combat starts
        Random rand = new Random();
        enemyIndex = rand.Next(PokemonDatabase.PokemonList.Count);
        enemy = new Pokemon(PokemonDatabase.PokemonList[enemyIndex]);
    }

    public Pokemon getPlayer() { return player; }

    public Pokemon getEnemy() { return enemy; }

    public void assignPlayer(int index)
    {
        playerIndex = index;
        player = new Pokemon(PokemonDatabase.PokemonList[playerIndex]);
    }

    // Go through core combat
    // Player and enemy take turns doing moves
    // The faster one goes first
    public IEnumerator startRound(MovesDatabase.Moves playerMove)
    {
        // Stop player from doing other things
        gamePaused = true;

        // Time between moves
        float pauseTime = 2;

        // Check who is faster
        if (enemy.getSpeed() > player.getSpeed())
        {
            // Select and do the enemy move
            autoSelectMove(ref enemy, ref player);

            // Pause
            yield return new WaitForSeconds(pauseTime);

            // Check if game has ended
            if (gameOver)
            {
                // Show player has fainted
                dialogue.text = player.pokemonName + " has fainted";
                // Make player disappear
                playerGO.SetActive(false);

                yield return new WaitForSeconds(pauseTime);

                // Restart Game
                SceneManager.LoadScene("Choose");
            }
            else
            {
                // Do the players move
                doMove(playerMove, player, enemy);
                
                yield return new WaitForSeconds(pauseTime);
            }
        }
        else // if Player is faster
        {
            doMove(playerMove,  player,  enemy);

            yield return new WaitForSeconds(pauseTime);

            if (gameOver)
            {
                dialogue.text = enemy.pokemonName + " has fainted";
                enemyGO.SetActive(false);
                yield return new WaitForSeconds(pauseTime);

                SceneManager.LoadScene("Fight");
            }
            else
            {
                // Choose and do enemy move
                autoSelectMove(ref enemy, ref player);

                yield return new WaitForSeconds(pauseTime);
            }
        }

        // Prompt player for next move
        dialogue.text = "Choose your next Move";
        // Return control to player
        gamePaused = false;

    }

    // Select a move for the enemy based on the player
    void autoSelectMove(ref Pokemon attacker, ref Pokemon target)
    {
        int[] weight = {1, 1, 1, 1};

        Random rand = new Random();

        // If low Health
        // High chance of choosing to heal
        if (attacker.getHealthPercent() < 30 && rand.Next(100) < 70)
        {
            // Use a potion
            doMove(MovesDatabase.Moves.Potion, attacker, target);
            return;
        }

        // Go through all other moves
        for (int i = 0; i < 4; i++)
        {
            // Get the move currently being checked
            Move currentMove = MovesDatabase.MovesList[(int)attacker.moves[i]];

            // Move is effective against player
            if (target.isWeakTo(currentMove.damageType))
            {
                // Increase priority of this move
                weight[i]++;
            }
            // Move is not effective
            else if (attacker.isGoodAgainst(currentMove.damageType))
            {
                // Decrease priority
                weight[i]--;
            }

            // Move involves attacking
            if (currentMove.effect == Move.attackType.Regular)
            {
                weight[i]++;
            }
        }

        // Set first move to heaviest
        int heaviest = 0;

        for (int i = 1; i < weight.Length; i++)
        {
            // find the move with highest priority
            if (weight[i] > weight[heaviest])
            {
                // Change position of highest priority
                heaviest = i;
            }
        }

        // Set highest priority to chosen move
        MovesDatabase.Moves moveChosen = attacker.moves[heaviest];

        // Execute the move
        doMove(moveChosen, attacker, target);  

    }

    // Execute a move based on who is using it and on who
    void doMove(MovesDatabase.Moves moveName, Pokemon attacker, Pokemon target)
    {
        // Set reference to move ding done
        Move move = MovesDatabase.MovesList[(int)moveName];

        // Output to player what move is being used by which pokemon
        dialogue.text = attacker.pokemonName + " used " + move.moveName;

        // Call methods based on the moves effect
        // Attack, heal, Buff, etc.
        switch (move.effect)
        {
            // Increase the user stats
            case Move.attackType.Buff:
                // Declare what is being done to player
                dialogue.text += " and increased it's stats";
                target.buff(move);
                break;

            // Reduce targets stats
            case Move.attackType.Debuff:
                dialogue.text += " and put and decreased the stats of " 
                                 + target.pokemonName;
                target.debuff(move);
                break;

            // Heal user
            case Move.attackType.Heal:
                dialogue.text = attacker.pokemonName 
                                + " used " + move.moveName + " to heal itself";
                attacker.healthIncrease(move);
                break;

            // Player tries to escape from the enemy
            case Move.attackType.Run:

                // 50% chance to succeed
                Random rand = new Random();
                if (rand.Next(10) < 5)
                {
                    dialogue.text = attacker.pokemonName 
                                    + " ran away successfully";
                }
                else
                {
                    dialogue.text = attacker.pokemonName 
                                    + " could not run away";
                }
                break;
            
            // Attack the target
            default:
                dialogue.text += " to attack " + target.pokemonName;
                //Check if the target is 0hp after attack
                if (target.takeDamage(move.damage, move))
                {
                    // End combat
                    gameOver = true;
                }
                break;
        }
    }

}
