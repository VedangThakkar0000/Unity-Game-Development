using UnityEngine;
[CreateAssetMenu(fileName = "SymbolData", menuName = "SlotMachine/Symbol")]
public class SymbolData : ScriptableObject
{
    public string symbolName;
    public Sprite icon;
    public int payoutValue = 1; // base payout multiplier
    [Range(1, 100)] public int weight = 10; // probability weight
}
