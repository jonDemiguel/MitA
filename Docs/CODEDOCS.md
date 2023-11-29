# CODE DIRECTORY STRUCTURE

# Table of Contents
- [CODE DIRECTORY STRUCTURE](#code-directory-structure)
- [Table of Contents](#table-of-contents)
  - [Assets](#assets)
    - [Editor](#editor)
    - [Game\_Anime](#game_anime)
    - [GameStory](#gamestory)
    - [MainChar](#mainchar)
    - [Map](#map)
    - [Materials](#materials)
    - [Monsters](#monsters)
    - [Music](#music)
    - [Prefabs](#prefabs)
    - [Resources](#resources)
    - [Scenes](#scenes)
    - [Scripts](#scripts)
    - [SpriteFor](#spritefor)
    - [TextMesh Pro](#textmesh-pro)
    - [UI](#ui)

## Assets
- The `Assets` folder is a game convention used by Unity for game development.
- This is the main folder containing all the assets used in the game.

### Editor
- **MapGeneratorEditor.cs**: Custom editor script for map generation.

### Game_Anime
- **AnimationController.controller, AnimeTimeline.playable, Anime_Canvas.prefab, MainMenuTimeline.playable, NextSceneLoader.prefab**: Components for game animations and main menu.
- #### Music
    - **FadeInandOut.anim, First Sentence.controller, IntroMusic.mp3, Second Sentence.controller, trainHorn.mp3**: Music and animation controllers for game scenes.

### GameStory
- **First Sentence.prefab, Second Sentence.prefab**: Prefab files for game story elements.

### MainChar
- **8-directions-idle.ase, cc-29-32x.png, endesga-32-32x.png, MainCharTest.unity**: Main character assets and test scenes.
- #### test
    - **MainCharTest.unity**: Unity test scene for the main character.
- #### weapons
    - **Spinning Sword.ase**: Animation for the main character's weapon.

### Map
- **GameplayMap**: Contains map elements like trees, sprites, and tiles.
- #### GameplayMap
    - ##### Tree
        - ###### Palette
            - **RA_Jungle.prefab**: Prefab for jungle-themed tree assets.
        - ###### Sprites
            - **RA_Jungle.png, RA_Jungle_Animation01.png, ... , tree06_s_03_animation.png**: Sprite assets for various trees.
    - ##### Water_Snow
        - **Water+.png**: Water and snow assets for map design.
- #### Item
    - **RA_Item_Icons01_2.png, ... , RA_Item_Icons03_2.png**: Icons for different items in the game.

### Materials
- **Map Mat.mat**: Material file for the map.

### Monsters
- **temp_main_char.ase**: Temporary asset for the main character.
- #### ExplodingEye, Purple_Monster_assets, red_eye_monster
    - **exploding_eye.ase, exploding_eye.prefab, ... , red_eye_monster_png.png**: Assets and prefabs for various monsters.
- #### test
    - **Character_Damage_Monsters.unity, ... , red_eye_test.unity**: Test scenes for monster behavior and interactions.

### Music
- **OpenSceneMusic.mp3**: Background music for the open scene.

### Prefabs
- **Chunks, Monster, Player, Props**: Prefabs for various game elements like terrain, monsters, player characters, and props.
- #### Chunks, ChunksLV2, ChunksLV3
    - **LV1.1.prefab, ... , LV1.7.prefab, lv2.1.prefab, ... , lv3.5.prefab**: Prefabs for different levels and game stages.
- #### DropItems
    - **RA_Item_Icons01_2_400 1.prefab, ... , RA_Item_Icons01_2_895.prefab**: Prefabs for item drops.
- #### Monster
    - **PF_1exploding_eye.prefab, ... , pm+prefab.prefab**: Prefabs for various monster types.
- #### Player
    - **run_east.ase, ... , spin.prefab**: Animation assets for player character movement.
- #### Props, Props_lv2
    - **RA_Jungle_1027.prefab, ... , RA_Ruins_Objects_86.prefab**: Prefabs for environmental props.

### Resources
- **Player_Test.prefab**: Prefab for player character testing.

### Scenes
- **GameMap.unity, MainMenu.unity, MainStory.unity, ... , Player_Camera.prefab**: Various Unity scene files and prefabs for player camera.

### Scripts
- **DamageFlash.cs**: Script for damage animation effects.
- #### Anime, Character, Game, Monsters, Scene
    - **CloseAnime.cs, ... , ItemPickup.cs**: Scripts for different game functionalities like animations, character behavior, game management, etc.

### SpriteFor
- **Example_Scene001.unity, ... , RA_Wasteland_Water.png**: Assets and scenes for various game environments.
- #### Ancient Ruins - Rogue Adventure, ... , Wastelands - Rogue Adventure
    - **Example_Ancient_Ruins.unity, ... , RA_Wastelands.prefab**: Assets and scenes for specific game environments.

### TextMesh Pro
- **Documentation, Fonts, Resources, Shaders, Sprites**: Assets and resources related to TextMesh Pro for UI text rendering.

### UI
- **GameOver.cs, LevelMenu.cs, MainMenu.cs, PauseMenu.cs**: Scripts for various UI elements.
- #### Resources
    - **MainMenuBackground.jpg, SettingMenu.prefab**: Assets for UI backgrounds and settings.
