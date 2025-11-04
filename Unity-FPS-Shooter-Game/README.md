# Unity Shooter Game

## Project Summary

This project is a fast-paced Unity shooter game where the player must survive and eliminate as many enemies as possible before time runs out. The game features a countdown timer, enemy waves, score tracking, and a simple UI for game over and menu navigation.

## Gameplay Explanation

- The player starts with a set amount of time (default: 120 seconds).
- Enemies spawn in waves and approach the player.
- The player must shoot and destroy enemies to increase their score.
- When the timer reaches zero, the game ends and the final score is displayed.
- The game includes a main menu and an end game UI for user navigation.

## Controls & Instructions

- **Movement:** Use `W`, `A`, `S`, `D` keys to move the player character.
- **Aiming:** Move the mouse to aim the gun.
- **Shooting:** Left mouse button to fire the gun.
- **Pause/Menu:** Press `Esc` to open the main menu.
- **Restart:** Use the UI buttons in the EndUI scene to restart or return to the main menu.

## Packages Used

- **TextMeshPro:** For advanced text rendering in UI elements (timer, score, etc.).
- **UnityEngine.UI:** For basic UI components such as buttons and panels.
- *(Add other packages here if used, e.g., Input System, Post Processing, Cinemachine, etc.)*

## Key Scripts & Class Descriptions

- **Timer.cs:** Handles the countdown timer and triggers game over when time runs out.
- **PlayerController.cs:** Manages player movement and input.
- **Gun.cs:** Controls gun behavior, including firing and reloading.
- **Shooter.cs:** Implements shooting mechanics and bullet instantiation.
- **Enemy.cs:** Defines enemy behavior, health, and interactions.
- **EnemySpawner.cs / EnemyWaveSpawner.cs:** Spawns enemies and manages wave progression.
- **EnemyDestroyCounter.cs / EnemyCounter.cs:** Tracks the number of enemies destroyed and updates the score.
- **MainMenu.cs:** Handles main menu navigation and UI interactions.
- **EndUI.cs:** Displays the end game UI, showing the final score and options to restart or exit.

## Known Limitations

- Basic enemy AI; enemies may have simple movement and attack patterns.
- No advanced input system (Unity's new Input System is not implemented).
- Limited variety in enemy types and wave mechanics.
- No post-processing or advanced visual effects.
- Game over logic is straightforward and may require further polish for production.
- No save/load functionality for scores or progress.

---

*Expand this README as your project grows, adding new features, packages, and gameplay details.*
