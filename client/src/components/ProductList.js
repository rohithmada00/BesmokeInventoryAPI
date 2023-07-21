import React, { useEffect, useState } from 'react';
import axios from 'axios';

function ProductList() {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    axios.get('/api/products')
      .then(res => setProducts(res.data))
      .catch(err => console.error(err));
  }, []);

  return (
    <div className="container mt-4">
      <h3>Available Products</h3>
      <ul className="list-group">
        {products.map(p => (
          <li key={p.id} className="list-group-item">
            {p.name} - {p.type}, {p.size}, {p.material}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default ProductList;
