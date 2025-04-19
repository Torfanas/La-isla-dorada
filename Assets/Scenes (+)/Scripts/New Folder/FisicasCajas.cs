using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PushableBox : MonoBehaviour
{
    public enum MaterialType { Wood, Oily }
    public MaterialType boxMaterial;

    public float pushStrength = 5f;
    private Rigidbody rb;
    private Collider col;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

        rb.useGravity = true;
        rb.isKinematic = false;

        ApplyMaterialFriction();
    }

    void ApplyMaterialFriction()
    {
        PhysicMaterial generatedMaterial = new PhysicMaterial();

        if (boxMaterial == MaterialType.Wood)
        {
            generatedMaterial.name = "Wood_AutoMaterial";
            generatedMaterial.staticFriction = 0.6f;
            generatedMaterial.dynamicFriction = 0.5f;
            generatedMaterial.frictionCombine = PhysicMaterialCombine.Average;
        }
        else if (boxMaterial == MaterialType.Oily)
        {
            generatedMaterial.name = "Oily_AutoMaterial";
            generatedMaterial.staticFriction = 0.05f;
            generatedMaterial.dynamicFriction = 0.02f;
            generatedMaterial.frictionCombine = PhysicMaterialCombine.Minimum;
        }

        col.material = generatedMaterial;
    }

    public void Push(Vector3 direction)
    {
        rb.AddForce(direction.normalized * pushStrength, ForceMode.Impulse);
    }

    // Para pruebas con clic
    void OnMouseDown()
    {
        Vector3 pushDir = Camera.main.transform.forward + Vector3.down * 0.2f;
        Push(pushDir);
    }
}


