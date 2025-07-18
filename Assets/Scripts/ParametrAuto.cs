using UnityEngine;

[System.Serializable]
public class ParametrAuto
{
    public readonly static Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
    public readonly static Color[] colors = { Color.green, Color.blue, Color.red, Color.yellow };

    public Vector2Int direction;
    public Color color;
    public Vector2Int position;
    public int width;
}