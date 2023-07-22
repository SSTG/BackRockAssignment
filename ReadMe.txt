Greetings. Here is the codebase for the project 3-Pac, a 3D PacMan clone game. As stated in the document, and as of this moment, here's the 
description of the codebase and the things accomplished.

1) All the basic mechanics have been implemented. Player can turn only on intersections, can consume pellets and will die on touching a ghost.
2) For some reason, NavMesh isn't working on my system. I tried everything but I couldn't get it to work. Therefore, I made a makeshift AI from 
scratch(Ghosts move in random directions). The problem with it is the ghost can sometimes get stuck to a wall, in which case his position is reset.
3) A simple UI is implemented in the game. A start menu, a score text and a simple death scene.
4) Singleton pattern has been used for the ScoreManager of the game
5) Object Pooling is used for the pellets. However, some pellets might spawn off-screen but majority lies within the maze