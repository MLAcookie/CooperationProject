using System.Collections;

public interface ICanvasAnimation
{
    public void ShowAnimation();
    public void HideAnimation();

    public IEnumerator Show();
    public IEnumerator Hide();
}
