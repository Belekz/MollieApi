﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Mollie.Api.Models.List;
using Mollie.Api.Models.Order;
using Mollie.Api.Models.Refund;
using Mollie.Api.Models.Url;

namespace Mollie.Api.Client.Abstract {
    public interface IOrderClient {
        Task<OrderResponse> CreateOrderAsync(OrderRequest orderRequest);
        Task<OrderResponse> GetOrderAsync(string orderId);
        Task<OrderResponse> UpdateOrderAsync(string orderId, OrderUpdateRequest orderUpdateRequest);
        Task CancelOrderAsync(string orderId);
        Task<ListResponse<OrderResponse>> GetOrderListAsync(string from = null, int? limit = null);
        Task<ListResponse<OrderResponse>> GetOrderListAsync(UrlObjectLink<ListResponse<OrderResponse>> url);
        Task CancelOrderLinesAsync(string orderId, IEnumerable<OrderLineDetails> orderLines);
        Task<RefundResponse> CreateOrderRefundAsync(string orderId, OrderRefundRequest orderRefundRequest);
        Task<ListResponse<RefundResponse>> GetOrderRefundListAsync(string from = null, int? limit = null);
    }
}