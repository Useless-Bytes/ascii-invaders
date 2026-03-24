using System;

namespace ASCII_Invaders
{
    /// <summary>
    /// Classe <c>Game</c> é a classe principal do jogo, responsável por gerenciar o loop principal do jogo, a lógica de atualização dos objetos do jogo, a detecção de colisões e a interação com o jogador. Ela contém métodos para inicializar o jogo, avançar para o próximo nível, finalizar o jogo, disparar projéteis, verificar teclas pressionadas, randomizar a velocidade dos inimigos, verificar se um inimigo aterrissou, atualizar a posição dos inimigos e projéteis, e atualizar a tela do jogo. A classe Game é essencial para o funcionamento do jogo e coordena todas as outras classes e objetos envolvidos na jogabilidade.
    /// </summary>
    class Game
    {
        private bool keepRunning;
        public  int aliveEnemies;
        private int enemiesShooting;
        private int maxEnemiesShooting;
        private  int _score;


        
        public  int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                if (_score > _bestScore)
                {
                    BestScore = _score;
                }
            }
        }

        private  int _bestScore;
        public  int BestScore
        {
            get
            {
                return _bestScore;
            }
            set
            {
                _bestScore = value;
                Util.WriteBestScore(BestScore);
            }
        }

        public  int Level { get; set; }
        private  bool enemiesGoLeft;
        private  bool enemiesGoDown;
        private  BattleField battleField;
        private  Cannon cannon;
        private int cannonsLeft;
        private  ConsoleKey keyPressed;

        private Bullet[] playerBullets = new Bullet[Constant.PlayerBullets];
        private Bullet[] enemiesBullets = new Bullet[Constant.EnemiesBullets];
        private Enemy[,] enemies = new Enemy[Constant.EnemiesRows, Constant.EnemiesPerRow];

        private  float enemiesSpeed = 10f;
        private  Random random = new Random();

        /// <summary>
        /// Método <c>Rum</c> é o ponto de entrada do jogo, responsável por inicializar o jogo e executar o loop principal do jogo enquanto a variável keepRunning for verdadeira. Dentro do loop, ele verifica se o nível é zero para iniciar o próximo nível, verifica se alguma tecla foi pressionada para executar a ação correspondente, faz uma pausa para controlar a velocidade do jogo e atualiza a tela. Quando o loop termina, ele exibe uma mensagem de despedida e restaura as configurações do console.
        /// </summary>
        public void Run()
        {
            Init();

            // Game loop - executado enquanto a variável keepRunning for verdadeira
            while (keepRunning)
            {
                if (Level == 0)
                {
                    cannonsLeft = Constant.Cannons;
                    NextLevel();
                }

                // Verifica se alguma tecla foi pressionada e executa a ação correspondente
                CheckKeypressed();

                // Executa uma pausa para controlar a velocidade do jogo e atualiza a tela
                Util.Wait(Constant.OneSecond / 60);
                Update();
            }

            // Fim do jogo - exibe uma mensagem de despedida e restaura as configurações do console
            Finish();
        }

        /// <summary>
        /// Método <c>LoadEnemies</c> carrega os inimigos na matriz de inimigos, posicionando-os de acordo com a linha e coluna correspondente. Cada inimigo é criado como um objeto da classe Enemy e adicionado à matriz enemies.
        /// </summary>
        private void LoadEnemies()
        {
            // Carrega os inimigos na matriz de inimigos, posicionando-os de acordo com a linha e coluna correspondente
            for (var row = 0; row < Constant.EnemiesRows; row++)
            {
                // Para cada linha de inimigos, cria um objeto Enemy para cada coluna e posiciona-o na matriz enemies
                for (var col = 0; col < Constant.EnemiesPerRow; col++)
                {
                    var enemy = new Enemy();
                    enemy.Position.Y = 3 + row;
                    enemy.Position.X = 10 + 5 * col;
                    enemies[row, col] = enemy;
                }
            }
        }

        /// <summary>
        /// Método <c>Init</c> é responsável por inicializar o jogo, configurando o console, exibindo o logotipo do jogo, criando os objetos necessários para o jogo, desenhando o campo de batalha e exibindo a tela de introdução. Ele também define as variáveis de controle do jogo, como a direção dos inimigos e a pontuação inicial.
        /// </summary>
        public void Init()
        {
            // Limpa a tela, oculta o cursor e desabilita o CTRL-C para evitar que o jogo seja interrompido acidentalmente
            Console.Clear();
            Console.CursorVisible = false;
            Console.TreatControlCAsInput = true; // disable CTRL-C
            

            keepRunning = true; // controle do game loop
            battleField = new BattleField(); // o campo de batalha
            cannon = new Cannon(); // o 'canhão' do jogador
            Program.PlaySound = true;
            battleField.Draw();
            // Mostra o logotipo do jogo por 2 segundos
            var ubLogo = new Logo();
            ubLogo.Show();
            Util.Wait(2000);

            // Esconde o logotipo do jogo
            ubLogo.Hide();
            battleField.ShowSplashScreen();
            enemiesGoLeft = true;
            enemiesGoDown = false;
            Score = 0;

            BestScore = Util.ReadBestScore();
        }

        /// <summary>
        /// Método <c>GameOver</c> mostra tela de fim de jogo
        /// </summary>
        private void GameOver()
        {
            Util.PlayWavFile(Resource1.game_over);
            battleField.GameOver(Score);
            Level = 0;
        }

        /// <summary>
        /// Método <c>Congratilations</c> mostra a tela de congratulações
        /// </summary>
        private void Congratulations()
        {
            battleField.Congratulations();
            Level = 0;
        }

        /// <summary>
        /// Método <c>NextLevel</c> é responsável por avançar para o próximo nível do jogo. Ele verifica se o nível atual é o último nível definido, e se for, exibe uma mensagem de parabéns e reinicia o jogo. Caso contrário, ele incrementa o número do nível, recarrega os projéteis e os inimigos, atualiza a contagem de inimigos vivos e exibe uma tela de transição para o próximo nível.
        /// </summary>
        private void NextLevel()
        {
            if (Level == Constant.FinalLevel)
            {
                // Último nível atingido
                if (Score > BestScore)
                {
                    Congratulations();
                }else
                {
                    GameOver();
                }
            }

            // Incrementa o número do nível
            Level++;

            // Carrega os projéteis do jogador
            for (var b = 0; b < Constant.PlayerBullets; b++)
            {
                playerBullets[b] = new Bullet();
            }

            for (var b = 0; b < Constant.EnemiesBullets; b++)
            {
                enemiesBullets[b] = new Bullet(true);
            }

            // Carrega os inimigos
            LoadEnemies();

            // Atualiza a contagem de inimigos vivos
            aliveEnemies = Constant.EnemiesPerRow * Constant.EnemiesRows;

            // Exibe a tela de transição para o próximo nível
            battleField.ShowLevelSplashScreen(Level);
            enemiesShooting = 0;
            maxEnemiesShooting = 20;
        }

        /// <summary>
        /// Método <c>Finish</c> é responsável por finalizar o jogo, limpando a tela, tornando o cursor visível novamente e exibindo uma mensagem de despedida. Ele é chamado quando o loop principal do jogo termina, indicando que o jogador escolheu sair do jogo ou que ocorreu um evento de game over.
        /// </summary>
        private void Finish()
        {
            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Bye...");
        }

        /// <summary>
        /// Método <c>PlayerShoot</c> é responsável por disparar um projétil do canhão do jogador. Ele percorre a lista de projéteis disponíveis e verifica se há algum que ainda não foi disparado. Se encontrar um projétil não disparado, ele marca o projétil como disparado, posiciona-o na frente do canhão e reproduz um som de tiro. O método retorna após disparar o primeiro projétil disponível, garantindo que apenas um projétil seja disparado por vez.
        /// </summary>
        private void PlayerShoot()
        {
            // Percorre a lista de projéteis disponíveis
            foreach (var bullet in playerBullets)
            {
                // Verifica se o projétil ainda não foi disparado
                if (!bullet.Shot)
                {
                    // Encontra um projétil disponível, marca-o como disparado e posiciona-o na frente do canhão
                    bullet.Shot = true;
                    bullet.Position.X = cannon.Position.X;
                    bullet.Position.Y = cannon.Position.Y - 1;

                    // Reproduz um som de tiro
                    Util.PlayWavFile(Resource1.hit);
                    return;
                }
            }
        }

        /// <summary>
        /// Método <c>EnemyShoot</c> é responsável por disparar um projétil do inimigo. 
        /// Ele percorre a lista de projéteis disponíveis e verifica se há algum que ainda não foi disparado. 
        /// Se encontrar um projétil não disparado, ele marca o projétil como disparado, posiciona-o abaixo do inimigo selecionado e reproduz um som de tiro. 
        /// O método retorna após disparar a quantidade máxima de tiros de inimigos.
        /// </summary>
        private void EnemyShoot(Enemy enemy)
        {
            // Percorre a lista de projéteis disponíveis
            foreach (var bullet in enemiesBullets)
            {
                // Verifica se o projétil ainda não foi disparado
                if (!bullet.Shot)
                {
                    // Encontra um projétil disponível, marca-o como disparado e posiciona-o abaixo do inimigo
                    bullet.Shot = true;
                    bullet.Position.X = enemy.Position.X;
                    bullet.Position.Y = enemy.Position.Y + 1;

                    // Reproduz um som de tiro
                    Util.PlayWavFile(Resource1.hit);
                }
            }
        }

        /// <summary>
        /// Método <c>CheckKeypressed</c> é responsável por verificar se alguma tecla foi pressionada pelo jogador e executar a ação correspondente. Ele utiliza a propriedade Console.KeyAvailable para verificar se há uma tecla na fila de entrada, e se houver, lê a tecla usando Console.ReadKey(true) e executa uma ação com base na tecla pressionada. As ações incluem mover o canhão para a esquerda ou direita, disparar um projétil, alternar o som, pausar o jogo ou sair do jogo. Após processar a tecla pressionada, o método chama Update() para atualizar a tela do jogo.
        /// </summary>
        private void CheckKeypressed()
        {
            // Verifica se alguma tecla foi pressionada
            if (Console.KeyAvailable)
            {
                // Lê a tecla pressionada e executa a ação correspondente
                keyPressed = Console.ReadKey(true).Key;

                // Executa a ação correspondente com base na tecla pressionada
                switch (keyPressed)
                {
                    case ConsoleKey.LeftArrow:
                        // Move o canhão para a esquerda
                        cannon.MoveLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        // Move o canhão para a direita
                        cannon.MoveRight();
                        break;
                    case ConsoleKey.Spacebar:
                        // Dispara um projétil
                        PlayerShoot();
                        break;
                    case ConsoleKey.M:
                        // Alterna o som
                        Program.PlaySound = !Program.PlaySound;
                        break;
                    case ConsoleKey.P:
                        // Pausa o jogo
                        battleField.Pause();
                        break;
                    case ConsoleKey.Escape:
                        // Sai do jogo
                        if (battleField.Confirm("Press Y to exit or any other key to continue"))
                        {
                            keepRunning = false;
                        }
                        break;
                }
                // Atualiza a tela do jogo após processar a tecla pressionada
                Update();
            }
        }

        /// <summary>
        /// Método <c>RandomizeEnemiesSpeed</c> é responsável por randomizar a velocidade dos inimigos com base no nível atual do jogo. Ele utiliza a classe Random para gerar um número aleatório entre 0 e 1, multiplica esse número pelo nível atual e subtrai o resultado da velocidade base dos inimigos. Isso faz com que a velocidade dos inimigos aumente à medida que o jogador avança para níveis mais altos, tornando o jogo mais desafiador.
        /// </summary>
        /// <returns>randomized enemy speed</returns>
        private float RandomizeEnemiesSpeed()
        {
            // Randomiza a velocidade dos inimigos com base no nível atual do jogo
            enemiesSpeed = enemiesSpeed - (float)random.NextDouble() * Level;
            return enemiesSpeed;
        }

        /// <summary>
        /// Método <c>TheEnemyLanded</c> é responsável por verificar se um inimigo atingiu o chão do campo de batalha. Ele recebe um objeto Enemy como parâmetro e compara a posição vertical do inimigo com a posição do chão do campo de batalha. Se a posição vertical do inimigo for igual à posição do chão, o método retorna true, indicando que o inimigo aterrissou. Caso contrário, retorna false, indicando que o inimigo ainda está no ar.
        /// </summary>
        /// <param name="enemy">Inimigo</param>
        /// <returns></returns>
        private bool TheEnemyLanded(Enemy enemy)
        {
            // Verifica se o inimigo atingiu o chão do campo de batalha
            if (enemy.Position.Y == Constant.BattleFieldBottom || 
                (enemy.Position.Y == cannon.Position.Y && enemy.Position.X == cannon.Position.X))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método <c>UpdateEnemies</c> é responsável por atualizar a posição dos inimigos no campo de batalha. Ele percorre a matriz de inimigos e move cada inimigo para baixo, para a esquerda ou para a direita, dependendo da direção atual dos inimigos. O método também verifica se algum inimigo atingiu o chão do campo de batalha, o que resultaria em um game over. Além disso, ele verifica se algum inimigo atingiu as bordas do campo de batalha para determinar se os inimigos devem mudar de direção e descer. A velocidade dos inimigos é controlada por uma variável que é randomizada com base no nível atual do jogo.
        /// </summary>
        private void UpdateEnemies()
        {
            var goLeft = enemiesGoLeft;
            var goDown = false;

            enemiesSpeed = Constant.EnemiesTimer;

            var randomEnemyPosition = Util.GetRandomEnemyPosition();

            // Atualiza a posição dos inimigos no campo de batalha
            for (var row = 0; row < Constant.EnemiesRows; row++)
            {
                // Move cada inimigo para baixo, para a esquerda ou para a direita, dependendo da direção atual dos inimigos
                for (var col = 0; col < Constant.EnemiesPerRow; col++)
                {
                    var enemy = enemies[row, col];

                    if (enemiesShooting < maxEnemiesShooting &&
                        enemy.Visible && 
                        !enemy.IsShooting && 
                        randomEnemyPosition.X == col && 
                        randomEnemyPosition.Y == row)
                    {
                        // Disparar
                        enemy.Shoot();
                        EnemyShoot(enemy);
                        enemiesShooting++;
                    }

                    // Verifica se o inimigo está visível antes de movê-lo
                    if (enemiesGoDown)
                    {
                        // Move o inimigo para baixo
                        enemy.MoveDown();
                    }
                    if (enemiesGoLeft)
                    {
                        // Move o inimigo para a esquerda
                        enemy.MoveLeft();
                    }
                    else
                    {
                        // Move o inimigo para a direita
                        enemy.MoveRight();
                    }

                    if (TheEnemyLanded(enemies[row, col]) || cannonsLeft < 0)
                    {
                        // Se um inimigo atingiu o chão do campo de batalha, ou todos os canhões
                        // foram destruídos, o jogo termina
                        GameOver();
                        Score = 0;
                        return;
                    }
                    if (enemy.Visible)
                    {
                        // Verifica se algum inimigo atingiu as bordas do campo de batalha para determinar se os inimigos devem mudar de direção e descer
                        if (enemy.Position.X == Constant.BattleFieldLeft)
                        {
                            // Se um inimigo atingiu a borda esquerda, os inimigos devem mudar de direção para a direita e descer
                            goLeft = false;
                            goDown = true;
                        }
                        if (enemy.Position.X == Constant.BattleFieldWidth - 2)
                        {
                            // Se um inimigo atingiu a borda direita, os inimigos devem mudar de direção para a esquerda e descer
                            goLeft = true;
                            goDown = true;
                        }
                    }
                }
            }
            // Atualiza a direção dos inimigos com base nas verificações realizadas
            enemiesGoLeft = goLeft;
            enemiesGoDown = goDown;
            
        }

        /// <summary>
        /// Método <c>CheckEnemyHit</c> é responsável por verificar se um projétil disparado pelo jogador atingiu algum inimigo no campo de batalha. Ele percorre a matriz de inimigos e compara a posição do projétil com a posição de cada inimigo visível. Se o projétil atingir um inimigo, o método atualiza a pontuação do jogador com base no nível e na linha do inimigo, reproduz um som de explosão, destrói o inimigo e decrementa a contagem de inimigos vivos. O método retorna true se algum inimigo foi atingido, indicando que o projétil deve ser removido do jogo, ou false se nenhum inimigo foi atingido, permitindo que o projétil continue em movimento.
        /// </summary>
        /// <param name="bullet">Projétil</param>
        /// <returns>Verdadeiro se algum inimigo foi atingido</returns>
        bool CheckEnemyHit(Bullet bullet)
        {
            // Verifica se um projétil disparado pelo jogador atingiu algum inimigo no campo de batalha
            for (var row = 0; row < Constant.EnemiesRows; row++)
            {
                // Compara a posição do projétil com a posição de cada inimigo visível
                for (var col = 0; col < Constant.EnemiesPerRow; col++)
                {
                    // Verifica se o inimigo está visível e se a posição do projétil coincide com a posição do inimigo (considerando a largura do inimigo)
                    if (enemies[row, col].Visible &&
                        enemies[row, col].Position.Y == bullet.Position.Y &&
                        (enemies[row, col].Position.X == bullet.Position.X ||
                         enemies[row, col].Position.X + 1 == bullet.Position.X ||
                         enemies[row, col].Position.X + 2 == bullet.Position.X
                        ))
                    {
                        // Se o projétil atingir um inimigo, atualiza a pontuação do jogador com base no nível e na linha do inimigo, reproduz um som de explosão, destrói o inimigo e decrementa a contagem de inimigos vivos
                        Score += Level * row;
                        Util.PlayWavFile(Resource1.explosion);
                        enemies[row, col].Destroy();
                        aliveEnemies--;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Método <c>CheckPlayerHit</c> é responsável por verificar se um projétil disparado pelo inimigo atingiu o jogador no campo de batalha.
        /// </summary>
        /// <param name="bullet">Projétil</param>
        /// <returns>Verdadeiro se algum inimigo foi atingido</returns>
        bool CheckPlayerHit(Bullet bullet)
        {
            // Compara a posição do projétil com a posição do canhão
            if (bullet.Position.X == cannon.Position.X && bullet.Position.Y ==  cannon.Position.Y)
            {                
                Util.PlayWavFile(Resource1.explosion);
                cannonsLeft--;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método <c>UpdatePlayerBullets</c> é responsável por atualizar a posição dos projéteis disparados pelo jogador e verificar se eles atingiram algum inimigo ou se saíram do campo de batalha. Ele percorre a lista de projéteis e, para cada projétil que foi disparado, desenha o projétil na tela, verifica se ele atingiu algum inimigo usando o método CheckEnemyHit, e se atingiu, marca o projétil como não disparado. Em seguida, faz uma pausa para controlar a velocidade do movimento do projétil, limpa a posição anterior do projétil e move o projétil para cima. Se o projétil atingir o topo do campo de batalha, ele é marcado como não disparado para ser reutilizado em futuros disparos.
        /// </summary>
        void UpdatePlayerBullets()
        {
            // Atualiza a posição dos projéteis disparados pelo jogador e verifica se eles atingiram algum inimigo ou se saíram do campo de batalha
            for (var b = 0; b < Constant.PlayerBullets; b++)
            {
                // Verifica se o projétil foi disparado
                if (playerBullets[b].Shot)
                {
                    // Desenha o projétil na tela
                    playerBullets[b].Draw();
                    if (CheckEnemyHit(playerBullets[b]))
                    {
                        // Se o projétil atingiu um inimigo, marca o projétil como não disparado para ser reutilizado em futuros disparos
                        playerBullets[b].Shot = false;
                    }
                    // Faz uma pausa para controlar a velocidade do movimento do projétil
                    Util.Wait(17);

                    // Limpa a posição anterior do projétil
                    playerBullets[b].Clear();

                    // Move o projétil para cima e verifica se atingiu o topo do campo de batalha
                    if (playerBullets[b].Position.Y-- == Constant.BattleFieldTop)
                    {
                        // Se o projétil atingiu o topo do campo de batalha, marca o projétil como não disparado para ser reutilizado em futuros disparos
                        playerBullets[b].Shot = false;
                    }
                }
            }
        }

        /// <summary>
        /// Método <c>UpdateEnemiesBullets</c> é responsável por atualizar a posição dos projéteis disparados pelos inimigos e verificar se eles atingiram o jogador ou se saíram do campo de batalha. 
        /// Ele percorre a lista de projéteis e, para cada projétil que foi disparado, desenha o projétil na tela, verifica se ele atingiu o jogador usando o método CheckPlayerHit, 
        /// e se atingiu, marca o projétil como não disparado. 
        /// Em seguida, faz uma pausa para controlar a velocidade do movimento do projétil, limpa a posição anterior do projétil e move o projétil para baixo. 
        /// Se o projétil atingir a base do campo de batalha, ele é marcado como não disparado para ser reutilizado em futuros disparos.
        /// </summary>
        void UpdateEnemiesBullets()
        {
            // Atualiza a posição dos projéteis disparados pelos inimigos e verifica se eles atingiram o jogador ou se saíram do campo de batalha
            for (var b = 0; b < Constant.PlayerBullets; b++)
            {
                // Verifica se o projétil foi disparado
                if (enemiesBullets[b].Shot)
                {
                    // Desenha o projétil na tela
                    enemiesBullets[b].Draw();
                    if (CheckPlayerHit(enemiesBullets[b]))
                    {
                        // Se o projétil atingiu o jogador, marca o projétil como não disparado para ser reutilizado em futuros disparos
                        enemiesBullets[b].Shot = false;
                        enemiesShooting--;
                    }
                    // Faz uma pausa para controlar a velocidade do movimento do projétil
                    Util.Wait(17);

                    // Limpa a posição anterior do projétil
                    enemiesBullets[b].Clear();

                    // Move o projétil para cima e verifica se atingiu a base do campo de batalha
                    if (enemiesBullets[b].Position.Y++ == Constant.BattleFieldBottom)
                    {
                        // Se o projétil atingiu a base do campo de batalha, marca o projétil como não disparado para ser reutilizado em futuros disparos
                        enemiesBullets[b].Shot = false;
                        enemiesShooting--;
                    }
                }
            }
        }

        /// <summary>
        /// Método <c>Update</c> é responsável por atualizar o estado do jogo a cada ciclo do loop principal. Ele desenha o canhão do jogador, verifica se todos os inimigos foram derrotados para avançar para o próximo nível, randomiza a velocidade dos inimigos e atualiza a posição dos inimigos e projéteis. Além disso, ele atualiza a barra de status do campo de batalha com as informações atuais do jogo, como o nível, a pontuação e a melhor pontuação.
        /// </summary>
        void Update()      
         {
            // Desenha o 'canhão' do jogador
            cannon.Draw();

            // Verifica se todos os inimigos foram derrotados para avançar para o próximo nível
            if (aliveEnemies == 0)
            {
                // Se todos os inimigos foram derrotados, avança para o próximo nível
                NextLevel();
            }

            // Randomiza a velocidade dos inimigos e atualiza a posição dos inimigos e projéteis
            if (RandomizeEnemiesSpeed() < 5f)
            {
                // Se a velocidade dos inimigos for menor que um determinado valor, atualiza a posição dos inimigos
                UpdateEnemies();
            }

            // Atualiza a posição dos projéteis disparados pelo jogador e verifica se eles atingiram algum inimigo ou se saíram do campo de batalha
            UpdatePlayerBullets();

            // Atualiza a posição dos projéteis disparados pelos inimigos e verifica se eles atingiram algum inimigo ou se saíram do campo de batalha
            UpdateEnemiesBullets();

            // Atualiza as informações atuais do jogo, como o nível, a pontuação e a melhor pontuação
            UpdateGameInfo();

        }

        /// <summary>
        /// Mostra a barra de status do jogo, atualizando as informações de som, nível, pontuação e melhor pontuação. O status do som é mostrado como "On" ou "Off", o nível é mostrado como um número inteiro, a pontuação e a melhor pontuação são mostrados como números inteiros com 6 dígitos, preenchidos com zeros à esquerda se necessário.
        /// </summary>
        public void UpdateGameInfo()
        {
            var cannons = "";
            if (cannonsLeft > 0)
            {
                cannons = Util.Repeat(cannon.Sprite + " ", cannonsLeft);
            }
            Util.WriteAt(3, 1, cannons.PadRight(5));
            Util.WriteAt(Constant.BattleFieldSoundStatusCol, Constant.BattleFieldStatusBar, Program.PlaySound ? "On " : "Off");
            Util.WriteAt(Constant.BattleFieldLevelCol, Constant.BattleFieldStatusBar, Level.ToString());
            Util.WriteAt(Constant.BattleFieldScoreCol, Constant.BattleFieldStatusBar, Score.ToString().PadLeft(6, '0'));
            Util.WriteAt(Constant.BattleFieldBestScoreCol, Constant.BattleFieldStatusBar, BestScore.ToString().PadLeft(6, '0'));
        }

    }
}
