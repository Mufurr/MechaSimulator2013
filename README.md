# MechaSimulator2013

Tags:
- Player: The mech should be tagged "Player"
- Map: The map and any obstacle should be tagged "Map"
- Enemy : All enemies should be tagged "Enemy"
- Button :  All pressable buttons should be tagged "Button"

Inputs:
- Horizontal : (q & d) to move left and right
- Horizontal2 : (z & s) to move up and down // Pierre wanted that name. yeah, I know....
- Rotation : (a & e) to rotate the mech left and right
- Mouse x : (Mouse axis, x axis, not inverted) horizontal mouvements of the mouse
- Mouse y : (Mouse axis, y axis, inverted) vertical mouvement of the mouse

All inputs are in azerty, for qwerty keyboard, just remember that q <-> a and w <-> z

Recommended sensitivity for the mouse is 30

Also, please be sure to go in project setting -> Physics -> uncheck "Queries Hit Triggers", it prevent 
missile from blocking the view of the enemies

In case of problems with the cockpit prefab, be sure to apply a texture to all components of the cockpit, 
to apply the "camera" texture to the screen and to drag&drop teh "camera" texture as the redirect texture
from the camera of the mech

Don't hesitate to tell me if I forgot anything

Chaussure.
