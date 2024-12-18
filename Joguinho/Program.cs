﻿using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

// INIMIGO //
public class enemy {
    public int maxHealth = 100;
    public int damage = 10;
    public int criticalMulti = 3;
    public int currentHealth;
    public int chanceAttack = 60;
    public int chanceDefense = 80;
    public bool bAtivouFeitico = false;

    public void deathEnemy() {
        Console.WriteLine($"Inimigo Morto!");
    }

    public bool bEstaVivo() {
        if (currentHealth <= 0) {
            return false;
        }
        else {
            return true;
        }
    }

    public void attackEnemy(player player, enemy enemy) {
        if (player.currentHealth < 0) {
            player.currentHealth = 0;
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"====================================");
        Console.WriteLine($"INIMIGO ATACOU!");
        criticalChancesEnemy(enemy, player);
        player.currentHealth -= damage * criticalMulti;
        Console.WriteLine($"-{enemy.damage * criticalMulti} de Vida");
        Console.WriteLine($"====================================\n");
    }

    public void criticalChancesEnemy(enemy enemy, player player) {
        Random random = new Random();
        int chance = random.Next(1, 101);
        if (chance <= 30) {
            Console.WriteLine($"\n--ATAQUE CRÍTICO!--\n");
            enemy.criticalMulti = 3;
        }
        else {
            enemy.criticalMulti = 1;
        }
    }

