using Joguinho_Console.entity;
using Joguinho_Console.movements;

class Program {
    private static string resposta;

    static void Main(string[] args) {

        do {
            Console.Clear();

            Player player = new Player();
            PlayerMovements playerMovements = new PlayerMovements();
            Enemy enemy = new Enemy();
            EnemyMovements enemyMovements = new EnemyMovements();

            player.CurrentHealth = player.MaxHealth;
            player.Damage = player.Damage;
            player.Round = player.Round;
            enemy.CurrentHealth = enemy.MaxHealth;

            Console.ResetColor();
            Console.Write("Player, digite seu nome: ");
            player.Nome = Console.ReadLine();

            do {
                player.Round++;
                playerMovements.money(player);
                player.bChangeTurno = true;
                
                if (playerMovements.upgrades(player, enemy) == true) {
                    player.Damage += 10;
                }
                enemy.bAtivouFeitico = false;
                player.bAtacou = false;

                enemyMovements.statusEnemy(enemy);
                playerMovements.status(player);

                playerMovements.actions(player, enemy);

                if (enemy.CurrentHealth <= 0) {
                    enemyMovements.deathEnemy();
                    break;
                }

                enemyMovements.enemyPuzzles(enemy, player);
                enemyMovements.enemyChanges(enemy, player);

            } while (playerMovements.bEstaVivo(player) && enemyMovements.bEstaVivo(enemy));

            if (playerMovements.bEstaVivo(player) == false) {
                Console.WriteLine("O jogador morreu. Fim do jogo!");
            }
            else {
                Console.WriteLine("O inimigo morreu. Fim do jogo!");
            }
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"\n\nQuer jogar novamente? ('S' ou 'SIM')");
            Console.Write(">> ");
            Program.resposta = Console.ReadLine();

        } while (resposta.Equals("s", StringComparison.OrdinalIgnoreCase) ||
                resposta.Equals("sim", StringComparison.OrdinalIgnoreCase));

        Console.WriteLine($"Fim do programa!");
    }
}