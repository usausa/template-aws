namespace Template.Lambda;

using Amazon.Lambda.APIGatewayEvents;

using Template.Components.Logging;

public sealed class HttpApiFilter
{
    public APIGatewayProxyResponse? OnFunctionExecuting(APIGatewayProxyRequest request, ILambdaContext context)
    {
        // ReSharper disable once ConstantNullCoalescingCondition TODO remove, R# bug?
        if (request.Headers?.ContainsKey("X-Lambda-Ping") ?? false)
        {
            return new Amazon.Lambda.APIGatewayEvents.APIGatewayProxyResponse { StatusCode = 200 };
        }

        LambdaLoggerContext.RequestId = context.AwsRequestId;

        return null;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060", Justification = "Ignore")]
    public void OnFunctionExecuted(APIGatewayProxyRequest request, ILambdaContext context)
    {
        LambdaLoggerContext.RequestId = null;
    }
}
