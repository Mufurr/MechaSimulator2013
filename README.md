# MechaSimulator2013

Tags:
- Player: The mecha shall be tagged "Player"
- Map: The map and any obstacle shall be tagged "Map"
- Enemy : All enemies shall be tagged "Enemy" (No kidding)
- Button :  All pressable buttons shall be tagged "Button" (...)
- Explosion : For explosions (surprise) (prefabs Explosion and BigExplosion)
- Flames : All the butterflies and flowers and unicorns- JUST KIDDING! This is for flames.
- Heal : Reloading points shall be tagged "Heal". Because they actually heal.

Inputs:
- Horizontal : (z & s) to move up and down 
- Rotation : (q & d) to rotate the mech left and right
- Mouse x : (Mouse axis, x axis, not inverted) horizontal movements of the mouse
- Mouse y : (Mouse axis, y axis, inverted) vertical movements of the mouse

All inputs are in azerty; for qwerty keyboards, just remember that q <-> a and w <-> z

Recommended sensitivity for the mouse is 30

Also, please make sure to go in project setting -> Physics -> uncheck "Queries Hit Triggers", it prevents 
missiles from blocking the view of the enemies

In case of problems with the cockpit prefab, make sure to apply a mesh and a material to all components of the cockpit, 
to apply the "camera" texture to the screen and to drag&drop the "camera" texture as the redirect texture
from the camera of the mecha.

Don't hesitate to tell me if I forgot anything

Chaussure.
(And Random.)
