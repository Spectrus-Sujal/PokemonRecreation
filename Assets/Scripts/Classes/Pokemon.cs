using System.Reflection;
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
    
    public MovesDatabase.Moves move1;
    public MovesDatabase.Moves move2;
    public MovesDatabase.Moves move3;
    public MovesDatabase.Moves move4;

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
        
        this.move1 = mon.move1;
        this.move2 = mon.move2;
        this.move3 = mon.move3;
        this.move4 = mon.move4;

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
        
        this.move1 = one;
        this.move2 = two;
        this.move3 = three;
        this.move4 = four;

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
    void takeDamage(int enemyAttack, Move move)
    {
        // Negative damage means healing
        if(move.damage < 0) 
        {
            currentHealth -= move.damage;
            return;
        }

        // Damage to be taken
        // Take damage based on other stats
        int damage = enemyAttack - defense;

        // Compare attributes
        if (isWeakTo(move.damageType))
        {
            damage += move.damage + (move.damage / 2);
        }
        else if (isGoodAgainst(move.damageType))
        {
            damage += move.damage / 2;
        }
        else
        {
            damage += move.damage;
        }

        if (damage <= 0) damage = 1;

        currentHealth -= damage;
    }

    public bool affectStat(Move move, int enemyAttack)
    {
       switch (move.stat) 
       {
        case Move.statAffected.Health:
            takeDamage(enemyAttack, move);
            break;

        case Move.statAffected.Attack:
            attack -= move.damage;
            break;

        case Move.statAffected.Defense:
            defense -= move.damage;
            break;

        case Move.statAffected.Speed:
            speed -= move.damage;
            break;
       }

       // Minimum of 1
        if (speed < 1) speed = 1;
        if (defense < 1) defense = 1;
        if (attack < 1) attack = 1;

        // Return if Pokemons fainted
        return currentHealth <= 0;
    }
}
