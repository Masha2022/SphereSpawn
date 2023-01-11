using UnityEngine;

public class PaintController : MonoBehaviour
{
    public void Colorize(PaintableObject target, Material material)
    {
        target.material = material;
    }
}