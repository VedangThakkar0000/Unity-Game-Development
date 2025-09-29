using UnityEngine;
[CreateAssetMenu(fileName = "ReelConfig", menuName = "SlotMachine/ReelConfig")]
public class ReelConfig : ScriptableObject
{
    [System.Serializable]
    public class ReelEntry
    {
        public SymbolData symbol;
        public int weight = 1;
    }
    public ReelEntry[] symbols;
    public SymbolData GetRandomSymbol()
    {
        int totalWeight = 0;
        foreach (var entry in symbols)
        {
            totalWeight += entry.weight;
        }
        int roll = Random.Range(0, totalWeight);
        foreach (var entry in symbols)
        {
            if (roll < entry.weight)
            {
                return entry.symbol;
            }
            roll -= entry.weight;
        }
        return symbols[0].symbol;
    }
}
