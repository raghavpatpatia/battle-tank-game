using System.Collections.Generic;

public interface Observer
{
    void ShowAchievements();
}

public class AchievementSystem : NonMonoGenericSingleton<AchievementSystem>, Observer
{
    public int bulletsFired;
    public int totalEnemiesKilled;
    public Achievements[] achievements;
    private AchievementSystemUI achievementSystemUI;
    private List<Achievements> achievementAchieved = new List<Achievements>();

    public AchievementSystem() : base()
    {
        base.Initialize();
        Initialization();
        Subscribe();
    }

    public void Initialization()
    {
        achievementSystemUI = GameManager.Instance.achievementSystemUI;
        achievements = GameManager.Instance.achievement;
    }

    public void Subscribe()
    {
        Events.Instance.BulletsFired += RecordBulletsFired;
        Events.Instance.EnemiesKilled += RecordEnemiesKilled;
    }

    public void RecordBulletsFired(int bullets)
    {
        bulletsFired = bullets;
        ShowAchievements();
    }

    public void RecordEnemiesKilled(int enemies)
    {
        totalEnemiesKilled = enemies;
        ShowAchievements();
    }

    protected void AchievementUnlocked(string avhievementText, Achievements unlockedAchievement)
    {
        if (!achievementAchieved.Contains(unlockedAchievement))
        {
            achievementSystemUI.UpdateText(avhievementText);
            achievementAchieved.Add(unlockedAchievement);
        }
    }

    public void ShowAchievements()
    {
        foreach (Achievements achievement in achievements)
        {
            if (achievement.achievement == AchievementType.BulletsFired)
            {
                if (achievement.totalNumber == bulletsFired)
                {
                    string achievementText = "Achievement Unlocked: You have fired " + achievement.totalNumber + " bullets.";
                    AchievementUnlocked(achievementText, achievement);
                }
            }
            if (achievement.achievement == AchievementType.EnemiesKilled)
            {
                if (achievement.totalNumber == totalEnemiesKilled)
                {
                    string achievementText = "Achievement Unlocked: You have killed " + achievement.totalNumber + " enemies.";
                    AchievementUnlocked(achievementText, achievement);
                }
            }
        }
    }

    public void Unsubscribe()
    {
        if (Events.Instance != null)
        {
            Events.Instance.BulletsFired -= RecordBulletsFired;
            Events.Instance.EnemiesKilled -= RecordEnemiesKilled;
        }
    }
}
