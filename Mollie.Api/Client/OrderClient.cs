﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Api.Client.Abstract;
using Mollie.Api.Models.List;
using Mollie.Api.Models.Order;
using Mollie.Api.Models.Refund;
using Mollie.Api.Models.Url;

namespace Mollie.Api.Client {
    public class OrderClient : BaseMollieClient, IOrderClient {
        public OrderClient(string apiKey, HttpClient httpClient = null) : base(apiKey, httpClient) {
        }

        public async Task<OrderResponse> CreateOrderAsync(OrderRequest orderRequest) {
            return await this.PostAsync<OrderResponse>("orders", orderRequest).ConfigureAwait(false);
        }

        public async Task<OrderResponse> GetOrderAsync(string orderId) {
            return await this.GetAsync<OrderResponse>($"orders/{orderId}").ConfigureAwait(false); ;
        }

        public async Task<OrderResponse> UpdateOrderAsync(string orderId, OrderUpdateRequest orderUpdateRequest) {
            return await this.PatchAsync<OrderResponse>($"orders/{orderId}", orderUpdateRequest).ConfigureAwait(false); ;
        }

        public async Task CancelOrderAsync(string orderId) {
            await this.DeleteAsync($"orders/{orderId}").ConfigureAwait(false);
        }

        public async Task<ListResponse<OrderResponse>> GetOrderListAsync(string from = null, int? limit = null) {
            return await this.GetListAsync<ListResponse<OrderResponse>>($"orders", from, limit).ConfigureAwait(false);
        }

        public async Task<ListResponse<OrderResponse>> GetOrderListAsync(UrlObjectLink<ListResponse<OrderResponse>> url) {
            return await this.GetAsync(url).ConfigureAwait(false);
        }

        public async Task CancelOrderLinesAsync(string orderId, IEnumerable<OrderLineDetails> orderLines) {
            await this.DeleteAsync($"orders/{orderId}", orderLines).ConfigureAwait(false); ;
        }

        public async Task<RefundResponse> CreateOrderRefundAsync(string orderId, OrderRefundRequest orderRefundRequest) {
            return await this.PostAsync<RefundResponse>($"orders/{orderId}", orderRefundRequest).ConfigureAwait(false);
        }

        public async Task<ListResponse<RefundResponse>> GetOrderRefundListAsync(string from = null, int? limit = null) {
            return await this.GetListAsync<ListResponse<RefundResponse>>($"orders", from, limit).ConfigureAwait(false);
        }
    }
}