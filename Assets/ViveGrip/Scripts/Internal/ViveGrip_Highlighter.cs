using UnityEngine;
using System.Collections.Generic;

public class ViveGrip_Highlighter : MonoBehaviour {
  Color tintColor = Color.white;
  float tintRatio = 2.2f;
  private Queue<Color> oldColors = new Queue<Color>();

  void Start () {}

  public void Highlight(Color color) {
    RemoveHighlight();
    foreach (Renderer material in GetComponentsInChildren<Renderer>()) {
      Color currentColor = material.material.color;
      oldColors.Enqueue(currentColor);
            material.material.color = Color.white; //Color.Lerp(currentColor, color, tintRatio);
    }
  }
  
    public void RemoveHighlight() {
    foreach (Renderer material in GetComponentsInChildren<Renderer>()) {
      if (oldColors.Count == 0) { break; }
      material.material.color = oldColors.Dequeue();
    }
    oldColors.Clear();
  }

  public static void AddTo(GameObject gameObject) {
    if (gameObject.GetComponent<Renderer>() == null) { return; }
    if (gameObject.GetComponent<ViveGrip_Highlighter>() == null) {
      gameObject.AddComponent<ViveGrip_Highlighter>();
    }
  }

  void ViveGripHighlightStart() {
    if (!this.enabled) { return; }
    Highlight(tintColor);
  }

  void ViveGripHighlightStop() {
    if (!this.enabled) { return; }
    RemoveHighlight();
  }

  void OnDestroy() {
    RemoveHighlight();
  }
}
