using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    public GameObject slicedFruitPrefab;

    public float explosionRadius = 5f;

    private GameManager mygm;

    public int scoreAmount;

    public void CreateSlicedFruit()
    {
        GameObject inst = Instantiate(slicedFruitPrefab, transform.position,transform.rotation);

        Rigidbody[] rbOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody rigidbody in rbOnSliced)
        {
            rigidbody.transform.rotation = Random.rotation;
            rigidbody.AddExplosionForce(Random.Range(500, 1000), transform.position, explosionRadius);
        }
        mygm.PlayRandomSliceSound();
        mygm.IncreaseScore(scoreAmount);
        Destroy(inst, 5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();
        if(!b)
        {
            return;
        }

        CreateSlicedFruit();
    }
    // Start is called before the first frame update
    void Start()
    {
        mygm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
