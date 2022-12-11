using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesDatabase : MonoBehaviour
{
    public List<Move> MovesList = new List<Move>()
    {
        new Move(),

        new Move("Pound", 5, Move.Attribute.Normal, 20, Move.attackType.Regular),

        new Move("Ember", 10, Move.Attribute.Fire, 10, Move.attackType.Regular)
    };

    public enum Moves
    {
        Empty,
        Pound,
        Ember
    }
}
