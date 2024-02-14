using UnityEngine;

public class FxManager : MonoBehaviour
{
    [SerializeField] private GameObject FXGameObject;
    [SerializeField] private float yOffset = 0.2f;
    [SerializeField] private float timeToAnim = 0;
    private Animator anim;
    private MeshRenderer render;

    private void Start()
    {
        anim = GetComponent<Animator>();
        render = GetComponent<MeshRenderer>();
        render.enabled = false;
        Invoke("StartAnim", timeToAnim);
    }

    void StartAnim()
    {
        render.enabled = true;
        anim.Play("texto");
    }

    void PlayEffect()
    {
        Instantiate(FXGameObject, new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z), Quaternion.identity);
    }
}
