# 3D-cooking-mama
This Github project contains the Unity game produced for our 6.835 final project.

The main game is in 'Leap Motion Test'. The two other folders, 'Models' and 'Prefabs' are backup folders.

## Requirements
* Unity (requires to be run on Windows)
* Leap Motion Sensor

* Blender (if you want to open or edit the 3D model files)

## How to Run
To run, place the "Leap Motion Test" folder into Unity Hub. When it is done compiling, you can open it. Start the game by pressing the play button at the top of the screen.

## Code (within `Leap Motion Test`)
The bulk of our code is in the `Assets` folder. Everything else came with Unity and the Unity Leap Motion Library we downloaded.
* `Assets`: contains all of our models, prefabs, scenes, and scripts.
    * `Models` : all of our blender models. Can be opened in Blender.
    * `Prefabs` : all of our models as prefabs, with their own components/colliders.
    * `Scripts` : the scripts we applied to our prefabs in our project.
        * `BetterGrabbing` : smooths grabbing and holding to make it easier to handle the knife and vegetables.
        * `Chop` : for chopping vegetables and changing the model to progressively more chopped versions.
        * `Highlight` and `HighlightKnife` : for highlighting models when the Leap hand hovers over them. 
        * `IncreaseCarrotCounter` and `IncreasePotatoCounter` : increases the numbers keeping track of carrots and potatoes chopped.
        * `MainMenuVoiceCommands` : listens for and acts on voice commands on the main menu scene.
        * `ProgressBar` : controls the progress bar on the stove scene.
        * `ProgressCounter` : adds checkmarks and eventually transitions to the stove scene as the user chops vegetables.
        * `QuitGame` : listens for the quit voice command on the GameOver scene.
        * `ShowInstructions` : shows instructions when it hears the voice command on the main menu scene.
        * `SnapToHand` : snaps objects to the correct position and orientation when grabbed.
        * `StartGame` : starts the game when the egg hits the target on the main menu screen.
        * `VoiceCommands` : listens for and acts on voice commands in the cutting board scene.
    * `Scenes` : the different scenes of our game. The beginning of our game is in `MainMenu`.
        * `MainMenu` : the beginning scene of our game. Includes the Desktop Leap Rig to keep track of the Leap hands, interactive elements such as the eggs and target for starting the game, and a Canvas element with instructions for the user.
        * `CuttingBoard` : the second scene of our game. Includes the same Desktop Leap Rig, as well as the interactive carrot, potato, and knife models. The Canvas element in this scene includes the vegetable icons which get checked off as the user progresses.
        * `Stove` : the third scene of our game. Includes the Desktop Leap Rig and 3D models for the stove elements, as well as a particle effect creater for the smoke coming from the pan. The Canvas element in this scene includes a progress bar which goes up as the vegetables cook.
        * `GameOver` : the final scene of our game, with no interactive elements (except for the "quit" voice command). Includes a 3D model of the completed dish, as well as the same Desktop Leap Rig.
