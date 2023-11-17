using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PokeInfoScreen : MonoBehaviour
{
    public Pokedex pokedexInfo;
    public GameObject allPokemonPanel;
    public GameObject selectedPanelpokemon;

    public RawImage pokemonImage;
    public TextMeshProUGUI pokemonName, pokemonNumber, pokemonType1, pokemonType2;

    public IntEventChannel ShowPokeInfoChannel;

    private void Start()
    {
        ShowPokeInfoChannel.OnEventRaised += ShowPokemonInfo;
    }

    private void OnDestroy()
    {
        ShowPokeInfoChannel.OnEventRaised -= ShowPokemonInfo;
    }
    public void ShowPokemonInfo(int number)
    {
        allPokemonPanel.SetActive(false);
        selectedPanelpokemon.SetActive(true);
        pokemonImage.texture = pokedexInfo.pokedexList[number].pokemonImage;
        pokemonName.text = pokedexInfo.pokedexList[number].pokemonName;
        pokemonNumber.text = pokedexInfo.pokedexList[number].pokemonNumber;
        pokemonType1.text = pokedexInfo.pokedexList[number].pokemonType1;
        pokemonType2.text = pokedexInfo.pokedexList[number].pokemonType2;
    }
}
