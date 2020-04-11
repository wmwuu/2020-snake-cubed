﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSchemesManager {

    private static Material boundsMaterial;
    private static Material snakeMaterial;
    private static Material appleMaterial;
    private static Material goldMaterial;
    private static Material badMaterial;
    private static bool hasLoadedMaterials;

    // UNUSED
    /*public static readonly int COLOR_SCHEME_ID_CUSTOM = -1;
    private static ColorScheme playerCustomScheme;*/

    private static readonly ColorScheme[] DEFAULT_COLOR_SCHEMES = {
        new ColorScheme(
            "Original", // ID = 0
            new Color(118/255f, 214/255f, 1f, 178/255f),    // bounds - light blue
            new Color(57/255f, 217/255f, 13/255f, 1f),      // snake - bright green
            new Color(1f, 0f, 31/255f, 1f),                 // apple - red
            new Color(1f, 223/255f, 42/255f, 1f),           // gold - gold
            new Color(87/255f, 36/255f, 120/255f, 1f),      // bad - purple
            "default"
        ),
        new ColorScheme(
            "Black and white", // ID = 1
            new Color(0f, 0f, 0f, 178/255f),                // bounds - black
            new Color(1f, 1f, 1f, 1f),                      // snake - white
            new Color(220/255f, 220/255f, 220/255f, 1f),    // apple - light gray
            new Color(1f, 223/255f, 42/255f, 1f),           // gold - gold
            new Color(30/255f, 30/255f, 30/255f, 1f),       // bad - dark gray
            "default"
        ),
        new ColorScheme(
            "Pastel", // ID = 2
            new Color(181/255f, 227/255f, 248/255f, 178/255f),  // bounds - pastel blue
            new Color(175/255f, 243/255f, 157/255f, 1f),        // snake - pastel green
            new Color(1f, 167/255f, 178/255f, 1f),              // apple - pastel red
            new Color(1f, 240/255f, 153/255f, 1f),              // gold - pastel yellow
            new Color(184/255f, 157/255f, 202/255f, 1f),        // bad - pastel purple
            StoreManager.ITEM_KEY_COLORS_PAS_FRU
        ),
        new ColorScheme(
            "Fruit", // ID = 3
            new Color(0f, 167/255f, 16/255f, 178/255f),     // bounds - dark green
            new Color(57/255f, 217/255f, 13/255f, 1f),      // snake - light green
            new Color(241/255f, 35/255f, 52/255f, 1f),      // apple - apple red
            new Color(1f, 211/255f, 25/255f, 1f),           // gold - banana yellow
            new Color(173/255f, 110/255f, 11/255f, 1f),     // bad - brown
            StoreManager.ITEM_KEY_COLORS_PAS_FRU
        ),
        new ColorScheme(
            "Warm", // ID = 4
            new Color(207/255f, 18/255f, 0f, 178/255f),     // bounds - dark red
            new Color(1f, 23/255f, 15/255f, 1f),            // snake - red
            new Color(248/255f, 130/255f, 0f, 1f),          // apple - orange
            new Color(1f, 211/255f, 25/255f, 1f),           // gold - yellow
            new Color(55/255f, 34/255f, 0f, 1f),            // bad - dark brown
            StoreManager.ITEM_KEY_COLORS_WAR_COO
        ),
        new ColorScheme(
            "Cool", // ID = 5
            new Color(3/255f, 120/255f, 16/255f, 178/255f), // bounds - dark green
            new Color(11/255f, 166/255f, 5/255f, 1f),       // snake - green
            new Color(8/255f, 97/255f, 183/255f, 1f),       // apple - blue
            new Color(138/255f, 43/255f, 195/255f, 1f),     // gold - purple
            new Color(0f, 15/255f, 65/255f, 1f),            // bad - dark navy blue
            StoreManager.ITEM_KEY_COLORS_WAR_COO
        ),
        new ColorScheme(
            "Midnight", // ID = 6
            new Color(0f, 0f, 0f, 230/255f),            // bounds - black
            new Color(1f, 1f, 1f, 1f),                  // snake - white
            new Color(20/255f, 20/255f, 20/255f, 1f),   // apple - very dark gray
            new Color(30/255f, 30/255f, 30/255f, 1f),   // gold - slightly less dark gray
            new Color(0f, 0f, 0f, 1f),                  // bad - black
            StoreManager.ITEM_KEY_COLORS_MID_WHI
        ),
        new ColorScheme(
            "Whiteout", // ID = 7
            new Color(1f, 1f, 1f, 230/255f),                // bounds - white
            new Color(0f, 0f, 0f, 1f),                      // snake - black
            new Color(245/255f, 245/255f, 245/255f, 1f),    // apple - light gray
            new Color(1f, 1f, 1f, 1f),                      // gold - white
            new Color(235/255f, 235/255f, 235/255f, 1f),    // bad - less light gray
            StoreManager.ITEM_KEY_COLORS_MID_WHI
        ),
        new ColorScheme(
            "RGB", // ID = 8
            new Color(0f, 0f, 0f, 178/255f),    // bounds - black
            new Color(1f, 1f, 1f, 1f),          // snake - white
            new Color(1f, 0f, 0f, 1f),          // apple - red
            new Color(0f, 1f, 0f, 1f),          // gold - green
            new Color(0f, 0f, 1f, 1f),          // bad - blue
            StoreManager.ITEM_KEY_COLORS_RGB_CMY
        ),
        new ColorScheme(
            "CMYK", // ID = 9
            new Color(255/255f, 255/255f, 255/255f, 178/255f),  // bounds - white
            new Color(0f, 146/255f, 209/255f, 1f),              // snake - cyan
            new Color(204/255f, 0f, 106/255f, 1f),              // apple - magenta
            new Color(1f, 241/255f, 11/255f, 1f),               // gold - yellow
            new Color(0f, 0f, 0f, 1f),                          // bad - black
            StoreManager.ITEM_KEY_COLORS_RGB_CMY
        )
        // new ColorScheme(
        //     "", // ID = _
        //     new Color(255/255f, 255/255f, 255/255f, 178/255f), // bounds
        //     new Color(255/255f, 255/255f, 255/255f, 1f),    // snake
        //     new Color(255/255f, 255/255f, 255/255f, 1f),    // apple
        //     new Color(255/255f, 255/255f, 255/255f, 1f),    // gold
        //     new Color(255/255f, 255/255f, 255/255f, 1f)     // bad
        // )
    };

    /* * * * Lifecycle methods * * * */

    /*void Awake() {
        // UNUSED
        // if custom color schemes are implemented, can't use lifecycle methods in this class
        retrievePlayerCustomScheme();
    }*/

    /* * * * Public getters * * * */

    // UNUSED
    /*public static ColorScheme getPlayerCustomScheme() { return playerCustomScheme; }*/

    /* * * * Public methods * * * */

    public static int getNumColorSchemes() {
        return DEFAULT_COLOR_SCHEMES.Length;
    }

    public static ColorScheme getColorSchemeWithID(int id) {
        // UNUSED
        /*if (id == COLOR_SCHEME_ID_CUSTOM) {
            return playerCustomScheme;
        }
        else if*/
        if (id < 0 || id >= getNumColorSchemes()) {
            return DEFAULT_COLOR_SCHEMES[0];
        }
        return DEFAULT_COLOR_SCHEMES[id];
    }

    public static void setColorScheme(int id) {
        changeToScheme(getColorSchemeWithID(id));
    }

    /* * * * Helper methods * * * */

    private static void changeToScheme(ColorScheme colorScheme) {
        if (!hasLoadedMaterials) {
            loadMaterials();
            hasLoadedMaterials = true;
        }
        colorScheme.changeMaterialColors(boundsMaterial, snakeMaterial, appleMaterial, goldMaterial, badMaterial);
    }

    private static void loadMaterials() {
        boundsMaterial = Resources.Load<Material>("Materials/Bounding Box");
        snakeMaterial = Resources.Load<Material>("Materials/Snake");
        appleMaterial = Resources.Load<Material>("Materials/Apple");
        goldMaterial = Resources.Load<Material>("Materials/Gold");
        badMaterial = Resources.Load<Material>("Materials/Bad");
    }

    // UNUSED
    /*private static void retrievePlayerCustomScheme() {
        playerCustomScheme = DataAndSettingsManager.retrievePlayerCustomColorScheme();
    }*/

}

