using UnityEngine;
using System.Collections;

public abstract class BasicGUI
{
    public virtual void Init(){}
	
    public abstract void DrawInterface();

    public virtual void OnShow(){}
    
	public virtual void OnHide(){}

    public virtual void Destroy(){}
}
