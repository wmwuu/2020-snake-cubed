﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSchemePickerListItem : MonoBehaviour {

    private delegate void SelectColorScheme();
    private static SelectColorScheme OnSelectColorScheme;

    public GameObject selectedIcon;
    public Text nameLabel;
    public RawImage background;
    public RawImage snakeColorIcon;
    public RawImage appleColorIcon;
    public RawImage goldColorIcon;
    public RawImage badColorIcon;

    private int colorSchemeID;
    private string colorSchemeName;
    private string packName;
    private bool isSelected;
    private bool isLocked;

    /* * * * Lifecycle methods * * * */

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    void OnEnable() {
        OnSelectColorScheme += this.respondToOtherItemSelected;
        if (this.isLocked) { // check if it should still be locked
            this.isLocked = (this.colorSchemeID > 1 && DataAndSettingsManager.getNumBoughtForStoreItem(this.packName) == 0);
            if (!this.isLocked) {
                this.nameLabel.text = this.colorSchemeName;
            }
        }
    }

    void OnDisable() {
        OnSelectColorScheme -= this.respondToOtherItemSelected;
    }

    /* * * * Public methods * * * */

    public void setup(int colorSchemeID, bool selected) {
        this.colorSchemeID = colorSchemeID;
        this.setSelected(selected);
        ColorScheme cs = ColorSchemesManager.getColorSchemeWithID(colorSchemeID);
        this.setColors(cs);
        this.colorSchemeName = cs.getName();
        this.nameLabel.text = this.colorSchemeName;
        this.packName = cs.getPackName();
        this.isLocked = (colorSchemeID > 1 && DataAndSettingsManager.getNumBoughtForStoreItem(this.packName) == 0);
        if (this.isLocked) {
            this.nameLabel.text += " (Locked)";
        }
    }

    ///<summary>This method is linked to the list item's button.</summary>
    public void selectAction() {
        if (this.isLocked) { return; }
        if (OnSelectColorScheme != null) {
            OnSelectColorScheme(); // deselect all list items
        }
        this.setSelected(true);
        ColorSchemesManager.setColorScheme(this.colorSchemeID);
        DataAndSettingsManager.setColorSchemeID(this.colorSchemeID);
    }

    ///<summary>The delegate method for OnSelectColorScheme.</summary>
    public void respondToOtherItemSelected() {
        this.setSelected(false);
    }

    /* * * * Helper methods * * * */

    private void setSelected(bool isSelected) {
        this.isSelected = isSelected;
        this.selectedIcon.SetActive(isSelected);
    }

    private void setColors(ColorScheme cs) {
        Color bg = cs.getBoundsColor();
        bg.a = 70/255f;
        this.background.color = bg;
        this.snakeColorIcon.color = cs.getSnakeColor();
        this.appleColorIcon.color = cs.getAppleColor();
        this.goldColorIcon.color = cs.getGoldColor();
        this.badColorIcon.color = cs.getBadColor();
    }

}
