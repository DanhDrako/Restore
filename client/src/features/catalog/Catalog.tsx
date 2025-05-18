import ProductList from './ProductList';
import { useGetProductsQuery } from './catalogApi';

export default function Catalog() {
  const { data: products, error, isLoading } = useGetProductsQuery();

  if (isLoading) return <div>Loading...</div>;
  if (error) return <div>Error loading products</div>;
  if (!products) return <div>No products found</div>;

  return (
    <>
      <ProductList products={products} />
    </>
  );
}
