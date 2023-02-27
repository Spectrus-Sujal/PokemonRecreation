using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    Pokemon player;
    Pokemon enemy;
    
    [Header("Player")]
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private Slider playerHealth;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private TextMeshProUGUI playerHealthNum;

    [SerializeField] private TextMeshProUGUI winCounter;

    [SerializeField] TextMeshProUGUI move1;
    [SerializeField] TextMeshProUGUI move2;
    [SerializeField] TextMeshProUGUI move3;
    [SerializeField] TextMeshProUGUI move4;

    [Header("Enemy")]
    [SerializeField] private TextMeshProUGUI enemyName;
    [SerializeField] private Slider enemyHealth;
    [SerializeField] private Transform enemyTransform;
    [SerializeField] private TextMeshProUGUI enemyHealthNum;

    [Header("Combate Manager")]
    [SerializeField] private Transform CombatManage;
    private CombatManager cm;

    // Start is called before the first frame update
    void Start()
    {
        cm = CombatManage.GetComponent<CombatManager>();
        player = cm.getPlayer();
        enemy = cm.getEnemy();

        move1.text = player.move1.ToString();
        move2.text = player.move2.ToString();
        move3.text = player.move3.ToString();
        move4.text = player.move4.ToString();

        playerName.text = player.pokemonName;
        enemyName.text = enemy.pokemonName;

        playerTransform.GetComponent<SpriteRenderer>().sprite = player.backPose;
        enemyTransform.GetComponent<SpriteRenderer>().sprite = enemy.frontPose;

        winCounter.text = "Number of Wins: " + CombatManager.playerWins;

    }

    void Update()
    {
        playerHealth.value = (float)player.getHealthPercent();
        enemyHealth.value = (float)enemy.getHealthPercent();

        int health = (int)(player.maxHealth * (player.getHealthPercent() / 100));

        if (health < 0) health = 0;

        playerHealthNum.text = health.ToString();

        health = (int)(enemy.maxHealth * (enemy.getHealthPercent() / 100));

        if (health < 0) health = 0;
        enemyHealthNum.text = health.ToString();
    }

    public Pokemon getPlayer()
    {
        return player;
    }

    public void doMove1()
    {
        if (cm.gamePaused) return;
        cm.StartCoroutine(cm.startRound(player.move1));
    }

    public void doMove2()
    {
        if (cm.gamePaused) return;
        cm.StartCoroutine(cm.startRound(player.move2));
    }

    public void doMove3()
    {
        if (cm.gamePaused) return;
        cm.StartCoroutine(cm.startRound(player.move3));
    }

    public void doMove4()
    {
        if (cm.gamePaused) return;
        cm.StartCoroutine(cm.startRound(player.move4));
    }

    public void usePotion()
    {
        if (cm.gamePaused) return;
        cm.StartCoroutine(cm.startRound(MovesDatabase.Moves.Potion));
    }

    public void runAway()
    {
        if (cm.gamePaused) return;
        cm.runAway = true;
        cm.StartCoroutine(cm.startRound(MovesDatabase.Moves.Empty));
    }
}
