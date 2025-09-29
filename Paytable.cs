using UnityEngine;
[CreateAssetMenu(fileName = "Paytable", menuName = "SlotMachine/Paytable")]
public class Paytable : ScriptableObject
{
    [System.Serializable]
    public class PayoutEntry
    {
        public SymbolData symbol;
        public int countRequired = 3; 
        public int payoutAmount = 50;
    }
    public PayoutEntry[] payouts;
    public int GetPayout(SymbolData[] result)
    {
        foreach (var entry in payouts)
        {
            int matchCount = 0;
            foreach (var symbol in result)
            {
                if (symbol == entry.symbol) matchCount++;
            }

            if (matchCount >= entry.countRequired)
            {
                return entry.payoutAmount;
            }
        }
        return 0;
    }
}
