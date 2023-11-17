using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PokedexCreateButtons : MonoBehaviour
{
    public GameObject buttonPrefab;
    private GameObject[] buttonsInstantiate = new GameObject[808];
    public Pokedex pokedexData;
    public GameObject loadingPanel;
    public IntEventChannel PokedexAttImages;
    // Start is called before the first frame update
    void Start()
    {
        PokedexAttImages.OnEventRaised += UpdateImages;
        for (int i = 1; i < 808; i++)
        {
            GameObject buttoninstantiated = Instantiate(buttonPrefab, this.transform);
            buttoninstantiated.GetComponentInChildren<RawImage>().texture = Texture2D.blackTexture;
            buttonsInstantiate[i] = buttoninstantiated;
            buttoninstantiated.GetComponent<ButtonNumber>().buttonNumber = i;
        }
    }
    private void OnDestroy()
    {
        PokedexAttImages.OnEventRaised -= UpdateImages;
    }

    public void UpdateImages(int index)
    {
        Debug.Log("Update Images");
        RawImage pokeimage = buttonsInstantiate[index].GetComponentInChildren<RawImage>();
        pokeimage.texture = pokedexData.pokedexList[index].pokemonImage;
        if(index >= 300)
        {
            loadingPanel.SetActive(false);
        }
        //for (int i = 1; i < 808; i++)
        //{
        //    RawImage pokeimage = buttonsInstantiate[i].GetComponentInChildren<RawImage>();
        //    pokeimage.texture = pokedexData.pokedexList[i].pokemonImage;

        //}
    }
}
