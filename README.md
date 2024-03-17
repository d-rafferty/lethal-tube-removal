# Lethal Pipe Removal

Lethal Company mod that allows for removal of certain items from the ship and allows for custom automatic placement of the terminal. Fully configurable with LethalConfig. 

# Contribution
Feel free to contribute anything or submit any requests and I will look into adding it!

## Link To ThunderStore Page

https://thunderstore.io/c/lethal-company/p/Hamster/LethalPipeRemoval/

## Help With Coordinate Settings

__If you find a spot you like, I would advise making a note of the coordinates and rotation in case they are reset.__

The coordinate settings can be a pain to get right, especially the rotations. I reccomend the following if you're having issues.

1. Start small. Typically incrementing or decrementing by .1 is a good way to get an idea of how far you need to move it.

2. Rotate in increments of 90. Most items are spawned flush with the wall. If this is what you want to achieve in a different spot, most of the time your answer is either 0, 90, 180 or 270.
 
3. If you're having issues with rotations not behaving as you'd expect (incrementing by 180 for a rotation but it only turns 90) try changing one of the other 2 coordinates by 90 to see if it will change this effect. I have a suspicion this is because the rotation is accepted as a 3 value vector (x,y,z), but the actual value is a Quaternion(x,y,z,w)? If anyone with Unity experience knows more about this please feel free to contribute or raise an issue.

5. If you're frustrated having issues and want to restart, clicking the circular arrow next to the config will reset it to it's default value. Doing this for all of the coordinates will reset it to default spawn position.


The coordinates update the position in real-time, so you can change them from within LethalConfig at the PAUSE menu. I have moved these options to the top of the list so it is more convenient to test with it until you get it right.

The default settings in the config are the default coordinates for each item. I have attached below the settings I used to get the charging station to the other side of the ship and flip it around. You can use this as a starting point to get an idea of how to move it. This position is local to your ship, so it will stay in the same spot as you fly in and out of orbit.


![313366292-aaaddec5-49a4-4451-8c1f-3265c481f748](https://github.com/d-rafferty/lethal-tube-removal/assets/90558421/0d0be701-d126-4722-bc33-2cb903291a00)
![313366294-20d94053-728a-40fd-b913-f17532e9b49b](https://github.com/d-rafferty/lethal-tube-removal/assets/90558421/35b31392-2acf-49e0-832e-129e100f9e56)
