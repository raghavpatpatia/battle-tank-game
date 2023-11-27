public class HealthSliderController
{
    private HealthSliderModel model;
    private HealthSliderView view;

    public HealthSliderController()
    {
        this.model = new HealthSliderModel();
    }

    public void SetHealthSliderModelValues(float startingealth, float currentHealth)
    {
        model.startingHealth = startingealth;
        model.currentHealth = currentHealth;
    }
}