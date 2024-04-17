using System.Collections;

public interface ICanvasAnimation
{
    public void ShowAnimation();
    public void HideAnimation();
    public void SetParameter<T>(T value);
    public IEnumerator Show();
    public IEnumerator Hide();
}
