using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisMonster : MonoBehaviour
{
    public MonsterDatabase.Monsters thisOne;
    public Monster monster;
    
    public Transform CombatManager;

    // Start is called before the first frame update
    void Start()
    {
        monster = CombatManager.GetComponent<MonsterDatabase>().MonstersList[(int)thisOne];
        this.name = monster.monsterName;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
