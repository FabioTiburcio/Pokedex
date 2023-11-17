using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Pokedex Data", menuName = "Pokemon/Pokedex Data")]
public class Pokedex : ScriptableObject
{
    [SerializeField]
    public PokemonData[] pokedexList = new PokemonData[808];
    public void addNewPokemon(Texture image, string name, string number, string type1, string type2)
    {
        if (image == null || name == null || number == null || type1 == null || type2 == null)
        {
            // Handle the case where one of the parameters is null
            Debug.LogError("null");
            return;
        }
        PokemonData pokemonData = new PokemonData();
        pokemonData.pokemonImage = image;
        pokemonData.pokemonName = name;
        pokemonData.pokemonNumber = number;
        pokemonData.pokemonType1 = type1;  
        pokemonData.pokemonType2 = type2;
        pokedexList[int.Parse(number)] = pokemonData;
    }
}

public class PokemonData
{
    public Texture pokemonImage;
    public string pokemonName, pokemonNumber, pokemonType1, pokemonType2;

    public void Initialize(Texture image, string name, string number, string type1, string type2)
    {
        pokemonImage = Texture2D.blackTexture;
        pokemonName = "";
        pokemonNumber = "";
        pokemonType1 = "";
        pokemonType2 = "";
    }
}
