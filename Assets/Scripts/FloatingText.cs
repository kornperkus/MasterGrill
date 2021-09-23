using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    private TextMeshPro textMesh;
    private Color color;

    public void SetText(int score) {
        textMesh = GetComponent<TextMeshPro>();
        color = textMesh.color;

        textMesh.text = score > 0 ? "+" + score : score.ToString();
        Destroy(gameObject, 1);
    }

    void Update() {
        if (textMesh != null) {
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime, transform.position.z);

            color.a -= Time.deltaTime;
            textMesh.color = color;
        }
    }
}
