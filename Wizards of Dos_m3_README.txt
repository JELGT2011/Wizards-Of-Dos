This is the README for team Wizards of Dos Milestone 3. 

a) Your team name should appear on the HUD of your game when it is running.


b) ZIP file name: Wizards_of_Dos_m2.zip


c) Readme file should be in the top level directory: < teamname >_m2_readme.txt and
should contain the following

i. Full name, email, and prism account name for each member of the team:

Lanssie Mingyue Ma, mma48@gatech.edu, mma48

Nate Ziran Chen, ziranchen@gatech.edu, 

Timothy Storm, tstorm3@gatech.edu, tstorm3

Jesus Carillo, jcarrillo9@gatech.edu,  Buddy Jesus

Robert Sun, sunwrobert@gmail.com, rsun39

Jason Libbey, jlibbey3@gatech.edu, ?

ii. Detail which requirements you have completed, which are incomplete, and which
are buggy (be specific)

1) We completed a RAIN AI Nav Mesh Rig that has Walkable Heigh, Walkable Radius,
Step Height, and Cell size. 

2) Our Navigation targets are two of the spawn points of the food in the scene. 
3) We created a Waypoint Network Rig that has 11 waypoints that covers the entire environment 

4) We created a Waypoint Route Rig that has about 4 waypoints.

5) Our NPC has a Mechanim Motor to control it’s motion

5) We has a single AI character that can use all three of the behaviors. 

6) WE have a Mechanim Animator with three animation states this is used in all the behavior
trees.

7) We have a custom RAIN AI Element for our NPC in a modified version of our agressive 
behavior tree to intercept the player, it will use an interception script that uses:
The AI's position/velocity
The player's position/velocity
The distance between the player and AI
the relative velocities of the player and AI

To best show this custom Element behavior it has its own demo scene named "InterceptDemo".
It does a good Job of predicting where the player might go but it has to reach the predicted
target postion before it sets a new one to find the player. Our player characters in our game 
are pretty fast so does not support our game type well.

8) We have 3 behavior trees created for our AI milestone. The 3 behavior trees are named:
"Aggressive", "Defensive", and "Guardian". 

Aggressive tree wanders the environment until it detects the player via a visual sensor and then will pursue the player 
and attack him when it is close enough. 

The Defensive tree attempts to retreat from the player. If the player gets close the AI will attack him momentarily 
and then attempt to flee again. 

The Guardian tree is similar to the the aggressive tree except it patrols a waypout route and attacks/Pursues the player
if the player gets close. 

All the trees share states for when the AI's health is low or reaches zero.
If the AI's health is low it will run to the two Navigation Targets in the environment. The idea here is that
that the navigation targets the location for health spwan pickups. If the AI's health reaches zero he should
enter a death state and trigger a Ragdoll Animation. 
  

iii. Detail any and all resources that were acquired outside of class and what it is
being used for(e.g. Asset Bundles downloaded from the Asset Store for double
sided cutout shaders, or this file was found on the internet has link
http://example.com/test and does the orbit camera tracking).
We used RAIN AI. 
For the wander behavior used in the behavior trees a custom action from the Rain starter kit was leveraged.
The retreat behavior is also leveraged from a custom action in the Rain starter kit.
The starter kit is on the Rain website under tutorials.




iv. Detail any special install instructions the grader will need to be aware of for
building and running your code.
No special installs should be required.



v. Detail exact steps grader should take to demonstrate that your game meets
assignment requirements (e.g. “First, walk towards the pile of blocks using
WASD and mouse and bump into them to knock them down. This should
demonstrate actor movement via physically simulated forces and interactivity with
environment…”) Please also include game feel description.

Scenes can be switch using the number keys: "1","2","3","4"

Key "1": Loads the Aggresssive Scene
Key "2": Loads the Defensive Scene
Key "3": Loads the Guardian Scene
Key "4": Loads the InterceptDemo Scene

Scene Controls: W,A,S,D for movement. Use mouse to rotate camera.

1) The Aggressive scene will have the aggressive behavior tree on the AI. In this scene walk towards the AI using
the W,A,S,D keys and he will pursue and attack the player. If the don't approach the AI he will wander the evironment
using the Waypoint Network. If you press number key "7" the AI's health will drop to 50 and cause him move to the navigation
target points continuously. If you press number key "8" his health will will be restored to 100 and he will resume his
standard behavrior. If you press number Key "9" his health will drop to 0 and his death state will trigger. 

2) The Defensive scene will have the defensive behavior tree on the AI. The AI will run from the player if you get reach his detection 
range. If you get close enough to the AI he might stop and attack the player momentarily and then begin to retreat again. You can corner the 
AI in the environment due to its small size. If you approach him when he is cornered he will turn to attack the player and then begin searching 
for a new place to retreat. If you are not in his sensor range he will wander the environment using the Waypoint Network.
If you press number key "7" the AI's health will drop to 50 and cause him move to the navigation
target points continuously. If you press number key "8" his health will will be restored to 100 and he will resume his
standard behavrior. If you press number Key "9" his health will drop to 0 and his death state will trigger.

3) The Guardian scene has the guardain behavior tree on the AI. The AI patrols a path on the a waypoint route. If you approach the the AI
he will attack and pursue. If you make it out of  his sensor range he will resume patrolling the path. 
If you press number key "7" the AI's health will drop to 50 and cause him move to the navigation
target points continuously. If you press number key "8" his health will will be restored to 100 and he will resume his
standard behavrior. If you press number Key "9" his health will drop to 0 and his death state will trigger.

4) The InterceptDemo scene has the aggressive AI with the custom action from requirement 7 on it. Its in a different environment at its best suited 
to show the behavior. It does a good Job of predicting where the player might go but it has to reach the predicted
target postion before it sets a new one to find the player. Our player characters in our game are pretty fast so does not support our game type well.
The controls are the same run around the environment and the AI will attempt to intercept the player.

Death state and low health triggers mapped to keys might have delay when triggered. 


vi. Which scene file is the main file that should be opened first in Unity
The Aggresssive Scene, Defensive Scene, Guardian Scene and InterceptDemo Scene can be opened in any order. 
Scene switchin should work from any of them.


vii. URL of the web page where you posted your assignment

http://www.prism.gatech.edu/~tstorm3/MileStone3/New%20Unity%20Project.html



