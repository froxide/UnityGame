using UnityEngine;
using TMPro;

public class LevelUpSystem : MonoBehaviour
{
    public TextMeshPro levelText;
    public float xpPerSecond = 1.0f;
    public int xpRequiredForLevelUp = 100;

    private int currentLevel = 1;
    private float currentXP = 0.0f;

    private void Start()
    {
        LoadPlayerProgress(); // Load saved progress

        UpdateLevelText();
        InvokeRepeating("GainXP", 1.0f, 1.0f); // Gain XP every second
    }

    private void GainXP()
    {
        currentXP += xpPerSecond;

        if (currentXP >= xpRequiredForLevelUp)
        {
            LevelUp();
        }

        UpdateLevelText();

        SavePlayerProgress(); // Save progress
    }

    private void LevelUp()
    {
        currentLevel++;
        currentXP = 0.0f;
        xpRequiredForLevelUp += 50; // You can adjust this as needed

        SavePlayerProgress(); // Save progress
    }

    private void UpdateLevelText()
    {
        levelText.text = "Level: " + currentLevel + "\nXP: " + currentXP.ToString("F0") + " / " + xpRequiredForLevelUp;
    }

    private void SavePlayerProgress()
    {
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.SetFloat("CurrentXP", currentXP);
        PlayerPrefs.SetInt("XPRequiredForLevelUp", xpRequiredForLevelUp);
        PlayerPrefs.Save();
    }

    private void LoadPlayerProgress()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", currentLevel);
        currentXP = PlayerPrefs.GetFloat("CurrentXP", currentXP);
        xpRequiredForLevelUp = PlayerPrefs.GetInt("XPRequiredForLevelUp", xpRequiredForLevelUp);
    }
}
