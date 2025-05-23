import { createApi } from '@reduxjs/toolkit/query/react';
import type { Product } from '../../app/models/product';
import { baseQueryWithErrorHandling } from '../../app/api/baseApi';

export const catalogApi = createApi({
  reducerPath: 'catalogApi',
  baseQuery: baseQueryWithErrorHandling,
  endpoints: (build) => ({
    fetchProducts: build.query<Product[], void>({
      query: () => 'products'
    }),
    fetchProductDetails: build.query<Product, number>({
      query: (id) => `products/${id}`
    })
  })
});

export const { useFetchProductsQuery, useFetchProductDetailsQuery } =
  catalogApi;
