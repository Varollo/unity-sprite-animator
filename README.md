# Sprite Animator

Sprite Animator is a Unity package that provides a custom animator designed specifically for 2D sprites. It leverages a global frame duration, allowing for full synchrony between animated objects.

## Features

- **Global Frame Duration:** Set a single frame duration that applies to all sprites in the scene, ensuring they animate in synchrony.
- **Customizable Animations:** Easily define animation sequences, repeatable frames, and customizable wrap modes per sprite.

## Installation

1. Download the latest `.unitypackage` file, from the [Releases](https://github.com/Varollo/unity-sprite-animator/releases) section.
2. Open your Unity project and go to `Assets > Import Package > Custom Package`
3. Select the Sprite Animator package file and import it.

## Usage

### Creating an animation

Right-click the "Project" window, or go to `Assets > Create > Sprite Animator > Animation`.

- **Key:** A key used to identify animations. 
  - *Ex:* "Idle", "Walk", "Jump", e.t.c.
- **WrapMode:** Defines how the animation will wrap, after completing.
  - *Default/Once/Clamp:* Displays the first frame after completion;
  - *Loop:* Restarts the animation from the first frame;
  - *Ping-Pong:* Replays the animation backwards upon completion;
- **Frames:** Each frame of the animation with it's duration.
  - *Sprite:* The sprite reference to display at that frame;
  - *Frame Length:* How many frames to display the sprite. Each frame takes a predefined duration of time, on the Project Settings;

### Setting the Global Frame Duration

To configure how long a frame takes to complete, go to the **Project Settings** window and look for the **Sprite Animator** section.

> **⚠ Warning!**
> Any changes during *play* are going to be **discarded**.

## License

This project is licensed under the MIT License. See the [LICENSE](https://github.com/Varollo/unity-sprite-animator/blob/main/LICENCE.txt) file for details.