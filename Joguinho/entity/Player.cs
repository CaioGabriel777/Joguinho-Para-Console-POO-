namespace Joguinho_Console.entity {
    public class Player {

        public int MaxHealth { get; set; } = 100;
        public int Damage { get; set; } = 10;
        public int CurrentHealth { get; set; }
        public int Level { get; set; } = 1;
        public int Round { get; set; } = 0;
        public int InicialMoney { get; set; } = 5; public int CurrentMoney { get; set; } public int MultiMoney { get; set; } = 1;
        public bool bAtacou { get; set; } = true;
        public bool bChangeTurno { get; set; } = false;
        public string Nome { get; set; }

        /*Construtor Padrão*/
        public Player() { }

        public Player(int pMaxHealth, int pDamage, int pCurrentHealth, int pLevel, int pRound, bool pAtacou,
            int pInicialMoney, int pCurrentMoney, int pMultiMoney, bool pChangeTurno, string pNome) {
            this.MaxHealth = pMaxHealth;
            this.Damage = pDamage;
            this.CurrentHealth = pCurrentHealth;
            this.Level = pLevel;
            this.Round = pRound;
            this.bAtacou = pAtacou;
            this.InicialMoney = pInicialMoney;
            this.CurrentMoney = pCurrentMoney;
            this.MultiMoney = pMultiMoney;
            this.bChangeTurno = pChangeTurno;
            this.Nome = pNome;
        }
    }
}
