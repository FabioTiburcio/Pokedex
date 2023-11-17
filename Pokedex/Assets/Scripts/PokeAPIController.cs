using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;
using System;
using System.Data;

public class PokeAPIController : MonoBehaviour
{
    public Pokedex pokedexData;
    private readonly string basePokeURL = "https://pokeapi.co/api/v2/";

    public BroadcasterScript pokedexAttImages;

    private void Start()
    {
        StartCoroutine(FillScriptableObject());
    }

    IEnumerator FillScriptableObject()
    {
        for (int i = 1; i < 808; i++)
        {
            StartCoroutine(GetPokemonAtIndex(i));
            
            StartCoroutine(Delay(i));

            yield return new WaitForSeconds(0.025f);
        }
        
    }

    IEnumerator Delay(int index)
    {
        yield return new WaitForSeconds(0.5f);
        pokedexAttImages.PokedexButtonsAtt(index);
    }
    IEnumerator GetPokemonAtIndex(int pokemonIndex)
    {
        // Get Pokemon Info

        string pokemonURL = basePokeURL + "pokemon/" + pokemonIndex.ToString();
        // Example URL: https://pokeapi.co/api/v2/pokemon/151

        UnityWebRequest pokeInfoRequest = UnityWebRequest.Get(pokemonURL);

        yield return pokeInfoRequest.SendWebRequest();

        if (pokeInfoRequest.isNetworkError || pokeInfoRequest.isHttpError)
        {
            Debug.LogError(pokeInfoRequest.error);
            yield break;
        }

        JSONNode pokeInfo = JSON.Parse(pokeInfoRequest.downloadHandler.text);

        string pokeName = pokeInfo["name"];
        string pokeSpriteURL = pokeInfo["sprites"]["front_default"];

        JSONNode pokeTypes = pokeInfo["types"];
        string[] pokeTypeNames = new string[pokeTypes.Count];

        for (int i = 0, j = pokeTypes.Count - 1; i < pokeTypes.Count; i++, j--)
        {
            pokeTypeNames[j] = pokeTypes[i]["type"]["name"];
        }

        // Get Pokemon Sprite

        UnityWebRequest pokeSpriteRequest = UnityWebRequestTexture.GetTexture(pokeSpriteURL);

        yield return pokeSpriteRequest.SendWebRequest();

        if (pokeSpriteRequest.isNetworkError || pokeSpriteRequest.isHttpError)
        {
            Debug.LogError(pokeSpriteRequest.error);
            yield break;
        }
        
        // Set UI Objects
        string pokemonType = "";
        string pokemonType2 = "";
        for (int i = 0; i < pokeTypeNames.Length; i++)
        {
            
            if(i > 0) 
            {
                pokemonType = CapitalizeFirstLetter(pokeTypeNames[i]);
            }
            else
            {
                if(pokeTypeNames.Length > 1)
                {
                    pokemonType2 = CapitalizeFirstLetter(pokeTypeNames[i]);
                }
                else
                {
                    pokemonType = CapitalizeFirstLetter(pokeTypeNames[i]);
                }
            }
        }
        pokedexData.addNewPokemon(DownloadHandlerTexture.GetContent(pokeSpriteRequest), CapitalizeFirstLetter(pokeName),pokemonIndex.ToString(), pokemonType, pokemonType2);
    }

    private string CapitalizeFirstLetter(string str)
    {
        return char.ToUpper(str[0]) + str.Substring(1);
    }
}
