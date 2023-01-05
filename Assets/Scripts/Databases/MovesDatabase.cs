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
                       (Move.statAffected) stat)
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
        DragonPulse
    }

    // A list containing all moves and their data
    public static readonly List<Move> MovesList = new List<Move>()
    {
        new Move(),

        new Move("Razor Leaf", 7, AttributeDatabase.Attribute.Grass, Move.statAffected.Health),

        new Move("Ember", 7, AttributeDatabase.Attribute.Fire, Move.statAffected.Health),

        new Move("Water Gun", 7, AttributeDatabase.Attribute.Water, Move.statAffected.Health),

        new Move("Growl", -1, AttributeDatabase.Attribute.Normal, Move.statAffected.Attack),

        new Move("Dragon Dance", 1, AttributeDatabase.Attribute.Dragon, Move.statAffected.Speed),

        new Move("Scratch", 3, AttributeDatabase.Attribute.Normal, Move.statAffected.Health),

        new Move("Pound", 3, AttributeDatabase.Attribute.Normal, Move.statAffected.Health),

        new Move("Howl", 1, AttributeDatabase.Attribute.Normal, Move.statAffected.Attack),

        new Move("Seismic Toss", 7, AttributeDatabase.Attribute.Fight, Move.statAffected.Health),

        new Move("Potion", -20, AttributeDatabase.Attribute.Normal, Move.statAffected.Health),

        new Move("DragonPulse", 9, AttributeDatabase.Attribute.Dragon, Move.statAffected.Health)
    };

}
