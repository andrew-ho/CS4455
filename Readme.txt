INSTRUCTIONS
- Get to the end of the room while avoiding or defeating enemies.
- Sneak around and don't let anyone see you.
- Use your environment to overcome puzzles and deal with enemies.

Controls:
W/D - Move forwards/backwards
Space - Jump
Shift (hold) - Run
E (while looking at an object/enemy) - Use ability
Mouse - Change direction
Mouse wheel - Change ability
Esc - Pause

Abilities:
Freeze - Freeze an object/enemy for five seconds.
Move - Take control of a faraway object. Use the mouse and mouse wheel to manipulate the object.
Push - Apply immediate force to, or push, a nearby object.

====================

“Spatial Control” is a Stealth/Puzzle game in which the player character, Reese, must navigate through areas within a secret underground base while avoiding or defeating guards. Nuclear Enterprises™ is secretly developing a doomsday device. Reese has acquired a prototype of a handheld spatial control device that can manipulate its surroundings, lifting objects from a distance and “pausing” objects and enemies for a limited amount of time. With this new tool, it’s up to Reese to infiltrate the underground base and destroy the doomsday device.

The object of the game is to reach the exit in each stage without getting captured. There are four areas, each with a boss enemy that must be defeated. The evil director in the final area is the last line of defense. Each level is harder than the last, with new enemy types, puzzles, and objects that can be manipulated. The player is able to complete challenges with a mix of strategic evasion and direct attack.

Aside from Reese, the other characters are guards and executives at Nuclear Enterprises, AI-controlled enemies who aim to stop any intruders. The easiest type is the Rent-A-Guard, who will only stand in place and detect what he sees in front of him. The second type is the Junior Guard, who will move in an AI-controlled pattern. The player has very little health, so poor planning will lead to failure.

The player can freely control Reese’s movement, along with the Pause, Move, and Force functions of the spatial controller, through a mouse and keyboard. Pause can temporarily freeze certain objects/enemies in time, Move allows the player to pick up certain objects from far away, and Force can push nearby heavy objects. In particular, the player can pause an object, apply a heavy force to the object, then un-pause to send it flying across the map. Though some enemies can be paused immediately, others have to be weakened first through environmental hazards (e.g. using Move to drop a boulder onto a slope, which rolls into the enemy). There are also certain objects that can only be slowed down, so the player may have to react quickly.

SUBMISSION TECHNOLOGIES REQUIREMENTS:
- The main character is controlled with a 3rd person character controller.
- The player and camera can be controlled independently.
- The game world utilizes physics-based puzzles with spatial simulation (e.g. placing blocks on one side of a fulcrum to weigh it down). These puzzles require the player to interact with their environment.
- There are state-based AI enemies that detect the player once they're in the enemy's field of view (which is a cone that simulates real vision, not a simple ray trace) and chase them using steering behaviors and a NavMesh. Soon after the player escapes the enemy's field of view, the enemy stops for a moment before giving up and walking back to its original location and rotation.

=====================

To Start Game: Unzip file and run Game Menu scene.

=====================

LEVEL WALKTHROUGH:
Tutorial Level Walkthrough
 
Opening text pops up when the level starts, then new text (see guide) pops up when the player enters each door (right before their respective puzzles).
 
(Opening Room)
This first level will teach you how to use each ability to solve puzzles. Walk with WASD and jump with the Spacebar. Move the camera with the Mouse.
 
(Push Room)
First, you have the ability to push objects that are directly in front of you. Walk up to an object and Left Click. Start by pushing this barrel out of the way.
    - Giant barrel in front of a door; push it out of the way and walk through
- Text: “Some objects, such as this boulder, can be used to knock over other objects.
    - Giant boulder on top of a slope, blocking a door, with small barrels at the bottom of the slope (with another slope leading up to the boulder); push it down the slope to unblock the door, and it also rolls down and knocks over the barrels (to show the player that things can be knocked over by other things)
 
(Move Room)
Next, you can move objects even if you are far away from them, like telekinesis. Use the Mouse Wheel to change your current ability from Push to Move. Face an object, press E to pick it up, and use the Mouse and Mouse Wheel to move it around. Press E again to drop it. Try moving this cube onto the button.”
    - Closed door next to cube and button; move the cube onto the button and the door opens
Use your environment to your advantage.”
    - A door on a platform that is too high to reach; move the wide, thin cube in beside the platform and jump up
 
Tutorial (Pause Room)
That platform is moving too fast to walk across. Swap to your Pause ability and press E while facing it to temporarily pause it. You can freeze moving objects for five seconds before they start moving again.
    - Platform moving back and forth over pit; pause it and walk across
        - If you fall down the pit, just walk back up the slope and try again
If you pause something at the wrong time, don’t worry. Wait for it to resume moving and try again.
    - Giant piston that pushes in and out to block door; pause it and walk past
        - Getting pushed shoves you into a pit to the side; walk up the slope and try again
 
Tutorial (Goal Room)
Well done! One more thing: there may be enemy guards that chase you if you enter their line of sight, so try to hide if you get caught. Walk forward to complete the tutorial. Good luck!”
    - The goal is straight ahead. Maybe a green, glowy spot on the ground that you walk onto?
=====================

OUTSIDE SOURCES:
Music is from Kevin MacLeod (incompetech.com)
Camera is from Invector
Humanoid animations are from Mixamo
Textures are from various sources

=====================

TEAM MEMBERS
=====================
name: Bang Pham
email: bangpham@gatech.edu
OIT: bpham31
Contribution: Game menu, instruction menu, pause feature, in game guides, level design ideas, generate scenes, UI, instructions, in game guides, pause analysis of playtesting results, brainstorming, conduct the playtest, conduct and report playtest, readme
=====================
name: Andrew Ho
email: aho44@gatech.edu
OIT: aho44
Contribution: Player Controller, Adding sound effect, player power features, camera,Adding objects to the scenes, polishing the Pause tool, adding missing arts, level design ideas,analysis of playtesting results, creating presentation materials, internal playtesting/QA
=====================
name: Jacob Light
email: tlight6@gatech.edu
OIT: tlight6
Contribution: Game AI, game levels logic, some menu,level design ideas, create scenes, enemy models, adding missing arts,analysis of playtesting results, presenting presentation materials
=====================
name: An Truong
email: atruong32@gatech.edu
OIT: atruong32
Contribution: Game Menu,Adding animations for player and enemies, Adding objects to the scenes, polishing menus, adding missing arts, analysis of playtesting results, deliverables created on time, bookkeeping
=====================
name: Quyen Tran
email: btran1002@gatech.edu
OIT: btran34
Contribution: Game Menu, Adding animations for player and enemies level design ideas, Adding objects to the scenes, polishing menus, adding missing arts,analysis of playtesting results, deliverables created on time, bookkeeping
=====================