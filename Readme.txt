Instructions:
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
To Start Game: Unzip file and run Game Menu scene.

“Spatial Control” is a Stealth/Puzzle game in which the player character, Reese, must navigate through areas within a secret underground base while avoiding or defeating guards. Nuclear Enterprises™ is secretly developing a doomsday device. Reese has acquired a prototype of a handheld spatial control device that can manipulate its surroundings, lifting objects from a distance and “pausing” objects and enemies for a limited amount of time. With this new tool, it’s up to Reese to infiltrate the underground base and destroy the doomsday device.

The object of the game is to reach the exit in each stage without getting captured. There are four areas, each with a boss enemy that must be defeated. The evil director in the final area is the last line of defense. Each level is harder than the last, with new enemy types, puzzles, and objects that can be manipulated. The player is able to complete challenges with a mix of strategic evasion and direct attack.

Aside from Reese, the other characters are guards and executives at Nuclear Enterprises, AI-controlled enemies who aim to stop any intruders. The easiest type is the Rent-A-Guard, who will only stand in place and detect what he sees in front of him. The second type is the Junior Guard, who will move in an AI-controlled pattern. The player has very little health, so poor planning will lead to failure.

The player can freely control Reese’s movement, along with the Pause, Move, and Force functions of the spatial controller, through a mouse and keyboard. Pause can temporarily freeze certain objects/enemies in time, Move allows the player to pick up certain objects from far away, and Force can push nearby heavy objects. In particular, the player can pause an object, apply a heavy force to the object, then un-pause to send it flying across the map. Though some enemies can be paused immediately, others have to be weakened first through environmental hazards (e.g. using Move to drop a boulder onto a slope, which rolls into the enemy). There are also certain objects that can only be slowed down, so the player may have to react quickly.

Submission Technology Requirements:
- The main character is controlled with a 3rd person character controller.
- The player and camera can be controlled independently.
- The game world utilizes physics-based puzzles with spatial simulation (e.g. placing blocks on one side of a fulcrum to weigh it down). These puzzles require the player to interact with their environment.
- There are state-based AI enemies that detect the player once they're in the enemy's field of view (which is a cone that simulates real vision, not a simple ray trace) and chase them using steering behaviors and a NavMesh. Soon after the player escapes the enemy's field of view, the enemy stops for a moment before giving up and walking back to its original location and rotation.


Team members:
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
email: bangpham@gatech.edu
OIT: bpham31
Contribution: Game AI, game levels logic, some menu,level design ideas, create scenes, enemy models, adding missing arts,analysis of playtesting results, presenting presentation materials
=====================
name: An Truong
email: atruong32@gatech.edu
OIT: atruong32
Contribution: Game Menu,Adding animations for player and enemies, Adding objects to the scenes, polishing menus, adding missing arts, analysis of playtesting results, deliverables created on time, bookkeeping
=====================
name: Quyen Do
email: btran1002@gatech.edu
OIT: btran1002
Contribution: Game Menu, Adding animations for player and enemies level design ideas, Adding objects to the scenes, polishing menus, adding missing arts,analysis of playtesting results, deliverables created on time, bookkeeping
=====================
