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

        public void statusEnemy(Enemy pEnemy) {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"-----------------------------------");
            Console.WriteLine($"{pEnemy.Nome}\n");
            Console.WriteLine($"VIDA: {pEnemy.MaxHealth}/{pEnemy.CurrentHealth}");
            Console.WriteLine($"DANO: {pEnemy.Damage}");
            Console.WriteLine($"-----------------------------------");
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
            if (pPlayer.bAtacou == true) {
                pEnemy.CurrentHealth += pEnemy.Defense;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"====================================");
                Console.WriteLine($"O INIMIGO DEFENDEU PARTE DO ATAQUE!");
                Console.WriteLine($"-{pPlayer.Damage - pEnemy.Defense} de dano sofrido!");
                Console.WriteLine($"====================================\n");
            }
            else {  
                attackEnemy(pEnemy, pPlayer);
            }

        }

        public void enemyChanges(Enemy pEnemy, Player pPlayer) {
            Random random = new Random();
            if (pEnemy.bAtivouFeitico == true) {
                int chance = random.Next(1, 101);
                if (chance <= 0) {
                    attackEnemy(pEnemy, pPlayer);
                }
                else if (chance <= 0) {
                    enemyDefense(pEnemy, pPlayer);
                }
            }
            else {
                int chance = random.Next(1, 101);
                if (chance <= pEnemy.ChanceAttack) {
                    attackEnemy(pEnemy, pPlayer);
                }
                else if (chance <= pEnemy.ChanceDefense) {
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

        public void enemyPuzzles(Enemy pEnemy, Player pPlayer) {
            Random random = new Random();
            int chanceFeitico = random.Next(1, 101);
            if (pPlayer.Round >= 5 && chanceFeitico <= 20) {
                pEnemy.bAtivouFeitico = true;
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
                    verificador = int.Parse(Console.ReadLine());
                    if (verificador == resultado) {
                        Console.WriteLine($"PARABÉNS! VOCÊ QUEBROU O FEITIÇO!");
                        Console.WriteLine($"============================================\n");
                    }
                    else {
                        Console.WriteLine($"VOCÊ ERROU!");
                        pPlayer.CurrentHealth -= 20;
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
                        pPlayer.CurrentHealth -= 20;
                        Console.WriteLine($"-20 DE VIDA!");
                        Console.WriteLine($"====================================\n");
                    }
                }

            }
        }
    }
}
