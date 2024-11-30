[System.Serializable]
public class EnemyStats
{
    public int health;
    public int attack;

    public EnemyStats(int hp, int atk)
    {
        this.health = hp;
        this.attack = atk;
    }

    public enum EnemyType
    {
        Bee,
        Mole,
        Spikes
    }
}