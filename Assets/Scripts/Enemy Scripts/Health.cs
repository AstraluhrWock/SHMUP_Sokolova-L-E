internal sealed class Health
{
    public float maxHealth { get; }
    public float currentHealth { get; private set; }

    public Health( float max, float current)
    {
        maxHealth = max;
        currentHealth = current;
    }

    public void ChangeCurrentHealth(float hp)
    {
        currentHealth = hp;
    }
 
}
