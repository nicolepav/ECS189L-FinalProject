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

*Space* - Rotate Camera/Gravity Clockwise

*Alt* - Rotate Camera/Gravity Counter Clockwise

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

I implemented various user interface elements as part of our game to communicate various information to the player. I implemented a title scene, which is the starting point of the game. The title scene has a start button that the player clicks on to play the game. The start button leads to the prologue scene, which tells the story behind our game to the player. Upon pressing enter, the game officially starts, entering the gameplay scene. In the actual game, I implemented a key map to communicate to the player what happens when certain keys are pressed. The player has 3 lives, and the number of lives that the player has left is shown by how many bubbles are displayed. I implemented the functionality so that one bubble disappears every time a life is lost. In the top right, the number of fish successfully saved is displayed with a counter. Pressing the escape button can pause as well as unpause the game. I also implemented an ending scene which tells the player the ending story(other group members then modified this to communicate whether the player won or lost) that leads to an option to play again. 

To communicate that a fish has been successfully saved or that the player is entering a new level, our group member with the audio subrole implemented sound effects.


## Movement/Physics

The premise of this game is that the blobfish can move around in 4 directions of gravity: Up, Down, Right, and Left. As a result, the basics of movement follow that of RigidBody2D and BoxCollider2D interactions paired with modifying the global Physics2D.gravity value as needed. It is an extension of the standard physics model. On certain input values, the physics is rotated left or right and the blobfish’s relative movements are internally altered so the respective left, right, and jump movements are maintained despite the direction of gravity. For example, if the gravity is towards the right (in the positive X-axis), then the blobfish's left and right movements result in its y-position being adjusted to parallel the standard physics system. The speed of the blobfish, the amount of gravity, its height of jump, as well as the level design are carefully coordinated to encourage the use of gravity change in completing the game. We created separate files for gravity adjustment, movement directions, and player’s movement to manage all the components that shift with the gravity, including the blobfish’s rotation and camera orientation. The movements of camera are discussed more in detail in the game feel section as it is a critical part to conveying the movements of the blobfish. 

## Animation and Visuals

Since the game was underwater, the graphics went for a world of underwater caves and things you would find in the ocean. Borders are clearly marked (except on level 4) with a tileset that looks rough rocks that seperate the player from the safe space to the dark unknown that is the outside. Platform that create both obstacle and platforms included seaweed blocks (level 1), rocks (level 2 & 3), metal parts (level 4) and gears (level 5). All the art was done in pixels with a simple color palatte and subtle shading, giving a nolstagic feel 8-bit game feel. 

The blobfish is main character so it is the only sprite that is animated. When it is idle or sliding on a platform, its animations are eye blinking and tail wagging. Once it jumps into the air, it swims with it tail and its facial expression changes. The clownfishes that are being trapped then rescued are brightly colored to standout from the background for visbility and they have a sad face since they are trapped. The messenger pearl was designed to also standout but look wise and feel like a information/narrative guide to the player.

The whole game is tied together through the consistent and cohesive use of art style, backgrounds, button designs, and color use. 

Assets are found in Visuals folder. Animations are found in Animations folder. All assets are created by Julia Ma.

## Input

**Describe the default input configuration.**

**Platforms**

- Windows

WAD movement (up, left, right), left mouse & space rotate right (clockwise), right mouse & alt rotate left (clockwise), q to pause, e to escape/continue dialog interactions

- MacOS

WAD movement (up, left, right), left mouse & space rotate right (clockwise), right mouse & option rotate left (clockwise), q to pause, e to escape/continue dialog interactions

- Web

WAD movement (up, left, right), left mouse & space rotate right (clockwise), right mouse & alt/option rotate left (clockwise), q to pause, e to escape/continue dialog interactions


Input was primarily implemented using the command pattern. Although it seems counter intuitive to have left mouse rotate clockwise and right counterclockwise, we did this because left mouse click is a more instinctual motion and should therefore match the conventional direction of rotation (clockwise).


## Game Logic

