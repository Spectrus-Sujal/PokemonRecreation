using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This contains all Moves and their info
/// </summary>
public class MovesDatabase : MonoBehaviour
{
    /* Instructions to Create a new Move

     1. Write the Move name in the public enum Moves
     2. Write New Move( (String)Name, (int)Damage(Negative if healing), 
                       (AttributeDatabase.Attribute) damageType, 
                       (Move.attackType) Effect)
    */

    // Name of all Moves
    // Used to reference that move from MoveList
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
        SeismicToss,
        Potion,
        Run
    }

    // A list containing all moves and their data
    public static readonly List<Move> MovesList = new List<Move>()
    {
        new Move(),

        new Move("Razor Leaf", 15, AttributeDatabase.Attribute.Grass, Move.attackType.Regular),

        new Move("Ember", 15, AttributeDatabase.Attribute.Fire, Move.attackType.Regular),

        new Move("Water Gun", 15, AttributeDatabase.Attribute.Water, Move.attackType.Regular),

        new Move("Growl", 0, AttributeDatabase.Attribute.Normal, Move.attackType.Debuff),

        new Move("Dragon Dance", 0, AttributeDatabase.Attribute.Normal, Move.attackType.Buff),

        new Move("Scratch", 6, AttributeDatabase.Attribute.Normal, Move.attackType.Regular),

        new Move("Pound", 5, AttributeDatabase.Attribute.Normal, Move.attackType.Regular),

        new Move("Howl", 0, AttributeDatabase.Attribute.Normal, Move.attackType.Debuff),

        new Move("Seismic Toss", 20, AttributeDatabase.Attribute.Fight, Move.attackType.Regular),

        new Move("Potion", 20, AttributeDatabase.Attribute.Normal, Move.attackType.Heal),

        new Move("Run", 0, AttributeDatabase.Attribute.Normal, Move.attackType.Run)
    };

}
