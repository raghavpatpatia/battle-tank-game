// Creating a Non MonoBehaviour Generic Singleton class
public class NonMonoGenericSingleton<T> where T : NonMonoGenericSingleton<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }

    protected NonMonoGenericSingleton() { Initialize(); }

    protected void Initialize()
    {
        if (instance == null)
        {
            instance = (T)this;
        }
    }
}
