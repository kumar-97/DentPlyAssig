using AuditTrailAPI.Models;
using Newtonsoft.Json.Linq;

namespace AuditTrailAPI.Services
{
    public class AuditTrailService
    {
        public AuditResponse GenerateAudit(AuditRequest request)
        {
            var response = new AuditResponse
            {
                EntityName = request.EntityName,
                UserId = request.UserId,
                Action = request.Action,
                Timestamp = DateTime.UtcNow,
                Changes = new Dictionary<string, (string, string)>()
            };

            if (request.Action == AuditAction.Created)
            {
                JObject afterObj = JObject.FromObject(request.After);
                foreach (var prop in afterObj.Properties())
                {
                    response.Changes[prop.Name] = (null, prop.Value?.ToString());
                }
            }
            else if (request.Action == AuditAction.Deleted)
            {
                JObject beforeObj = JObject.FromObject(request.Before);
                foreach (var prop in beforeObj.Properties())
                {
                    response.Changes[prop.Name] = (prop.Value?.ToString(), null);
                }
            }
            else if (request.Action == AuditAction.Updated)
            {
                JObject beforeObj = JObject.FromObject(request.Before);
                JObject afterObj = JObject.FromObject(request.After);

                foreach (var prop in afterObj.Properties())
                {
                    var oldVal = beforeObj[prop.Name]?.ToString();
                    var newVal = prop.Value?.ToString();

                    if (oldVal != newVal)
                    {
                        response.Changes[prop.Name] = (oldVal, newVal);
                    }
                }
            }

            return response;
        }
    }
}