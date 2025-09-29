using UnityEngine;

public static class SaveSystem
{
    public static void SaveBalance(int balance)
    {
        PlayerPrefs.SetInt("Balance", balance);
        PlayerPrefs.Save();
    }
    public static int LoadBalance(int defaultValue = 1000)
    {
        return PlayerPrefs.GetInt("Balance", defaultValue);
    }
    public static void SaveBet(int bet)
    {
        PlayerPrefs.SetInt("Bet", bet);
        PlayerPrefs.Save();
    }
    public static int LoadBet(int defaultValue = 10)
    {
        return PlayerPrefs.GetInt("Bet", defaultValue);
    }
    public static void SaveAutoSpin(bool isOn)
    {
        PlayerPrefs.SetInt("AutoSpin", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
    public static bool LoadAutoSpin(bool defaultValue = false)
    {
        return PlayerPrefs.GetInt("AutoSpin", defaultValue ? 1 : 0) == 1;
    }
}
