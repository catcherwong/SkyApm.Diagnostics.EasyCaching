namespace SkyApm.Diagnostics.EasyCaching
{
    using global::EasyCaching.Core.Diagnostics;
    using SkyApm.Common;
    using SkyApm.Tracing;
    using System;

    public class EasyCachingTracingDiagnosticProcessor : ITracingDiagnosticProcessor
    {
        public string ListenerName => EasyCachingDiagnosticStrings.DiagnosticListenerName;

        private readonly string EASYCACHING = "EasyCaching/";

        private readonly ITracingContext _tracingContext;
        private readonly IEntrySegmentContextAccessor _entrySegmentContextAccessor;
        private readonly IExitSegmentContextAccessor _exitSegmentContextAccessor;

        public EasyCachingTracingDiagnosticProcessor(ITracingContext tracingContext,
            IEntrySegmentContextAccessor entrySegmentContextAccessor,
            IExitSegmentContextAccessor exitSegmentContextAccessor)
        {
            _tracingContext = tracingContext;
            _exitSegmentContextAccessor = exitSegmentContextAccessor;
            _entrySegmentContextAccessor = entrySegmentContextAccessor;
        }

        [DiagnosticName(EasyCachingDiagnosticStrings.EasyCachingBeforeSetCache)]
        public void BeforeSetCache([Object] BeforeSetRequestEventData eventData)
        {
            if (eventData == null) return;

            var context = _tracingContext.CreateExitSegmentContext($"{EASYCACHING}{eventData.Operation}", "");
            context.Span.SpanLayer = Tracing.Segments.SpanLayer.CACHE;
            context.Span.Component = EasyCachingComponents.EasyCaching;
            context.Span.AddTag(Tags.DB_TYPE, eventData.Name);
            context.Span.AddTag(Tags.DB_STATEMENT, string.Join(",", eventData.Dict.Keys));
        }

        [DiagnosticName(EasyCachingDiagnosticStrings.EasyCachingAfterSetCache)]
        public void AfterSetCache()
        {
            var context = _entrySegmentContextAccessor.Context;
            if (context != null)
            {
                _tracingContext.Release(context);
            }
        }

        [DiagnosticName(EasyCachingDiagnosticStrings.EasyCachingBeforeSetCache)]
        public void ErrorSetCache([Property(Name = "Exception")] Exception ex)
        {
            var context = _entrySegmentContextAccessor.Context;
            if (context != null)
            {
                context.Span.ErrorOccurred(ex);
                _tracingContext.Release(context);
            }
        }

        [DiagnosticName(EasyCachingDiagnosticStrings.EasyCachingBeforeGetCache)]
        public void BeforeGetCache([Object] BeforeGetRequestEventData eventData)
        {
            if (eventData == null) return;

            var context = _tracingContext.CreateExitSegmentContext($"{EASYCACHING}{eventData.Operation}", "");
            context.Span.SpanLayer = Tracing.Segments.SpanLayer.CACHE;
            context.Span.Component = EasyCachingComponents.EasyCaching;
            context.Span.AddTag(Tags.DB_TYPE, eventData.Name);
            context.Span.AddTag(Tags.DB_STATEMENT, string.Join(",", eventData.CacheKeys));            
        }

        [DiagnosticName(EasyCachingDiagnosticStrings.EasyCachingAfterGetCache)]
        public void AfterGetCache()
        {
            var context = _entrySegmentContextAccessor.Context;
            if (context != null)
            {
                _tracingContext.Release(context);
            }
        }

        [DiagnosticName(EasyCachingDiagnosticStrings.EasyCachingErrorGetCache)]
        public void ErrorGetCache([Property(Name = "Exception")] Exception ex)
        {
            var context = _entrySegmentContextAccessor.Context;
            if (context != null)
            {
                context.Span.ErrorOccurred(ex);
                _tracingContext.Release(context);
            }
        }

        [DiagnosticName(EasyCachingDiagnosticStrings.EasyCachingBeforePublishMessage)]
        public void BeforePublishMessage()
        {

        }

        [DiagnosticName(EasyCachingDiagnosticStrings.EasyCachingAfterPublishMessage)]
        public void AfterPublishMessage()
        {

        }

        [DiagnosticName(EasyCachingDiagnosticStrings.EasyCachingErrorPublishMessage)]
        public void ErrorPublishMessage([Property(Name = "Exception")] Exception ex)
        {

        }
    }
}
