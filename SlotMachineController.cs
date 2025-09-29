using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachineController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private BankrollManager bankrollManager;
    [SerializeField] private UIController uiController;

    [Header("Reels")]
    [SerializeField] private ReelConfig[] reels;
    [SerializeField] private Paytable paytable;

    [Header("UI Images for Reels")]
    [SerializeField] private Image[] reelImages;

    [Header("Animation Settings")]
    [SerializeField] private float spinDuration = 1.0f;
    [SerializeField] private float spinDelay = 0.3f;  
    [SerializeField] private float autoSpinDelay = 0.5f;  

    private bool isSpinning = false; 
    public void Spin()
    {
        if (isSpinning) return;
        if (!bankrollManager.CanAffordSpin())
        {
            Debug.Log("Not enough balance!");
            return;
        }
        bankrollManager.ApplySpinCost();
        uiController?.SetSpinInteractable(false);
        AudioManager.Instance.PlaySpin();
        StartCoroutine(SpinRoutine());
    }
    private IEnumerator SpinRoutine()
    {
        isSpinning = true;

        SymbolData[] result = new SymbolData[reels.Length];

        for (int i = 0; i < reels.Length; i++)
        {
            yield return StartCoroutine(SpinSingleReel(i, result));
            yield return new WaitForSeconds(spinDelay);
        }

        int payout = paytable.GetPayout(result);
        if (payout > 0)
        {
            bankrollManager.AddWinnings(payout);
            Debug.Log("WIN! Payout: " + payout);
            AudioManager.Instance.PlayWin();
            uiController?.ShowWin(payout);
        }
        uiController?.UpdateHUD();
        isSpinning = false;
        if (uiController != null && !uiController.AutoSpinEnabled)
            uiController.SetSpinInteractable(true);
        if (uiController != null && uiController.AutoSpinEnabled && bankrollManager.CanAffordSpin())
        {
            yield return new WaitForSeconds(autoSpinDelay);
            Spin();
        }
    }

    private IEnumerator SpinSingleReel(int reelIndex, SymbolData[] result)
    {
        float elapsed = 0f;

        while (elapsed < spinDuration)
        {
            SymbolData temp = reels[reelIndex].GetRandomSymbol();
            if (reelImages != null &&
                reelImages.Length > reelIndex &&
                reelImages[reelIndex] != null &&
                temp != null)
            {
                reelImages[reelIndex].sprite = temp.icon; 
            }
            elapsed += Time.deltaTime;
            yield return null;
        }
        result[reelIndex] = reels[reelIndex].GetRandomSymbol();
        if (reelImages != null &&
            reelImages.Length > reelIndex &&
            reelImages[reelIndex] != null &&
            result[reelIndex] != null)
        {
            reelImages[reelIndex].sprite = result[reelIndex].icon; 
        }
    }
}