    public void enemyDefense(enemy enemy, player player) {
        int defense = 5;
        if (player.bAtacou == true) {
            currentHealth += defense;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"====================================");
            Console.WriteLine($"O INIMIGO DEFENDEU PARTE DO ATAQUE!");
            Console.WriteLine($"VIDA ATUAL DO INIMIGO: {maxHealth}/{currentHealth}");
            Console.WriteLine($"====================================\n");
        }
        else {
            enemy.attackEnemy(player, enemy);
        }
        
    }

    public void enemyPuzzles(enemy enemy, player player) {
        Random random = new Random();
        int chanceFeitico = random.Next(1, 101); 
        if (player.round >= 5 && chanceFeitico <= 20) {
            enemy.bAtivouFeitico = true;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"============================================");
            Console.WriteLine($"O INIMIGO LANÇOU UM FEITIÇO, TENTE QUEBRAR!");
            int num1 = random.Next(1, 10);
            int num2 = random.Next(1, 10);
            int resultado, verificador;
            int operadores = random.Next(1, 3);

            if (operadores == 1) {
                resultado = num1 + num2;
                Console.WriteLine($"Quanto é {num1} + {num2}?");
                Console.Write(">> "); 
                verificador = int.Parse( Console.ReadLine());
                if (verificador == resultado) {
                    Console.WriteLine($"PARABÉNS! VOCÊ QUEBROU O FEITIÇO!");
                    Console.WriteLine($"============================================\n");
                }
                else {
                    Console.WriteLine($"VOCÊ ERROU!");
                    player.currentHealth -= 20;
                    Console.WriteLine($"-20 DE VIDA!");
                    Console.WriteLine($"============================================\n");
                }

            }
            else {
                resultado = num1 - num2;
                Console.WriteLine($"Quanto é {num1} - {num2}?");
                Console.Write(">> ");
                verificador = int.Parse(Console.ReadLine());
                if (verificador == resultado) {
                    Console.WriteLine($"PARABÉNS! VOCÊ QUEBROU O FEITIÇO!");
                    Console.WriteLine($"====================================\n");
                }
                else {
                    Console.WriteLine($"VOCÊ ERROU!");
                    player.currentHealth -= 20;
                    Console.WriteLine($"-20 DE VIDA!");
                    Console.WriteLine($"====================================\n");
                }
            }
            
        }
    }

    public void enemyChanges(enemy enemy, player player) {
        Random random = new Random();
        if (bAtivouFeitico == true) {
            int chance = random.Next(1, 101);
            if (chance <= 0) {
                enemy.attackEnemy(player, enemy);
            }
            else if (chance <= 0) {
                enemy.enemyDefense(enemy, player);
            }
        }
        else {
            int chance = random.Next(1, 101);
            if (chance <= enemy.chanceAttack) {
                enemy.attackEnemy(player, enemy);
            }
            else if (chance <= enemy.chanceDefense) {
                enemy.enemyDefense(enemy, player);
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


//PLAYER
public class player {
    public int maxHealth = 100;
    public int damage = 10;
    public int currentHealth;
    public int level = 1;
    public int round = 0;
    public bool bAtacou = false;

    public bool bEstaVivo() {
        if (currentHealth <= 0) {
            return false;
        }
        else {
            return true;
        }
    }

    public void status() {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"-----------------------------------");
        Console.WriteLine($"ROUND ATUAL: {round}");
        Console.WriteLine($"LEVEL: {level}");
        Console.WriteLine($"VIDA: {maxHealth}/{currentHealth}");
        Console.WriteLine($"DANO: {damage}");
        Console.WriteLine($"-----------------------------------");
    }

    public void attack(enemy enemy) {
        Console.Clear();
        enemy.currentHealth -= damage;
        bAtacou = true;
        if (enemy.currentHealth < 0) {
            enemy.currentHealth = 0;
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"-----------------------------------");
        Console.WriteLine($"VOCÊ ATACOU!");
        Console.WriteLine($"VIDA ATUAL DO INIMIGO: {enemy.maxHealth}/{enemy.currentHealth}");
        Console.WriteLine($"-----------------------------------\n");
        Thread.Sleep(500);
    }

    public void pocaoCura(enemy enemy, player player) {
        Console.Clear();
        int pocaoCura = 10;
        currentHealth += pocaoCura;
        if (currentHealth > maxHealth) {
            int diferenca = currentHealth - maxHealth;
            currentHealth -= diferenca;
        }
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"-----------------------------------");
        Console.WriteLine($"VOCÊ TOMOU POTE!");
        Console.WriteLine($"+{pocaoCura} DE VIDA!");
        Console.WriteLine($"-----------------------------------\n");
        Thread.Sleep(500);
    }

    public bool upgrades(enemy enemy, player player) {
        Random random = new Random();
        int chance = random.Next(1, 101);
        if(round >= 5 && chance <= 10) {
            int incrementeDamage = damage + 10;
            Console.ResetColor();
            Console.WriteLine($"****************************");
            Console.WriteLine($"VOCÊ TEVE UM UPGRADE NA SUA ESPADA!");
            Console.WriteLine($"AGORA VOCÊ DÁ {incrementeDamage} DE DANO");
            Console.WriteLine($"****************************\n");
            return true;
        }
        else {
            return false;
        }
    }

}
    class Program {
    private static string resposta;

    static void Main(string[] args) {

            

            do {
                Console.Clear();
                enemy enemy = new enemy();
                player player = new player();
                player.currentHealth = player.maxHealth;
                enemy.currentHealth = enemy.maxHealth;
                player.damage = player.damage;
                player.round = player.round;

                do {
                    player.round++;
                    if (player.upgrades(enemy, player) == true) {
                        player.damage += 10;
                    }
                    enemy.bAtivouFeitico = false;
                    player.bAtacou = false;
                    player.status();
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
                        case 1: player.attack(enemy); break;

                        case 2: player.pocaoCura(enemy, player); break;

                    }

                    if (enemy.currentHealth <= 0) {
                        enemy.deathEnemy();
                        break;
                    }

                    enemy.enemyPuzzles(enemy, player);  
                    enemy.enemyChanges(enemy, player);

                } while (player.bEstaVivo() && enemy.bEstaVivo());

                if (player.bEstaVivo() == false) {
                    Console.WriteLine("O jogador morreu. Fim do jogo!");
                }
                else {
                    Console.WriteLine("O inimigo morreu. Fim do jogo!");
                }
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"\n\nQuer jogar novamente?");
                Console.Write(">> ");
                Program.resposta = Console.ReadLine();

            }while(resposta == "sim" || resposta == "Sim" || resposta == "SIM" || resposta == "S" || resposta == "s");
        Console.WriteLine($"Fim do programa!");
        Console.ResetColor();
    }
}
