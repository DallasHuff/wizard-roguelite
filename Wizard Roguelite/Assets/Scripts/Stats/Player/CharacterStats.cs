using UnityEngine;

namespace Woguelite.Stats
{
    public class CharacterStats : MonoBehaviour
    {
        #region Singleton
        public static CharacterStats instance;
        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("More than one instance of CharacterStats found!");
                return;
            }
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        #endregion

        public Stat maxHealth;          // modified by flat amount
        public Stat abilityHaste;       // modified by flat amount
        public Stat armor;              // modified by flat amount
        public Stat damage;             // modified by %
        public Stat speed;              // modified by %
        public Stat projectileSpeed;    // modified by %
        public Stat waterDamage;        // modified by %
        public Stat fireDamage;         // modified by %
        public Stat natureDamage;       // modified by %
        public Stat rockDamage;         // modified by %
        public Stat lightningDamage;    // modified by %

        public float currentHealth;

        private void Start()
        {
            Inventory.instance.onItemPickup += onItemPickup;
            currentHealth = maxHealth.GetValue();
        }

        private void onItemPickup(Item item)
        {

        }

        public void UpdateStat(Stat stat, float mod)
        {
            // TODO what was I trying to do? This just basically does AddModifier. GetValue doesn't actually do anything here
            stat.AddModifier(mod);
            stat.GetValue();
        }

        public void TakeDamage(int damage)
        {
            damage = Mathf.Clamp(damage, 0, int.MaxValue);
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            //TODO: Do something when player dies
            Debug.Log("player died");
        }
    }
}