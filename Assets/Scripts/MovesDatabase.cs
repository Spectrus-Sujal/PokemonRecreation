using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesDatabase : MonoBehaviour
{
    public List<Move> MovesList = new List<Move>()
    {
        new Move(),

        new Move("Razor Leaf", 5, AttributeDatabase.Attribute.Grass, 20, Move.attackType.Regular),

        new Move("Ember", 10, AttributeDatabase.Attribute.Fire, 10, Move.attackType.Regular)
    };

    public enum Moves
    {
        Empty,
        RazorLeaf,
        Ember
    }
}
