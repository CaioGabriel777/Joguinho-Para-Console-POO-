namespace Joguinho_Console.entity {
    public class Enemy {
        public int MaxHealth { get; set; } = 100;
        public int Damage { get; set; } = 10;
        public int CriticalMulti { get; set; } = 3;
        public int CurrentHealth { get; set; }

        public Enemy() { }

        public Enemy(int pMaxHealth, int pDamage, int pCriticalMulti, int pCurrentHealth) {
            MaxHealth = pMaxHealth;
            Damage = pDamage;
            CriticalMulti = pCriticalMulti;
            CurrentHealth = pCurrentHealth;
        }
    }
}
