# Relatório Snakes and Ladders - Linguagens de Programação I
**Trabalho realizado por: Hugo Carvalho 21901624 | André Figueira 21901435 | João Gonçalves 21901696**

---

## Divisão do projeto:

**1. Create repository with solution and gitignore -** João Gonçalves
   - Criação do projeto.

**2. Create Introduction and Menu of the game -** João Gonçalves
   - Criação da introdução e menu de jogo.

**3. Project organization, gitattributes added -** Hugo Carvalho
   - Organização conforme o "gameloop pattern", e adição do "gitattributes".


**4. Creates and displays menu -** André Figueira
   - Criação da enumaração *Houses*, do tabuleiro de jogo e representação do tabuleiro.

**5. Write Instructions -** João Goncalves
   - Adição das instruções de jogo.

**6. Update DisplayMenu code -** João Gonçalves
   - Update do DisplayMenu.

**7. Player class add, house enum fix, UserInterface fix, board fix -** Hugo Carvalho
   - Criação da classe *player*, Correção na enumeração House e no board.

**8. Add GameLoop, General Bugfix -** André Figueira
   - Criação da classe *GameLoop*, e "bugfixing" do UserInterface.

**9. Dice class add, Houses diplayed in board add -** João Gonçalves
   - Criação da classe *Dice*, Geração das casas especiais, e representação das mesmas no tabuleiro.

**10. add player movement, winner message, board class organization -** Hugo Carvalho
   - Adição do movimento do jogador, mensagem de vitória e organização da classe *Board*

**11. Add snakes and ladders houses -** André Figueira
   - Casas "snakes" e "ladders" a funcionar conforme as suas ações respetivas.

**12. Add Cobra and boost houses -** Hugo Carvalho
   - Casas "Cobra" e "boost" a funcionar conforme as suas ações respetivas.

**12. Add U-Turn, Extra Die and general bug fixing -** João Gonçalves
   - Casas "U-Turn" e "Extra Die" a funcionar conforme as suas ações respetivas.

**13. Add report -** André Figueira
   - Adicionado o report do trabalho.
---

## Arquitetura da Solução:
Em relação à arquitetura da nossa solução, utilizámos o Gameloop Pattern e o Single Responsibility Pattern, pois a classe *GameLoop* é responsável por interagir com as restantes. A nossa solução consiste na classe *Board* que contém o tabuleiro do jogo, sendo que este tem um array bidimensional de char[,]  que por sua vez são manipulados pela enum char *Houses*,  que contém os tipos de cada casa. A classe *Player* cria os jogadores que irão ser movidos através da classe *Board*. A classe *Dice* gera números aleatórios que depois fazem com que os jogadores sejam movidos. Temos depois uma classe *UserInterface* que é responsável pelas impressões na consola. Por fim, existe a classe *Gameloop* que tem as instâncias *board* e *userInterface*, para que haja um loop entre o movimento das peças, atualização das posições, renderização do tabuleiro e pela troca de turno caso a condição de vitória ainda não tenha sido verificada. Quando um jogador vence o jogo, o programa termina.

![Flowchart](flowchart.png)

---

## Referências:

- Na realização do nosso projeto, foram trocadas impressões com o nosso colega João Matos, sobre o movimento dos jogadores pelo tabuleiro. Depois desta troca de ideias implementámos então a lógica discutida com o colega.
- StackOverflow
- Microsoft .NET API