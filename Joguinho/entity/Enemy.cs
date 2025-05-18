namespace Joguinho_Console.entity {
    public class Enemy {
        public int MaxHealth { get; set; } = 100;
        public int Damage { get; set; } = 10;
        public int CriticalMulti { get; set; } = 3;
        public int CurrentHealth { get; set; }
        public int ChanceAttack { get; set; } = 60;
        public int ChanceDefense { get; set; } = 80; public int Defense { get; set; } = 5;
        public bool bAtivouFeitico { get; set; } = false;
        public string Nome { get; set; } = "Inimigo 1";

        public Enemy() { }

        public Enemy(int pMaxHealth, int pDamage, int pCriticalMulti, int pCurrentHealth, int pChanceDefense, int pDefense,
            int pChanceAttack, bool pAtivouFeitico, string pNome) {

            this.MaxHealth = pMaxHealth;
            this.Damage = pDamage;
            this.CriticalMulti = pCriticalMulti;
            this.CurrentHealth = pCurrentHealth;
            this.ChanceDefense = pChanceDefense;
            this.Defense = pDefense;
            this.bAtivouFeitico = pAtivouFeitico;
            this.Nome = pNome;
            this.ChanceAttack = pChanceAttack;
        }
    }
}