The game makes use of 5 different states that the player cycles through as they play the game. The player goes from the Menu->Prologue->Play->Ending, along with a gameover state that can occur during play, which restarts player. The game makes use of the [obeserver](https://github.com/nicolepav/ECS189L-FinalProject/blob/69400a1e0c1ff435885a2ef8e4d733ba2bd0d16f/Game/Assets/Scripts/Managers/LevelManager.cs#L29-L35), [singleton](https://github.com/nicolepav/ECS189L-FinalProject/blob/69400a1e0c1ff435885a2ef8e4d733ba2bd0d16f/Game/Assets/Scripts/Managers/GameManager.cs#L8), [command](https://github.com/nicolepav/ECS189L-FinalProject/blob/69400a1e0c1ff435885a2ef8e4d733ba2bd0d16f/Game/Assets/Scripts/Movement/PlayerController.cs#L130), and [state](https://github.com/nicolepav/ECS189L-FinalProject/blob/69400a1e0c1ff435885a2ef8e4d733ba2bd0d16f/Game/Assets/Scripts/Managers/GameManager.cs#L32-L36) patterns to facilitate gameplay and development. Data about the player's lives and score is recorded and tracked using events in the Game Manager, which passes it on to the scripts that need it. Dialogue was also implmented using scriptable objects allowing for drag-and-drop scripts to be used for conversation with NPCs. The Dialgoue makes use of the LeanTween library from the asset store to provide ease in & out animations for the UI. Levels are also handled through the use of a manager that listens for state changes that signal the game to move the player to the next level. 

# Sub-Roles

## Audio

Below are the attributions/licenses of the sound assets used in the game. This same information can also be found a README.md file found inside of the
folder containing the sound assets.

"269583__deleted-user-3854053__bubble.wav" from [Bubble](https://freesound.org/people/deleted_user_3854053/sounds/269583/) by deleted-user-3854053 licensed under [Creative Commons 0](https://creativecommons.org/publicdomain/zero/1.0/)

"341250__jeremysykes__select01.wav" from [8Bit Video Games](https://freesound.org/people/jeremysykes/sounds/341250/) by jeremysykes licensed under [Creative Commons 0](https://creativecommons.org/publicdomain/zero/1.0/)

"398708__inspectorj__water-swirl-small-17.wav" from [Water Swirl, Small](https://freesound.org/people/InspectorJ/sounds/398708/) by InspectorJ licensed under [Creative Commons Attribution 4.0](https://creativecommons.org/licenses/by/4.0/)

"485065__javierserrat__bubble.wav" from [Bubble](https://freesound.org/people/JavierSerrat/sounds/485065/) by JavierSerrat licensed under [Creative Commons Attribution 3.0](https://creativecommons.org/licenses/by/3.0/)

"530617__lukeo135__slime.ogg" from [Slime](https://freesound.org/people/Lukeo135/sounds/530617/) by Lukeo135 licensed under [Creative Commons 0](https://creativecommons.org/publicdomain/zero/1.0/)

"530776__rickplayer__select.mp3" from [Select](https://freesound.org/people/Rickplayer/sounds/530776/) by Rickplayer licensed under [Creative Commons 0](https://creativecommons.org/publicdomain/zero/1.0/)

"Death Sound 4.mp3" from [GameBoy SFX Pack #1](https://omegaosg.itch.io/gameboy-sfx-pack) by OmegaPixelArt

"Low Thud.mp3" from [GameBoy SFX Pack #1](https://omegaosg.itch.io/gameboy-sfx-pack) by OmegaPixelArt

"Ludum Dare 32 - Track 2.wav" from [FREE Music Loop Bundle](https://tallbeard.itch.io/music-loop-bundle) by [Abstraction](http://www.abstractionmusic.com/)

"Ludum Dare 32 - Track 5.wav" from [FREE Music Loop Bundle](https://tallbeard.itch.io/music-loop-bundle) by [Abstraction](http://www.abstractionmusic.com/)

"Ludum Dare 38 - Track 2.wav" from [FREE Music Loop Bundle](https://tallbeard.itch.io/music-loop-bundle) by [Abstraction](http://www.abstractionmusic.com/)

"Somewhere at Sea.wav" from [Space Music Pack](https://gooseninja.itch.io/space-music-pack) by Goose Ninja

"Underwater Shoot.wav" from [GameBoy SFX Pack #1](https://omegaosg.itch.io/gameboy-sfx-pack) by OmegaPixelArt

The audio system was implemented in a similar manner to the audio systems found in each of the exercises for ECS 189L, having a [SoundManager script](https://github.com/nicolepav/ECS189L-FinalProject/blob/34a7d17a452b0afa679bf9e6719cbbc881b22ce9/Game/Assets/Scripts/Managers/SoundManager.cs)
handle the playback of each music track and sound effect added as a [Sound Clip](https://github.com/nicolepav/ECS189L-FinalProject/blob/34a7d17a452b0afa679bf9e6719cbbc881b22ce9/Game/Assets/Scripts/SoundClip.cs).
Brackey's [Intro to AUDIO in Unity](https://www.youtube.co/watch?v=6OT43pvUyfY) was used as a reference for this implementation. In addition, the
SoundManager script was made to be a static instance that can be called directly from other scripts, instead of having to find the SoundManager object
each time a sound needed to be played.

The desired sound style for this game is a retro 8-bit/16-bit aesthetic, in order to align with the pixel art of the game's visuals. I used music tracks
and sound effects that either directly mirrored this sound style or were reminiscent of it while using more modern sound production. In addition, I used
wet, watery sounds like bubbles and splashing to complement the underwater theme of the game.

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

The game followed the story of one blobfish's adventure discovering the ancient art of gravity maniputlation which the prologue gave context to. On each level, there is a Messenger Pearl that the player will talk to that give them a little more information about what's going on in the world that he is completing his rescue mission in. At the end, the epilogue provides insight to the future of now the gravity-defying blobfish and his new life. 

As the levels advance, shapes the maps helped the narrative too. It provided the world that the blobfish travels in and the stories that the messsenger pearl would tell.

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**
Project README.md includes brief press overview, including links to trailer and flyer/press release. README also contains most of the screenshots.

[Press Flyer](https://github.com/nicolepav/ECS189L-FinalProject/blob/main/Press%20Kit.pdf) 

[Trailer/Demo](https://youtu.be/wfalc53Injc)

[Project README (overview)](https://github.com/nicolepav/ECS189L-FinalProject#readme)


**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**

To showcase the work, I started by creating a press release flyer. I wanted to combine the original art that Julia had made with more of a poster style, and also because it was easier to implement as a PDF than as a website. The flyer features the key pieces of a press release- story, screenshots, reviews, dev team, link to trailer, and overview of features. I was incredibly happy with how it came out and feel like it ties into the game scheme/theme flawlessly.

For the trailer, I created a dramaticized intro that transitioned into gameplay footage. The dramatic intro helps to convey the story behind the game, and if we had been able to implement cut scenes, the trailer is what I imagined they would be like. To choose footage, I first played through the entire game and then tried to sample footage from different levels using jump cuts. This was to provide a good sample of what the game is like without completely spoiling what each level was like, and still demonstrate key features like the gravity rotation, fish collection, narrative dialog, and puzzle solving. Screenshots (featured in project readme) were chosen similarly to higlight the individual level themes, art, and features.


## Game Feel

As the theme of the game is set under the ocean, I had decreased the magnitude of the gravity to allow more of a floating feel. Furthermore, when creating the levels I chose elements that would fit the ocean theme while also giving the player to explore different techniques of gravity adjustment. As a result, the first level shaped as a whale is without any danger zones, followed by a level that requires the use of gravity in mostly all directions. Levels 3,4, and 5 display a water bottle, a diver’s helmet, and an explorative anchor that each require different techniques and timings to navigate. There are intentional gaps especially within the diver’s helmet to increase its level of difficulty. Lastly, we needed an indicator for the player to stay relatively close to the level and not drift off, and so we created a life system that would decrease if the player went too far away from the level. In order to indicate the danger of leaving the level platforms, we color coordinated the level to suggest that the calmer waters of inside the level are more preferable than the dark blue dangerous waters. Outside of the levels themselves, the rotation of gravity brought its own set of altercations. In order to keep the player engaged, the gravity, player, and camera had to be rotation in unison so the gameplay felt logical. Furthermore, to prevent spamming of gravity rotations and the abrupt shifts of the screen, a delay had to be incorporated for the rotation of both the camera and the player. This resulted in rotating the camera and the player the same number of degrees and creating an indicator for when new gravity rotation values could be accepted. And so, the gravity had to be low enough to not allow abrupt movements or shifts in the blobfish, but high enough to still incorporate a physics system. 
