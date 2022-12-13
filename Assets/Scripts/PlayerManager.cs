using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI move1;
    [SerializeField] TextMeshProUGUI move2;
    [SerializeField] TextMeshProUGUI move3;
    [SerializeField] TextMeshProUGUI move4;

    private Monster player;

    private ThisMonster th;

    [SerializeField] Transform combatManager;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("initialize", 0.1f);
    }

    void initialize()
    {
        th = GetComponent<ThisMonster>();
        player = th.monster;
        move1.text = player.moves[0].moveName;
        move2.text = player.moves[1].moveName;
        move3.text = player.moves[2].moveName;
        move4.text = player.moves[3].moveName;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doMove1()
    {
        combatManager.GetComponent<CombatManage>().startRound(player.moves[0]);
    }

    public void doMove2()
    {
        combatManager.GetComponent<CombatManage>().startRound(player.moves[1]);
    }

    public void doMove3()
    {
        combatManager.GetComponent<CombatManage>().startRound(player.moves[2]);
    }

    public void doMove4()
    {
        combatManager.GetComponent<CombatManage>().startRound(player.moves[3]);
    }
}
