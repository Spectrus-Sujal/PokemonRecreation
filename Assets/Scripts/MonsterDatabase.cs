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
        Torchic
    }

    void Start()
    {
        MD = transform.GetComponent<MovesDatabase>();
        addMonsters();
    }

    void addMonsters()
    {
        Monster Treeko = new Monster("Treeko",
            20, 8, 10, 7,
            MD.MovesList[(int)MovesDatabase.Moves.Pound],
            MD.MovesList[(int)MovesDatabase.Moves.Empty],
            MD.MovesList[(int)MovesDatabase.Moves.Empty],
            MD.MovesList[(int)MovesDatabase.Moves.Empty]);

        MonstersList.Add(Treeko);

        Monster Torchic = new Monster("Torchic",
            18, 10, 8, 9,
            MD.MovesList[(int)MovesDatabase.Moves.Pound],
            MD.MovesList[(int)MovesDatabase.Moves.Empty],
            MD.MovesList[(int)MovesDatabase.Moves.Empty],
            MD.MovesList[(int)MovesDatabase.Moves.Empty]);
        
        MonstersList.Add(Torchic);
    }
}
