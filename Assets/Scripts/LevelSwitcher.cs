using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown pokSelector;
    public Monster player;

    [SerializeField] private Transform combatManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void assignPokemon(TMP_Dropdown change)
    {
        player = combatManager.GetComponent<MonsterDatabase>().MonstersList[change.value];
        combatManager.GetComponent<CombatManage>().assignPlayer(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadCombat()
    {
        assignPokemon(pokSelector);
        SceneManager.LoadScene("Fight");
    }
}
