using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDatabase : MonoBehaviour
{
    MovesDatabase MD;
    private Move m;

    public List<Monster> MonstersList = new List<Monster>();

    public enum Monsters
    {
        Treeko,
        Torchic
    }

    void Awake()
    {
        MD = GetComponent<MovesDatabase>();
        addMonsters();
    }

    void addMonsters()
    {
        Monster Treeko = new Monster("Treeko", AttributeDatabase.Attribute.Grass,
            20, 8, 10, 7,
            MD.MovesList[(int)MovesDatabase.Moves.RazorLeaf],
            MD.MovesList[(int)MovesDatabase.Moves.Empty],
            MD.MovesList[(int)MovesDatabase.Moves.Empty],
            MD.MovesList[(int)MovesDatabase.Moves.Empty]);

        MonstersList.Add(Treeko);

        Monster Torchic = new Monster("Torchic", AttributeDatabase.Attribute.Fire,
            18, 10, 8, 9,
            MD.MovesList[(int)MovesDatabase.Moves.Ember],
            MD.MovesList[(int)MovesDatabase.Moves.Empty],
            MD.MovesList[(int)MovesDatabase.Moves.Empty],
            MD.MovesList[(int)MovesDatabase.Moves.Empty]);
        
        MonstersList.Add(Torchic);

        Monster Mudkip = new Monster("Mudkip", AttributeDatabase.Attribute.Water,
            18, 10, 8, 9,
            MD.MovesList[(int)MovesDatabase.Moves.Ember],
            MD.MovesList[(int)MovesDatabase.Moves.Empty],
            MD.MovesList[(int)MovesDatabase.Moves.Empty],
            MD.MovesList[(int)MovesDatabase.Moves.Empty]);
        
        MonstersList.Add(Mudkip);
    }
}
