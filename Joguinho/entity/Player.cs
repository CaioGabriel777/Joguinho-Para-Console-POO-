using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joguinho_Console.entity {
    public class Player {

        public int MaxHealth { get; set; } = 100;
        public int Damage { get; set; } = 10;
        public int CurrentHealth { get; set; }
        public int Level { get; set; } = 1;
        public int Round { get; set; } = 0;
        public bool Atacou { get; set; } = false;

        /*Construtor Padrão*/
        public Player() { }

        public Player(int pMaxHealth, int pDamage, int pCurrentHealth, int pLevel, int pRound, bool pAtacou) {
            this.MaxHealth = pMaxHealth;
            this.Damage = pDamage;
            this.CurrentHealth = pCurrentHealth;
            this.Level = pLevel;
            this.Round = pRound;
            this.Atacou = pAtacou;
        }
    }
}
