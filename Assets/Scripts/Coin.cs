using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] PlayerCoins player;

    void Start()
    {
            player.onCoinTaken += UpdateCoins;
    }

    void UpdateCoins(int coin)
    {
        Debug.Log("monedas recibidas: " + coin);
    }

}
