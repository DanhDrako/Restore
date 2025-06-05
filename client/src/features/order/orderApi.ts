import { createApi } from '@reduxjs/toolkit/query/react';
import { baseQueryWithErrorHandling } from '../../app/api/baseApi';
import type { CreateOrder, Order } from '../../app/models/order';

export const orderApi = createApi({
  reducerPath: 'orderApi',
  baseQuery: baseQueryWithErrorHandling,
  endpoints: (builder) => ({
    fetchOrders: builder.query<Order[], void>({
      query: () => 'orders'
    }),
    fetchOrderDetails: builder.query<Order, number>({
      query: (id) => `orders/${id}`
    }),
    createOrder: builder.mutation<Order, CreateOrder>({
      query: (order) => ({
        url: 'orders',
        method: 'POST',
        body: order
      }),
      async onQueryStarted(_, { queryFulfilled }) {
        try {
          await queryFulfilled;
        } catch (error) {
          console.log(error);
          throw error; // Re-throw the error to be handled by the base query error handling
        }
      }
    })
  })
});

export const {
  useFetchOrdersQuery,
  useFetchOrderDetailsQuery,
  useCreateOrderMutation
} = orderApi;
