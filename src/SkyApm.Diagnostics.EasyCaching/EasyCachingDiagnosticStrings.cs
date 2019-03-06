namespace SkyApm.Diagnostics.EasyCaching
{
    internal static class EasyCachingDiagnosticStrings
    {
        public const string DiagnosticListenerName = "EasyCachingDiagnosticListener";
        
        public const string EasyCachingBeforeSetCache = "EasyCaching.WriteSetCacheBefore";
        public const string EasyCachingAfterSetCache = "EasyCaching.WriteSetCacheAfter";
        public const string EasyCachingErrorSetCache = "EasyCaching.WriteSetCacheError";

        public const string EasyCachingBeforeGetCache = "EasyCaching.WriteGetCacheBefore";
        public const string EasyCachingAfterGetCache = "EasyCaching.WriteGetCacheAfter";
        public const string EasyCachingErrorGetCache = "EasyCaching.WriteGetCacheError"; 

        public const string EasyCachingBeforePublishMessage = "EasyCaching.WritePublishMessageBefore";
        public const string EasyCachingAfterPublishMessage = "EasyCaching.WritePublishMessageAfter";
        public const string EasyCachingErrorPublishMessage = "EasyCaching.WritePublishMessageError"; 

        public const string EasyCachingBeforeSubscribeMessage = "EasyCaching.WriteSubscribeMessageBefore";
        public const string EasyCachingAfterSubscribeMessage = "EasyCaching.WriteSubscribeMessageAfter"; 
        public const string EasyCachingErrorSubscribeMessage = "EasyCaching.WriteSubscribeMessageError";
    }
}
