namespace SkyApm.Diagnostics.EasyCaching
{
    using global::EasyCaching.Core.Diagnostics;
    using SkyApm.Common;
    using SkyApm.Tracing;
    using System;

    public class EasyCachingTracingDiagnosticProcessor : ITracingDiagnosticProcessor
    {
        public string ListenerName => EasyCachingDiagnosticStrings.DiagnosticListenerName;

        private readonly ITracingContext _tracingContext;
        private readonly ILocalSegmentContextAccessor _localSegmentContextAccessor;

        public EasyCachingTracingDiagnosticProcessor(ITracingContext tracingContext,
            ILocalSegmentContextAccessor localSegmentContextAccessor)
        {
            _tracingContext = tracingContext;
            _localSegmentContextAccessor = localSegmentContextAccessor;
        }

        [DiagnosticName(EasyCachingDiagnosticStrings.EasyCachingBeforeSetCache)]
        public void BeforeSetCache([Property(Name = "EventData")] BeforeSetRequestEventData eventData)
        {
            if (eventData == null) return;

            string operationName = $"{EasyCachingDiagnosticStrings.EasyCachingPrefix}{eventData.Operation}";
 
            var context = _tracingContext.CreateLocalSegmentContext(operationName);
            context.Span.SpanLayer = Tracing.Segments.SpanLayer.CACHE;
            context.Span.Component = EasyCachingComponents.EasyCaching;
            context.Span.AddTag(Tags.DB_TYPE, "cache");
            context.Span.AddTag(Tags.DB_INSTANCE, $"{eventData.CacheType}-{eventData.Name}");
            context.Span.AddTag(Tags.DB_STATEMENT, string.Join(",", eventData.Dict.Keys));
        }

        [DiagnosticName(EasyCachingDiagnosticStrings.EasyCachingAfterSetCache)]
        public void AfterSetCache()
        {
            var context = _localSegmentContextAccessor.Context;
            if (context != null)
            {
                _tracingContext.Release(context);
            }
        }

        [DiagnosticName(EasyCachingDiagnosticStrings.EasyCachingErrorSetCache)]
        public void ErrorSetCache([Property(Name = "Exception")] Exception ex)
        {
            var context = _localSegmentContextAccessor.Context;
            if (context != null)
            {
                context.Span.ErrorOccurred(ex);
                _tracingContext.Release(context);
            }
        }

        [DiagnosticName(EasyCachingDiagnosticStrings.EasyCachingBeforeGetCache)]
        public void BeforeGetCache([Property(Name = "EventData")] BeforeGetRequestEventData eventData)
        {
            if (eventData == null) return;

            string operationName = $"{EasyCachingDiagnosticStrings.EasyCachingPrefix}{eventData.Operation}";

            var context = _tracingContext.CreateLocalSegmentContext(operationName);
            context.Span.SpanLayer = Tracing.Segments.SpanLayer.CACHE;
            context.Span.Component = EasyCachingComponents.EasyCaching;
            context.Span.AddTag(Tags.DB_TYPE, "cache");
            context.Span.AddTag(Tags.DB_INSTANCE, $"{eventData.CacheType}-{eventData.Name}");
            context.Span.AddTag(Tags.DB_STATEMENT, string.Join(",", eventData.CacheKeys));            
        }

        [DiagnosticName(EasyCachingDiagnosticStrings.EasyCachingAfterGetCache)]
        public void AfterGetCache()
        {
            var context = _localSegmentContextAccessor.Context;
            if (context != null)
            {
                _tracingContext.Release(context);
            }
        }

        [DiagnosticName(EasyCachingDiagnosticStrings.EasyCachingErrorGetCache)]
        public void ErrorGetCache([Property(Name = "Exception")] Exception ex)
        {
            var context = _localSegmentContextAccessor.Context;
            if (context != null)
            {
                context.Span.ErrorOccurred(ex);
                _tracingContext.Release(context);
            }
        }

        [DiagnosticName(EasyCachingDiagnosticStrings.EasyCachingBeforeRemoveCache)]
        public void BeforeRemoveCache([Property(Name = "EventData")] BeforeRemoveRequestEventData eventData)
        {
            if (eventData == null) return;

            string operationName = $"{EasyCachingDiagnosticStrings.EasyCachingPrefix}{eventData.Operation}";

            var context = _tracingContext.CreateLocalSegmentContext(operationName);
            context.Span.SpanLayer = Tracing.Segments.SpanLayer.CACHE;
            context.Span.Component = EasyCachingComponents.EasyCaching;
            context.Span.AddTag(Tags.DB_TYPE, "cache");
            context.Span.AddTag(Tags.DB_INSTANCE, $"{eventData.CacheType}-{eventData.Name}");
            context.Span.AddTag(Tags.DB_STATEMENT, string.Join(",", eventData.CacheKeys));
        }

        [DiagnosticName(EasyCachingDiagnosticStrings.EasyCachingAfterRemoveCache)]
        public void AfterRemoveCache()
        {
            var context = _localSegmentContextAccessor.Context;
            if (context != null)
            {
                _tracingContext.Release(context);
            }
        }

        [DiagnosticName(EasyCachingDiagnosticStrings.EasyCachingErrorRemoveCache)]
        public void ErrorRemoveCache([Property(Name = "Exception")] Exception ex)
        {
            var context = _localSegmentContextAccessor.Context;
            if (context != null)
            {
                context.Span.ErrorOccurred(ex);
                _tracingContext.Release(context);
            }
        }       
    }
}
