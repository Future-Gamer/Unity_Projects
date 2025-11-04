# XR Target Shooting Game

## Overview

This is a VR target shooting game built with Unity and XR Interaction Toolkit. Players use XR controllers (or the XR Device Simulator) to grab a gun, shoot targets, and aim for the highest score before time runs out.

---

## Setup Instructions

### Prerequisites

- **Unity Version:** *[Replace with your Unity version, e.g., 2021.3.10f1]*
- **Packages Used:**
  - XR Interaction Toolkit *(e.g., 2.3.2)*
  - Input System *(e.g., 1.3.0)*
  - TextMeshPro
  - (Add any other relevant packages)

### XR Device Simulator Setup

1. Open your Unity project.
2. Go to `Window > Package Manager`.
3. Install **XR Interaction Toolkit**.
4. In the Project window, navigate to `Assets > XR > Device Simulator`.
5. Drag the **XR Device Simulator** prefab into your scene.
6. Ensure the **XR Rig** is present and configured.
7. Press Play. Use keyboard/mouse controls to simulate XR input.

---

## How the Game Works

- **Objective:** Shoot as many targets as possible before the timer runs out.
- **Gameplay:**
  - Grab the gun using the XR controller or simulator.
  - Aim at targets and fire.
  - Each hit increases your score.
  - The game ends when time expires or all targets are hit.
  - End UI displays your score and options to play again or quit.

---

## Controls

### XR Device Simulator (Default Key Bindings)

| Action                | Key/Mouse                |
|-----------------------|--------------------------|
| Move Headset          | Right Mouse + Move Mouse |
| Move Left Controller  | Q/E (up/down), WASD      |
| Move Right Controller | R/F (up/down), IJKL      |
| Select/Activate       | Left/Right Ctrl          |
| Grab Object           | Left/Right Alt           |
| Teleport              | T                        |
| Fire Gun              | Activate (Ctrl)          |

*Refer to the XR Device Simulator documentation for full key mapping.*

---

## Screenshots

> *(Insert screenshots here. Example below:)*

![Gameplay Screenshot](Screenshots\Screenshot 2025-10-20 212342.png)
![Gameplay Screenshot](Screenshots\Screenshot 2025-10-20 212404.png)
![Gameplay Screenshot](Screenshots\Screenshot 2025-10-20 212511.png)
![End UI Screenshot](Screenshots\Screenshot 2025-10-20 212557.png)

---

## Known Limitations & Bugs

- **Editor Quit:** `Quit` button only exits play mode in the Unity Editor, not the editor itself.
- **Simulator Controls:** Some XR interactions may not be fully replicated with the simulator.
- **Performance:** May vary depending on hardware and XR device.
- **Other Issues:** *(List any additional bugs or limitations found during testing.)*
