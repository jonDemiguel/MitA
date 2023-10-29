using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int level = 1;
    int experience = 0;
    [SerializeField] ExperienceBar experienceBar;

    // Base experience required to level up from level 1 to 2
    private const int baseExperience = 1000;

    // Additional experience required for each subsequent level
    private const int additionalExperiencePerLevel = 1000;

    // Calculate the total experience required to reach the next level
    private int ExperienceToLevelUp
    {
        get
        {
            return baseExperience + (level - 1) * additionalExperiencePerLevel;
        }
    }

    public int Level_update
    {
        get => level;
        private set
        {
            level = value;
            experienceBar.SetLevelText(level);
        }
    }

    private void Start()
    {
        experienceBar.UpdateExperienceSlider(experience, ExperienceToLevelUp);
        experienceBar.SetLevelText(Level_update);
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceSlider(experience, ExperienceToLevelUp);
    }

    private void CheckLevelUp()
    {
        while (experience >= ExperienceToLevelUp)
        {
            experience -= ExperienceToLevelUp;
            Level_update += 1;  // Use the property here
            OnLevelUp();
        }
    }

    private void OnLevelUp()
    {
        Debug.Log("Level Up! New Level: " + Level_update);
    }
}