///<summary>A class to represent a single color scheme.</summary>
[System.Serializable]
public class ColorScheme {

    [SerializeField]
    private string name;
    [SerializeField]
    private Color boundsColor, snakeColor, appleColor, goldColor, badColor;
    private string pack;

    public ColorScheme(string name, Color bounds, Color snake, Color apple, Color gold, Color bad, string pack) {
        this.name = name;
        this.boundsColor = bounds;
        this.snakeColor = snake;
        this.appleColor = apple;
        this.goldColor = gold;
        this.badColor = bad;
        this.pack = pack;
    }

    public string getName() { return this.name; }
    public Color getBoundsColor() { return this.boundsColor; }
    public Color getSnakeColor() { return this.snakeColor; }
    public Color getAppleColor() { return this.appleColor; }
    public Color getGoldColor() { return this.goldColor; }
    public Color getBadColor() { return this.badColor; }
    public string getPackName() { return this.pack; }

    ///<summary>Sets the albedo colors of the given materials to the colors specified in this `ColorScheme`.</summary>
    public void changeMaterialColors(Material bounds, Material snake, Material apple, Material gold, Material bad) {
        /*if (bounds == null) {
            //Debug.Log("bounds null");
        }
        if (this.boundsColor == null) {
            //Debug.Log("boundsColor null");
        }*/
        bounds.SetColor("_Color", this.boundsColor);
        snake.SetColor("_Color", this.snakeColor);
        apple.SetColor("_Color", this.appleColor);
        gold.SetColor("_Color", this.goldColor);
        bad.SetColor("_Color", this.badColor);
    }

}
