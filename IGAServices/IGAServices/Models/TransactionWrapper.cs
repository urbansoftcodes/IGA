using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGAServices.Models
{
    public class TransactionWrapper
    {
        [JsonProperty(PropertyName = "isTransactionDone")]
        public bool IsTransactionDone { get; set; }

        [JsonProperty(PropertyName = "transactionErrorMessage")]
        public string TransactionErrorMessage { get; set; }
    }
}