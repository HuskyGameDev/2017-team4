# Digital Demon

### HGD 2017 Team 4:
*Jeremy M. Barker*  
*Nic Fosdick*  
*Jordan Gagnon*  
*Jacob Gust*  
*Josh Kiger*  
*Andy Merdzinski*  
*Riley Mulford*  
   
**GAME OVERVIEW**

* *GENERAL DESCRIPTION*
  * Digital Demon is a hybrid rhythm and RPG fighter. The idea is that the player will precisely hit notes on a rhythm track just like a traditional rhythm game, but there will also be a RPG combat “visualization” where rhythm performance impacts the player character in their battles.
  * When a song is selected, enemies will relentlessly come at the player character, and the player has the option to attack, defend, or evade. The player can actively switch between which action they are trying to perform. Hitting combos in the rhythm aspect will increase the success rate of the current selected action.
  * To succeed in the game, a certain score must be met for each song. Doing this will unlock additional songs to be played. High scores will also be kept for the player to do better on previous levels.

* *THEME & STORY*
  * Digital Demon takes place in a cyberpunk world. The game will focus primarily on atmospheric storytelling, as opposed to a structured plot. The general story will revolve around the player character who is using a computer avatar to destroy digital demons and keep his avatar alive.
  * The general UI will portray a retro style computer while simultaneously be capable of futuristic actions.

* *INSPIRATION*
  * 10,000,000 is the most notable source of inspiration. 10,000,000 is a hybrid puzzle-RPG where the player solves a matching puzzle game to fight enemies, collect items, and progress through a dungeon.
  * 10,000,000’s innovating hybrid of a puzzle game with RPG elements inspired Digital Demon’s rhythm-RPG hybrid, only with a significantly strong emphasis on combat.

* *GAMEPLAY DESCRIPTION*
  * At game start, the player will be prompted with a list of songs to choose from. Initially, most of these songs will be unlocked, but completing available songs will unlock more. Each song will have a difficulty associated with it. Greater difficulties can increase the stats of enemies, abundance of enemies, bosses, and reduce the player’s success rates of performing actions.
  * At the start of a song, the player must hit the notes of the song which will be bound to certain keys. Hitting successful combos of notes will increase the success rate of the player character's combat actions. Likewise, missing notes will decrease the success rate. The initial value of the success rate of actions will be dependent on the difficulty selected.
  * The player also has the option to change the player character’s combat action. The options are attack, defend, or evade and will be represented by an icon above the UI element for the notes. Actions can be switched at any time and happens instantaneously as to not interrupt the rhythm aspect. The action switch will also be done with a keypress. Actions will happen automatically through the use of an ATB gauge, so when the gauge fills the current action is executed.
  * Defeating enemies and hitting note combos in songs will gain points for the player which can be used to buy stat increases for the player (e.g. strength). Increasing player stats will be necessary to complete harder songs.
  * The player’s main objective is to complete every song. There is no real end game as the player can also return and get higher scores on older levels. Game over happens anytime the player character dies during a song.
   
**TEAM MEMBER MANAGEMENT**

* *JEREMY M. BARKER*
  * Team Leader
    * Lead meetings, general planning, supervise progress
  * Artist
    * General aesthetic design
    * Sprites and animations
    * UI and menu design
  * Programmer
    * Incorporating art assets into game

* *JORDAN GAGNON*
  * Programmer (Implementation of Rhythm Mechanic)
    * Get detection of note successes and failures working
    * Note layout
    * Make sure notes spawn properly

* *NIC FOSDICK*
  * Programmer (Implementation of Rhythm Mechanic)
    * Switching actions of notes (Attack, Block, Evade)
    * Note layout
    * Incorporate rhythm success with combat actions

* *RILEY MULFORD*
  * Programmer (Combat Visualizations Architect)
    * Implement general workings of combat mechanic
    * Implement ATB gauge and action execution
    * Implement workings of player and enemy stats

* *JOSH KIGER*
  * Programmer (Game State Management)
    * Transitions
    * Failure/Success scenarios
    * Generic menu transitions
    * Saving and loading (unlocks and score)
    * Implement in-game stat shop

* *ANDY MERDZINSKI*
  * Programmer (Menu and UI implementation)
    * Level Select / Main Menu / Player Menu (Stats)
    * General layout for UI components
  
