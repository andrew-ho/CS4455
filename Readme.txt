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



Submission Technology Requirements:
- The main character is controlled with a 3rd person character controller.
- The player and camera can be controlled independently.
- The game world utilizes physics-based puzzles with spatial simulation (e.g. placing blocks on one side of a fulcrum to weigh it down). These puzzles require the player to interact with their environment.
- There are state-based AI enemies that detect the player once they're in the enemy's field of view (which is a cone that simulates real vision, not a simple raytrace) and chase them using steering behaviors and a NavMesh. Soon after the player escapes the enemy's field of view, the enemy stops for a moment before giving up and walking back to its original location and rotation.
- Some elements, such as animations and aspects of the character controller, are placeholder assets from the Asset Store. These will be replaced with custom assets in the final build.