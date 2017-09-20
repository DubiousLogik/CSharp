Towers of Hanoi
Procedural Solution (no recursion)
rdevine

This is a console application implementing a procedural solution to 
the Towers of Hanoi puzzle.  

-- Program.cs is the entry point, which performs input validation and invokes the game.
-- TowersGameBoard.cs contains the game logic and state 

I set a min value of 1 and max value of 16.  Ensure the max post value always exceeds the max
input value.  Max post value is 99.  I set this value when a post is empty to denote that any
disk can be moved onto it.  I check if a disk can move by ensuring the disk value is less 
than the value on top of the post, which if empty is 99.

Usage: TowersHanoi.exe [int number of disks from {minValue} to {maxValue}] [bool display game state]

Debug limit exists as a failsafe to ensure programs exit when testing new logic.