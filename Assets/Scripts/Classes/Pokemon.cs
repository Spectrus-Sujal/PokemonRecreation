using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

/// <summary>
/// The basis for all Pokemons, containing 
/// all components a Pokemons needs
/// </summary>

[CreateAssetMenu(fileName = "NewPokemon", menuName = "Pokemon")]

public class Pokemon : ScriptableObject
{
    ////////// Stats //////////
    public string pokemonName;
    public AttributeDatabase.Attribute type;
    public int maxHealth;
    public int speed;
    public int attack;
    public int defense;

    private int currentHealth;

    public MovesDatabase.Moves[] moves;

    // Player Side
    public Sprite backPose;
    // Enemy Side
    public Sprite frontPose;
    //////////      //////////

    //Constructors 
    // Make a new monster based on an existing one
    public Pokemon(Pokemon mon)
    {
        this.pokemonName = mon.pokemonName;
        this.type = mon.type;
        this.maxHealth = mon.maxHealth;
        currentHealth = mon.maxHealth;
        this.speed = mon.speed;
        this.attack = mon.attack;
        this.defense = mon.defense;

        this.moves = new MovesDatabase.Moves[4];
        this.moves[0] = mon.moves[0];
        this.moves[1] = mon.moves[1];
        this.moves[2] = mon.moves[2];
        this.moves[3] = mon.moves[3];

        this.backPose = mon.backPose;
        this.frontPose = mon.frontPose;
    }

    // New monster with all stats
    public Pokemon(string pokemonName, AttributeDatabase.Attribute type, 
        int maxHealth, int speed, int attack, int defense, 
        MovesDatabase.Moves one, MovesDatabase.Moves two, 
        MovesDatabase.Moves three, MovesDatabase.Moves four,
        Sprite back, Sprite front)
    {
        this.pokemonName = pokemonName;
        this.type = type;
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
        this.speed = speed;
        this.attack = attack;
        this.defense = defense;

        this.moves = new MovesDatabase.Moves[4];
        this.moves[0] = one;
        this.moves[1] = two;
        this.moves[2] = three;
        this.moves[3] = four;

        this.backPose = back;
        this.frontPose = front;
    }

    // Compare move attribute to Pokemons attribute
    public bool isWeakTo(AttributeDatabase.Attribute move)
    {
        return AttributeDatabase.isWeakTo(type, move);
    }

    public bool isGoodAgainst(AttributeDatabase.Attribute move)
    {
        return AttributeDatabase.isGoodAgainst(type, move);
    }

    // Accessors
    public int getSpeed()
    {
        return speed;
    }

    public int getAttack()
    {
        return attack;
    }

    // current health compared to max
    public double getHealthPercent()
    {
        return ((double)currentHealth / maxHealth) * 100;
    }

    // Change Pokemons stats based on Moves effect(attack type)

    // Reduce health based move attribute and Pokemons attribute
    public bool takeDamage(int attack, Move move)
    {
        // Damage to be taken
        // Take damage based on other stats
        int damage = move.damage + attack - defense;

        // Compare attributes
        if (isWeakTo(move.damageType))
        {
            damage = move.damage + (move.damage / 2);
        }
        else if (isGoodAgainst(move.damageType))
        {
            damage = move.damage / 2;
        }
        else
        {
            damage = move.damage;
        }

        if (damage < 0) damage = 0;

        currentHealth -= damage;

        // Return if Pokemons fainted
        return currentHealth <= 0;
    }

    // Increase health
    public void healthIncrease(Move move)
    {
        // heals damage amount
        currentHealth += move.damage;

        // Make sure current health is not over max
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }

    // Reduce stats
    public void debuff(Move move)
    {
        speed -= 2;
        defense -= 2;
        attack -= 2;

        // Minimum of 1
        if (speed < 1) speed = 1;
        if (defense < 1) defense = 1;
        if (attack < 1) attack = 1;
    }

    // Increase stats
    public void buff(Move move)
    {
        speed += 2;
        defense += 2;
        attack += 2;
    }
}
