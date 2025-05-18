using Joguinho_Console.entity;
using System;

namespace Joguinho_Console.movements {
    public class PlayerMovements {

        public bool bEstaVivo(Player pPlayer) {
            if (pPlayer.CurrentHealth <= 0) {
                return false;
            }
            else {
                return true;
            }
        }
        public void actions(Player pPlayer, Enemy pEnemy) {
            Console.ResetColor();
            Console.WriteLine($"-----------------------------------");
            Console.WriteLine($"O que você quer fazer?");
            Console.WriteLine($"1 - Ataque");
            Console.WriteLine($"2 - Tomar Poção de Cura");
            Console.Write($">> ");
            string entrada = Console.ReadLine();
            Console.WriteLine($"-----------------------------------");
            int conversorInt = int.Parse(entrada);

            switch (conversorInt) {
                default: Console.WriteLine("Escolha uma opção válida!"); break;
                case 1: attack(pPlayer, pEnemy); break;

                case 2: pocaoCura(pPlayer, pEnemy); break;

            }
        }

        public void status(Player pPlayer) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"-----------------------------------");
            Console.WriteLine($"ROUND ATUAL: {pPlayer.Round}");
            Console.WriteLine($"LEVEL: {pPlayer.Level}");
            Console.WriteLine($"VIDA: {pPlayer.MaxHealth}/{pPlayer.CurrentHealth}");
            Console.WriteLine($"DANO: {pPlayer.Damage}");
            Console.WriteLine($"-----------------------------------");
        }

        public void attack(Player pPlayer, Enemy pEnemy) {
            Console.Clear();
            pEnemy.CurrentHealth -= pPlayer.Damage;
            pPlayer.Atacou = true;
            if (pEnemy.CurrentHealth < 0) {
                pEnemy.CurrentHealth = 0;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"-----------------------------------");
            Console.WriteLine($"VOCÊ ATACOU!");
            Console.WriteLine($"VIDA ATUAL DO INIMIGO: {pEnemy.MaxHealth}/{pEnemy.CurrentHealth}");
            Console.WriteLine($"-----------------------------------\n");
        }

        public void pocaoCura(Player pPlayer, Enemy pEnemy) {
            Console.Clear();
            int pocaoCura = 10;
            pPlayer.CurrentHealth += pocaoCura;
            if (pPlayer.CurrentHealth > pPlayer.MaxHealth) {
                int diferenca = pPlayer.CurrentHealth - pPlayer.MaxHealth;
                pPlayer.CurrentHealth -= diferenca;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"-----------------------------------");
            Console.WriteLine($"VOCÊ TOMOU POTE!");
            Console.WriteLine($"+{pocaoCura} DE VIDA!");
            Console.WriteLine($"-----------------------------------\n");
        }

        public bool upgrades(Player pPlayer, Enemy pEnemy) {
            Random random = new Random();
            int chance = random.Next(1, 101);
            if (pPlayer.Round >= 5 && chance <= 20) {
                int incrementeDamage = pPlayer.Damage + 10;
                Console.ResetColor();
                Console.WriteLine($"");
                Console.WriteLine($"VOCÊ TEVE UM UPGRADE NA SUA ESPADA!");
                Console.WriteLine($"AGORA VOCÊ DÁ {incrementeDamage} DE DANO");
                Console.WriteLine($"\n");
                return true;
            }
            else {
                return false;
            }
        }

    }
}