* *JACOB GUST*
  * Music and Sound
    * General audio direction
    * Creation of all in-game music and sound effects
  
**GAME SPECS**

* *RULES*
  * Player’s main objective is to complete each song in the game
  * During a song, the player only has control over:
    * Hitting notes from the rhythm mechanic
    * Switching which action the player character focuses on
  * Menus available to the player include:
    * Song selection
    * Player stats screen (where player can increase player stats)

* *INTERACTIONS*
  * During a control, the player mostly interacts with the rhythm mechanic. The player uses keypresses to hit notes with appropriate timing, and this boosts the success of the combat actions. The player can also choose which action the player focuses on, but the player character will automatically execute the focused action by use of an ATB gauge.
  * Otherwise, the player can interact with various menus outside of playing songs. This includes the song selection menu where the player can view the complete list of songs and their respective difficulties. The other menu is a player stat menu where the attack, defense, and evasion of the player character can be viewed and potentially increased by spending points gained from playing songs. 

* *USER INTERFACE*
  * Main gameplay screen (see concept sketch)
    * Features the main rhythm and combat mechanics
    * Incorporates cyberpunk theme by use of retro-computerized look with advanced functionality (hightech/lowlife)
  * Main menus will feature similar cyberpunk aesthetics, but will only have components for selection (song selection, viewing player stats)

* *LIST OF MECHANICS*
  * Rhythm
    * Precisely hit notes
    * Consecutive hits turn into combos
      * Combos increase player action success rate
  * Combat
    * Player character fights on-coming enemies
    * Player has option to attack, defend, or evade
      * Success rate of these actions depend on rhythm mechanic
      * ATTACK: player attacks enemy decreasing its life until death
      * DEFEND: player defends incoming attack to reduce damage
      * EVADE: player risks evading an attack
        * Failure to evade results in taking full damage
    * Player must defeat enemies to gain enough points to complete the level. If the player dies or does not reach the score threshold, then they fail the song
  * Rhythm & Combat
    * Player has option to switch which action the player character will focus on
    * Hitting note combos will increase the success rate of the focused action
    * Player has a ATB gauge that fills up over time; when the gauge fills, the player character automatically performs the focused action
  * Scoring
    * High scores for each level
    * Score is gained when defeating enemies
    * Score threshold must be met to successfully complete level
    * Scores are keep regardless of success or failure
    * A cumulative score is kept and those score points can be spent to increase the player character's stats
  * Level Select
    * Start with one level available (tutorial)
    * Unlock more levels when previous levels are completed
    * Each level has a selectable difficulty which increase enemy strength, and reduce starting success rate of player actions
  * Stats
    * Combat uses player stats when fighting enemies
      * These stats are related to the actions of attacking, defending, and evading
    * Enemies will have stats of their own, and difficulty modifiers will make these stats greater
    * Points from the cumulative score can be spent on boosting player stats through use of an in-game store.
  
* *ART*
  * Artwork will focus heavily on the hightech/lowlife cyberpunk theme. As the player character is mostly represented through a digital avatar on a computer screen, the UI for the game will look like a retro computer monitor that also has advanced functionality. This is to highlight the hightech/lowlife aspect of cyberpunk.

* *SOUND*
  * The sound for the game will also fit with the cyberpunk theme. In game sound (simple button presses) will be a digitized sound reminiscent of retro computer technology.
  * The music used for the songs/levels will feature elements of jazz which fits well with the lowlife aspects of cyberpunk.
   
**TECHNICAL SPECS**

* *TARGET PLATFORM*
  * PC
 
* *IMPLEMENTATION DETAILS*
  * Unreal Engine 4
  * Paper 2D
  * Blueprint system
  
**TIMELINE**

* *Sprint 1*
  * Have working rhythm mechanic
  * One set of notes (sample beat)
  * Recognize precision of hitting notes
  * Enough UI to support gameplay

* *Sprint 2*
  * Have other three sets of notes
  * Track score and actions
  * Include sounds and art
  * Flesh out UI and menus

* *Sprint 3*
  * Have one complete level with enemies
  * Player can see and upgrade stats
  * Have difficulty modifiers

* *Next semester:*
  * Add more levels/songs
  * Add several unique combos bonuses for consecutively hitting notes
  * Save high scores and have a “records” menu
  * Create a “theater” mode to just list to game’s music
