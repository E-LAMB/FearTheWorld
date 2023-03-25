using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Mind 
{

    // Fuses
    public static bool fuse_chronophobia = false;
    public static bool fuse_decideophobia = false;
    public static bool fuse_thalassophobia = false;
    public static bool fuse_coulrophobia = false;
    public static bool fuse_nyctophobia = false;
    public static bool fuse_linonophobia = false;
    public static bool fuse_koumpounophobia = false;
    public static bool fuse_acrophobia = false;
    public static bool fuse_globophobia = false;
    public static bool fuse_necrophobia = false;
    public static bool fuse_arachnophobia = false;
    public static bool fuse_claustrophobia = false;
    public static bool fuse_dentophobia = false;
    public static bool fuse_spectrophobia = false;
    public static bool fuse_scoptophobia = false;
    public static int fuses_in_inventory = 0;

    // Opened doors
    public static bool opened_core_door = false;
    public static bool opened_basement_door = false;
    public static bool opened_claustrophobia = false;
    public static bool opened_decideophobia = false;

    // Buttons / Switches / Keys
    public static bool switch_left_claustrophobia = false;
    public static bool switch_right_claustrophobia = false;
    public static bool button_koumpounophobia = false;
    public static bool key_dentophobia = false;

    // Items
    public static int teeth_collected = 0;

    // Health
    public static int max_health = 3;
    public static int health = 3;

    // Stamina
    public static int white_cubes_collected = 0;
    public static float max_stamina = 10f;
    public static float stamina = 10f;

    // Misc
    public static bool clown_roaming = false;    
    public static int graves_dug = 0;

}
