# PokemonRecreation

## Description 
This project is a recreation of the comabt system of the classic Pokemon games. You are able to modularly create as many Pokemons, Moves, and attributes in the editor without needing
to touch the combat or enemy code at all.


## Dependencies
This recreation of Pokemon was made using Unity 2021.3.6f1

### Creating New Objects

Steps to Create a new Pokemon
<ol>
 <li> Right click in the Assets/Pokemons folder and click Create -> Pokemon
 <li> Give the prefab a name
 <li> Assign the Pokemon its Attribue, Stats and Moves, Sprites
 <li> Open the CombatManager prefab in Assets/Prefabs -> Press + iunder Pokemons -> Drag and Drop you new Pokemon in the list -> Save
</ol>

Steps to Create a new Move
<ol>
 <li> Go to Assets/Databases/MoveDatabase
 <li> Write the Move name in the public enum Moves
 <li> Write New Move( (String)Name, (int)Damage(Negative if healing), (AttributeDatabase.Attribute) damageType, (Move.statAffected) stat)
 <li> Save
</ol>

Steps to Create a new Attribute
<ol>
 <li> Go to Assets/Databases/AttributeDatabase
 <li> Write the Attribute name in the public enum Attributes
 <li> Write New Attribute(Attribute.(Attribute name from The first step), Attribute.(The attribute that this is weak to),
 Attribute.(The attribute that this is good against))
 <li> Save
</ol>

## License
I own no rights to Pokemon and they are owned by Nintendo
