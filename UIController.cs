using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour
{
    [Header("HUD References")]
    [SerializeField] private TMP_Text balanceText;
    [SerializeField] private TMP_Text betText;
    [SerializeField] private GameObject winBanner;   // 👈 Assign a banner panel (with text inside)
    [SerializeField] private TMP_Text winText;

    [Header("Buttons")]
    [SerializeField] private Button spinButton;
    [SerializeField] private Button betUpButton;
    [SerializeField] private Button betDownButton;
    [SerializeField] private Button resetButton;

    [Header("Managers")]
    [SerializeField] private BankrollManager bankrollManager;
    [SerializeField] private SlotMachineController slotMachine;

    [Header("Toggles")]
    [SerializeField] private Toggle autoSpinToggle;

    public bool AutoSpinEnabled => autoSpinToggle != null && autoSpinToggle.isOn;

    private void Start()
    {
        // Button listeners
        if (spinButton != null) spinButton.onClick.AddListener(OnSpinPressed);
        if (betUpButton != null) betUpButton.onClick.AddListener(OnBetUpPressed);
        if (betDownButton != null) betDownButton.onClick.AddListener(OnBetDownPressed);
        if (resetButton != null) resetButton.onClick.AddListener(OnResetPressed);

        // Toggle listener
        if (autoSpinToggle != null)
        {
            autoSpinToggle.onValueChanged.AddListener(OnAutoSpinChanged);

            bool savedState = SaveSystem.LoadAutoSpin(false);
            autoSpinToggle.isOn = savedState;
        }

        // HUD
        UpdateHUD();

        // Make sure win banner starts hidden
        if (winBanner != null) winBanner.SetActive(false);
    }

    public void UpdateHUD()
    {
        if (balanceText != null)
            balanceText.text = $"Balance: {bankrollManager.Balance}";

        if (betText != null)
            betText.text = $"Bet: {bankrollManager.Bet}";
    }

    // Called by SlotMachineController when a win happens
    public void ShowWin(int payout)
    {
        if (winBanner == null || winText == null) return;

        winBanner.SetActive(true);
        winText.text = $"YOU WIN {payout}!";
        winText.color = Color.yellow;

        // Animate: shake + bounce
        StartCoroutine(AnimateWinBanner());

        // Hide after 2 seconds
        StopAllCoroutines();
        StartCoroutine(HideWinBannerAfterDelay(2f));
    }

    private IEnumerator AnimateWinBanner()
    {
        Vector3 originalScale = winBanner.transform.localScale;

        // Quick bounce animation
        float t = 0f;
        while (t < 0.5f)
        {
            t += Time.deltaTime * 4f;
            float scale = 1f + Mathf.Sin(t * Mathf.PI) * 0.2f; // bounce effect
            winBanner.transform.localScale = originalScale * scale;
            yield return null;
        }

        winBanner.transform.localScale = originalScale;
    }

    private IEnumerator HideWinBannerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (winBanner != null)
            winBanner.SetActive(false);
    }

    public void SetSpinInteractable(bool interactable)
    {
        if (spinButton != null) spinButton.interactable = interactable;
    }

    private void OnSpinPressed()
    {
        AudioManager.Instance.PlayButton();
        if (slotMachine == null) return;

        slotMachine.Spin();
        UpdateHUD();
    }

    private void OnBetUpPressed()
    {
        AudioManager.Instance.PlayButton();
        bankrollManager.IncreaseBet();
        UpdateHUD();
    }

    private void OnBetDownPressed()
    {
        AudioManager.Instance.PlayButton();
        bankrollManager.DecreaseBet();
        UpdateHUD();
    }

    private void OnResetPressed()
    {
        AudioManager.Instance.PlayButton();
        bankrollManager.ResetBankroll();
        UpdateHUD();
    }

    private void OnAutoSpinChanged(bool isOn)
    {
        SaveSystem.SaveAutoSpin(isOn);
    }
}
