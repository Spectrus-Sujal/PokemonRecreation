using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown pokSelector;

    [SerializeField] private Transform combatManager;
    private CombatManager cm;

    // Start is called before the first frame update
    void Start()
    {
        cm = combatManager.GetComponent<CombatManager>();

        pokSelector.options = new List<TMP_Dropdown.OptionData>();

        foreach (Pokemon pokemon in cm.pokemons)
        {
            pokSelector.options.Add(new TMP_Dropdown.OptionData(pokemon.pokemonName));
        }
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
