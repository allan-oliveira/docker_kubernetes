namespace APICount.Models
{
    using System;
    using System.Reflection;
    using System.Runtime.Versioning;
    public class Count
    {
        private static readonly string _LOCAL;
        private static readonly string _KERNEL;
        private static readonly string _TARGET_FRAMEWORK;

        static Count()
        {
            _LOCAL = Environment.MachineName;
            _KERNEL = Environment.OSVersion.VersionString;
            _TARGET_FRAMEWORK = Assembly
                .GetEntryAssembly()?
                .GetCustomAttribute<TargetFrameworkAttribute>()?
                .FrameworkName;
        }

        public int ActualValue { get; private set; } = 0;
        public string Local { get => _LOCAL; }
        public string Kernel { get => _KERNEL; }
        public string TargetFramework { get => _TARGET_FRAMEWORK; }

        public void Increment()
        {
            ActualValue++;
        }
    }
}
