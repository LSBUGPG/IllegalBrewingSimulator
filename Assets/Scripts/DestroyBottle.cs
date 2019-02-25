using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Worktop))]
public class DestroyBottle : MonoBehaviour
{
	public Score Wine;
	Worktop worktop;
	int count;

	void Awake()
	{
		worktop = GetComponent<Worktop>();
		worktop.onPlaceItem.AddListener((item) => Score(item));
	}

	void Score(Pickable item)
	{
		if (item.CompareTag("Bottle"))
		{
			count++;
			Wine.count = count;
		}
		worktop.Take();
		item.Respawn();
	}
}