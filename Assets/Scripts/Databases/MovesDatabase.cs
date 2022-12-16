using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesDatabase : MonoBehaviour
{
    public List<Move> MovesList = new List<Move>()
    {
        new Move(),

        new Move("Razor Leaf", 15, AttributeDatabase.Attribute.Grass, 10, Move.attackType.Regular),

        new Move("Ember", 15, AttributeDatabase.Attribute.Fire, 10, Move.attackType.Regular),

        new Move("Water Gun", 15, AttributeDatabase.Attribute.Water, 10, Move.attackType.Regular),

        new Move("Growl", 0, AttributeDatabase.Attribute.Normal, 15, Move.attackType.Debuff),

        new Move("Dragon Dance", 0, AttributeDatabase.Attribute.Normal, 10, Move.attackType.Buff),

        new Move("Scratch", 6, AttributeDatabase.Attribute.Normal, 20, Move.attackType.Regular),

        new Move("Pound", 5, AttributeDatabase.Attribute.Normal, 20, Move.attackType.Regular),

        new Move("Howl", 0, AttributeDatabase.Attribute.Normal, 10, Move.attackType.Debuff),

        new Move("Seismic Toss", 20, AttributeDatabase.Attribute.Fight, 12, Move.attackType.Regular)
    };

    public enum Moves
    {
        Empty,
        RazorLeaf,
        Ember,
        WaterGun,
        Growl,
        DragonDance,
        Scratch,
        Pound,
        Howl,
        SeismicToss

    }
}
