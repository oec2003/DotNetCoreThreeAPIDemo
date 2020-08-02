namespace InjectLib
{
    public interface IEngine
    {
        IUserManager UserManager { get; }
        void Start();
        void OnLoad();
    }
}