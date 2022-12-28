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
    
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private Slider playerHealth;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private TextMeshProUGUI enemyName;
    [SerializeField] private Slider enemyHealth;
    [SerializeField] private Transform enemyTransform;

    
    [SerializeField] TextMeshProUGUI move1;
    [SerializeField] TextMeshProUGUI move2;
    [SerializeField] TextMeshProUGUI move3;
    [SerializeField] TextMeshProUGUI move4;

    [SerializeField] private Transform CombatManager;
    private CombatManager cm;

    // Start is called before the first frame update
    void Start()
    {
        cm = CombatManager.GetComponent<CombatManager>();
        player = cm.getPlayer();
        enemy = cm.getEnemy();

        move1.text = player.moves[0].ToString();
        move2.text = player.moves[1].ToString();
        move3.text = player.moves[2].ToString();
        move4.text = player.moves[3].ToString();

        playerName.text = player.pokemonName;
        enemyName.text = enemy.pokemonName;

        playerTransform.GetComponent<SpriteRenderer>().sprite = player.backPose;
        enemyTransform.GetComponent<SpriteRenderer>().sprite = enemy.frontPose;
    }

    void Update()
    {
        playerHealth.value = (float)player.getHealthPercent();
        enemyHealth.value = (float)enemy.getHealthPercent();
    }

    public Pokemon getPlayer()
    {
        return player;
    }

    public void doMove1()
    {
        if (cm.gamePaused) return;
        cm.StartCoroutine(cm.startRound(player.moves[0]));
    }

    public void doMove2()
    {
        if (cm.gamePaused) return;
        cm.StartCoroutine(cm.startRound(player.moves[1]));
    }

    public void doMove3()
    {
        if (cm.gamePaused) return;
        cm.StartCoroutine(cm.startRound(player.moves[2]));
    }

    public void doMove4()
    {
        if (cm.gamePaused) return;
        cm.StartCoroutine(cm.startRound(player.moves[3]));
    }

    public void usePotion()
    {
        if (cm.gamePaused) return;
        cm.StartCoroutine(cm.startRound(MovesDatabase.Moves.Potion));
    }

    public void runAway()
    {
        if (cm.gamePaused) return;
        cm.StartCoroutine(cm.startRound(MovesDatabase.Moves.Run));
    }
}
