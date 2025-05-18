using Joguinho_Console.entity;

namespace Joguinho_Console.movements {
    public class EnemyMovements {

        public void deathEnemy() {
            Console.WriteLine($"Inimigo Morto!");
        }

        public bool bEstaVivo(Enemy pEnemy) {
            if (pEnemy.CurrentHealth <= 0) {
                return false;
            }
            else {
                return true;
            }
        }

        public void attackEnemy(Enemy pEnemy, Player pPlayer) {
            if (pPlayer.CurrentHealth < 0) {
                pPlayer.CurrentHealth = 0;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"====================================");
            Console.WriteLine($"INIMIGO ATACOU!");
            criticalChancesEnemy(pEnemy, pPlayer);
            pPlayer.CurrentHealth -= pEnemy.Damage * pEnemy.CriticalMulti;
            Console.WriteLine($"-{pEnemy.Damage * pEnemy.CriticalMulti} de Vida");
            Console.WriteLine($"====================================\n");
        }

        public void criticalChancesEnemy(Enemy pEnemy, Player pPlayer) {
            Random random = new Random();
            int chance = random.Next(1, 101);
            if (chance <= 30) {
                Console.WriteLine($"\n--ATAQUE CRÍTICO!--\n");
                pEnemy.CriticalMulti = 3;
            }
            else {
                pEnemy.CriticalMulti = 1;
            }
        }

        public void enemyDefense(Enemy pEnemy, Player pPlayer) {
            int defense = 5;
            if (pPlayer.Atacou == true) {
                pEnemy.CurrentHealth += defense;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"====================================");
                Console.WriteLine($"O INIMIGO DEFENDEU PARTE DO ATAQUE!");
                Console.WriteLine($"VIDA ATUAL DO INIMIGO: {pEnemy.MaxHealth}/{pEnemy.CurrentHealth}");
                Console.WriteLine($"====================================\n");
            }

        }

        public void enemyChanges(Enemy pEnemy, Player pPlayer) {
            Random random = new Random();

            int chance = random.Next(1, 101);
            if (chance <= 60) {
                attackEnemy(pEnemy, pPlayer);
            }
            else if (chance <= 80) {
                enemyDefense(pEnemy, pPlayer);
            }
            else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"====================================");
                Console.WriteLine("O inimigo está pensando...");
                Console.WriteLine($"====================================\n");
            }
        }
    }
}
