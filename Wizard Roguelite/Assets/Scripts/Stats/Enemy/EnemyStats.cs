using UnityEngine;

[CreateAssetMenu(menuName = "Stats/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public int maxHealth;
    public int damage;
    public int armor;
    public int speed;
    public bool flying;
}
