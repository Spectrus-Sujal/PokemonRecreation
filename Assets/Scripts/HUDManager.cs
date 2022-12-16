using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    Monster player;
    Monster enemy;
    
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
    private CombatManage cm;

    [SerializeField] private Sprite[] backs;
    [SerializeField] private Sprite[] fronts;

    // Start is called before the first frame update
    void Start()
    {
        cm = CombatManager.GetComponent<CombatManage>();
        player = cm.getPlayer();
        enemy = cm.getEnemy();

        move1.text = player.moves[0].moveName;
        move2.text = player.moves[1].moveName;
        move3.text = player.moves[2].moveName;
        move4.text = player.moves[3].moveName;

        playerName.text = player.monsterName;
        enemyName.text = enemy.monsterName;

        playerTransform.GetComponent<SpriteRenderer>().sprite = backs[cm.getPlayerIndex()];
        enemyTransform.GetComponent<SpriteRenderer>().sprite = fronts[cm.getEnemyIndex()];
    }

    void Update()
    {
        playerHealth.value = (float)player.getHealthPercent();
        enemyHealth.value = (float)enemy.getHealthPercent();
    }

    public Monster getPlayer()
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
}
