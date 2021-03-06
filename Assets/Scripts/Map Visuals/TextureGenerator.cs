﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Generates textures for the mesh. 
/// TextureFromHeightMap: Black &amp; white texture created from height values.
/// TextureFromColourMap: Creates a texture from colour map.
/// </summary>

public static class TextureGenerator {

	public static Texture2D TextureFromColourMap(Color[] colourMap, int width, int height) {
		Texture2D texture = new Texture2D (width, height);
		texture.filterMode = FilterMode.Point;
		texture.wrapMode = TextureWrapMode.Clamp;
		texture.SetPixels (colourMap);
		texture.Apply ();
		return texture;
	}


	public static Texture2D TextureFromHeightMap(MapData mapData) {
		int width = mapData.GetWidth();
		int height = mapData.GetHeight();

		Color[] colourMap = new Color[width * height];
		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				colourMap [y * width + x] = Color.Lerp (Color.black, Color.white, mapData.GetSquished(x, y));
			}
		}

		return TextureFromColourMap (colourMap, width, height);
	}

}
