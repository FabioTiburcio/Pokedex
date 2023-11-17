using UnityEngine;

public class BroadcasterScript : MonoBehaviour
{
    public IntEventChannel infoButtonChannel;
    public IntEventChannel pokedexButtonsAttChannel;
    // Update is called once per frame

    public void InfoButtonClicked(int value)
    {
        infoButtonChannel.RaiseEvent(value);
    }

    public void PokedexButtonsAtt(int value)
    {
        pokedexButtonsAttChannel.RaiseEvent(value);
    }
}
