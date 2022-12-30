using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script containing all Pokemons and their information
/// as well as where new Pokemons are added
/// </summary>
public class PokemonDatabase : MonoBehaviour
{
    /* Instructions to Create a new Pokemons

     1. Write the Pokemon name in the public enum Pokemons
     2. Increase number of Pokemon in Header on line 47
     3. Add Sprite of Pokemon from the back to MonsterSpritesBack
     4. Add Sprite of Pokemon from the front to MonsterSpritesFront
     5. Write Pokemon (Pokemon Name) =  New Pokemon(
                          (String) Name, 
                          (AttributeDatabase.Attribute) Type,
                          (int) Max Health, (int) Speed, 
                          (int) Attack, (int) Defense,
                          (MoveDatabase.Move) Move 1, 
                          (MoveDatabase.Move) Move 2, 
                          (MoveDatabase.Move) Move 3,
                          (MoveDatabase.Move) Move 4,
                          (from MonsterSpritesBack) Backside Pose, 
                          (from MonsterSpritesFront) Front side pose)
    6. Write PokemonList.Add((Pokemon Name used in step 5))

    */

    // List containing all Pokemons
    public static readonly List<global::Pokemon> PokemonList = new List<global::Pokemon>();

    // Names of Pokemons created
    // Used to access Pokemons from PokemonList
    public enum Pokemons
    {
        Treeko,
        Torchic,
        Mudkip,
        Machop,
        Infernape
    }

    // Indication for number of monsters in editor
    [Header("Number of Pokemons: 5")]

    [Header("Pokemons Sprites")]
    // Sprites used for monsters 
    // Must be added in the editor
    public List<Sprite> MonsterSpritesBack;
    public List<Sprite> MonsterSpritesFront;

    // Add monsters to MonsterList as soon as game starts
    // Due to other scripts needing to load before this

    void Awake()
    {
        addMonsters();
    }

    // Method where all monsters are added
    public void addMonsters()
    {
        Pokemon Treeko = new Pokemon(
            "Treeko", 
            AttributeDatabase.Attribute.Grass,
            20, 8, 10, 7,
            MovesDatabase.Moves.RazorLeaf,
            MovesDatabase.Moves.Empty,
            MovesDatabase.Moves.Empty,
            MovesDatabase.Moves.Empty,
            MonsterSpritesBack[(int)Pokemons.Treeko],
            MonsterSpritesFront[(int)Pokemons.Treeko]);

        PokemonList.Add(Treeko);

        Pokemon Torchic = new Pokemon(
            "Torchic", 
            AttributeDatabase.Attribute.Fire,
            18, 10, 8, 9,
            MovesDatabase.Moves.Ember,
            MovesDatabase.Moves.Empty,
            MovesDatabase.Moves.Empty,
            MovesDatabase.Moves.Empty,
            MonsterSpritesBack[(int)Pokemons.Torchic], 
            MonsterSpritesFront[(int)Pokemons.Torchic]);
        
        PokemonList.Add(Torchic);

        Pokemon Mudkip = new Pokemon(
            "Mudkip", 
            AttributeDatabase.Attribute.Water,
            24, 5, 14, 6,
            MovesDatabase.Moves.WaterGun,
            MovesDatabase.Moves.Growl,
            MovesDatabase.Moves.Empty,
            MovesDatabase.Moves.Empty,
            MonsterSpritesBack[(int)Pokemons.Mudkip], 
            MonsterSpritesFront[(int)Pokemons.Mudkip]);
        
        PokemonList.Add(Mudkip);

        Pokemon Machop = new Pokemon(
            "Machop", 
            AttributeDatabase.Attribute.Fight,
            14, 12, 4, 14,
            MovesDatabase.Moves.SeismicToss,
            MovesDatabase.Moves.Pound,
            MovesDatabase.Moves.Scratch,
            MovesDatabase.Moves.Empty,
            MonsterSpritesBack[(int)Pokemons.Machop],
            MonsterSpritesFront[(int)Pokemons.Machop]);
        
        PokemonList.Add(Machop);

        Pokemon Infernape = new Pokemon(
            "Infernape", 
            AttributeDatabase.Attribute.Fire,
            30, 15, 10, 20,
            MovesDatabase.Moves.Ember,
            MovesDatabase.Moves.SeismicToss,
            MovesDatabase.Moves.Howl,
            MovesDatabase.Moves.DragonDance,
            MonsterSpritesBack[(int)Pokemons.Infernape],
            MonsterSpritesFront[(int)Pokemons.Infernape]);
        
        PokemonList.Add(Infernape);
    }
}
