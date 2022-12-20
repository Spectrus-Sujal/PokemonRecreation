using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script containing all monsters and their information
/// as well as where new monsters are added
/// </summary>
public class MonsterDatabase : MonoBehaviour
{
    MovesDatabase MD;

    [Header("Number of Monsters: 5")]

    public List<Monster> MonstersList = new List<Monster>();

    public enum Monsters
    {
        Treeko,
        Torchic,
        Mudkip,
        Machop,
        Infernape
    }

    [Header("Monster Sprites")]
    public List<Sprite> MonsterSpritesBack = new List<Sprite>();
    public List<Sprite> MonsterSpritesFront = new List<Sprite>();

    void Awake()
    {
        MD = GetComponent<MovesDatabase>();
        addMonsters();
    }

    public void addMonsters()
    {
        Monster Treeko = new Monster("Treeko", AttributeDatabase.Attribute.Grass,
            20, 8, 10, 7,
            MovesDatabase.Moves.RazorLeaf,
            MovesDatabase.Moves.Empty,
            MovesDatabase.Moves.Empty,
            MovesDatabase.Moves.Empty,
            MonsterSpritesBack[0], MonsterSpritesFront[0]);

        MonstersList.Add(Treeko);

        Monster Torchic = new Monster("Torchic", AttributeDatabase.Attribute.Fire,
            18, 10, 8, 9,
            MovesDatabase.Moves.Ember,
            MovesDatabase.Moves.Empty,
            MovesDatabase.Moves.Empty,
            MovesDatabase.Moves.Empty,
            MonsterSpritesBack[1], MonsterSpritesFront[1]);
        
        MonstersList.Add(Torchic);

        Monster Mudkip = new Monster("Mudkip", AttributeDatabase.Attribute.Water,
            24, 5, 14, 6,
            MovesDatabase.Moves.WaterGun,
            MovesDatabase.Moves.Growl,
            MovesDatabase.Moves.Empty,
            MovesDatabase.Moves.Empty,
            MonsterSpritesBack[2], MonsterSpritesFront[2]);
        
        MonstersList.Add(Mudkip);

        Monster Machop = new Monster("Machop", AttributeDatabase.Attribute.Fight,
            14, 12, 4, 14,
            MovesDatabase.Moves.SeismicToss,
            MovesDatabase.Moves.Pound,
            MovesDatabase.Moves.Scratch,
            MovesDatabase.Moves.Empty,
            MonsterSpritesBack[3], MonsterSpritesFront[3]);
        
        MonstersList.Add(Machop);

        Monster Infernape = new Monster("Infernape", AttributeDatabase.Attribute.Fire,
            30, 15, 10, 20,
            MovesDatabase.Moves.Ember,
            MovesDatabase.Moves.SeismicToss,
            MovesDatabase.Moves.Howl,
            MovesDatabase.Moves.DragonDance,
            MonsterSpritesBack[4], MonsterSpritesFront[4]);
        
        MonstersList.Add(Infernape);
    }
}
