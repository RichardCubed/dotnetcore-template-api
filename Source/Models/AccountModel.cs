using System;
using Amazon.DynamoDBv2.DataModel;

namespace Accounts.Models
{
    /// <summary>
    /// Defines the Account model with attributes to map to a DynamoDB table in AWS
    /// https://aws.amazon.com/dynamodb/
    /// </summary>
    [DynamoDBTable("accounts")]
    public class AccountModel
    {
        [DynamoDBHashKey]
        public string AccountId { get; set; }

        public string Name { get; set; }

        public AccountModel()
        {
            AccountId = Guid.NewGuid().ToString();
        }
    }
}