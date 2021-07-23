using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomCoins : MonoBehaviour
{
    // the center point for the area
    public Vector3 center = new Vector3(0f, 0f, -0.5f);
    // the size of the area
    public Vector3 size = new Vector3(15f, 9.5f, 0f);

    public GameObject coin;

    private Vector3 pos = new Vector3(0, 0, 0);

    private static GenerateRandomCoins sharedInstance;

    public static GenerateRandomCoins GetInstane()
    {
        return sharedInstance;
    }

    private void Start()
    {
        CoinLocation();
    }

    private void Awake()
    {
        sharedInstance = this;
    }

    private void OnDrawGizmosSelected()
    {
        // give color to the area of generation
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        // draw the area with center and size
        Gizmos.DrawCube(center, size);

    }

    public void CoinLocation()
    {
        // calculate random position
        pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), 0);
        // generate new coin in calculated position
        Instantiate(coin, pos, Quaternion.identity);
    }

    public void CoinLocation(Vector3 position)
    {
        // generate new coin in given position
        Instantiate(coin, position, Quaternion.identity);
    }

    public Vector3 GetCoinPosition()
    {
        return pos;
    }
}
