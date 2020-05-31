namespace InjectDemo
{
    public class User:IUser
    {
        private ILog _log;

        public User(ILog log)
        {
            _log = log;
        }
        public string GetUserName()
        {
            _log.Write("获取用户名称");
            return "oec2003";
            
        }
    }
}