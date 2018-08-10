﻿using Square.Connect.Api;
using Square.Connect.Client;
using Square.Connect.Model;
using System;
using Microsoft.Extensions.Configuration;

namespace AtmoreChamber.Models
{
    public class Transaction
    {
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }


        private readonly string LocationId;

        public string ResultMessage
        {
            get;
            set;
        }

        public Transaction(IConfiguration configuration)
        {
            this.LocationId = configuration["AppSettings:LocationId"];
        }

        public void OnPost(string nonce, int transamount)
        {
            TransactionsApi transactionsApi = new TransactionsApi();
            // Every payment you process with the SDK must have a unique idempotency key.
            // If you're unsure whether a particular payment succeeded, you can reattempt
            // it with the same idempotency key without worrying about double charging
            // the buyer.
            string uuid = NewIdempotencyKey();

            // Monetary amounts are specified in the smallest unit of the applicable currency.
            // This amount is in cents. It's also hard-coded for $1.00,
            // which isn't very useful.
            Money amount = new Money(transamount, Money.CurrencyEnum.USD);

            // To learn more about splitting transactions with additional recipients,
            // see the Transactions API documentation on our [developer site]
            // (https://docs.connect.squareup.com/payments/transactions/overview#mpt-overview).
            ChargeRequest body = new ChargeRequest(AmountMoney: amount, IdempotencyKey: uuid, CardNonce: nonce);

            try
            {
                var response = transactionsApi.Charge(LocationId, body);
                this.ResultMessage = "Transaction complete!   " + response.ToJson();
            }
            catch (ApiException e)
            {
                this.ResultMessage = e.Message;
            }
        }

        private static string NewIdempotencyKey()
        {
            return Guid.NewGuid().ToString();
        }
    }
}