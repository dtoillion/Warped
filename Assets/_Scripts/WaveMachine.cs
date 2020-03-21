using UnityEngine;
using System.Collections;

public class WaveMachine : MonoBehaviour {

  public GameObject[] obstacles;
  public float SpawnRateA = 5f;
  public float SpawnRateB = 5f;
  public float startDelay = 3f;
  public float minX = 0f;
  public float maxX = 0f;
  public float minY = 0f;
  public float maxY = 0f;
  public float minZ = 0f;
  public float maxZ = 0f;
  private Vector3 originPosition;

  void Start ()
  {
    originPosition = new Vector3((Random.Range(minX, maxX)), (Random.Range(minY, maxY)), (Random.Range(minZ, maxZ)));
    StartCoroutine (Spawn());
  }

  IEnumerator Spawn()
  {
    yield return new WaitForSeconds (startDelay);
    while (true)
    {
      for (int i = 1; i < 30; i++)
      {
        originPosition = new Vector3((Random.Range(minX, maxX)), (Random.Range(minY, maxY)), (Random.Range(minZ, maxZ)));
        Instantiate(obstacles[Random.Range(0, obstacles.Length)], originPosition, transform.rotation);
        yield return new WaitForSeconds (Random.Range(SpawnRateA, SpawnRateB));
      }
    }
  }

}