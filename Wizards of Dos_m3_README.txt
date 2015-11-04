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

We completed a RAIN AI Nav Mesh Rig that has Walkable Heigh, Walkable Radius, Step Height, and Cell size that all our NPC’s have. We has a single AI character that can use all three of the behaviors. Our Navigation targets are two of the spawn points of the food, and the player itself. This is used is the ____ tree. 

We created a Waypoint Network Rig that has 11 waypoints that covers the entire environment and a simpler Waypoint Route Rig that has about 4 waypoints. 

Our NPC has a Mechanim Motor to control it’s motion and an Animator with one animation state in the aggressive behavior tree. 

We have a custom RAIN AI Element for our NPC in our aggressive behavior tree to attack our character. 

We have 3 NPC AI types that have different personalities. The first is an aggressive behavior, which will try to find and attack the player. The aggressive behavior will use the animator to predict the placement of the character in order to attack him. The second is a defensive behavior that will try to avoid you but will attack if you get too close. These first two use the Waypoint Network Rig to move around the environment. The third is a guardian behavior which will patrol the Waypoint Route Rig and attack if the player gets too close to the food.  


iii. Detail any and all resources that were acquired outside of class and what it is
being used for(e.g. Asset Bundles downloaded from the Asset Store for double
sided cutout shaders, or this file was found on the internet has link
http://example.com/test and does the orbit camera tracking).
We used RAIN AI. 

iv. Detail any special install instructions the grader will need to be aware of for
building and running your code

v. Detail exact steps grader should take to demonstrate that your game meets
assignment requirements (e.g. “First, walk towards the pile of blocks using
WASD and mouse and bump into them to knock them down. This should
demonstrate actor movement via physically simulated forces and interactivity with
environment…”) Please also include game feel description.



vi. Which scene file is the main file that should be opened first in Unity


vii. URL of the web page where you posted your assignment


d) Complete Unity project (each script file you created should include team name and
members’ names in comments at top of file, and any file you acquired outside should also
be attributed with the appropriate source information)

