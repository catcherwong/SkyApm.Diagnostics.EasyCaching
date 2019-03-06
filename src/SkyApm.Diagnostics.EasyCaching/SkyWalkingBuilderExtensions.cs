namespace SkyApm.Diagnostics.EasyCaching
{
    using Microsoft.Extensions.DependencyInjection;
    using SkyApm.Utilities.DependencyInjection;
    using System;

    public static class SkyWalkingBuilderExtensions
    {
        public static SkyApmExtensions AddEasyCaching(this SkyApmExtensions extensions)
        {
            if (extensions == null)
            {
                throw new ArgumentNullException(nameof(extensions));
            }

            extensions.Services.AddSingleton<ITracingDiagnosticProcessor, EasyCachingTracingDiagnosticProcessor>();

            return extensions;
        }
    }
}
