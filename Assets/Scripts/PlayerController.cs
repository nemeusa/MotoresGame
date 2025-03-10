using UnityEngine;
using System.Collections;
using static Enum;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 100;         
    public int currentHealth;            
    public HealthStatus currentHealthStatus = HealthStatus.Full;  // Estado de salud

    [Header("Inmunidad")]
    [SerializeField] private MeshRenderer[] meshRenderers;
    [SerializeField] private Color[] normalColors;
    [SerializeField] private Color flashColor = Color.white; 

    private void Start()
    {

        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        normalColors = new Color[meshRenderers.Length];

        for (int i = 0; i < meshRenderers.Length; i++)
        {
            normalColors[i] = meshRenderers[i].material.color;
        }


        currentHealth = maxHealth;
    }

    private void Update()
    {CheckHealthStatus();}
    public void TakeDamage(int damageAmount)
    {
        if (currentHealthStatus == HealthStatus.Inmunity)
        {
            Debug.Log("Inmune");
            return;
        }

        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        currentHealthStatus = HealthStatus.Damage;

        if (currentHealth == 0)
        {
            Die();
        }

        Debug.Log("Salud actual: " + currentHealth);
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log("Jugador curado. Salud actual: " + currentHealth);
    }
    private void Die()
    {
        currentHealthStatus = HealthStatus.Dead;
        Debug.Log("muelto");
        SceneManager.LoadScene(0);
    }

    public void ActivateImmunity(float duration)
    {
        currentHealthStatus = HealthStatus.Inmunity;
        StartCoroutine(FlashImmunity(duration));

        Invoke(nameof(DeactivateImmunity), duration);
    }

    private IEnumerator FlashImmunity(float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            for (int i = 0; i < meshRenderers.Length; i++)
            {
                meshRenderers[i].material.color = (meshRenderers[i].material.color == normalColors[i]) ? flashColor : normalColors[i];
            }

            elapsedTime += 0.1f; // Cambiar de color cada 0.1 segundos
            yield return new WaitForSeconds(0.1f); // Esperar 0.1 segundos
        }

        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].material.color = normalColors[i];
        }
    }

    private void DeactivateImmunity()
    {
        currentHealthStatus = HealthStatus.Full;
    }

    private void CheckHealthStatus()
    {
        if (currentHealth == maxHealth && currentHealthStatus != HealthStatus.Full)
        {
            currentHealthStatus = HealthStatus.Full;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            TakeDamage(10);

            ActivateImmunity(1.5f);
        }
    }
}