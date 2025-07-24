using System;
using System.Collections.Generic;

namespace AuditTrailAPI.Models
{
    public class AuditResponse
    {
        public string EntityName { get; set; }
        public string UserId { get; set; }
        public AuditAction Action { get; set; }
        public DateTime Timestamp { get; set; }
        public Dictionary<string, (string OldValue, string NewValue)> Changes { get; set; } = new();
    }
}
