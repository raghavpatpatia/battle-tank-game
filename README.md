# BattleTank Game

[![BattleTank Gameplay](https://img.youtube.com/vi/EMmD5BAQf1A/0.jpg)](https://www.youtube.com/watch?v=EMmD5BAQf1A)

BattleTank is an exciting tank battle game featuring advanced game development concepts such as Model-View-Controller (MVC) architecture, Singletons, Observer Pattern, Event System, Object Pooling, Interfaces, and Object-Oriented Programming (OOP) principles.

## Features

### MVC Architecture

The game follows the MVC design pattern to separate concerns and organize the codebase efficiently. This architecture enhances maintainability and scalability.

### Singletons

Managers and services in the game are implemented as Singletons to ensure a single instance throughout the game's lifecycle. This includes the GameManager, TankService, EnemyTankService, BulletService, and more.

### Observer Pattern and Event System

The game utilizes the Observer Pattern and an Event System for the Achievement System. Achievements are unlocked through events, providing a flexible and decoupled system for tracking player progress.

### Object Pooling

Bullet instantiation and destruction are optimized using Object Pooling. The BulletService manages pools of bullets, improving performance by reusing objects instead of creating and destroying them dynamically.

### Interfaces and OOPs Concepts

The codebase incorporates Interfaces and Object-Oriented Programming principles to enhance modularity, extensibility, and code readability.

## Game Components

- **GameManager:** Manages overall game state and initialization.
- **TankService:** Controls player tank movement and actions.
- **EnemyTankService:** Handles spawning and management of enemy tanks.
- **BulletService:** Manages bullet firing and collision detection.
- **Achievement System:** Unlocks achievements based on player actions.

