﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSchemePicker : MonoBehaviour {

    public GameObject listContentRect;
    public ColorSchemePickerListItem listItemPrefab;

    private List<ColorSchemePickerListItem> listItems;

    // Start is called before the first frame update
    void Start() {
        this.setupList();
    }

    // Update is called once per frame
    void Update() {        
    }

    private void setupList() {
        int selectedID = DataAndSettingsManager.getColorSchemeID();
        for (int i = 0; i < ColorSchemesManager.getNumColorSchemes(); i++) {
            // instantiate a list item in the scroll view for each color scheme
            ColorSchemePickerListItem item = Instantiate(this.listItemPrefab, new Vector2(0f, -120f * i - 60f), Quaternion.identity) as ColorSchemePickerListItem;
            RectTransform itemRect = item.gameObject.GetComponent<RectTransform>();
            itemRect.SetParent(this.listContentRect.transform, false);
            item.setup(i, (i == selectedID));
        }
    }

}
