using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Initialize : MonoBehaviour
{
    static Monster player;
    static Monster enemy;
    
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private Slider playerHealth;
    [SerializeField] private TextMeshProUGUI enemyName;
    [SerializeField] private Slider enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        
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

    public void assignPlayer(Monster p)
    {
        player = p;
    }
}
