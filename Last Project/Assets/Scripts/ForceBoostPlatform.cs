using UnityEngine;

public class ForceBoostPlatform : MonoBehaviour
{
	[SerializeField] float boostForce;
	[SerializeField] Vector2 direction;
	AbilityBoardPickup useAnimation;
	void Start()
	{
		useAnimation = GetComponent<AbilityBoardPickup>();
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			useAnimation.PlayPickup();
			Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
			rb.velocity = Vector2.zero;
			rb.AddForce(direction.normalized * boostForce, ForceMode2D.Impulse);
		}
	}
}
