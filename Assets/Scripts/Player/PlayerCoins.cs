using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    public delegate void OnCoinTaken(int amount);
    public event OnCoinTaken onCoinTaken;
    [SerializeField] Coin _coins;
    private int _totalCoins;

    public void AddCoins(int Coins)
    {
        _totalCoins += Coins;
        //Debug.Log("monedas del jugador: " + _totalCoins);
        

        onCoinTaken?.Invoke(_totalCoins);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (_coins != null)
        {
            AddCoins(10);
        }
    }
}
