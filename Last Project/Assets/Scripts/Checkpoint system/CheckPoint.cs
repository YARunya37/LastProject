using UnityEngine;

public class CheckPoint : MonoBehaviour
{
	[SerializeField] private AudioSource au;
	[SerializeField] private Transform spawnPoint;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag("Player") || other.isTrigger)
			return;

		au.Play();

		PlayerDeathEffect deathEffect = other.GetComponent<PlayerDeathEffect>();

		if (deathEffect != null)
		{
			deathEffect.KillAndRespawn(spawnPoint.position + Vector3.up);
		}
	}
}