using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown pokSelector;

    [SerializeField] private Transform combatManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void assignPokemon(TMP_Dropdown change)
    {
        combatManager.GetComponent<CombatManager>().assignPlayer(change.value);
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
