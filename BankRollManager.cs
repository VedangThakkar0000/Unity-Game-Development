using UnityEngine;

public class BankrollManager : MonoBehaviour
{
    [Header("Bankroll Settings")]
    [SerializeField] private int startingBalance = 1000;
    [SerializeField] private int startingBet = 10;
    [SerializeField] private int minBet = 10;
    [SerializeField] private int maxBet = 100;

    public int Balance { get; private set; }
    public int Bet { get; private set; }

    private void Awake()
    {
        // Load saved values if they exist, otherwise use defaults
        Balance = SaveSystem.LoadBalance(startingBalance);
        Bet = SaveSystem.LoadBet(startingBet);
    }

    public void IncreaseBet()
    {
        if (Bet < maxBet)
        {
            Bet += 10;
            SaveSystem.SaveBet(Bet);
        }
    }

    public void DecreaseBet()
    {
        if (Bet > minBet)
        {
            Bet -= 10;
            SaveSystem.SaveBet(Bet);
        }
    }

    public bool CanAffordSpin()
    {
        return Balance >= Bet;
    }

    public void ApplySpinCost()
    {
        if (CanAffordSpin())
        {
            Balance -= Bet;
            SaveSystem.SaveBalance(Balance);
        }
    }

    public void AddWinnings(int amount)
    {
        Balance += amount;
        SaveSystem.SaveBalance(Balance);
    }

    public void ResetBankroll()
    {
        Balance = startingBalance;
        Bet = startingBet;

        SaveSystem.SaveBalance(Balance);
        SaveSystem.SaveBet(Bet);
    }
}
