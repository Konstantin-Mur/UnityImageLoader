using UnityEngine.Events;

public class EventAgregator
{
    public static UnityEvent<string> getAllLinksOfPictures = new UnityEvent<string>();
    public static UnityEvent LoadAllPickures = new UnityEvent();
    public static UnityEvent InvalidInput = new UnityEvent();
}
