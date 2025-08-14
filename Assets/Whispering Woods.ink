VAR courage = 0
VAR found_map = false

-> start

=== start ===
# location: Whispering Woods - Start
You stand at the edge of the Whispering Woods, clutching your backpack. A faint trail leads into the trees.

Will you step bravely into the shadows, or look around for clues first?

* [Enter the woods]
    ~ courage += 1
    The forest feels alive. You continue traveling but you notice your compass not working and find yourself to be lost on the current trail you're on.
    -> crossroads
    
    * [Investigate the sound]
        You part the branches carefully and find a crumpled map on the ground!
        ~ found_map = true
        -> crossroads

    * [Ignore it and keep walking]
        You freeze. The noise stops. Nothing moves.
        You shake it off and keep going, but a strange chill lingers.
        -> crossroads

* [Examine your surroundings]
    You circle the area and notice a crumpled map tucked under a stone.
    ~ found_map = true
    -> crossroads

=== crossroads ===
# location: Whispering Woods - Crossroads
You reach a fork in the path. One trail is dark and overgrown; the other is well-worn but eerily silent.

* [Take the dark path]
    ~ courage += 1
    The path is difficult, but your courage pushes you onward.
    -> ending

* [Take the silent path]
    You move quietly, senses heightened.
    -> ending

=== ending ===
# location: Whispering Woods - Ending
{found_map && courage >= 1:
    With courage and a map, you find the lost treasure of the woods!
    -> good_ending
- else:
    The woods confuse you and you find yourself back at the start, but safe.
    -> bad_ending
}

=== good_ending ===
You return home with stories and the treasure in your backpack. Adventure complete!

-> END

=== bad_ending ===
You leave the forest, but the mystery remains unsolved. Maybe next time!

-> END