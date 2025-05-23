﻿using Joguinho_Console.entity;

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
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"-----------------------------------");
            Console.WriteLine($"PLAYER: {pPlayer.Nome}\n");
            Console.WriteLine($"ROUND ATUAL: {pPlayer.Round}");
            Console.WriteLine($"LEVEL: {pPlayer.Level}");
            Console.WriteLine($"VIDA: {pPlayer.MaxHealth}/{pPlayer.CurrentHealth}");
            Console.WriteLine($"DANO: {pPlayer.Damage}");
            Console.WriteLine($"${pPlayer.CurrentMoney}");
            Console.WriteLine($"-----------------------------------");
        }

        public void attack(Player pPlayer, Enemy pEnemy) {
            Console.Clear();
            pEnemy.CurrentHealth -= pPlayer.Damage;
            pPlayer.bAtacou = true;
            if (pEnemy.CurrentHealth < 0) {
                pEnemy.CurrentHealth = 0;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"-----------------------------------");
            Console.WriteLine($"VOCÊ ATACOU!");
            Console.WriteLine($"-{pPlayer.Damage} de Vida.");
            Console.WriteLine($"-----------------------------------\n");
            Thread.Sleep(500);
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
            Console.WriteLine($"+{pocaoCura} de Vida!");
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

        public void money(Player pPlayer) {
            if (pPlayer.Round == 1) {
                pPlayer.CurrentMoney += 0 * pPlayer.MultiMoney;
                pPlayer.CurrentMoney = pPlayer.InicialMoney;
            }
            if (pPlayer.bChangeTurno == true) {
                pPlayer.CurrentMoney += 10 * pPlayer.MultiMoney;
            }
        }

    }
}
