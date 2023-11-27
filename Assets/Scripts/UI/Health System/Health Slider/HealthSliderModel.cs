public class HealthSliderModel
{
    public float startingHealth { get; set; }
    public float currentHealth { get; set; }

    public HealthSliderModel()
    {
        startingHealth = currentHealth;
    }
}