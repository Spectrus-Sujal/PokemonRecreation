using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDatabase : MonoBehaviour
{
    MovesDatabase MD;

    public List<Monster> MonstersList = new List<Monster>();

    public enum Monsters
    {
        Treeko,
        Torchic,
        Mudkip,
        Machop,
        Infernape
    }

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
            MovesDatabase.Moves.Empty);

        MonstersList.Add(Treeko);

        Monster Torchic = new Monster("Torchic", AttributeDatabase.Attribute.Fire,
            18, 10, 8, 9,
            MovesDatabase.Moves.Ember,
            MovesDatabase.Moves.Empty,
            MovesDatabase.Moves.Empty,
            MovesDatabase.Moves.Empty);
        
        MonstersList.Add(Torchic);

        Monster Mudkip = new Monster("Mudkip", AttributeDatabase.Attribute.Water,
            24, 5, 14, 6,
            MovesDatabase.Moves.WaterGun,
            MovesDatabase.Moves.Growl,
            MovesDatabase.Moves.Empty,
            MovesDatabase.Moves.Empty);
        
        MonstersList.Add(Mudkip);

        Monster Machop = new Monster("Machop", AttributeDatabase.Attribute.Fight,
            14, 12, 4, 14,
            MovesDatabase.Moves.SeismicToss,
            MovesDatabase.Moves.Pound,
            MovesDatabase.Moves.Scratch,
            MovesDatabase.Moves.Empty);
        
        MonstersList.Add(Machop);

        Monster Infernape = new Monster("Infernape", AttributeDatabase.Attribute.Fire,
            30, 15, 10, 20,
            MovesDatabase.Moves.Ember,
            MovesDatabase.Moves.SeismicToss,
            MovesDatabase.Moves.Pound,
            MovesDatabase.Moves.DragonDance);
        
        MonstersList.Add(Infernape);
    }
}
