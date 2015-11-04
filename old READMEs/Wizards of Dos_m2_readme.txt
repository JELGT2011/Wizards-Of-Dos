This is the README for team Wizards of Dos Milestone two. 

a) Your team name should appear on the HUD of your game when it is running.


b) ZIP file name: Wizards_of_Dos_m2.zip


c) Readme file should be in the top level directory: < teamname >_m2_readme.txt and
should contain the following

i. Full name, email, and prism account name for each member of the team
Lanssie Mingyue Ma, mma48@gatech.edu, lanseafood

Nate Ziran Chen, ziranchen@gatech.edu, 

Timothy Storm, tstorm3@gatech.edu, tstorm3

Jesus Carillo, jcarrillo9@gatech.edu,  Buddy Jesus

Robert Sun, sunwrobert@gmail.com, rsun39

Jason Libbey, jlibbey3@gatech.edu

The character we made is a Ninja. For a physical target he is a fast and repsonsive character.
The emotional target for the character is that he is strong willed, ready face danger and
his swords show he is looking for a fight. To accomplish the physical target he move and repsonds to 
input quickly. For emotional goal we show his daring, ready to fight attitde, with the blades in his hands.


ii. Detail which requirements you have completed, which are incomplete, and which
are buggy (be specific)

/////////Lanssie- ICE Environment

I made an icy-winter environment. 

I made some of the unique actors also compound. I have some boxes that you can kick around the environment, a flag that you can knock around a barn (compound), a boat that you can push around but won’t cooperate fully with the water, and a door with side fences that swings out. I also have a platform that makes you bounce if you land on it, so it forces you to bounce around. 

• The level must have variable height terrain 
There is a ramp to a dock and a lot of random hills and mountains. There’s also a small lake in the middle of the environment that he can walk through. 

• The level must have at least three material sounds that play while the character is
interacting with the ground surface
So I made the wind in the background, which I think sounds actually pretty good. I made him have snowy sounding footsteps when he moves, and a sound for when he knocks into boxes around the environment. 

• Game Feel: I made two particle systems. One for the snow and the other for a windy snow, so that combined they make it look more wintery. I also tried to make the friction on the environment much more icey, but since I’m sharing the controller with my teammates, the change I make to it to adjust the vector would have complicated theirs. However, the items  in the environment do respond to the low friction in the environment. 
The water was really hard, I tried to get splashes and to change the friction but it was not cooperating with me. I’ll have to keep trying. The boat I couldn’t really get to float, even though I tried writing several iterations of the script. That part is buggy. 

What to do:
You should try running around the arena and the water, kicking away boxes, running from the ramp to the dock, pushing around the boat on the water, swinging around the flag on the barn, pushing the door open on the gated area, and landing on the small platform that makes you bounce. The wind and sound effects will take place as you interact with certain parts of the environment. Remember everything has little friction so things will go pretty far! 

////////Nate - Sunset Forest

ii.
Completed all individual parts for "Sunset Forest" (jungle.level). 
One minor issue: for the interacion, I implemented randomly generating potions that will play a sound on collision, instead of dust from foot step. The generated potion bottles do not always stick to the floor. However they are always reachable by the player.

iv.
None.

v.
Walk around to see different trees/terrain/stone walls/broken bridge/river and waterfall, and pickup randomly generated bottles.
Bottles should play a sound on pickup. (interaction with environment)
Material sounds includes: Footstep sounds when walking on the ground, water sound when walking into/under river, and a clash sound when bumping into the wooden gate.
Two hinge joints: A stone gate is attached to a stone fence. Bump into it to open. A rope is attached to the tree in sight on start (the tree next to the bridge). It is hard to bump into it, but it should swing when you do. The original design was to hang a dead body on it, but it is too creepy.


///////////Timothy - Japanese Environment

My environment has a Japanese theme. 

ii.
-Actors in the scene include a bucket, two umbrella, a pair or bladed weapons, Hanging lanterns which use a character joint
to create the chain like behavior, and the doors to the house which use a configurable joint. 

-Material sounds are on the ground, the hanging lanterns and the bladed weapons.

iii.
The house is from the Japanese Village asset pack on Unity Store
Then Lantern is from the unity asset store
Chain links are from the asset store. The chain come with a prefab configured with joints. I had to a set a new chain to match the behavor I wanted
and add the lantern to it to have it react properly. 
The trees, umbrellas, bridge, fence around the pound and fence around the environment are from the Japanese Garden set pack on the asset store.
The blade weapons(Naginata) are from a blade pack on the asset store.

v.
-For game feel I tried to allow everything that looks interactive to exhibit behavior. Such as the lanterns swinging when the player runs into them. 
The player should feel like they are free to explore and interact with the environment as they might expect to.

-What to do: When the scene first loads you will be at the bridge and can immediately run into the bucket. After you cross the bridge you can run into 
the umbrellas next to the bench. After the house's doors can be opened by pressing the "O" letter key when you are close. Once you enter the house 
the hanging lanterns and bladed weapons will be inside. You can run into both of these to see them react. 




//////////Jesus  Evil Mountain 
The player should be limited to the mesa, but he can jump off. The sign in front of the player's spawn can be hit to swing it, but if you hit the post, you take a short stun and have to play the knockback animation. The player can also run into the dead trees to knock snow off of them.
The high elevation of the mountian made me want to make use of the particle system. I decided a good combination was slight red snow fall and a small snow storm. I limited the amount of particle effects to to make sure the player didnt have to deal with limited visibility.
Sounds include the snound of steps on the snow, hitting the trees, and hitting the sign post.
The sign is composed of several smaller cubes. The sign is attached to the top of the sign post with two smaller cubes that act like links.
The top of the mountain is a very quiet place. I wanted to include sounds to go along with the windy environment, but couldn't really find anything that didnt get annoying quickly.



///////////Robert DESERT Environment
iv. Switch to desert scene as shown in readme.
v. Run around to hear sand sfx. Run into the cacti and rocks to hear the other environmental sfx. Lastly run into the two signs to see demonstration of hinge joints. Also press Z to see ragdoll controller



////////////Jason
-emailed professor, he’s submitting late. 



iii. Detail any and all resources that were acquired outside of class and what it is
being used for(e.g. Asset Bundles downloaded from the Asset Store for double
sided cutout shaders, or this file was found on the internet has link
http://example.com/test and does the orbit camera tracking ).

Collectively we used:
UF Creator LITE for houses, 
Water FX pack
Standard Assets
Cactus/Rock desert pack 
Sand textures pack




iv. Detail any special install instructions the grader will need to be aware of for
building and running your code

Test ragdoll (press Z) at last.
Some map edges are not enclosed so you may run off the edges.




vi. Which scene file is the main file that should be opened first in Unity
Any of the scenes in side of Assets\Scenes
These include the following:
jungle
SnowMountain
Desert
Evil Mountain
JapaneseEnvironmentScene
M2_ice

are the five scenes for milestone 2. Start with any one of these and press keyboard 1 - 5 to navigate.

vii. URL of the web page: http://www.prism.gatech.edu/~tstorm3/MileStorn2/Documents.html

d) Complete Unity project (each script file you created should include team name and
members’ names in comments at top of file, and any file you acquired outside should also
be attributed with the appropriate source information)

