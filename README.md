# Unity-Bullet-Emitters
Code used for Game Objects to emit bullets for shoot 'em up or danmaku games.

This code contains an example ObjectPool and GameState, but that is up to the game implementation.

It's a pretty simple approach to have bullet emitters shoot at a target, at a fixed direction, and a more complex emitter that can be configured on every instance of an object.
Updating the `BasicBulletEmitter` in fixedupdate cycles allow to create some basic but interesting patterns that can be easily applied into any 2D shooting game gameplay.
