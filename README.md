# Game World Setup Note

CollapsingWorld (Assets/Scene/CollapsingWorld) is the prototyping game scene I prefer to use. It will generate a flat platform on game start to let the fighters fight on. The platform consists of 100 cube objects by default, and after every few seconds a piece will collapse and disappear, and eventually all parts of the platform will be gone, forcing the players to fight in a tight time frame. 

The collapse script is inside EventSystem object. Feel free to play around with the parameters:

- ScaleX and ScaleZ are the numbers of objects per edge. 
- Randomness takes a value from 0f to 1f. At value 0, outer blocks will collapse first. The larger the randomness is, the harder the blocks will be shuffled, resulting in more random order of collapses.
- Collapse Interval defines how often a block will collapse.
- Default y position of the blocks is 0. x,z positions are with in (-4.5, 4.5) at a scale of 1.