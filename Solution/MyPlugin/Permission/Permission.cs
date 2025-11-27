namespace Oxide.Plugins
{
    using System.Reflection;

    public partial class MyPlugin : RustPlugin
    {
        public static class Permission
        {
            public const string UserPermission1 = "myplugin.user.permission1";
            public const string UserPermission2 = "myplugin.user.permission2";
            public const string AdminPermission = "myplugin.admin";

            public static void RegisterAll(MyPlugin instance)
            {
                foreach (FieldInfo field in typeof(Permission).GetFields(BindingFlags.Public | BindingFlags.Static))
                    instance.permission.RegisterPermission((string)field.GetRawConstantValue(), instance);
            }
        }
    }
}