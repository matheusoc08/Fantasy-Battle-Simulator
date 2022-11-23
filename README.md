# Fantasy Battle Simulator
Jogo de batalhas em turnos inspirado em RPG.

Projeto inicialmetne solo apenas para estudo.

## Proposta
A proposta do jogo é possibilitar batalhas 1v1 em que os jogadores poderão selecionar um dos personagens disponíveis e selecionar seus movimentos de luta. A partida acabará quando a vida de um dos lados chegar a 0.

## Personagens
Cada personagem possui uma classe que implica valores diferentes em seus atributos. As classes disponíveis são Warrior, Barbarian, Mage e Assassin.

Os atributos que sofrem variação pela classe são:
- Health Points (Pontos de vida)
    #### Vida máxima que enquanto for maior que 0 permite ao personagem continuar em batalha.
- Mana Points (Pontos de mana)
    #### Enquanto for maior que 0 permite ao personagem conjurar magias.
- Physical Attack (Ataque físico)
    #### Quantidade de dano físico que o personagem pode infligir.
- Magic Attack (Ataque mágico)
    #### Quantidade de dano mágico que o personagem pode infligir.
- Physical Defense (Defesa física)
    #### Quantidade de dano físico que o personagem pode anular.
- Magic Defense (Defesa mágica)
    #### Quantidade de dano mágico que o personagem pode anular.
- Critical Rate (Taxa crítica)
    #### Probabilidade de infligir um ataque mais poderoso na rodada.

## Classes
O personagem base possui status com valores mínimos que recebem a variação pela classe.

- HealthPoints = 500
- ManaPoints = 100
- PhysicalAttack = 100
- MagicAttack = 50
- PhysicalDefense = 20
- MagicDefense = 15
- CriticalRate = 1

### Warrior - Guerreiro
Guerreiros são personagens intermediários com bonus moderado em ataque fisico, defesa fisica, pontos de vida e um bonus baixo em taxa crítica.

HealthPoints += 50
PhysicalAttack += 15
PhysicalDefense += 10
CriticalRate += 4

### Barbarian - Bárbaro
Bárbaros são personagens focados em durabilidade, possuindo um bonus alto nos pontos de vida e um bonus moderado em ataque fisico e defesa fisica.

HealthPoints += 100
PhysicalAttack += 10
PhysicalDefense += 15
### Mage - Mago
Magos são personagens com bonus altos em todos os atributos ligados a magia.

ManaPoints += 100
MagicAttack += 100
MagicDefense += 10
### Assassin - Assassino
Assassinos são focados exclusivamente em ataque físico recebendo bonus altos em ataque físico e na taxa crítica.

PhysicalAttack += 20
CriticalRate += 30

## Ataques
Cada ataque possui um nome, tipo (físico ou mágico) e valor de efeito. Esse valor soma-se ao valor do atributo referente do personagem.

### Físicos
O dano efetivo causado por ataques físicos é calculado após subtrair o valor total pela defesa física do alvo. Se o resto for menor que a defesa física do oponente, o ataque será anulado.

### Mágicos
Todos os ataques mágicos consomem uma quantia de MP para serem efetuados. Se não houver MP o bastante, o ataque não será executado e o personagem perderá o round.

O dano efetivo causado por ataques mágicos é calculado após subtrair o valor total pela defesa mágica do alvo. Se o resto for menor que a defesa mágica do oponente, o ataque será anulado. Mesmo tendo o ataque anulado, ainda haverá o consumo de MP.

