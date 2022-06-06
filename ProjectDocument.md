# Game Basic Information #

## Summary ##

One unfortunate day, an evil fishing net was cast over the sea, trapping and endangering all the marine life. With no other hope left, the fishes look to
a blobfish named Blob Boi, who inherits the ancient ability of gravity manipulation to lift himself off of the sea floor. Unwilling to let the net
conquer all that remains, Blob Boi rises to the occasion, tasked with ensuring the safe rescue of his aquatic brethren and returning peace to sea. Will
he be able to turn the tides and save everyone? Or will life as he knows it be forever swept away by the net's destruction?

## Gameplay Explanation ##

This game functions as a 2D platformer that features puzzle elements centered around player movement. The core gameplay mechanic revolves around rotating 
the camera, which changes the direction of gravity along with it. The player needs to use this mechanic to maneuver through levels and gain access to
otherwise impossible-to-reach places.

In order to win the game, the player must save all the fish. Each level contains fish placed in various locations, who can be saved by directly
approaching them. Players can proceed on to the next level by reaching the exit portal. All fish must be saved before the player reaches the final exit
portal in order to achieve the game's good ending.

The player possesses three lives. A life is lost when the player falls outside of the level's boundaries. Game Over occurs when all lives are lost or when there are still fish remaining after reaching the final exit portal.

### Controls ###

*W* - Jump

*A* - Move Left

*D* - Move Right

*E* - Proceed with Dialogue

*Q* - Pause Game

*Left Click* - Rotate Camera/Gravity Clockwise

*Right Click* - Rotate Camera/Gravity Counter Clockwise


**If you did work that should be factored in to your grade that does not fit easily into the proscribed roles, add it here! Please include links to resources and descriptions of game-related material that does not fit into roles here.**

# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## User Interface

**Describe your user interface and how it relates to gameplay. This can be done via the template.**

## Movement/Physics

The premise of this game is that the blobfish can move around in 4 directions of gravity: Up, Down, Right, and Left. As a result, the basics of movement follow that of RigidBody2D and BoxCollider2D interactions paired with modifying the global Physics2D.gravity value as needed. It is an extension of the standard physics model. On certain input values, the physics is rotated left or right and the blobfish’s relative movements are internally altered so the respective left, right, and jump movements are maintained despite the direction of gravity. For example, if the gravity is towards the right (in the positive X-axis), then the blobfish's left and right movements result in its y-position being adjusted to parallel the standard physics system. The speed of the blobfish, the amount of gravity, its height of jump, as well as the level design are carefully coordinated to encourage the use of gravity change in completing the game. We created separate files for gravity adjustment, movement directions, and player’s movement to manage all the components that shift with the gravity, including the blobfish’s rotation and camera orientation. The movements of camera are discussed more in detail in the game feel section as it is a critical part to conveying the movements of the blobfish. 

## Animation and Visuals

**List your assets including their sources and licenses.**

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

## Input

**Describe the default input configuration.**

**Add an entry for each platform or input style your project supports.**

## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

# Sub-Roles

## Audio

**List your assets including their sources and licenses.**

**Describe the implementation of your audio system.**

**Document the sound style.** 

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**



## Game Feel

As the theme of the game is set under the ocean, I had decreased the magnitude of the gravity to allow more of a floating feel. Furthermore, when creating the levels I chose elements that would fit the ocean theme while also giving the player to explore different techniques of gravity adjustment. As a result, the first level shaped as a whale is without any danger zones, followed by a level that requires the use of gravity in mostly all directions. Levels 3,4, and 5 display a water bottle, a diver’s helmet, and an explorative anchor that each require different techniques and timings to navigate. There are intentional gaps especially within the diver’s helmet to increase its level of difficulty. Lastly, we needed an indicator for the player to stay relatively close to the level and not drift off, and so we created a life system that would decrease if the player went too far away from the level. In order to indicate the danger of leaving the level platforms, we color coordinated the level to suggest that the calmer waters of inside the level are more preferable than the dark blue dangerous waters. Outside of the levels themselves, the rotation of gravity brought its own set of altercations. In order to keep the player engaged, the gravity, player, and camera had to be rotation in unison so the gameplay felt logical. Furthermore, to prevent spamming of gravity rotations and the abrupt shifts of the screen, a delay had to be incorporated for the rotation of both the camera and the player. This resulted in rotating the camera and the player the same number of degrees and creating an indicator for when new gravity rotation values could be accepted. And so, the gravity had to be low enough to not allow abrupt movements or shifts in the blobfish, but high enough to still incorporate a physics system. 
