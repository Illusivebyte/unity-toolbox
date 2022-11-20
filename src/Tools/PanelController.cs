using UnityEngine;

[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(CanvasGroup))]
public class PanelController : MonoBehaviour {
	
	protected Animation animationComponent;
    protected bool active {get; set;}
    public bool isActive {get {return this.active;}}

    protected virtual void Awake()
    {
        active = false; 
        animationComponent = this.gameObject.GetComponent<Animation>();
    }

	public virtual void FadeIn()
	{
        this.active = true;
		this.animationComponent.Play("canvasGroupFadeIn");
	}

    public virtual void FadeOut()
	{
        this.active = false;
		this.animationComponent.Play("canvasGroupFadeOut");
	}
}
